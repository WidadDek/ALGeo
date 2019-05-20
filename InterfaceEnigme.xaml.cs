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
    /// <summary>
    /// Logique d'interaction pour InterfaceEnigme.xaml
    /// </summary>
    public partial class InterfaceEnigme : Window
    {
        public InterfaceEnigme()
        {
            InitializeComponent();
        }

        private void Enigme_Click(object sender, RoutedEventArgs e)
        {
         
            String path = "TestFinal/Exo5/EnigmesExercice.xaml";
            Uri currentExo = new Uri(path, UriKind.Relative);
            ExoFrame.NavigationService.Navigate(currentExo);
            Enigme.Visibility = Visibility.Hidden;
            Correction.Visibility = Visibility.Hidden;

        }



        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ExoFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void Correction_Click(object sender, RoutedEventArgs e)
        {
            String path = "TestFinal/Exo5/EnigmesCorrection.xaml";
            Uri currentExo = new Uri(path, UriKind.Relative);
            ExoFrame.NavigationService.Navigate(currentExo);
            Enigme.Visibility = Visibility.Hidden;
            Correction.Visibility = Visibility.Hidden;


        }
    }
}
