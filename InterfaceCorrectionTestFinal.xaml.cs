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
using System.Windows.Shapes;

namespace AlGeo
{
    public partial class InterfaceCorrectionTestFinal : Window
    {
        string path;
        public InterfaceCorrectionTestFinal()
        {
            InitializeComponent();
        }
        private void GoToExoMenu_Click(object sender, RoutedEventArgs e)
        {


            ExoFrame.Content = null;
            GoToExoMenu.Visibility = Visibility.Hidden;
            corrigemMenuGrid.Visibility = Visibility.Visible;
            CommentTB.Visibility = Visibility.Hidden;

        }
        private void CorrectionExo1_Click(object sender, RoutedEventArgs e)
        {
            CommentTB.Inlines.Clear();
            CommentTB.Inlines.Add(new Run(" تصحيح التمرين 1 : اجب بصحيح ام خطا."));
            CommentTB.Visibility = Visibility.Visible;
            corrigemMenuGrid.Visibility = Visibility.Hidden;
            GoToExoMenu.Visibility = Visibility.Visible;
            path = "TestFinal/Exo1/CorrigeExerciceVraiOuFaux.xaml";
            ExoFrame.NavigationService.Navigate(new Uri(path, UriKind.Relative));


        }
        private void CorrectionExo2_Click(object sender, RoutedEventArgs e)
        {
            CommentTB.Inlines.Clear();
            CommentTB.Inlines.Add(new Run(" تصحيح التمرين 2"));
            CommentTB.Visibility = Visibility.Visible;
            corrigemMenuGrid.Visibility = Visibility.Hidden;
            GoToExoMenu.Visibility = Visibility.Visible;
            path = "TestFinal/Exo2/CorrigerExercice2.xaml";
            ExoFrame.NavigationService.Navigate(new Uri(path, UriKind.Relative));


        }
        private void CorrectionExo3_Click(object sender, RoutedEventArgs e)
        {

        }
        private void CorrectionExo4_Click(object sender, RoutedEventArgs e)
        {
            CommentTB.Inlines.Clear();
            CommentTB.Inlines.Add(new Run(" تصحيح التمرين 4 : الربط بين الكلمات."));
            CommentTB.Visibility = Visibility.Visible;
            corrigemMenuGrid.Visibility = Visibility.Hidden;
            GoToExoMenu.Visibility = Visibility.Visible;
            path = "TestFinal/Exo4/CorrigerRelier.xaml";
            ExoFrame.NavigationService.Navigate(new Uri(path, UriKind.Relative));
        }
        private void CorrectionExo5_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

