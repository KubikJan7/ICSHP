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

namespace AsteroidsRemake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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

            //Polygon blackPolygon = new Polygon();
            //blackPolygon.Stroke = colorBrush;
            //blackPolygon.Fill = colorBrush;
            //blackPolygon.StrokeThickness = 4;

            //Point point1 = new Point(MainWindow1.Width / 2, MainWindow1.Height / 2);
            //Point point2 = new Point(MainWindow1.Width / 2 - 15, MainWindow1.Height / 2 + 40);
            //Point point3 = new Point(MainWindow1.Width / 2 + 15, MainWindow1.Height / 2 + 40);
            //PointCollection polygonPoints = new PointCollection();
            //polygonPoints.Add(point1);
            //polygonPoints.Add(point2);
            //polygonPoints.Add(point3);

            //blackPolygon.Points = polygonPoints;

            //BackgroundCanvas.Children.Add(blackPolygon);
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

        private void RotateShip(string direction)
        {
            double cX, cY;
            Point a = playerPolygon.Points[0];
            Point b = playerPolygon.Points[1];
            Point c = playerPolygon.Points[2];
            (cX,cY) = MathLibrary.MathClass.FindCenterOfTriangle(a.X, b.X, c.X, a.Y, b.Y, c.Y);
            polygonRotation.CenterX = cX;
            polygonRotation.CenterY = cY;
            if (direction == "to left")
            {
                polygonRotation.Angle -= 5;
            }
            else
            {
                polygonRotation.Angle += 5;
            }
        }

        private void DrawScene()
        {
            CreatePlayerShip();
        }

        private void MainWindow1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                Shoot();
            
            if (e.Key == Key.A || e.Key == Key.Left)
                RotateShip("to left");
            else if (e.Key == Key.D || e.Key == Key.Right)
                RotateShip("to right");
        }

        private void MainWindow1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W || e.Key == Key.Up)
                AccelerateShip();
        }

            #endregion
        }
}
