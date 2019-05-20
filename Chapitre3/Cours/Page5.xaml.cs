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

namespace AlGeo.Chapitre3.Cours
{
    /// <summary>
    /// Logique d'interaction pour Page5.xaml
    /// </summary>
    public partial class Page5 : Page
    {
        /* constructeur */
        public Page5()
        {
            InitializeComponent();
        }


        
        /*******  Afficher a l'eleve ce qu'il a  faire  *******/
        private void HelpButton_MouseLeave(object sender, MouseEventArgs e)
        {
            InfoBulleGrid.Visibility = Visibility.Hidden;
        }

        private void HelpButton_MouseMove(object sender, MouseEventArgs e)
        {
            InfoBulleGrid.Visibility = Visibility.Visible;
        }
        /******************************************************/


        /***** selection du 1er element de la liste  *******/
        private void Item1_Selected(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);
            AinAminasGrid.Visibility = Visibility.Visible;
            HassiMassoudGrid.Visibility = Visibility.Visible;

            HassiRmelGrid.Visibility = Visibility.Hidden;
            AlgerGrid.Visibility = Visibility.Hidden;
            SkikdaGrid.Visibility = Visibility.Hidden;
            ArziouGrid.Visibility = Visibility.Hidden;
        }
        /******************************************************/


        /***** selection du 2eme element de la liste  *******/
        private void Item2_Selected(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);
            AinAminasGrid.Visibility = Visibility.Visible;
            HassiRmelGrid.Visibility = Visibility.Visible;

            AlgerGrid.Visibility = Visibility.Hidden;
            SkikdaGrid.Visibility = Visibility.Hidden;
            HassiMassoudGrid.Visibility = Visibility.Hidden;
            ArziouGrid.Visibility = Visibility.Hidden;
        }
        /******************************************************/


        /***** selection du 3eme element de la liste  *******/
        private void Item3_Selected(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);
            AinAminasGrid.Visibility = Visibility.Hidden;
            HassiRmelGrid.Visibility = Visibility.Hidden;

            AlgerGrid.Visibility = Visibility.Visible;
            SkikdaGrid.Visibility = Visibility.Visible;
            ArziouGrid.Visibility = Visibility.Visible;
            HassiMassoudGrid.Visibility = Visibility.Visible;
        }
        /******************************************************/


        /***** selection du 4eme element de la liste  *******/
        private void Item4_Selected(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);
            SkikdaGrid.Visibility = Visibility.Visible;
            ArziouGrid.Visibility = Visibility.Visible;

            HassiMassoudGrid.Visibility = Visibility.Hidden;
            HassiRmelGrid.Visibility = Visibility.Hidden;
            AlgerGrid.Visibility = Visibility.Hidden;
            AinAminasGrid.Visibility = Visibility.Hidden;
        }
        /******************************************************/


        /***** selection du 5eme element de la liste  *******/
        private void Item5_Selected(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);
            SkikdaGrid.Visibility = Visibility.Visible;
            ArziouGrid.Visibility = Visibility.Visible;

            HassiMassoudGrid.Visibility = Visibility.Hidden;
            HassiRmelGrid.Visibility = Visibility.Hidden;
            AlgerGrid.Visibility = Visibility.Hidden;
            AinAminasGrid.Visibility = Visibility.Hidden;
        }
        /******************************************************/

    }
}
