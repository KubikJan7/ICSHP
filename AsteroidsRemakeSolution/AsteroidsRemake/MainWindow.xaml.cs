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
        private DispatcherTimer activateBtnTimer;
        private Storyboard storyboard;

        private List<GameObject> gameObjects = new List<GameObject>();
        private PlayerShip player;
        private Dictionary<Shot, Ellipse> shotDict = new Dictionary<Shot, Ellipse>();
        private bool IsAccelerating { get; set; }
        private Random random = new Random();

        double screenWidth;
        double screenHeight;

        public MainWindow()
        {
            InitializeComponent();
            screenWidth = BackgroundCanvas.Width;
            screenHeight = BackgroundCanvas.Height;
            InitializeTimers();
            DrawScene();
        }

        private void InitializeTimers()
        {
            mainTimer = new DispatcherTimer(DispatcherPriority.Render);
            mainTimer.Tick += new EventHandler(MainTimer_Tick);
            mainTimer.Interval = TimeSpan.FromSeconds(0.01);
            mainTimer.Start();

            activateBtnTimer = new DispatcherTimer();
            activateBtnTimer.Tick += new EventHandler(ActivateBtnTimer_Tick);
            activateBtnTimer.Interval = TimeSpan.FromSeconds(1);
            activateBtnTimer.Start();
        }
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            ManageVelocity(); // increase or decrease the ship velocity through the time
            AccelerateShip();

            CreateNoEdgeScreen();
            Shoot();
        }

        private void ActivateBtnTimer_Tick(object sender, EventArgs e)
        {
            HyperDriveActive = true;
        }

        private void DrawScene()
        {
            storyboard = new Storyboard();
            CreatePlayerShip();
            CreateAsteroids();
        }

        private void CreatePlayerShip()
        {
            player = new PlayerShip(new Point(0, 0), 40);
            gameObjects.Add(player);

            SolidColorBrush colorBrush = new SolidColorBrush
            {
                Color = Color.FromRgb(138, 148, 255)
            };

            playerPolygon.Fill = colorBrush;
        }

        private int asteroidCount = 4;
        private void CreateAsteroids()
        {

            SolidColorBrush colorBrush = new SolidColorBrush
            {
                Color = Color.FromRgb(132, 118, 85)
            };

            for (int i = 0; i < asteroidCount; i++)
            {
                bool hasCollision;
                Asteroid asteroid = new Asteroid(200);
                gameObjects.Add(asteroid);
                do
                {
                    Point position = GenerateObjectPosition(asteroid.Size);
                    asteroid.Position = position;

                    hasCollision = FindCollisionWithOtherObjects(asteroid);

                } while (hasCollision);

                Ellipse el = new Ellipse
                {
                    Width = asteroid.Size,
                    Height = asteroid.Size,
                    Fill = colorBrush,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                // The substraction by the (asteroid.Size/2) is used so the circle is drawn from its center 
                Canvas.SetLeft(el, asteroid.Position.X - asteroid.Size / 2);
                Canvas.SetTop(el, asteroid.Position.Y - asteroid.Size / 2);
                BackgroundCanvas.Children.Add(el);
            }
            asteroidCount++;
        }
        private void CreateNoEdgeScreen()
        {
            // Check a collision with a window edge
            if (player.Position.X > screenWidth / 2 || player.Position.X < -(screenWidth / 2)
                || player.Position.Y > screenHeight / 2 || player.Position.Y < -(screenHeight / 2))
            {
                double relativeScreenW = screenWidth / 2;
                double relativeScreenH = screenHeight / 2;

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
            Point shotStart = MathClass.MovePointByGivenDistanceAndAngle(new Point(player.Position.X, player.Position.Y), 30, polygonRotation.Angle);
            // Calculate the position of the shot vanishing spot
            Point shotEnd = MathClass.MovePointByGivenDistanceAndAngle(shotStart, 640, polygonRotation.Angle);
            // Create shot with target set in front of the ship nose
            Shot shot = new Shot(shotStart, shotEnd, 5);
            SolidColorBrush colorBrush = new SolidColorBrush
            {
                Color = Color.FromRgb(249, 248, 113)
            };
            Ellipse el = new Ellipse
            {
                Height = shot.Size,
                Width = shot.Size,
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
                    item.Key.Position = MathClass.MovePointTowards(item.Key.Position, item.Key.Target, 5.0);
                    Canvas.SetLeft(item.Value, item.Key.Position.X + screenWidth/2.0 - item.Key.Size/2.0);
                    Canvas.SetTop(item.Value, -item.Key.Position.Y + screenHeight / 2.0 + item.Key.Size/2.0);

                    if (MathClass.IsPointInsideCircle(item.Key.Target.X, item.Key.Target.Y, 2, item.Key.Position.X, item.Key.Position.Y))
                    {
                        BackgroundCanvas.Children.Remove(item.Value);
                        shotDict.Remove(item.Key);
                    }
                }
            }
        }
        private void AccelerateShip()
        {
            double movementStep = 5.0;

            // Get the current player position
            if (IsAccelerating) // Key W is pressed
            {
                double angleDifference = MathClass.FindDifferenceOfTwoAngles(player.MotionDirection, polygonRotation.Angle);
                if ((angleDifference >= 20 && angleDifference < 160) || (angleDifference > 200 && angleDifference <= 340))
                    player.Velocity = 0.0;
                // Check if the ship is moving backwards
                else if (angleDifference >= 160 && angleDifference <= 200)
                    player.Velocity *= -1.0; // set negative value to move slowly backwards (inertia)
                player.MotionDirection = polygonRotation.Angle;
            }
            // Move the ship in the forward direction (ship nose) by the specified step
            player.Position = MathClass.MovePointByGivenDistanceAndAngle(player.Position, movementStep
                * player.Velocity, player.MotionDirection);
            // Display the new position on the canvas
            Canvas.SetLeft(playerPolygon, player.Position.X);
            Canvas.SetTop(playerPolygon, -player.Position.Y); // minus sign due to the use of the canvas top component
        }

        private void ManageVelocity()
        {
            if (IsAccelerating && player.Velocity < 1)
                player.Velocity += 0.003; // accelerating
            else if (!IsAccelerating && player.Velocity > 0)
                player.Velocity -= 0.0001; // slowing down
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
        private bool HyperDriveActive;
        /// <summary>
        /// This method will basically make the player teleport to another location.
        /// </summary>
        private void TravelThroughHyperspace()
        {
            if (HyperDriveActive)
            {
                HyperDriveActive = false;
                Point pos = GenerateObjectPosition(40);
                player.Position = new Point(pos.X - BackgroundCanvas.Width / 2, pos.Y - BackgroundCanvas.Height / 2); //position relative to the polygon
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
            else if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
                TravelThroughHyperspace();
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

        private Point GenerateObjectPosition(double size)
        {
            double minWidth = 0 + size / 2.0;
            double maxWidth = screenWidth - size / 2.0-20;
            double minHeight = 0 + size / 2.0;
            double maxHeight = screenHeight - size / 2.0-20;

            double x = random.NextDouble() * (maxWidth - minWidth) + minWidth;
            double y = random.NextDouble() * (maxHeight - minHeight) + minHeight;
            return new Point(x, y);
        }

        private bool FindCollisionWithOtherObjects(GameObject gameObject)
        {
            foreach (var item in gameObjects)
            {
                if (gameObject.Equals(item))
                    continue;

                double dist;
                // changes playership coordinations since its origin is situated in the canvas center
                if (item is PlayerShip)
                    dist = MathClass.GetDistance(gameObject.Position.X, item.Position.X + screenWidth / 2,
                        gameObject.Position.Y, item.Position.Y + screenHeight / 2);
                else
                dist = MathClass.GetDistance(gameObject.Position.X, item.Position.X, gameObject.Position.Y, item.Position.Y);
                double radSum = gameObject.Size / 2.0 + item.Size / 2.0+10;
                if (dist < radSum)
                    return true;
            }
            return false;
        }
        #endregion
    }
}
