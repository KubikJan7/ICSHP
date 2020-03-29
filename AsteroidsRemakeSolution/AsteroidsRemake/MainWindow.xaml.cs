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
        private DispatcherTimer MainTimer = new DispatcherTimer();
        private Storyboard storyboard;
        private SpaceShip player;
        private bool IsAccelerating { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            InitializeTimers();
            DrawScene();
        }

        private void InitializeTimers()
        {
            MainTimer.Tick += new EventHandler(MainTimer_Tick);
            MainTimer.Interval = TimeSpan.FromMilliseconds(0.45);
            MainTimer.Start();
        }
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            if (IsAccelerating)
                AccelerateShip();
        }

        private void DrawScene()
        {
            storyboard = new Storyboard();
            CreatePlayerShip();
        }

        private void CreatePlayerShip()
        {
            player = new SpaceShip(new Point(0, 0));

            SolidColorBrush colorBrush = new SolidColorBrush
            {
                Color = Color.FromRgb(138, 148, 255)
            };

            playerPolygon.Fill = colorBrush;
        }

        #region ship controlling methods
        private void Shoot()
        {
            Ellipse el = new Ellipse
            {
                Height = 7,
                Width = 7,
                Fill = Brushes.Black,
            };

            BackgroundCanvas.Children.Add(el);
        }

        private double oldRotation;
        private void AccelerateShip()
        {
            Point shipCenter = player.Position;
            Point shipVertex = MathClass.MovePointByGivenDistanceAndAngle(shipCenter, 20, polygonRotation.Angle);
            player.Position = MathClass.MovePointTowards(shipCenter, shipVertex, -0.5);
            Canvas.SetLeft(playerPolygon, - player.Position.X);
            Canvas.SetTop(playerPolygon, player.Position.Y);

            oldRotation = polygonRotation.Angle;
        }

        private double goalRotation;
        private void RotateShip(string direction)
        {
            if (goalRotation == polygonRotation.Angle)
            {
                Point p = GetShipCenter();
                polygonRotation.CenterX = p.X;
                polygonRotation.CenterY = p.Y;

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
            if (!e.IsRepeat) //when a key is held down
            {
                if (e.Key == Key.A || e.Key == Key.Left || e.Key == Key.D || e.Key == Key.Right)
                {
                    storyboard.Resume(); //resume animation
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
                Shoot();
        }

        private void MainWindow1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A || e.Key == Key.Left || e.Key == Key.D || e.Key == Key.Right)
                storyboard.Pause(); //pause rotating animation
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
