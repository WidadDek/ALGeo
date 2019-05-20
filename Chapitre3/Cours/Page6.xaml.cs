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
    /// Logique d'interaction pour Page6.xaml
    /// </summary>
    public partial class Page6 : Page
    {
        /* constructeur */
        public Page6()
        {
            InitializeComponent();
        }




        /* Click sur le bouton Zakar */
        private void Zakar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            /* affichage de la description */
            Animations.AddSound(1);
            DescriptionGrid.Visibility = Visibility.Visible;
            Location.Content = "زكار";

            Item1.Content = "الزنك";
            IconItem1.Source = Animations.GetImage(@"..\Images\zink.png");

            Item2.Visibility = Visibility.Visible;
            IconItem2.Visibility = Visibility.Visible;
            Item2.Content = "الرصاص";
            IconItem2.Source = Animations.GetImage(@"..\Images\rassass.png");

            Item3.Visibility = Visibility.Hidden;
            IconItem3.Visibility = Visibility.Hidden;
        }
        /*******************************************************************/



        /* Click sur le bouton Ouanza */        
        private void Ouanza_MouseDown(object sender, MouseButtonEventArgs e)
        {
            /* affichage de la description */
            Animations.AddSound(1);
            DescriptionGrid.Visibility = Visibility.Visible;
            Location.Content = "الونزة";

            Item1.Content = "الحديد";
            IconItem1.Source = Animations.GetImage(@"..\Images\hadid.png");

            Item2.Visibility = Visibility.Visible;
            IconItem2.Visibility = Visibility.Visible;
            Item2.Content = "الفوسفات";
            IconItem2.Source = Animations.GetImage(@"..\Images\fusfate.png");

            Item3.Visibility = Visibility.Visible;
            IconItem3.Visibility = Visibility.Visible;
            Item3.Content = "الرصاص";
            IconItem3.Source = Animations.GetImage(@"..\Images\rassass.png");
        }
        /*******************************************************************/



        /* Click sur le bouton BniSaf */
        private void BniSaf_MouseDown(object sender, MouseButtonEventArgs e)
        {
            /* affichage de la description */
            Animations.AddSound(1);
            DescriptionGrid.Visibility = Visibility.Visible;
            Location.Content = "بني صاف";

            Item1.Content = "الحديد";
            IconItem1.Source = Animations.GetImage(@"..\Images\hadid.png");

            Item2.Visibility = Visibility.Hidden;
            IconItem2.Visibility = Visibility.Hidden;

            Item3.Visibility = Visibility.Hidden;
            IconItem3.Visibility = Visibility.Hidden;
        }
        /*******************************************************************/


        /* Click sur le bouton Abed */
        private void Abed_MouseDown(object sender, MouseButtonEventArgs e)
        {
            /* affichage de la description */
            Animations.AddSound(1);
            DescriptionGrid.Visibility = Visibility.Visible;
            Location.Content = "العابد";

            Item1.Content = "الزنك";
            IconItem1.Source = Animations.GetImage(@"..\Images\zink.png");

            Item2.Visibility = Visibility.Visible;
            IconItem2.Visibility = Visibility.Visible;
            Item2.Content = "الرصاص";
            IconItem2.Source = Animations.GetImage(@"..\Images\rassass.png");

            Item3.Visibility = Visibility.Hidden;
            IconItem3.Visibility = Visibility.Hidden;
        }
        /*******************************************************************/


        /* Click sur le bouton Knadsa */
        private void Knadsa_MouseDown(object sender, MouseButtonEventArgs e)
        {
            /* affichage de la description */
            Animations.AddSound(1);
            DescriptionGrid.Visibility = Visibility.Visible;
            Location.Content = "قنادسة";

            Item1.Content = "الفحم";
            IconItem1.Source = Animations.GetImage(@"..\Images\fa7m.png");

            Item2.Visibility = Visibility.Visible;
            IconItem2.Visibility = Visibility.Visible;
            Item2.Content = "المنغنيز";
            IconItem2.Source = Animations.GetImage(@"..\Images\manghaniz.png");

            Item3.Visibility = Visibility.Visible;
            IconItem3.Visibility = Visibility.Visible;
            Item3.Content = "اليورانيوم";
            IconItem3.Source = Animations.GetImage(@"..\Images\Uranium.png");
        }
        /*******************************************************************/


        /* Click sur le bouton Djbilat */
        private void Djbilat_MouseDown(object sender, MouseButtonEventArgs e)
        {
            /* affichage de la description */
            Animations.AddSound(1);
            DescriptionGrid.Visibility = Visibility.Visible;
            Location.Content = "جبيلات";

            Item1.Content = "الحديد";
            IconItem1.Source = Animations.GetImage(@"..\Images\hadid.png");

            Item2.Visibility = Visibility.Hidden;
            IconItem2.Visibility = Visibility.Hidden;

            Item3.Visibility = Visibility.Hidden;
            IconItem3.Visibility = Visibility.Hidden;
        }
        /*******************************************************************/

        /* Click sur le bouton Hoggar */
        private void Hoggar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            /* affichage de la description */
            Animations.AddSound(1);
            DescriptionGrid.Visibility = Visibility.Visible;
            Location.Content = "الهقار";

            Item1.Content = "الذهب";
            IconItem1.Source = Animations.GetImage(@"..\Images\or.png");

            Item2.Visibility = Visibility.Hidden;
            IconItem2.Visibility = Visibility.Hidden;

            Item3.Visibility = Visibility.Hidden;
            IconItem3.Visibility = Visibility.Hidden;
        }
        /*******************************************************************/



        /*** afficher l'infoBulle qui montrent a l'eleve ce qu'il faut faire */
        private void HelpButton_MouseLeave(object sender, MouseEventArgs e)
        {
            InfoBulleGrid.Visibility = Visibility.Hidden;

        }

        private void HelpButton_MouseMove(object sender, MouseEventArgs e)
        {
            InfoBulleGrid.Visibility = Visibility.Visible;
        }
        /*********************************************************************/
    }
}

