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
    /// Logique d'interaction pour Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        /* constructeur */
        public Page2()
        {
            InitializeComponent();
        }

        
               
        private List<string> colorBrushesBackground = new List<string>() { "#FF1ABC9C", "#FF1ABC9C", "#FF455799" };


        /* Click sur la surface/vecteur TlemcenPath */
        private void TlemcenPath_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            DescriptionStack.Visibility = Visibility.Visible;
            Location.Visibility = Visibility.Visible;
            /* affichage de la wilaya selectionnée */
            Location.Text = "ولاية تلمسان";
            descriptionBlock.Text = "الرمز\nالمساحة\nعدد السكان\nطول الساحل\n";
            this.TlemcenPath.Fill = System.Windows.Media.Brushes.Red;

            this.AintimouchentPath.Fill = Brushes.Orange;
            this.OranPath.Fill = Brushes.Orange;
            this.MostaganemPath.Fill = Brushes.Orange;
            this.ChlefPath.Fill = Brushes.Orange;
            this.TipazaPath.Fill = Brushes.Orange;
            this.AlgerPath.Fill = Brushes.Orange;
            this.BoumerdasPath.Fill = Brushes.Orange;
            this.TiziouzouPath.Fill = Brushes.Orange;
            this.BejaiaPath.Fill = Brushes.Orange;
            this.JijelPath.Fill = Brushes.Orange;
            this.SkikdaPath.Fill = Brushes.Orange;
            this.AnnabaPath.Fill = Brushes.Orange;
            this.TarefPath.Fill = Brushes.Orange;
        }
        /**********************************************/


        /* Click sur la surface/vecteur AintimouchentPath */
        private void AintimouchentPath_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            DescriptionStack.Visibility = Visibility.Visible;
            Location.Visibility = Visibility.Visible;
            /* affichage */
            Location.Text = "ولاية عين تيموشنت";
            descriptionBlock.Text = "الرمز\nالمساحة\nعدد السكان\nطول الساحل\n";
            this.AintimouchentPath.Fill = Brushes.Red;

            this.TlemcenPath.Fill = Brushes.Orange;
            this.OranPath.Fill = Brushes.Orange;
            this.MostaganemPath.Fill = Brushes.Orange;
            this.ChlefPath.Fill = Brushes.Orange;
            this.TipazaPath.Fill = Brushes.Orange;
            this.AlgerPath.Fill = Brushes.Orange;
            this.BoumerdasPath.Fill = Brushes.Orange;
            this.TiziouzouPath.Fill = Brushes.Orange;
            this.BejaiaPath.Fill = Brushes.Orange;
            this.JijelPath.Fill = Brushes.Orange;
            this.SkikdaPath.Fill = Brushes.Orange;
            this.AnnabaPath.Fill = Brushes.Orange;
            this.TarefPath.Fill = Brushes.Orange;
        }
        /**********************************************/


        /* Click sur la surface/vecteur OranPath */
        private void OranPath_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            DescriptionStack.Visibility = Visibility.Visible;
            Location.Visibility = Visibility.Visible;
            /* affichage */
            Location.Text = "ولاية وهران";
            descriptionBlock.Text = "الرمز\nالمساحة\nعدد السكان\nطول الساحل\n";
            this.OranPath.Fill = Brushes.Red;

            this.TlemcenPath.Fill = Brushes.Orange;
            this.AintimouchentPath.Fill = Brushes.Orange;
            this.MostaganemPath.Fill = Brushes.Orange;
            this.ChlefPath.Fill = Brushes.Orange;
            this.TipazaPath.Fill = Brushes.Orange;
            this.AlgerPath.Fill = Brushes.Orange;
            this.BoumerdasPath.Fill = Brushes.Orange;
            this.TiziouzouPath.Fill = Brushes.Orange;
            this.BejaiaPath.Fill = Brushes.Orange;
            this.JijelPath.Fill = Brushes.Orange;
            this.SkikdaPath.Fill = Brushes.Orange;
            this.AnnabaPath.Fill = Brushes.Orange;
            this.TarefPath.Fill = Brushes.Orange;
        }
        /**********************************************/


        /* Click sur la surface/vecteur MostaganemPath */
        private void MostaganemPath_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            DescriptionStack.Visibility = Visibility.Visible;
            Location.Visibility = Visibility.Visible;
            /* affichage */
            Location.Text = "ولاية مستغانم";
            descriptionBlock.Text = "الرمز\nالمساحة\nعدد السكان\nطول الساحل\n";
            this.MostaganemPath.Fill = Brushes.Red;

            this.TlemcenPath.Fill = Brushes.Orange;
            this.AintimouchentPath.Fill = Brushes.Orange;
            this.OranPath.Fill = Brushes.Orange;
            this.ChlefPath.Fill = Brushes.Orange;
            this.TipazaPath.Fill = Brushes.Orange;
            this.AlgerPath.Fill = Brushes.Orange;
            this.BoumerdasPath.Fill = Brushes.Orange;
            this.TiziouzouPath.Fill = Brushes.Orange;
            this.BejaiaPath.Fill = Brushes.Orange;
            this.JijelPath.Fill = Brushes.Orange;
            this.SkikdaPath.Fill = Brushes.Orange;
            this.AnnabaPath.Fill = Brushes.Orange;
            this.TarefPath.Fill = Brushes.Orange;
        }
        /**********************************************/


        /* Click sur la surface/vecteur ChlefPath */
        private void ChlefPath_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            DescriptionStack.Visibility = Visibility.Visible;
            Location.Visibility = Visibility.Visible;
            /* affichage */
            Location.Text = " ولاية الشلف";
            descriptionBlock.Text = "الرمز\nالمساحة\nعدد السكان\nطول الساحل\n";
            this.ChlefPath.Fill = Brushes.Red;

            this.TlemcenPath.Fill = Brushes.Orange;
            this.AintimouchentPath.Fill = Brushes.Orange;
            this.OranPath.Fill = Brushes.Orange;
            this.MostaganemPath.Fill = Brushes.Orange;
            this.TipazaPath.Fill = Brushes.Orange;
            this.AlgerPath.Fill = Brushes.Orange;
            this.BoumerdasPath.Fill = Brushes.Orange;
            this.TiziouzouPath.Fill = Brushes.Orange;
            this.BejaiaPath.Fill = Brushes.Orange;
            this.JijelPath.Fill = Brushes.Orange;
            this.SkikdaPath.Fill = Brushes.Orange;
            this.AnnabaPath.Fill = Brushes.Orange;
            this.TarefPath.Fill = Brushes.Orange;
        }
        /**********************************************/



        /* Click sur la surface/vecteur TipazaPath */
        private void TipazaPath_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            DescriptionStack.Visibility = Visibility.Visible;
            Location.Visibility = Visibility.Visible;
            /* affichage */
            Location.Text = "ولاية تيبازة";
            descriptionBlock.Text = "الرمز\nالمساحة\nعدد السكان\nطول الساحل\n";
            this.TipazaPath.Fill = Brushes.Red;

            this.TlemcenPath.Fill = Brushes.Orange;
            this.AintimouchentPath.Fill = Brushes.Orange;
            this.OranPath.Fill = Brushes.Orange;
            this.MostaganemPath.Fill = Brushes.Orange;
            this.ChlefPath.Fill = Brushes.Orange;
            this.AlgerPath.Fill = Brushes.Orange;
            this.BoumerdasPath.Fill = Brushes.Orange;
            this.TiziouzouPath.Fill = Brushes.Orange;
            this.BejaiaPath.Fill = Brushes.Orange;
            this.JijelPath.Fill = Brushes.Orange;
            this.SkikdaPath.Fill = Brushes.Orange;
            this.AnnabaPath.Fill = Brushes.Orange;
            this.TarefPath.Fill = Brushes.Orange;
        }
        /**********************************************/



        /* Click sur la surface/vecteur AlgerPath */
        private void AlgerPath_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            DescriptionStack.Visibility = Visibility.Visible;
            Location.Visibility = Visibility.Visible;
            /* affichage */
            Location.Text = "ولاية الجزائر";
            descriptionBlock.Text = "الرمز\nالمساحة\nعدد السكان\nطول الساحل\n";
            this.AlgerPath.Fill = Brushes.Red;

            this.TlemcenPath.Fill = Brushes.Orange;
            this.AintimouchentPath.Fill = Brushes.Orange;
            this.OranPath.Fill = Brushes.Orange;
            this.MostaganemPath.Fill = Brushes.Orange;
            this.ChlefPath.Fill = Brushes.Orange;
            this.TipazaPath.Fill = Brushes.Orange;
            this.BoumerdasPath.Fill = Brushes.Orange;
            this.TiziouzouPath.Fill = Brushes.Orange;
            this.BejaiaPath.Fill = Brushes.Orange;
            this.JijelPath.Fill = Brushes.Orange;
            this.SkikdaPath.Fill = Brushes.Orange;
            this.AnnabaPath.Fill = Brushes.Orange;
            this.TarefPath.Fill = Brushes.Orange;
        }
        /**********************************************/



        /* Click sur la surface/vecteur BoumerdasPath */
        private void BoumerdasPath_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            DescriptionStack.Visibility = Visibility.Visible;
            Location.Visibility = Visibility.Visible;
            /* affichage */
            Location.Text = "ولاية بومرداس";
            descriptionBlock.Text = "الرمز\nالمساحة\nعدد السكان\nطول الساحل\n";
            this.BoumerdasPath.Fill = Brushes.Red;

            this.TlemcenPath.Fill = Brushes.Orange;
            this.AintimouchentPath.Fill = Brushes.Orange;
            this.OranPath.Fill = Brushes.Orange;
            this.MostaganemPath.Fill = Brushes.Orange;
            this.ChlefPath.Fill = Brushes.Orange;
            this.TipazaPath.Fill = Brushes.Orange;
            this.AlgerPath.Fill = Brushes.Orange;
            this.TiziouzouPath.Fill = Brushes.Orange;
            this.BejaiaPath.Fill = Brushes.Orange;
            this.JijelPath.Fill = Brushes.Orange;
            this.SkikdaPath.Fill = Brushes.Orange;
            this.AnnabaPath.Fill = Brushes.Orange;
            this.TarefPath.Fill = Brushes.Orange;
        }
        /**********************************************/



        /* Click sur la surface/vecteur TiziouzouPath */
        private void TiziouzouPath_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            DescriptionStack.Visibility = Visibility.Visible;
            Location.Visibility = Visibility.Visible;
            /* affichage */
            Location.Text = "ولاية تيزي وزو";
            descriptionBlock.Text = "الرمز\nالمساحة\nعدد السكان\nطول الساحل\n";
            this.TiziouzouPath.Fill = Brushes.Red;

            this.TlemcenPath.Fill = Brushes.Orange;
            this.AintimouchentPath.Fill = Brushes.Orange;
            this.OranPath.Fill = Brushes.Orange;
            this.MostaganemPath.Fill = Brushes.Orange;
            this.ChlefPath.Fill = Brushes.Orange;
            this.TipazaPath.Fill = Brushes.Orange;
            this.AlgerPath.Fill = Brushes.Orange;
            this.BoumerdasPath.Fill = Brushes.Orange;
            this.BejaiaPath.Fill = Brushes.Orange;
            this.JijelPath.Fill = Brushes.Orange;
            this.SkikdaPath.Fill = Brushes.Orange;
            this.AnnabaPath.Fill = Brushes.Orange;
            this.TarefPath.Fill = Brushes.Orange;
        }
        /**********************************************/



        /* Click sur la surface/vecteur BejaiaPath */
        private void BejaiaPath_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            DescriptionStack.Visibility = Visibility.Visible;
            Location.Visibility = Visibility.Visible;
            /* affichage */
            Location.Text = "ولاية بجاية";
            descriptionBlock.Text = "الرمز\nالمساحة\nعدد السكان\nطول الساحل\n";
            this.BejaiaPath.Fill = Brushes.Red;

            this.TlemcenPath.Fill = Brushes.Orange;
            this.AintimouchentPath.Fill = Brushes.Orange;
            this.OranPath.Fill = Brushes.Orange;
            this.MostaganemPath.Fill = Brushes.Orange;
            this.ChlefPath.Fill = Brushes.Orange;
            this.TipazaPath.Fill = Brushes.Orange;
            this.AlgerPath.Fill = Brushes.Orange;
            this.BoumerdasPath.Fill = Brushes.Orange;
            this.TiziouzouPath.Fill = Brushes.Orange;
            this.JijelPath.Fill = Brushes.Orange;
            this.SkikdaPath.Fill = Brushes.Orange;
            this.AnnabaPath.Fill = Brushes.Orange;
            this.TarefPath.Fill = Brushes.Orange;
        }
        /**********************************************/



        /* Click sur la surface/vecteur JijelPath */
        private void JijelPath_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            DescriptionStack.Visibility = Visibility.Visible;
            Location.Visibility = Visibility.Visible;
            /* affichage */
            Location.Text = "ولاية جيجل";
            descriptionBlock.Text = "الرمز\nالمساحة\nعدد السكان\nطول الساحل\n";
            this.JijelPath.Fill = Brushes.Red;

            this.TlemcenPath.Fill = Brushes.Orange;
            this.AintimouchentPath.Fill = Brushes.Orange;
            this.OranPath.Fill = Brushes.Orange;
            this.MostaganemPath.Fill = Brushes.Orange;
            this.ChlefPath.Fill = Brushes.Orange;
            this.TipazaPath.Fill = Brushes.Orange;
            this.AlgerPath.Fill = Brushes.Orange;
            this.BoumerdasPath.Fill = Brushes.Orange;
            this.TiziouzouPath.Fill = Brushes.Orange;
            this.BejaiaPath.Fill = Brushes.Orange;
            this.SkikdaPath.Fill = Brushes.Orange;
            this.AnnabaPath.Fill = Brushes.Orange;
            this.TarefPath.Fill = Brushes.Orange;
        }
        /**********************************************/



        /* Click sur la surface/vecteur SkikdaPath */
        private void SkikdaPath_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            DescriptionStack.Visibility = Visibility.Visible;
            Location.Visibility = Visibility.Visible;
            /* affichage */
            Location.Text = "ولاية سكيكدة";
            descriptionBlock.Text = "الرمز\nالمساحة\nعدد السكان\nطول الساحل\n";
            this.SkikdaPath.Fill = Brushes.Red;

            this.TlemcenPath.Fill = Brushes.Orange;
            this.AintimouchentPath.Fill = Brushes.Orange;
            this.OranPath.Fill = Brushes.Orange;
            this.MostaganemPath.Fill = Brushes.Orange;
            this.ChlefPath.Fill = Brushes.Orange;
            this.TipazaPath.Fill = Brushes.Orange;
            this.AlgerPath.Fill = Brushes.Orange;
            this.BoumerdasPath.Fill = Brushes.Orange;
            this.TiziouzouPath.Fill = Brushes.Orange;
            this.BejaiaPath.Fill = Brushes.Orange;
            this.JijelPath.Fill = Brushes.Orange;
            this.AnnabaPath.Fill = Brushes.Orange;
            this.TarefPath.Fill = Brushes.Orange;
        }
        /**********************************************/



        /* Click sur la surface/vecteur AnnabaPath */
        private void AnnabaPath_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            DescriptionStack.Visibility = Visibility.Visible;
            Location.Visibility = Visibility.Visible;
            /* affichage */
            Location.Text = "ولاية عنابة";
            descriptionBlock.Text = "الرمز\nالمساحة\nعدد السكان\nطول الساحل\n";
            this.AnnabaPath.Fill = Brushes.Red;

            this.TlemcenPath.Fill = Brushes.Orange;
            this.AintimouchentPath.Fill = Brushes.Orange;
            this.OranPath.Fill = Brushes.Orange;
            this.MostaganemPath.Fill = Brushes.Orange;
            this.ChlefPath.Fill = Brushes.Orange;
            this.TipazaPath.Fill = Brushes.Orange;
            this.AlgerPath.Fill = Brushes.Orange;
            this.BoumerdasPath.Fill = Brushes.Orange;
            this.TiziouzouPath.Fill = Brushes.Orange;
            this.BejaiaPath.Fill = Brushes.Orange;
            this.JijelPath.Fill = Brushes.Orange;
            this.SkikdaPath.Fill = Brushes.Orange;
            this.TarefPath.Fill = Brushes.Orange;
        }
        /**********************************************/



        /* Click sur la surface/vecteur TarefPath */
        private void TarefPath_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
            DescriptionStack.Visibility = Visibility.Visible;
            Location.Visibility = Visibility.Visible;
            /* affichage */
            Location.Text = "ولاية الطارف";
            descriptionBlock.Text = "الرمز\nالمساحة\nعدد السكان\nطول الساحل\n";
            this.TarefPath.Fill = Brushes.Red;

            this.TlemcenPath.Fill = Brushes.Orange;
            this.AintimouchentPath.Fill = Brushes.Orange;
            this.OranPath.Fill = Brushes.Orange;
            this.MostaganemPath.Fill = Brushes.Orange;
            this.ChlefPath.Fill = Brushes.Orange;
            this.TipazaPath.Fill = Brushes.Orange;
            this.AlgerPath.Fill = Brushes.Orange;
            this.BoumerdasPath.Fill = Brushes.Orange;
            this.TiziouzouPath.Fill = Brushes.Orange;
            this.BejaiaPath.Fill = Brushes.Orange;
            this.JijelPath.Fill = Brushes.Orange;
            this.SkikdaPath.Fill = Brushes.Orange;
            this.AnnabaPath.Fill = Brushes.Orange;
        }
        /**********************************************/




        /*** afficher l'infoBulle qui montrent a l'eleve ce qu'il faut faire */
        private void HelpButton_MouseMove(object sender, MouseEventArgs e)
        {
            InfoBulleGrid.Visibility = Visibility.Visible;
        }


        private void HelpButton_MouseLeave(object sender, MouseEventArgs e)
        {
            InfoBulleGrid.Visibility = Visibility.Hidden;
        }
        /*********************************************************************/


    }
}


