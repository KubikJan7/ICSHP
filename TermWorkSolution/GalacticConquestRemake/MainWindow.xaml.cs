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
using GalacticConquestRemake.Common;
namespace TermWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GeneratePlanets();
        }

        public void GeneratePlanets()
        {
            BackgroundCanvas.Children.Clear();

            double winHeight = BackgroundCanvas.Height;
            double winWidth = BackgroundCanvas.Width;
            Random rand = new Random();
            int planetCount = rand.Next(8, 13);

            for (int i = 0; i < planetCount; i++)
            {
                Planet p = new Planet(rand.Next(16, 49), "Red");
                p.Position = new Position(rand.Next(0 + (p.Size / 2), (int)winWidth - (p.Size / 2)+1), rand.Next(0 + (p.Size / 2), (int)winHeight - (p.Size / 2)+1));

                Ellipse el = new Ellipse
                {
                    Width = p.Size,
                    Height = p.Size,
                    Fill = (SolidColorBrush)new BrushConverter().ConvertFromString(p.OwnerColor)
                };
                Canvas.SetLeft(el, (p.Position.X - (p.Size / 2)));
                Canvas.SetTop(el, (p.Position.Y - (p.Size / 2)));

                BackgroundCanvas.Children.Add(el);
            }
        }
    }
}
