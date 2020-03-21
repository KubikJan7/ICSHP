using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using GalacticConquestRemake.Common;
using GalacticConquestRemake.MathLibrary;

namespace TermWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int PLANET_COUNT = 10;
        private const int PLAYER_PLANET_COUNT = 3;
        private const int NPC_PLANET_COUNT = 3;

        private string playerColor = "Red";
        private string npcColor = "Blue";
        private string neutralColor = "Gray";

        private List<GameObject> gameObjects = new List<GameObject>();
        private DispatcherTimer MainTimer = new DispatcherTimer();
        private DispatcherTimer AITimer = new DispatcherTimer();
        private int RatioOfSentUnits = 50;
        private Planet chosenPlanet;

        private Random rand = new Random();

        private bool gameWon;

        Polyline currentPolyLine = new Polyline();
        Polyline currentAIPolyLine = new Polyline();

        private Dictionary<SpaceShip, Path> spaceShipDict = new Dictionary<SpaceShip, Path>();

        public MainWindow()
        {
            InitializeComponent();
            GeneratePlanets();
            InitializeTimers();
        }
        private void InitializeTimers()
        {
            MainTimer.Tick += new EventHandler(MainTimer_Tick);
            MainTimer.Interval = TimeSpan.FromMilliseconds(20);
            MainTimer.Start();

            AITimer.Tick += new EventHandler(AITimer_Tick);
            AITimer.Interval = TimeSpan.FromMilliseconds(rand.Next(300, 701));
            AITimer.Start();
        }
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            UpdateGameObjects();
            RemoveCompletedObjects();
            CheckIfNPCLost();
        }

        private void AITimer_Tick(object sender, EventArgs e)
        {
            AILogic();
        }
        public void CheckIfNPCLost()
        {
            int counter = 0;
            foreach (var item in gameObjects)
            {
                if (item is Planet planet)
                {
                    if (planet.OwnerColor == npcColor)
                        counter++;
                }
            }
            if (counter == 0)
            {
                gameWon = true;
                AITimer.Stop();
            }

        }

        private void GeneratePlanets()
        {
            BackgroundCanvas.Children.Clear();
            double winHeight = BackgroundCanvas.Height;
            double winWidth = BackgroundCanvas.Width;
            int planetCount = PLANET_COUNT;

            for (int i = 0; i < planetCount; i++)
            {
                bool comparingFinished = false;

                string color = playerColor;
                if (i >= PLAYER_PLANET_COUNT && i < NPC_PLANET_COUNT + PLAYER_PLANET_COUNT)
                    color = npcColor;
                else if (i >= NPC_PLANET_COUNT + PLAYER_PLANET_COUNT)
                    color = neutralColor;
                Planet planet;
                while (comparingFinished == false)
                {
                    int size = rand.Next(16, 49);
                    double screenBorderRadius = size / 2.0 * Planet.dodgeRadiusMultiple;
                    Point position = new Point(rand.Next((int)Math.Round(0 + screenBorderRadius), (int)Math.Round(winWidth - screenBorderRadius)),
                        rand.Next((int)Math.Round(0 + screenBorderRadius), (int)Math.Round(winHeight - screenBorderRadius)));
                    planet = new Planet(position, size, color);

                    bool intersect = false;
                    for (int j = 0; j < gameObjects.Count; j++)
                    {
                        if (gameObjects.Count == 0 || gameObjects[j] is SpaceShip)
                            continue;
                        //Distance between centers C1 and C2 -> C1C2 = sqrt((x1 - x2)2 + (y1 - y2)2).
                        double dist = MathClass.GetDistance(planet.Position.X, gameObjects[j].Position.X, planet.Position.Y, gameObjects[j].Position.Y);
                        double radSum = ((planet.Size / 2.0 * Planet.dodgeRadiusMultiple) + (gameObjects[j].Size / 2.0 * Planet.dodgeRadiusMultiple));

                        //1.If C1C2 == R1 + R2
                        //     Circle A and B are touch to each other.
                        // 2.If C1C2 > R1 + R2
                        //     Circle A and B are not touch to each other.
                        // 3.If C1C2 < R1 + R2
                        //     Circle intersects each other.

                        if (dist < radSum)
                        {
                            intersect = true;
                            break;
                        }
                    }
                    if (intersect == false)
                    {
                        comparingFinished = true;
                        gameObjects.Add(planet);
                    }
                }
            }
            DrawScene();
        }
        private void DrawScene()
        {
            BackgroundCanvas.Children.Clear();
            foreach (GameObject item in gameObjects)
            {
                if (item.GetType() == typeof(Planet))
                {
                    Planet p = (Planet)item;
                    Ellipse el = new Ellipse
                    {
                        Width = p.Size,
                        Height = p.Size,
                        Fill = (SolidColorBrush)new BrushConverter().ConvertFromString(p.OwnerColor),
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };

                    Border b = new Border
                    {
                        Width = p.Size,
                        Height = p.Size,
                        CornerRadius = new CornerRadius(80)
                    };
                    Canvas.SetLeft(b, (p.Position.X - (p.Size / 2.0)));
                    Canvas.SetTop(b, (p.Position.Y - (p.Size / 2.0)));
                    b.MouseEnter += OnPlanetMouseEnter;
                    b.MouseEnter += CreatePath;
                    b.MouseLeave += OnPlanetMouseLeave;
                    b.MouseLeave += DestroyPath;
                    b.MouseLeftButtonDown += OnPlanetLeftMouseClick;
                    b.MouseRightButtonDown += OnPlanetRightMouseClick;


                    TextBlock t = new TextBlock
                    {
                        Text = p.UnitCount.ToString(),
                        Foreground = Brushes.Yellow,
                        FontSize = 3.0,
                        Width = 5.0,
                        Height = 4.0,
                        TextAlignment = TextAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };
                    Grid grid = new Grid();
                    grid.Children.Add(el);
                    grid.Children.Add(t);
                    b.Child = grid;
                    BackgroundCanvas.Children.Add(b);
                    BackgroundCanvas.MouseWheel += OnPlanetMouseWheelMove;
                    #region Draw contact and dodge points
                    //foreach (var point in p.ContactPoints)
                    //{
                    //    Ellipse elPoint = new Ellipse
                    //    {
                    //        Width = 1.0,
                    //        Height = 1.0,
                    //        Fill = Brushes.Black,
                    //    };
                    //    Canvas.SetLeft(elPoint, point.X - (elPoint.Width / 2));
                    //    Canvas.SetTop(elPoint, point.Y - (elPoint.Height / 2));
                    //    BackgroundCanvas.Children.Add(elPoint);
                    //}
                    //foreach (var point in p.DodgePoints)
                    //{
                    //    Ellipse elPoint = new Ellipse
                    //    {
                    //        Width = 1.0,
                    //        Height = 1.0,
                    //        Fill = Brushes.Green,
                    //    };
                    //    Canvas.SetLeft(elPoint, point.X - (elPoint.Width / 2));
                    //    Canvas.SetTop(elPoint, point.Y - (elPoint.Height / 2));
                    //    BackgroundCanvas.Children.Add(elPoint);
                    //}
                    #endregion
                }

            }
        }

        private void OnPlanetMouseWheelMove(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
                RatioOfSentUnits += 10;
            else
                RatioOfSentUnits -= 20;

            if (RatioOfSentUnits > 100)
                RatioOfSentUnits = 100;
            else if (RatioOfSentUnits < 10)
                RatioOfSentUnits = 10;
        }

        private void OnPlanetRightMouseClick(object sender, MouseButtonEventArgs e)
        {
            if (chosenPlanet != null)
            {
                if (currentPolyLine.Points.Count == 0)
                    return;
                int unitCount = (int)Math.Round(chosenPlanet.UnitCount / 100.0 * RatioOfSentUnits);
                if (unitCount == 0)
                    return;
                chosenPlanet.UnitCount -= unitCount;
                chosenPlanet.UnitCountChanged = true;
                Planet targetPlanet = FindPlanetByBorder(sender as Border);
                SpaceShip spaceShip = new SpaceShip(chosenPlanet, targetPlanet, unitCount, currentPolyLine.Points.ToList(), playerColor);
                AnimateSpaceShipPath(spaceShip, MathClass.GetDistanceBetweenPointsInList(currentPolyLine.Points.ToList()), playerColor, currentPolyLine.Points);
                gameObjects.Add(spaceShip);
            }
        }
        public void AnimateSpaceShipPath(SpaceShip spaceShip, double distance, string ownerColor, PointCollection pointCol)
        {
            // Create a NameScope for the page so that
            // we can use Storyboards.
            NameScope.SetNameScope(this, new NameScope());

            // Create the EllipseGeometry to animate.
            EllipseGeometry animatedEllipseGeometry =
                new EllipseGeometry(pointCol[0], 1, 1);

            // Register the EllipseGeometry's name with
            // the page so that it can be targeted by a
            // storyboard.
            this.RegisterName("AnimatedEllipseGeometry", animatedEllipseGeometry);

            // Create a Path element to display the geometry.
            Path ellipsePath = new Path
            {
                Data = animatedEllipseGeometry,
                Fill = (SolidColorBrush)new BrushConverter().ConvertFromString(ownerColor),
            };

            spaceShipDict.Add(spaceShip, ellipsePath);

            BackgroundCanvas.Children.Add(ellipsePath);

            // Create the animation path.
            PathGeometry animationPath = new PathGeometry();
            PathFigure pFigure = new PathFigure();
            pFigure.StartPoint = pointCol[0];
            PolyBezierSegment pBezierSegment = new PolyBezierSegment();
            for (int i = 1; i < pointCol.Count; i++)
            {
                pBezierSegment.Points.Add(pointCol[i]);
                pBezierSegment.Points.Add(pointCol[i]);
                pBezierSegment.Points.Add(pointCol[i]);
            }

            pFigure.Segments.Add(pBezierSegment);
            animationPath.Figures.Add(pFigure);

            // Freeze the PathGeometry for performance benefits.
            animationPath.Freeze();

            // Create a PointAnimationgUsingPath to move
            // the EllipseGeometry along the animation path.
            PointAnimationUsingPath centerPointAnimation =
                new PointAnimationUsingPath();
            centerPointAnimation.PathGeometry = animationPath;
            double speedControl = 1.97;
            centerPointAnimation.Duration = TimeSpan.FromMilliseconds((distance / (0.125)) * speedControl);
            centerPointAnimation.RepeatBehavior = new RepeatBehavior(1);

            // Set the animation to target the Center property
            // of the EllipseGeometry named "AnimatedEllipseGeometry".
            Storyboard.SetTargetName(centerPointAnimation, "AnimatedEllipseGeometry");
            Storyboard.SetTargetProperty(centerPointAnimation,
                new PropertyPath(EllipseGeometry.CenterProperty));

            // Create a Storyboard to contain and apply the animation.
            Storyboard pathAnimationStoryboard = new Storyboard();
            pathAnimationStoryboard.RepeatBehavior = new RepeatBehavior(1);
            pathAnimationStoryboard.AutoReverse = false;
            pathAnimationStoryboard.Children.Add(centerPointAnimation);

            // Start the Storyboard when ellipsePath is loaded.
            ellipsePath.Loaded += delegate (object sender2, RoutedEventArgs evArgs)
            {
                // Start the storyboard.
                pathAnimationStoryboard.Begin(this);
            };
        }

        private (Point[], Point?, Point?) CheckIfExistsStraightPath(Planet originPlanet, Planet destinationPlanet)
        {
            double shortestDist = double.MaxValue;
            double shortestStraightPathDist = double.MaxValue;
            Point? bestOrigP = null;
            Point? bestDestP = null;
            Point[] straightPathPoints = new Point[2];

            foreach (Point origP in originPlanet.ContactPoints)
            {
                foreach (Point destP in destinationPlanet.ContactPoints)
                {
                    bool intersection = false;
                    foreach (var item in gameObjects)
                    {
                        if (item is Planet planet)
                        {
                            int collision = FindCollision(originPlanet, planet, destinationPlanet, origP, destP);
                            if (collision == -1)
                                continue;
                            else if (collision == 1)
                            {
                                intersection = true;
                                break;
                            }
                            else { }
                        }
                    }
                    double dist = MathClass.GetDistance(origP.X, destP.X, origP.Y, destP.Y);
                    // gets points for straight path
                    if (dist < shortestStraightPathDist)
                    {
                        shortestStraightPathDist = dist;
                        straightPathPoints[0] = origP;
                        straightPathPoints[1] = destP;
                    }

                    // gets the shortest path without collision
                    if (dist < shortestDist && !intersection)
                    {
                        shortestDist = dist;
                        bestOrigP = origP;
                        bestDestP = destP;
                    }
                }
            }
            return (straightPathPoints, bestOrigP, bestDestP);
        }
        private int FindCollision(Planet originPlanet, Planet collisionPlanet, Planet destinationPlanet, Point origP, Point destP)
        {
            Point midPoint = new Point((originPlanet.Position.X + destinationPlanet.Position.X) / 2, (originPlanet.Position.Y + destinationPlanet.Position.Y) / 2); // midpoint between origin and target
            double midPointTargetDist = MathClass.GetDistance(midPoint.X, destinationPlanet.Position.X, midPoint.Y, destinationPlanet.Position.Y);
            double midPointCollisionPlanetDist = MathClass.GetDistance(midPoint.X, collisionPlanet.Position.X, midPoint.Y, collisionPlanet.Position.Y);
            // find collision with other planets and check if the other planets aren't too far away
            if (collisionPlanet == originPlanet || collisionPlanet == destinationPlanet || midPointTargetDist < midPointCollisionPlanetDist)
                return -1;
            if (MathClass.LineAndCircleIntersectionExists(collisionPlanet.Position.X, collisionPlanet.Position.Y, collisionPlanet.Size / 2.0 * Planet.dodgeRadiusMultiple, origP, destP))
            {
                return 1; // intersection
            }
            return 0; // no collision
        }
        private PointCollection DesignAlternativePath(Planet originPlanet, Planet destinationPlanet, Point[] straightPathPoints)
        {
            PointCollection points = new PointCollection();
            List<Planet> planetList = new List<Planet>();
            // finds collisions between default and final position
            foreach (var item in gameObjects)
            {
                if (item is Planet planet)
                {
                    int collision = FindCollision(originPlanet, planet, destinationPlanet, new Point(originPlanet.Position.X, originPlanet.Position.Y), new Point(destinationPlanet.Position.X, destinationPlanet.Position.Y));
                    if (collision == -1)
                        continue;
                    else if (collision == 1)
                    {
                        planetList.Add(planet);
                    }
                    else { }
                }
            }
            // sorting by distance from origin
            if (planetList.Count > 1)
                planetList.Sort((x, y) => MathClass.GetDistance(originPlanet.Position.X, x.Position.X, originPlanet.Position.Y, x.Position.Y)
                .CompareTo(MathClass.GetDistance(originPlanet.Position.X, y.Position.X, originPlanet.Position.Y, y.Position.Y)));

            planetList.Insert(0, originPlanet); // add origin planet at the start of list
            planetList.Insert(planetList.Count, destinationPlanet); // add destination planet at the end of list
            Point? bestPointA = null;
            Point? bestPointB = null;
            List<Point> defaultPlanetPathPoints;
            List<Point> targetPlanetPathPoints;
            for (int i = 0; i < planetList.Count; i++)
            {
                double shortestDist = double.MaxValue;
                if (i == planetList.Count - 1) // if i == last planet, loop will be ended
                    break;

                #region Deciding between contact or dodge points connection
                if (i == 0)
                    defaultPlanetPathPoints = planetList[i].ContactPoints;
                else
                    defaultPlanetPathPoints = planetList[i].DodgePoints;

                if (i == planetList.Count - 2)
                    targetPlanetPathPoints = planetList[i + 1].ContactPoints;
                else
                    targetPlanetPathPoints = planetList[i + 1].DodgePoints;
                #endregion

                foreach (Point a in defaultPlanetPathPoints)
                {
                    foreach (Point b in targetPlanetPathPoints)
                    {
                        double dist = MathClass.GetDistance(a.X, b.X, a.Y, b.Y);
                        // gets points for straight path
                        if (dist < shortestDist)
                        {
                            shortestDist = dist;
                            bestPointA = a;
                            bestPointB = b;
                        }
                    }
                }
                if (bestPointA != null && bestPointB != null)
                {
                    if (i != 0 && i != planetList.Count - 1)
                    {
                        int clockwiseDirCount = FindDodgePointsPath(planetList, points, bestPointA, points.Last(), 1, i, false);
                        int anticlockwiseDirCount = FindDodgePointsPath(planetList, points, bestPointA, points.Last(), -1, i, false);
                        // finds out which path is shorter
                        if (clockwiseDirCount < anticlockwiseDirCount)
                            FindDodgePointsPath(planetList, points, bestPointA, points.Last(), 1, i, true);
                        else
                            FindDodgePointsPath(planetList, points, bestPointA, points.Last(), -1, i, true);
                    }
                    points.Add((Point)bestPointA);
                    points.Add((Point)bestPointB);
                }
            }
            return points;
        }
        private int FindDodgePointsPath(List<Planet> planetList, PointCollection points, Point? origin, Point target, int direction, int planetList_i, bool savePoints)
        {
            bool pathCompleted = false;
            int counter = 0;
            int j = 0;
            int walkThroughNum = 0;
            bool startDrawing = false;
            Point originP = points.Last();
            while (!pathCompleted)
            {
                if (planetList[planetList_i].DodgePoints[j] == origin)
                    startDrawing = false;
                if (startDrawing)
                {
                    if (savePoints)
                        points.Add(planetList[planetList_i].DodgePoints[j]);
                    counter++;
                }
                if (planetList[planetList_i].DodgePoints[j] == originP)
                {
                    startDrawing = true;
                    walkThroughNum++;
                }
                if (walkThroughNum == 2)
                    pathCompleted = true;
                j += direction;
                if (j == Planet.borderPointCount && direction == 1)
                    j = 0;
                else if (j == -1 && direction == -1)
                    j = Planet.borderPointCount - 1;
            }
            return counter;
        }
        private void CreatePath(object sender, MouseEventArgs e)
        {
            if (chosenPlanet != null)
            {
                Point? origP;
                Point? destP = null;
                Point[] straightPathPoints;
                if (chosenPlanet != null)
                {
                    if (FindPlanetByBorder(sender as Border) != chosenPlanet)
                    {
                        PointCollection points = new PointCollection();

                        (straightPathPoints, origP, destP) = CheckIfExistsStraightPath(chosenPlanet, FindPlanetByBorder(sender as Border));
                        if (origP == null || destP == null)
                            points = DesignAlternativePath(chosenPlanet, FindPlanetByBorder(sender as Border), straightPathPoints);
                        else
                        {

                            points.Add((Point)origP);
                            points.Add((Point)destP);
                        }
                        currentPolyLine.StrokeThickness = .8;
                        currentPolyLine.Stroke = Brushes.Blue;
                        currentPolyLine.Points = points;
                        BackgroundCanvas.Children.Add(currentPolyLine);
                    }
                }
            }
        }

        private void DestroyPath(object sender, MouseEventArgs e)
        {
            BackgroundCanvas.Children.Remove(currentPolyLine);
        }

        private void OnPlanetLeftMouseClick(object sender, MouseButtonEventArgs e)
        {
            Border b;
            Ellipse el;
            // if there is already chosen planet, it will be unselected
            if (chosenPlanet != null)
            {
                b = FindBorderByPlanet(chosenPlanet);
                el = (Ellipse)((Grid)b.Child).Children[0];
                el.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString(chosenPlanet.OwnerColor);
                // if player choses already selected planet, it will be unselected as well
                if (chosenPlanet == FindPlanetByBorder((sender as Border)))
                {
                    chosenPlanet = null;
                    return;
                }
            }

            b = (sender as Border);
            el = (Ellipse)((Grid)b.Child).Children[0];
            Planet p = FindPlanetByBorder(b);
            // checks if the planet belongs to the player
            if (p.OwnerColor == playerColor)
            {
                chosenPlanet = p;
                el.Fill = Brushes.Orange;
            }
            else
            {
                chosenPlanet = null;
            }

        }
        private void OnPlanetMouseEnter(object sender, MouseEventArgs e)
        {
            Grid grid = (Grid)(sender as Border).Child;
            Ellipse el = (Ellipse)grid.Children[0];
            el.Fill = Brushes.Orange;
        }
        private void OnPlanetMouseLeave(object sender, MouseEventArgs e)
        {
            Border b = (sender as Border);
            Planet p = FindPlanetByBorder(b);
            Ellipse el = (Ellipse)((Grid)b.Child).Children[0];
            if (p != chosenPlanet)
                el.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString(p.OwnerColor);

        }
        /// <summary>
        /// Checks equlity of coordinations of given planet and border component
        /// </summary>
        /// <param name="p"></param>
        /// <param name="b"></param>
        /// <returns>boolean value</returns>
        private bool PlanetEqualsBorder(Planet p, Border b)
        {
            return p.Position.X == (Canvas.GetLeft(b) + p.Size / 2.0) && p.Position.Y == (Canvas.GetTop(b) + p.Size / 2.0);
        }

        private void RemoveCompletedObjects()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i] is SpaceShip spaceShip)
                {
                    if (spaceShip.CompletionIndication)
                    {
                        BackgroundCanvas.Children.Remove(spaceShipDict[spaceShip]);
                        gameObjects.Remove(spaceShip);
                        spaceShipDict.Remove(spaceShip);
                    }
                }
            }
        }

        private void UpdateGameObjects()
        {
            foreach (GameObject ob in gameObjects)
            {
                //Canvas.SetLeft(b, (p.Position.X - (p.Size / 2)));
                //Canvas.SetTop(b, (p.Position.Y - (p.Size / 2)));
                if (ob is Planet planet)
                {
                    Border b = FindBorderByPlanet(planet);
                    Grid grid = (Grid)b.Child;
                    if (planet.UnitCountChanged)
                    {
                        TextBlock tb = (TextBlock)grid.Children[1];
                        tb.Text = planet.UnitCount.ToString();
                        planet.UnitCountChanged = false;
                    }
                    if (planet.OwnerChanged)
                    {
                        Ellipse el = (Ellipse)grid.Children[0];
                        el.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString(planet.OwnerColor);
                        planet.OwnerChanged = false;
                    }

                }
                if (ob is SpaceShip spaceShip)
                {
                    spaceShip.Update(MainTimer.Interval.TotalMilliseconds);
                    EllipseGeometry data = (EllipseGeometry)spaceShipDict[spaceShip].Data;
                    spaceShip.Position = data.Center;
                }
            }
        }

        /// <summary>
        /// Method finds appropriate Planet by a specific Border component
        /// </summary>
        /// <param name="b"></param>
        /// <returns>object of type Planet</returns>
        private Planet FindPlanetByBorder(Border b)
        {
            foreach (var item in gameObjects)
            {
                if (item is Planet)
                    if (PlanetEqualsBorder((Planet)item, b))
                        return (Planet)item;
            }
            throw new NullReferenceException();
        }

        /// <summary>
        /// Method finds appropriate Border component by a specific Planet
        /// </summary>
        /// <param name="p"></param>
        /// <returns>object of type Border</returns>
        private Border FindBorderByPlanet(Planet p)
        {
            foreach (var item in BackgroundCanvas.Children)
            {
                if (item is Border b)
                {
                    if (PlanetEqualsBorder(p, b))
                    {
                        return b;

                    }
                }
            }
            throw new NullReferenceException();
        }

        #region AI methods
        private void AILogic()
        {
            if (gameWon)
                return;
            DestroyAIPath();
            int targetPlanetNum;
            int originPlanetNum;

            bool targetPlanetChosen = false;
            do
            {
                targetPlanetNum = rand.Next(gameObjects.Count);

                if (gameObjects[targetPlanetNum].GetType() == typeof(Planet))
                    targetPlanetChosen = true;
                if (gameWon)
                    break;
            }
            while (!targetPlanetChosen);

            bool originPlanetChosen = false;
            do
            {
                originPlanetNum = rand.Next(gameObjects.Count);
                if (gameObjects[originPlanetNum].GetType() == typeof(Planet) && gameObjects[originPlanetNum].OwnerColor == "Blue" && originPlanetNum != targetPlanetNum)
                    originPlanetChosen = true;
                if (gameWon)
                    break;
            }
            while (!originPlanetChosen);
            if (gameWon)
                return;
            Planet origin = gameObjects[originPlanetNum] as Planet;
            Planet target = gameObjects[targetPlanetNum] as Planet;
            CreateAIPath(origin, target);
            AnimateAIShips(origin, target);
        }
        private void AnimateAIShips(Planet originPlanet, Planet targetPlanet)
        {
            if (currentAIPolyLine.Points.Count == 0)
                return;
            int unitCount = (int)Math.Round(originPlanet.UnitCount / 100.0 * 50);
            if (unitCount == 0)
                return;
            originPlanet.UnitCount -= unitCount;
            originPlanet.UnitCountChanged = true;
            SpaceShip spaceShip = new SpaceShip(originPlanet, targetPlanet, unitCount, currentAIPolyLine.Points.ToList(), npcColor);
            AnimateSpaceShipPath(spaceShip, MathClass.GetDistanceBetweenPointsInList(currentAIPolyLine.Points.ToList()), npcColor, currentAIPolyLine.Points);
            gameObjects.Add(spaceShip);
        }
        private void CreateAIPath(Planet origin, Planet target)
        {
            Point? origP;
            Point? destP = null;
            Point[] straightPathPoints;
            if (target != origin)
            {
                PointCollection points = new PointCollection();

                (straightPathPoints, origP, destP) = CheckIfExistsStraightPath(origin, target);
                if (origP == null || destP == null)
                    points = DesignAlternativePath(origin, target, straightPathPoints);
                else
                {
                    points.Add((Point)origP);
                    points.Add((Point)destP);
                }
                #region Draw AI Path
                //currentAIPolyLine.StrokeThickness = .8;
                //currentAIPolyLine.Stroke = Brushes.Green;
                #endregion
                currentAIPolyLine.Points = points;
                BackgroundCanvas.Children.Add(currentAIPolyLine);
            }
        }
        private void DestroyAIPath()
        {
            BackgroundCanvas.Children.Remove(currentAIPolyLine);
        }
        #endregion
    }
}
