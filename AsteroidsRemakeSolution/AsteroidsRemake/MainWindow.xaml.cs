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
            CreateScene();
        }

        private void CreateScene()
        {

            SolidColorBrush blackBrush = new SolidColorBrush();
            blackBrush.Color = Color.FromRgb(138,148,255);

            Polygon blackPolygon = new Polygon();
            blackPolygon.Stroke = blackBrush;
            blackPolygon.Fill = blackBrush;
            blackPolygon.StrokeThickness = 4;

            Point point1 = new Point(MainWindow1.Width/2, MainWindow1.Height/2);
            Point point2 = new Point(MainWindow1.Width / 2-20, MainWindow1.Height / 2+40);
            Point point3 = new Point(MainWindow1.Width / 2+20, MainWindow1.Height / 2+40);
            PointCollection polygonPoints = new PointCollection();
            polygonPoints.Add(point1);
            polygonPoints.Add(point2);
            polygonPoints.Add(point3);

            blackPolygon.Points = polygonPoints;

            BackgroundCanvas.Children.Add(blackPolygon);
        }
    }
}
