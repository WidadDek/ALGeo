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

namespace AlGeo.Chapitre1.Cours
{
    /// <summary>        
    /// Logique d'interaction pour Page7.xaml
    /// </summary>
    public partial class Page7 : Page
    { 
        /* constucteur */
        public Page7()
        {
            InitializeComponent();
        }
              
       
        /* Click sur le bouton btnRiq */
        private void btnRiq_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Animations.AddSound(1); // son click 
            this.GridLabel.Visibility = Visibility.Visible;
            /* affichage */
            labelDefinition.Text = "الرق";
            this.paysage.Source = Animations.GetImage("../Images/rik.JPG");
        }
        /*****************************/


        /* Click sur le bouton  btnTadmait */
        private void btnTadmait_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Animations.AddSound(1); // son click 
            this.GridLabel.Visibility = Visibility.Visible;
            /* affichage */
            this.labelDefinition.Text = "هضبة تادميت";
            this.paysage.Source = Animations.GetImage("../Images/tadmait.jpg");
        }
        /*****************************/


        /* Click sur le bouton  btnIrq */
        private void btnIrq_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Animations.AddSound(1); // son click 
            this.GridLabel.Visibility = Visibility.Visible;
            /* affichage */
            this.labelDefinition.Text = " العرق الشرقي";
            this.paysage.Source = Animations.GetImage("../Images/irkcharki.jpg");
        }
        /*****************************/


        /* Click sur le bouton  btnHoggar */
        private void btnHoggar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Animations.AddSound(1); // son click 
            this.GridLabel.Visibility = Visibility.Visible;
            /* affichage */
            this.labelDefinition.Text = "جبال الهقار";
            this.paysage.Source = Animations.GetImage("../Images/tahat.jpg");
        }
        /*****************************/




        /*** afficher l'infoBulle d'aide qui montre a l'eleve ce qu'il faut faire */
        private void HelpButton_MouseMove(object sender, MouseEventArgs e)
        {
            InfoBulleGrid.Visibility = Visibility.Visible;
        }

        private void HelpButton_MouseLeave(object sender, MouseEventArgs e)
        {
            InfoBulleGrid.Visibility = Visibility.Hidden;
        }
        /**************************************************************************/


    }
}

