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
        private List<GameObject> gameObjects = new List<GameObject>();
        public MainWindow()
        {
            InitializeComponent();
            GeneratePlanets();
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
                Planet p = new Planet();
                bool comparingFinished = false;

                string color = "Red";
                if (i >= 3 && i < 6)
                    color = "Blue";
                else if (i >= 6)
                    color = "Gray";

                while (comparingFinished == false)
                {
                    p = new Planet(rand.Next(16, 49), color);
                    p.Position = new Position(rand.Next((int)(0 + (p.Size / 2 * Planet.dodgeRadius)), (int)(winWidth - (p.Size / 2 * Planet.dodgeRadius))), rand.Next((int)(0 + (p.Size / 2 * Planet.dodgeRadius)), (int)(winHeight - (p.Size / 2 * Planet.dodgeRadius))));
                    bool intersect = false;

                    for (int j = 0; j < gameObjects.Count; j++)
                    {
                        if (gameObjects.Count == 0 || gameObjects[j].GetType() != typeof(Planet))
                            continue;
                        // Distance between centers C1 and C2 -> C1C2 = sqrt((x1 - x2)2 + (y1 - y2)2).
                        double dist = GetDistance(p.Position.X, gameObjects[j].Position.X, p.Position.Y, gameObjects[j].Position.Y);
                        double radSum = ((p.Size / 2 * Planet.dodgeRadius) + (gameObjects[j].Size / 2 * Planet.dodgeRadius)) *
                                        ((p.Size / 2 * Planet.dodgeRadius) + (gameObjects[j].Size / 2 * Planet.dodgeRadius));

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
            foreach (GameObject item in gameObjects)
            {
                if (item.GetType() == typeof(Planet))
                {
                    Planet p = (Planet)item;
                    Ellipse el = new Ellipse
                    {
                        Width = p.Size,
                        Height = p.Size,
                        Fill = (SolidColorBrush)new BrushConverter().ConvertFromString(p.OwnerColor)
                    };
                    Canvas.SetLeft(el, (p.Position.X - (p.Size / 2)));
                    Canvas.SetTop(el, (p.Position.Y - (p.Size / 2)));
                    el.MouseEnter += OnPlanetMouseEnter;
                    el.MouseLeave += OnPlanetMouseLeave;
                    TextBlock t = new TextBlock
                    {
                        Text = p.UnitCount.ToString(),
                        Foreground = Brushes.Yellow,
                        FontSize = 3,
                        Width = 4,
                        Height = 4,
                        TextAlignment = TextAlignment.Center,
                    };
                    Canvas.SetLeft(t, (p.Position.X - (t.Width / 2)));
                    Canvas.SetTop(t, (p.Position.Y - (t.Height / 2)));
                    BackgroundCanvas.Children.Add(el);
                    BackgroundCanvas.Children.Add(t);
                }
            }
        }

        private void OnPlanetMouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Ellipse).Fill = Brushes.Orange;
        }
        private void OnPlanetMouseLeave(object sender, MouseEventArgs e)
        {
            Ellipse el = (sender as Ellipse);
            System.Windows.Point p = e.GetPosition(this);
            // Check if mouse cursor is not on TextBlock
            if (GetDistance(Canvas.GetLeft(el) + el.Width / 2, p.X, Canvas.GetTop(el) + el.Height / 2, p.Y) > (el.Width/2 * el.Width/2))
                foreach (var item in gameObjects)
                {
                    if (item.GetType() != typeof(SpaceShip))
                        if (item.Position.X == (Canvas.GetLeft(el) + item.Size / 2) && item.Position.Y == (Canvas.GetTop(el) + item.Size / 2))
                        {
                            el.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString(item.OwnerColor);
                        }
                }

        }
        private double GetDistance(double x1, double x2, double y1, double y2)
        {
            return (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2);
        }
    }
}