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
        private DispatcherTimer hyperDriveTimer;
        private DispatcherTimer gunLoadedTimer;
        private DispatcherTimer enemySpawnTimer;
        private Storyboard storyboard;

        private List<GameObject> gameObjects = new List<GameObject>();
        private PlayerShip player;
        private Dictionary<GameObject, Shape> gameObjectDictionary = new Dictionary<GameObject, Shape>();
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
            CreateEnemyShip();
        }

        private void InitializeTimers()
        {
            mainTimer = new DispatcherTimer(DispatcherPriority.Render);
            mainTimer.Tick += new EventHandler(MainTimer_Tick);
            mainTimer.Interval = TimeSpan.FromSeconds(0.01);
            mainTimer.Start();

            hyperDriveTimer = new DispatcherTimer();
            hyperDriveTimer.Tick += new EventHandler(ActivateHyperDrive_Tick);
            hyperDriveTimer.Interval = TimeSpan.FromSeconds(1);
            hyperDriveTimer.Start();

            gunLoadedTimer = new DispatcherTimer();
            gunLoadedTimer.Tick += new EventHandler(LoadGun_Tick);
            gunLoadedTimer.Interval = TimeSpan.FromSeconds(0.15);
            gunLoadedTimer.Start();

            enemySpawnTimer = new DispatcherTimer();
            enemySpawnTimer.Tick += new EventHandler(EnemySpawn_Tick);
            enemySpawnTimer.Interval = TimeSpan.FromSeconds(20);
            enemySpawnTimer.Start();
        }
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            ManageVelocity(); // increase or decrease the ship velocity through the time
            AccelerateShip();
            MoveAsteroids();
            MoveEnemyShips();

            CreateNoEdgeScreen();
            Shoot();
        }

        private bool HyperDriveActive { get; set; }
        private void ActivateHyperDrive_Tick(object sender, EventArgs e)
        {
            HyperDriveActive = true;
        }
        private bool GunLoaded { get; set; }
        private void LoadGun_Tick(object sender, EventArgs e)
        {
            GunLoaded = true;
        }

        private void EnemySpawn_Tick(object sender, EventArgs e)
        {
            CreateEnemyShip();
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
            gameObjectDictionary.Add(player, playerPolygon);

            playerPolygon.Fill = CreateNewColorBrush(138, 148, 255);
            playerPolygon.Stroke = CreateNewColorBrush(70, 69, 80);
            playerPolygon.StrokeThickness = 1;
        }

        private int asteroidCount = 4;
        private void CreateAsteroids()
        {
            for (int i = 0; i < asteroidCount; i++)
            {
                bool hasCollision;
                double rndMovementDir = random.NextDouble() * 360;
                Asteroid asteroid = new Asteroid(300, rndMovementDir);
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
                    Fill = CreateNewColorBrush(191,165,164),
                    Stroke = CreateNewColorBrush(70, 69, 80),
                    StrokeThickness = 1,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                BackgroundCanvas.Children.Add(el);
                gameObjectDictionary.Add(asteroid, el);
            }
            asteroidCount++;
        }

        private void MoveAsteroids()
        {
            if (gameObjectDictionary.Count > 0)
            {
                double movementStep = 0.75;
                foreach (var item in gameObjectDictionary)
                {
                    if (item.Key is Asteroid asteroid)
                    {
                        // The substraction by the (asteroid.Size/2) is used so the circle is drawn from its center 
                        Canvas.SetLeft(item.Value, asteroid.Position.X - asteroid.Size / 2);
                        Canvas.SetTop(item.Value, asteroid.Position.Y - asteroid.Size / 2);

                        asteroid.Position = MathClass.MovePointByGivenDistanceAndAngle(asteroid.Position, movementStep, asteroid.MotionDirection);
                    }
                }
            }
        }

        private void CreateEnemyShip()
        {
            bool hasCollision;
            double rndMovementDir = random.NextDouble() * 360;
            EnemyShip enemy = new EnemyShip(50, rndMovementDir);
            gameObjects.Add(enemy);
            do
            {
                Point position = GenerateObjectPosition(enemy.Size);
                // will choose side (based on enemy movement direction) from which the enemy will occur
                if(enemy.MotionDirection>315|| enemy.MotionDirection <=45)
                    position.Y = screenHeight + enemy.Size/2;
                else if (enemy.MotionDirection > 45 || enemy.MotionDirection <= 135)
                    position.X = 0 - enemy.Size/2;
                else if (enemy.MotionDirection > 135 || enemy.MotionDirection <= 225)
                    position.Y = 0 - enemy.Size/2;
                else if (enemy.MotionDirection > 225 || enemy.MotionDirection <= 315)
                    position.X = screenWidth + enemy.Size / 2;

                enemy.Position = position;

                hasCollision = FindCollisionWithOtherObjects(enemy);

            } while (hasCollision);

            Rectangle rec = new Rectangle
            {
                Width = enemy.Size,
                Height = enemy.Size,
                Fill = CreateNewColorBrush(253, 112, 118),
                Stroke = CreateNewColorBrush(70, 69, 80),
                StrokeThickness = 1,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            BackgroundCanvas.Children.Add(rec);
            gameObjectDictionary.Add(enemy, rec);
        }

        private void MoveEnemyShips()
        {
            if (gameObjectDictionary.Count > 0)
            {
                double movementStep = 0.75;
                foreach (var item in gameObjectDictionary)
                {
                    if (item.Key is EnemyShip enemy)
                    {
                        // The substraction by the (asteroid.Size/2) is used so the circle is drawn from its center 
                        Canvas.SetLeft(item.Value, enemy.Position.X - enemy.Size / 2);
                        Canvas.SetTop(item.Value, enemy.Position.Y - enemy.Size / 2);

                        enemy.Position = MathClass.MovePointByGivenDistanceAndAngle(enemy.Position, movementStep, enemy.MotionDirection);
                    }
                }
            }
        }

        private void CreateNoEdgeScreen()
        {
            double minScreenW, maxScreenW, minScreenH, maxScreenH;
            foreach (var item in gameObjectDictionary)
            {
                GameObject gameObject = item.Key;
                if(gameObject is PlayerShip || gameObject is Shot)
                {
                    minScreenW = -screenWidth / 2 - gameObject.Size / 2;
                    maxScreenW = screenWidth / 2 + gameObject.Size / 2;
                    minScreenH = -screenHeight / 2 - gameObject.Size / 2;
                    maxScreenH = screenHeight / 2 + gameObject.Size / 2;
                }
                else
                {
                    minScreenW = 0 - gameObject.Size;
                    maxScreenW = screenWidth + gameObject.Size;
                    minScreenH = 0 - gameObject.Size;
                    maxScreenH = screenHeight + gameObject.Size;
                }

                // Check a collision with a window edge
                if (gameObject.Position.X > maxScreenW || gameObject.Position.X < minScreenW
                    || gameObject.Position.Y > maxScreenH || gameObject.Position.Y < minScreenH)
                {
                    if (gameObject.Position.X > maxScreenW)
                    {
                        gameObject.Position = new Point(minScreenW, gameObject.Position.Y);
                    }
                    else if (gameObject.Position.X < minScreenW)
                    {
                        gameObject.Position = new Point(maxScreenW, gameObject.Position.Y);
                    }
                    else if (gameObject.Position.Y > maxScreenH)
                    {
                        gameObject.Position = new Point(gameObject.Position.X, minScreenH);
                    }
                    else if (gameObject.Position.Y < minScreenH)
                    {
                        gameObject.Position = new Point(gameObject.Position.X, maxScreenH);
                    }
                    Canvas.SetLeft(item.Value, gameObject.Position.X);
                    Canvas.SetTop(item.Value, gameObject.Position.Y);
                }
            }
        }

        #region ship controlling methods
        private void PrepareShot()
        {
            if (GunLoaded)
            {
                GunLoaded = false;
                double maximumDistance = screenWidth / 3;
                // Get the shooting starting point
                Point shotStart = MathClass.MovePointByGivenDistanceAndAngle(new Point(player.Position.X, player.Position.Y), 30, polygonRotation.Angle);
                // Calculate the position of the shot vanishing spot
                Point shotEnd = MathClass.MovePointByGivenDistanceAndAngle(shotStart, maximumDistance, polygonRotation.Angle);
                // Create shot with target set in front of the ship nose
                Shot shot = new Shot(shotStart, shotEnd, 5, maximumDistance);

                Ellipse el = new Ellipse
                {
                    Height = shot.Size,
                    Width = shot.Size,
                    Fill = CreateNewColorBrush(249, 248, 113),
                };

                gameObjectDictionary.Add(shot, el);
                BackgroundCanvas.Children.Add(el);
            }
        }
        private void Shoot()
        {
            if (gameObjectDictionary.Count > 0)
            {
                KeyValuePair<GameObject, Shape> item;
                for (int i = 0; i < gameObjectDictionary.Count; i++)
                {
                    item = gameObjectDictionary.ElementAt(i);
                    if (item.Key is Shot shot)
                    {
                        shot.Position = MathClass.MovePointTowards(shot.Position, shot.Target, 8.0);
                        Canvas.SetLeft(item.Value, shot.Position.X + screenWidth / 2.0 - shot.Size / 2.0);
                        Canvas.SetTop(item.Value, -shot.Position.Y + screenHeight / 2.0 + shot.Size / 2.0);
                        shot.TraveledDistance += 8;

                        if (shot.TraveledDistance >= shot.MaximumDistance)
                        {
                            BackgroundCanvas.Children.Remove(item.Value);
                            gameObjectDictionary.Remove(item.Key);
                        }
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
        /// <summary>
        /// This method will basically make the player teleport to another location.
        /// </summary>
        private void TravelThroughHyperspace()
        {
            if (HyperDriveActive)
            {
                HyperDriveActive = false;
                Point pos = GenerateObjectPosition(player.Size);
                player.Position = new Point(pos.X - screenWidth / 2, pos.Y - screenHeight / 2); //position relative to the polygon
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
            {
                PrepareShot();
            }
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
        private SolidColorBrush CreateNewColorBrush(byte r, byte g, byte b)
        {
            SolidColorBrush colorBrush = new SolidColorBrush
            {
                Color = Color.FromRgb(r, g, b)
            };
            return colorBrush;
        }

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
            double maxWidth = screenWidth - size / 2.0 - 20;
            double minHeight = 0 + size / 2.0;
            double maxHeight = screenHeight - size / 2.0 - 20;

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
                    dist = MathClass.GetDistance(gameObject.Position.X, item.Position.X - screenWidth / 2,
                        gameObject.Position.Y, item.Position.Y - screenHeight / 2);
                else
                    dist = MathClass.GetDistance(gameObject.Position.X, item.Position.X, gameObject.Position.Y, item.Position.Y);
                double radSum = gameObject.Size / 2.0 + item.Size / 2.0 + 10;
                if (dist < radSum)
                    return true;
            }
            return false;
        }
        #endregion
    }
}
