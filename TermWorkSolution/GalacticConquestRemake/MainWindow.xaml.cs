﻿using System;
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
        private List<GameObject> gameObjects = new List<GameObject>();
        private DispatcherTimer timer = new DispatcherTimer();
        private uint spaceShipUnitCount = 50;
        private Planet chosenPlanet;
        private string playerColor = "Red";
        public MainWindow()
        {
            InitializeComponent();
            GeneratePlanets();
            InitializeTimer();
        }
        private void InitializeTimer()
        {
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdatePlanetUnits();
            RemoveCompletedObjects();
        }

        private void GeneratePlanets()
        {
            BackgroundCanvas.Children.Clear();
            double winHeight = BackgroundCanvas.Height;
            double winWidth = BackgroundCanvas.Width;
            Random rand = new Random();
            int planetCount = 10; //rand.Next(8, 13);

            for (int i = 0; i < planetCount; i++)
            {
                bool comparingFinished = false;

                string color = "Red";
                if (i >= 3 && i < 6)
                    color = "Blue";
                else if (i >= 6)
                    color = "Gray";
                Planet planet;
                while (comparingFinished == false)
                {
                    int size = rand.Next(16, 49);
                    double screenBorderRadius = size / 2.0 * Planet.dodgeRadiusMultiple;
                    Position position = new Position(rand.Next((int)Math.Round(0 + screenBorderRadius), (int)Math.Round(winWidth - screenBorderRadius)),
                        rand.Next((int)Math.Round(0 + screenBorderRadius), (int)Math.Round(winHeight - screenBorderRadius)));
                    planet = new Planet(position, size, color);

                    bool intersect = false;
                    for (int j = 0; j < gameObjects.Count; j++)
                    {
                        if (gameObjects.Count == 0 || gameObjects[j] is SpaceShip)
                            continue;
                        //Distance between centers C1 and C2 -> C1C2 = sqrt((x1 - x2)2 + (y1 - y2)2).
                        double dist = MathClass.GetDistance(planet.Position.X, gameObjects[j].Position.X, planet.Position.Y, gameObjects[j].Position.Y);
                        double radSum = ((planet.Size / 2.0 * Planet.dodgeRadiusMultiple) + (gameObjects[j].Size / 2.0 * Planet.dodgeRadiusMultiple)) *
                                        ((planet.Size / 2.0 * Planet.dodgeRadiusMultiple) + (gameObjects[j].Size / 2.0 * Planet.dodgeRadiusMultiple));

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

                    #region Draw border points
                    foreach (var point in p.ContactPoints)
                    {
                        Ellipse elPoint = new Ellipse
                        {
                            Width = 1.0,
                            Height = 1.0,
                            Fill = Brushes.Black,
                        };
                        Canvas.SetLeft(elPoint, point.X - (elPoint.Width / 2));
                        Canvas.SetTop(elPoint, point.Y - (elPoint.Height / 2));
                        BackgroundCanvas.Children.Add(elPoint);
                    }
                    foreach (var point in p.DodgePoints)
                    {
                        Ellipse elPoint = new Ellipse
                        {
                            Width = 1.0,
                            Height = 1.0,
                            Fill = Brushes.Green,
                        };
                        Canvas.SetLeft(elPoint, point.X - (elPoint.Width / 2));
                        Canvas.SetTop(elPoint, point.Y - (elPoint.Height / 2));
                        BackgroundCanvas.Children.Add(elPoint);
                    }
                    #endregion
                }

            }
        }

        private void OnPlanetRightMouseClick(object sender, MouseButtonEventArgs e)
        {
            if (currentPolyLine.Points.Count == 0)
                return;
            PointCollection pointCol = currentPolyLine.Points;
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
                Fill = Brushes.Red,
            };

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
            centerPointAnimation.Duration = TimeSpan.FromSeconds(5);
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

        private (Point[], Point?, Point?) CheckIfExistsStraightPath(Planet destinationPlanet)
        {
            double shortestDist = double.MaxValue;
            double shortestStraightPathDist = double.MaxValue;
            Point? bestOrigP = null;
            Point? bestDestP = null;
            Point[] straightPathPoints = new Point[2];

            foreach (Point origP in chosenPlanet.ContactPoints)
            {
                foreach (Point destP in destinationPlanet.ContactPoints)
                {
                    bool intersection = false;
                    foreach (var item in gameObjects)
                    {
                        if (item is Planet planet)
                        {
                            // find collision with other planets
                            if (planet == chosenPlanet || planet == destinationPlanet)
                                continue;
                            if (MathClass.LineAndCircleIntersectionExists(planet.Position.X, planet.Position.Y, planet.Size / 2.0 * Planet.dodgeRadiusMultiple, origP, destP))
                            {
                                intersection = true;
                                break;
                            }
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
        private PointCollection DesignAlternativePath(Planet destinationPlanet, Point[] straightPathPoints)
        {
            PointCollection points = new PointCollection();
            List<Planet> planetList = new List<Planet>();
            foreach (var item in gameObjects)
            {
                if (item is Planet planet)
                {
                    // find collision with other planets
                    if (planet == chosenPlanet || planet == destinationPlanet)
                        continue;
                    if (MathClass.LineAndCircleIntersectionExists(planet.Position.X, planet.Position.Y, planet.Size / 2.0 * Planet.dodgeRadiusMultiple, straightPathPoints[0], straightPathPoints[1]))
                    {
                        planetList.Add(planet);
                        break;
                    }
                }
            }
            // sorting by distance from origin
            if (planetList.Count > 1)
                planetList.OrderBy(t => MathClass.GetDistance(chosenPlanet.Position.X, t.Position.X, chosenPlanet.Position.Y, t.Position.Y)).ToList();

            planetList.Insert(0, chosenPlanet); // add origin planet at the start of list
            planetList.Insert(planetList.Count, destinationPlanet); // add destination planet at the end of list
            Point? bestPointA = null;
            Point? bestPointB = null;
            for (int i = 0; i < planetList.Count; i++)
            {
                double shortestDist = double.MaxValue;
                if (i == planetList.Count - 1)
                    break;
                foreach (Point a in planetList[i].DodgePoints)
                {
                    foreach (Point b in planetList[i + 1].DodgePoints)
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
                        bool startDrawing = false;
                        foreach (Point point in planetList[i].DodgePoints)
                        {
                            if (point == bestPointA)
                                startDrawing = false;
                            if (startDrawing)
                                points.Add(point);
                            if (point == points.Last())
                                startDrawing = true;
                        }
                    }
                    points.Add((Point)bestPointA);
                    points.Add((Point)bestPointB);
                }

            }
            return points;
        }
        Polyline currentPolyLine = new Polyline();
        private void CreatePath(object sender, MouseEventArgs e)
        {
            Point? origP;
            Point? destP = null;
            Point[] straightPathPoints;
            if (chosenPlanet != null)
            {
                if (FindPlanetByBorder(sender as Border) != chosenPlanet)
                {
                    PointCollection points = new PointCollection();

                    (straightPathPoints, origP, destP) = CheckIfExistsStraightPath(FindPlanetByBorder(sender as Border));
                    if (origP == null || destP == null)
                        points = DesignAlternativePath(FindPlanetByBorder(sender as Border), straightPathPoints);
                    else
                    {

                        points.Add((Point)origP);
                        points.Add((Point)destP);
                    }
                    currentPolyLine.StrokeThickness = 1;
                    currentPolyLine.Stroke = Brushes.Blue;
                    currentPolyLine.Points = points;
                    BackgroundCanvas.Children.Add(currentPolyLine);
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
            foreach (var ob in gameObjects)
            {
                if (ob.CompletionIndication)
                    gameObjects.Remove(ob);
            }
        }

        private void UpdatePlanetUnits()
        {
            foreach (GameObject ob in gameObjects)
            {
                //Canvas.SetLeft(b, (p.Position.X - (p.Size / 2)));
                //Canvas.SetTop(b, (p.Position.Y - (p.Size / 2)));
                if (ob is Planet planet)
                {
                    if (planet.NeedOfUpdate)
                    {
                        Border b = FindBorderByPlanet(planet);
                        Grid grid = (Grid)b.Child;
                        TextBlock tb = (TextBlock)grid.Children[1];
                        tb.Text = planet.UnitCount.ToString();
                        planet.NeedOfUpdate = false;
                    }
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
    }
}
