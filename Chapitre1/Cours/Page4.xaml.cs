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
    /// Logique d'interaction pour Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
        /* constucteur */
        public Page4()
        {
            InitializeComponent();
        }



        /* Click sur le bouton btnMetidja */
        private void btnMetidja_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();  // son click 
            GridLabel.Visibility = Visibility.Visible;
            /* affichage */
            paysage.Source = Animations.GetImage("../Images/metidja.jpg");
            labelLocation.Visibility = Visibility.Visible;
            labelLocation.Text = " سهل متيجة ";
            descriptionBlock.Text = "سهل واسع ينحصر بين البحر و الأطلس البليدي طوله 100كم و عرضه 20كم يعتبر من اغنى سهول الجزائر";
        }
        /**********************************/


        /* Click sur le bouton btnAnnaba */
        private void btnAnnaba_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Media.SystemSounds.Beep.Play(); // son click 
            GridLabel.Visibility = Visibility.Visible;
            /* affichage */
            paysage.Source = Animations.GetImage("../Images/annaba3.jpg");
            labelLocation.Visibility = Visibility.Visible;
            labelLocation.Text = "سهل عنابة ";
            descriptionBlock.Text = " يقع بشرق البلاد،يمتد من عنابة إلى القالة تجري فيه الأودية و البحيرات مثل واد السيبوس تربته شديدة الخصوبة  ";
        }
        /**********************************/



        /* Click sur le bouton btnSidiBelAbbas */
        private void btnSidiBelAbbas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            GridLabel.Visibility = Visibility.Visible;
            /* affichage */
            paysage.Source = Animations.GetImage("../Images/sidiabdeli.jpg");
            labelLocation.Visibility = Visibility.Visible;
            labelLocation.Text = " سهل سيدي بلعباس ";
            descriptionBlock.Text = "يمتد بمسـاحة 2.102,85 كم بارتفـاع ما بين 400 و 800 م";
        }
        /**********************************/


        /* Click sur le bouton btnOran */
       private void btnOran_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            GridLabel.Visibility = Visibility.Visible;
            /* affichage */
            paysage.Source = Animations.GetImage("../Images/sebkhaOran.jpg");
            labelLocation.Visibility = Visibility.Visible;                                            
            labelLocation.Text = "سهل وهران";
            descriptionBlock.Text = "يمتد من الغزوات إلى الشلف تربته ملحية";
        }
        /**********************************/


        /* Click sur le bouton btnTlemcen */
        private void btnTlemcen_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            GridLabel.Visibility = Visibility.Visible;
            /* affichage */
            paysage.Source = Animations.GetImage("../Images/tlemcen.jpg");
            labelLocation.Visibility = Visibility.Visible;
            labelLocation.Text = "سهل تلمسان";
            descriptionBlock.Text = "يقع غرب البلاد و هو سهل داخلي ذو تربة خصبة";
        }
        /**********************************/
        


        /*** afficher l'infoBulle qui montrent a l'eleve ce qu'il faut faire */
        private void HelpButton_MouseMove(object sender, MouseEventArgs e)
        {
            InfoBulleGrid.Visibility = Visibility.Visible;
        }

        private void HelpButton_MouseLeave(object sender, MouseEventArgs e)
        {
            InfoBulleGrid.Visibility = Visibility.Hidden;
        }
        /**********************************************************************/
    }
}

