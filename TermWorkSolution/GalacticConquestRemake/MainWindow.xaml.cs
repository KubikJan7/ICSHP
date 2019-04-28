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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using GalacticConquestRemake.Common;
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

                while (comparingFinished == false)
                {
                    int size = rand.Next(16, 49);
                    double screenBorderRadius = size / 2.0 * Planet.dodgeRadiusMultiple;
                    Point pos = new Point(rand.Next((int)Math.Round((0 + screenBorderRadius)), (int)Math.Round((winWidth - screenBorderRadius))),
                        rand.Next(Convert.ToInt32((0 + screenBorderRadius)), Convert.ToInt32((winHeight - screenBorderRadius))));
                    Planet p = new Planet(pos, size, color);

                    bool intersect = false;

                    for (int j = 0; j < gameObjects.Count; j++)
                    {
                        if (gameObjects.Count == 0 || gameObjects[j].GetType() != typeof(Planet))
                            continue;
                        // Distance between centers C1 and C2 -> C1C2 = sqrt((x1 - x2)2 + (y1 - y2)2).
                        double dist = GetDistance(p.Position.X, gameObjects[j].Position.X, p.Position.Y, gameObjects[j].Position.Y);
                        double radSum = ((p.Size / 2.0 * Planet.dodgeRadiusMultiple) + (gameObjects[j].Size / 2.0 * Planet.dodgeRadiusMultiple)) *
                                        ((p.Size / 2.0 * Planet.dodgeRadiusMultiple) + (gameObjects[j].Size / 2.0 * Planet.dodgeRadiusMultiple));

                        // 1.If C1C2 == R1 + R2
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
                        gameObjects.Add(p);
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
            PathGeometry animationPath = new PathGeometry();
        }

        private (Point?, Point?) CheckIfExistsStraightPath(Planet destinationPlanet)
        {
            double shortestDist = double.MaxValue;
            Point? bestOrigP = null;
            Point? bestDestP = null;
            foreach (var origP in chosenPlanet.ContactPoints)
            {
                foreach (var destP in destinationPlanet.ContactPoints)
                {
                    double dist = GetDistance(origP.X, destP.X, origP.Y, destP.Y);
                    bool intersection = false;
                    foreach (var item in gameObjects)
                    {
                        if (item.GetType() == typeof(Planet))
                        {
                            Planet p = (Planet)item;
                            if (LineAndCircleIntersectionExists(p.Position.X, p.Position.Y, p.Size / 2.0 * Planet.dodgeRadiusMultiple, origP, destP))
                            {
                                intersection = true;
                                break;
                            }
                        }
                    }
                    if (dist < shortestDist && !intersection)
                    {
                        shortestDist = dist;
                        bestOrigP = origP;
                        bestDestP = destP;
                    }
                }
            }
            return (bestOrigP, bestDestP);
        }
        private void DesignAlternativePath()
        {

        }

        private void CreatePath(object sender, MouseEventArgs e)
        {
            Point? origP;
            Point? destP = null;
            if (chosenPlanet != null)
            {
                if (FindPlanetByBorder(sender as Border) != chosenPlanet)
                {
                    (origP, destP) = CheckIfExistsStraightPath(FindPlanetByBorder(sender as Border));
                    if (origP == null || destP == null)
                        DesignAlternativePath();
                    else
                    {
                        PointCollection points = new PointCollection
                    {
                        (Point)origP,
                        (Point)destP
                    };
                        Polyline pl = new Polyline
                        {
                            StrokeThickness = 1,
                            Stroke = Brushes.Blue,
                            Points = points
                        };
                        BackgroundCanvas.Children.Add(pl);
                    }
                }
            }
        }

        private void DestroyPath(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < BackgroundCanvas.Children.Count; i++)
            {
                if (BackgroundCanvas.Children[i].GetType() == typeof(Polyline))
                    BackgroundCanvas.Children.Remove(BackgroundCanvas.Children[i]);
            }

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
        /// Returns distance between 2 points
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="y1"></param>
        /// <param name="y2"></param>
        /// <returns>distance in double</returns>
        private double GetDistance(double x1, double x2, double y1, double y2)
        {
            return (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2);
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
                if (ob.GetType() == typeof(Planet))
                {
                    Planet p = (Planet)ob;
                    Border b = FindBorderByPlanet(p);
                    Grid grid = (Grid)b.Child;
                    TextBlock tb = (TextBlock)grid.Children[1];
                    tb.Text = p.UnitCount.ToString();
                }
                ob.Update(ob.Sum);
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
                if (item.GetType() != typeof(SpaceShip))
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
                if (item.GetType() == typeof(Border))
                {
                    Border b = (Border)item;
                    if (PlanetEqualsBorder(p, b))
                    {
                        return b;

                    }
                }
            }
            throw new NullReferenceException();
        }
        // Find the points of intersection.
        private bool LineAndCircleIntersectionExists(
            double cx, double cy, double radius,
            Point point1, Point point2)
        {
            double dx, dy, A, B, C, det;

            dx = point2.X - point1.X;
            dy = point2.Y - point1.Y;

            A = dx * dx + dy * dy;
            B = 2 * (dx * (point1.X - cx) + dy * (point1.Y - cy));
            C = (point1.X - cx) * (point1.X - cx) +
                (point1.Y - cy) * (point1.Y - cy) -
                radius * radius;

            det = B * B - 4 * A * C;
            if ((A <= 0.0000001) || (det < 0) || (det == 0))
            {
                // no or one intersection
                return false;
            }
            else
            {
                // two intersections
                return true;
            }
        }
    }
}
