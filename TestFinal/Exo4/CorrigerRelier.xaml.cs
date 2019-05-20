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

namespace AlGeo.TestFinal.Exo4
{
    /// <summary>
    /// Interaction logic for CorrigerRelier.xaml
    /// </summary>
    public partial class CorrigerRelier : Page
    {
        Line line1 = new Line();
        Line line2 = new Line();
        Line line3 = new Line();
        Line line4 = new Line();
        public CorrigerRelier()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {//correction
            Animations.AddSound(1);
            canvaslines.Children.Remove(line1);
            canvaslines.Children.Remove(line2);
            canvaslines.Children.Remove(line3);
            canvaslines.Children.Remove(line4);
            line1.Y1 = Canvas.GetTop(l3) + 27;
            line1.Y2 = Canvas.GetTop(l2) + 27;
            line1.X1 = Canvas.GetLeft(l3) + 261;
            line1.X2 = Canvas.GetLeft(l2);
            line1.Stroke = System.Windows.Media.Brushes.Yellow;
            line1.StrokeThickness = 3;
            canvaslines.Children.Add(line1);

            line2.Y1 = Canvas.GetTop(l1) + 27;
            line2.Y2 = Canvas.GetTop(l6) + 27;
            line2.X1 = Canvas.GetLeft(l1) + 261;
            line2.X2 = Canvas.GetLeft(l6);
            line2.Stroke = System.Windows.Media.Brushes.Yellow;
            line2.StrokeThickness = 3;
            canvaslines.Children.Add(line2);

            line3.Y1 = Canvas.GetTop(l8) + 27;
            line3.Y2 = Canvas.GetTop(l5) + 27;
            line3.X1 = Canvas.GetLeft(l8) + 261;
            line3.X2 = Canvas.GetLeft(l5);
            line3.Stroke = System.Windows.Media.Brushes.Yellow;
            line3.StrokeThickness = 3;
            canvaslines.Children.Add(line3);

            line4.Y1 = Canvas.GetTop(l7) + 27;
            line4.Y2 = Canvas.GetTop(l4) + 27;
            line4.X1 = Canvas.GetLeft(l7) + 261;
            line4.X2 = Canvas.GetLeft(l4);
            line4.Stroke = System.Windows.Media.Brushes.Yellow;
            line4.StrokeThickness = 3;
            canvaslines.Children.Add(line4);
        }
    }
}
