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
        public MainWindow()
        {
            InitializeComponent();
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

        private void BaseStartingEllipse_KeyDown(object sender, KeyEventArgs e)
        {
            double top;
            //var bottom;
            //var left;
            //var right;
            switch (e.Key)
            {
                case Key.Down:
                    top = Canvas.GetTop(BaseStartingEllipse);
                    if (Double.IsNaN(top))
                        Canvas.SetTop(BaseStartingEllipse, 50);
                    else
                        Canvas.SetTop(BaseStartingEllipse, top + 5);
                    break;
                case Key.Up:
                    //var bottom = Canvas.GetBottom(BaseStartingEllipse);
                    //if (Double.IsNaN(bottom))
                    //    Canvas.SetBottom(BaseStartingEllipse, 50);
                    //else
                    //    Canvas.SetBottom(BaseStartingEllipse, bottom - 5);
                    //break;
                    top = Canvas.GetTop(BaseStartingEllipse);
                    if (Double.IsNaN(top))
                        Canvas.SetTop(BaseStartingEllipse, 50);
                    else
                        Canvas.SetTop(BaseStartingEllipse, top - 5);
                    break;
                case Key.Right:
                    top = Canvas.GetLeft(BaseStartingEllipse);
                    if (Double.IsNaN(top))
                        Canvas.SetLeft(BaseStartingEllipse, 50);
                    else
                        Canvas.SetLeft(BaseStartingEllipse, top + 5);
                    break;
                case Key.Left:
                    top = Canvas.GetLeft(BaseStartingEllipse);
                    if (Double.IsNaN(top))
                        Canvas.SetLeft(BaseStartingEllipse, 50);
                    else
                        Canvas.SetLeft(BaseStartingEllipse, top - 5);
                    break;
            }
        }
    }
}
