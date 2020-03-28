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

namespace AsteroidsRemake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Storyboard storyboard;
        public MainWindow()
        {
            InitializeComponent();
            DrawScene();
        }

        private void CreatePlayerShip()
        {
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

        private void AccelerateShip()
        {

        }

        private double goalRotation;
        private void RotateShip(string direction)
        {
            if (goalRotation == polygonRotation.Angle)
            {
                double cX, cY;
                Point a = playerPolygon.Points[0];
                Point b = playerPolygon.Points[1];
                Point c = playerPolygon.Points[2];
                (cX, cY) = MathLibrary.MathClass.FindCenterOfTriangle(a.X, b.X, c.X, a.Y, b.Y, c.Y);
                polygonRotation.CenterX = cX;
                polygonRotation.CenterY = cY;

                goalRotation = ((direction == "to left") ? polygonRotation.Angle - 360 : polygonRotation.Angle + 360);

                storyboard.Duration = new Duration(TimeSpan.FromSeconds(1));
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

        private void DrawScene()
        {
            storyboard = new Storyboard();
            CreatePlayerShip();
        }

        private void MainWindow1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.IsRepeat) //when a key is held down
            {
                storyboard.Resume(); //resume animation
                goalRotation = polygonRotation.Angle;
            }
            if (e.Key == Key.W || e.Key == Key.Up)
                AccelerateShip();
            else if (e.Key == Key.A || e.Key == Key.Left)
            {
                RotateShip("to left");
            }
            else if (e.Key == Key.D || e.Key == Key.Right)
                RotateShip("to right");
            else if (e.Key == Key.Space)
                Shoot();
        }

        private void MainWindow1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A || e.Key == Key.Left || e.Key == Key.D || e.Key == Key.Right)
                storyboard.Pause(); //pause rotating animation
        }
        #endregion
    }
}
