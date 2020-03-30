using AsteroidsRemake.Common;
using AsteroidsRemake.MathLibrary;
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

namespace AsteroidsRemake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer mainTimer;
        private Storyboard storyboard;
        private PlayerShip player;
        private Dictionary<Shot, Ellipse> shotDict = new Dictionary<Shot, Ellipse>();
        private bool IsAccelerating { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            InitializeTimers();
            DrawScene();
        }

        private void InitializeTimers()
        {
            mainTimer = new DispatcherTimer();
            mainTimer.Tick += new EventHandler(MainTimer_Tick);
            mainTimer.Interval = TimeSpan.FromMilliseconds(0.45);
            mainTimer.Start();
        }
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            ManageProgressiveSpeed();
            if (player.Speed > 0)
            {
                AccelerateShip();
            }

            CreateNoEdgeScreen();
            Shoot();
        }

        private void DrawScene()
        {
            storyboard = new Storyboard();
            CreatePlayerShip();
        }

        private void CreatePlayerShip()
        {
            player = new PlayerShip(new Point(0, 0));

            SolidColorBrush colorBrush = new SolidColorBrush
            {
                Color = Color.FromRgb(138, 148, 255)
            };

            playerPolygon.Fill = colorBrush;
        }

        private void CreateNoEdgeScreen()
        {
            // Check a collision with a window edge
            if (player.Position.X > MainWindow1.Width / 2 + 20 || player.Position.X < -(MainWindow1.Width / 2 + 20)
                || player.Position.Y > MainWindow1.Height / 2 + 20 || player.Position.Y < -(MainWindow1.Height / 2 + 20))
            {
                double relativeScreenW = MainWindow1.Width / 2 + 20;
                double relativeScreenH = MainWindow1.Height / 2 + 20;

                if (player.Position.X > relativeScreenW)
                {
                    player.Position = new Point(-relativeScreenW, player.Position.Y);
                }
                else if (player.Position.X < -relativeScreenW)
                {
                    player.Position = new Point(relativeScreenW, player.Position.Y);
                }
                else if (player.Position.Y > relativeScreenH)
                {
                    player.Position = new Point(player.Position.X, -relativeScreenH);
                }
                else if (player.Position.Y < -relativeScreenH)
                {
                    player.Position = new Point(player.Position.X, relativeScreenH);
                }
                Canvas.SetLeft(playerPolygon, player.Position.X);
                Canvas.SetTop(playerPolygon, player.Position.Y);
            }
        }

        #region ship controlling methods
        private void PrepareShot()
        {
            // Get the shooting starting point
            Point shotStart = MathClass.MovePointByGivenDistanceAndAngle(player.Position, 30, polygonRotation.Angle);
            // Calculate the position of the shot vanishing spot
            Point shotEnd = MathClass.MovePointByGivenDistanceAndAngle(shotStart, 640, polygonRotation.Angle);
            // Create shot with target set in front of the ship nose
            Shot shot = new Shot(shotStart, shotEnd);
            SolidColorBrush colorBrush = new SolidColorBrush
            {
                Color = Color.FromRgb(249, 248, 113)
            };
            Ellipse el = new Ellipse
            {
                Height = 5,
                Width = 5,
                Fill = colorBrush,
            };

            shotDict.Add(shot, el);
            BackgroundCanvas.Children.Add(el);
        }
        private void Shoot()
        {
            if (shotDict.Count > 0)
            {
                KeyValuePair<Shot, Ellipse> item;
                for (int i = 0; i < shotDict.Count; i++)
                {
                    item = shotDict.ElementAt(i);
                    item.Key.Position = MathClass.MovePointTowards(item.Key.Position, item.Key.Target, 0.4);
                    Canvas.SetLeft(item.Value, item.Key.Position.X + 640);
                    Canvas.SetTop(item.Value, -item.Key.Position.Y + 360);

                    if (MathClass.IsPointInsideCircle(item.Key.Target.X, item.Key.Target.Y, 2, item.Key.Position.X, item.Key.Position.Y))
                    {
                        BackgroundCanvas.Children.Remove(item.Value);
                        shotDict.Remove(item.Key);
                    }
                }
            }
        }
        private double flightRotation;
        private void AccelerateShip()
        {
            // Get the current player position
            Point shipCenter = player.Position;

            if (IsAccelerating)
                flightRotation = polygonRotation.Angle;
            // Calculate the position of the ship front part
            Point shipNose = MathClass.MovePointByGivenDistanceAndAngle(shipCenter, 20, flightRotation);
            // Move the ship in the forward direction (ship nose) by the specified step
            player.Position = MathClass.MovePointTowards(shipCenter, shipNose, 0.5 * player.Speed);
            // Display the new position on the canvas
            Canvas.SetLeft(playerPolygon, player.Position.X);
            Canvas.SetTop(playerPolygon, -player.Position.Y); // minus sign due to the use of the canvas top component
        }

        private void ManageProgressiveSpeed()
        {
            if (IsAccelerating && player.Speed < 1)
                player.Speed += 0.0001;
            else if (!IsAccelerating && player.Speed > 0)
                player.Speed -= 0.0001;
        }

        private double goalRotation;
        private void RotateShip(string direction)
        {
            if (goalRotation == polygonRotation.Angle)
            {
                Point p = GetShipCenter();
                polygonRotation.CenterX = p.X;
                polygonRotation.CenterY = p.Y;
                // Will set the goal rotation depending on the current direction
                goalRotation = ((direction == "to left") ? polygonRotation.Angle - 3600 : polygonRotation.Angle + 3600);

                storyboard.Duration = new Duration(TimeSpan.FromSeconds(10));
                DoubleAnimation rotateAnimation = new DoubleAnimation()
                {
                    From = polygonRotation.Angle,
                    To = goalRotation,
                    Duration = storyboard.Duration,
                };
                Storyboard.SetTarget(rotateAnimation, playerPolygon);
                Storyboard.SetTargetProperty(rotateAnimation, new PropertyPath("(Polygon.RenderTransform).(RotateTransform.Angle)"));
                storyboard.Children.Clear();
                storyboard.Children.Add(rotateAnimation);
                storyboard.Begin();
            }
        }

        private void MainWindow1_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if a key is held down
            if (!e.IsRepeat)
            {
                if (e.Key == Key.A || e.Key == Key.Left || e.Key == Key.D || e.Key == Key.Right)
                {
                    // Resume animation
                    storyboard.Resume();
                    goalRotation = polygonRotation.Angle;
                }
            }
            if (e.Key == Key.W || e.Key == Key.Up)
                IsAccelerating = true;
            else if (e.Key == Key.A || e.Key == Key.Left)
                RotateShip("to left");
            else if (e.Key == Key.D || e.Key == Key.Right)
                RotateShip("to right");
            else if (e.Key == Key.Space)
                PrepareShot();
        }

        private void MainWindow1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A || e.Key == Key.Left || e.Key == Key.D || e.Key == Key.Right)
                storyboard.Pause(); // Pause the animation of rotation
            if (e.Key == Key.W || e.Key == Key.Up)
                IsAccelerating = false;
        }
        #endregion


        #region Auxiliary methods
        private Point GetShipCenter()
        {
            Point a = playerPolygon.Points[0];
            Point b = playerPolygon.Points[1];
            Point c = playerPolygon.Points[2];
            return MathClass.FindCenterOfTriangle(a, b, c);
        }
        #endregion
    }
}
