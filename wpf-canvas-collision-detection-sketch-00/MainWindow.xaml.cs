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

namespace wpf_canvas_collision_detection_sketch_00
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public object BaseStartingEllipse { get; private set; }
        public static double delta = 10;

        public MainWindow()
        {
            InitializeComponent();
            // < !--< Ellipse Name = "BaseStartingEllipse" Width = "100" Height = "100" Stroke = "Black" StrokeThickness = "5" TouchDown = "Ellipse_TouchDown" MouseDown = "BaseStartingEllipse_MouseDown" Fill = "Aquamarine" MouseEnter = "BaseStartingEllipse_MouseEnter" >
            Ellipse e = new Ellipse { Name = "BaseStartingEllipse",
                Width = 100, Height = 100, Stroke = Brushes.Black, StrokeThickness = 4,
                
            };
            mainCanvas.Children.Add(e);
            Canvas.SetTop(e, 50);
            Canvas.SetLeft(e, 50);
            e.KeyDown += BaseStartingEllipse_KeyDown;
            BaseStartingEllipse = e;
        }

        // TODO: see http://mark-dot-net.blogspot.com/2012/11/how-to-drag-shapes-on-canvas-in-wpf.html
        private void Ellipse_TouchDown(object sender, TouchEventArgs e)
        {
            var a = 0;
            var b = 1;
        }

        private void BaseStartingEllipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var a = 0;
            var b = 1;
        }

        private void BaseStartingEllipse_MouseEnter(object sender, MouseEventArgs e)
        {
            var a = 0;
            var b = 1;
        }


        private void MoveObject(Object o, string direction)
        {
            Ellipse e = (Ellipse)o;
            double pos = 0;
            double top = 0;
            double left = 0;
            Point p;
            switch (direction)
            {
                case "n":
                    pos = Canvas.GetTop(e);
                    Canvas.SetTop(e, pos - delta);
                    break;

                case "ne":
                    top = Canvas.GetTop(e);
                    left = Canvas.GetLeft(e);
                    Canvas.SetTop(e, top - delta);
                    Canvas.SetLeft(e, left + delta);
                    break;

                case "e":
                    pos = Canvas.GetLeft(e);
                    Canvas.SetLeft(e, pos + delta);
                    break;

                case "se":
                    top = Canvas.GetTop(e);
                    left = Canvas.GetLeft(e);
                    Canvas.SetTop(e, top + delta);
                    Canvas.SetLeft(e, left + delta);
                    break;

                case "s":
                    pos = Canvas.GetTop(e);
                    Canvas.SetTop(e, pos + delta);
                    break;

                case "sw":
                    top = Canvas.GetTop(e);
                    left = Canvas.GetLeft(e);
                    Canvas.SetTop(e, top + delta);
                    Canvas.SetLeft(e, left - delta);
                    break;

                case "w":
                    pos = Canvas.GetLeft(e);
                    Canvas.SetLeft(e, pos - delta);
                    break;

                case "nw":
                    top = Canvas.GetTop(e);
                    left = Canvas.GetLeft(e);
                    Canvas.SetTop(e, top - delta);
                    Canvas.SetLeft(e, left - delta);
                    break;
            }
            //CombinedGeometry g = new CombinedGeometry(e, StationaryEllipse);
            // EllipseGeometry eg1 = new EllipseGeometry(e);
            // EllipseGeometry eg2 = new EllipseGeometry(StationaryEllipse);
            // if (e.IntersectsWith)
            Rect r1 = new Rect(Canvas.GetLeft(e), Canvas.GetTop(e), e.Width, e.Height);
            Rect r2 = new Rect(Canvas.GetLeft(StationaryEllipse), Canvas.GetTop(StationaryEllipse), StationaryEllipse.Width, StationaryEllipse.Height);
            EllipseGeometry eg1 = new EllipseGeometry(r1);
            EllipseGeometry eg2 = new EllipseGeometry(r2);
            CombinedGeometry g = new CombinedGeometry(eg1, eg2);
            g.GeometryCombineMode = GeometryCombineMode.Intersect;
            if (double.IsInfinity(g.Bounds.Bottom) ||
                    double.IsInfinity(g.Bounds.Left) ||
                    double.IsInfinity(g.Bounds.Right) ||
                    double.IsInfinity(g.Bounds.Top))
                StationaryEllipse.Fill = Brushes.Red;
            else
                StationaryEllipse.Fill = Brushes.Aquamarine;

            var a = 2;
        }

        private void BaseStartingEllipse_KeyDown(object sender, KeyEventArgs e)
        {
            double pos;
            //var bottom;
            //var left;
            //var right;
            switch (e.Key)
            {
                case Key.Up:
                    if (Keyboard.IsKeyDown(Key.Left))
                        MoveObject(BaseStartingEllipse, "nw");
                    else if (Keyboard.IsKeyDown(Key.Right))
                        MoveObject(BaseStartingEllipse, "ne");
                    else
                        MoveObject(BaseStartingEllipse, "n");
                    break;

                case Key.Down:
                    if (Keyboard.IsKeyDown(Key.Left))
                        MoveObject(BaseStartingEllipse, "sw");
                    else if (Keyboard.IsKeyDown(Key.Right))
                        MoveObject(BaseStartingEllipse, "se");
                    else
                        MoveObject(BaseStartingEllipse, "s");
                    break;

                case Key.Right:
                    if (Keyboard.IsKeyDown(Key.Up))
                        MoveObject(BaseStartingEllipse, "ne");
                    else if (Keyboard.IsKeyDown(Key.Down))
                        MoveObject(BaseStartingEllipse, "se");
                    else
                        MoveObject(BaseStartingEllipse, "e");
                    break;

                case Key.Left:
                    if (Keyboard.IsKeyDown(Key.Up))
                        MoveObject(BaseStartingEllipse, "nw");
                    else if (Keyboard.IsKeyDown(Key.Down))
                        MoveObject(BaseStartingEllipse, "sw");
                    else
                        MoveObject(BaseStartingEllipse, "w");
                    break;
            }
        }
    }
}
