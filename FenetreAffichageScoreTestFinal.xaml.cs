using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;

namespace AlGeo
{
    /// <summary>
    /// Logique d'interaction pour FenetreAffichageScoreTestFinal.xaml
    /// </summary>
    public partial class FenetreAffichageScoreTestFinal : Window
    {
        int comment;//Commentaire sur le score.
        Image img;//Objet Image pour afficher les etoiles de score.
        private int Score;
        private int Total = 33;
        Exercice exercice = new Exercice();
        private int Choix;//variable qui indique si on veut quitter l'app ou pas.
        /*Constructeur:sert à initialiser la variable choix selon le choix de l'utilisateur:il veut quitter ou pas*/
        public FenetreAffichageScoreTestFinal(int Choix)
        {   /*Initialser les variables*/
            this.Choix = Choix;
            this.Score = exercice.RecupererScore(13);
            /**************************/
            App.mainWindow.Opacity = 0.5f;
            InitializeComponent();
            /*Condition d'acces au bonus du test final*/
            if(Score>20)
            { Bonus.IsEnabled = true; }
            if (Choix == 1)
            {
                DescriptionTB.Inlines.Add(new Run("  للاسف , انتهى الوقت"));
                DescriptionTB.Inlines.Add(new LineBreak());
            }
            else if (Choix == 2)
            {
                DescriptionTB.Inlines.Add(new Run("احسنت ! , لقد انهيت الاختبار."));
                DescriptionTB.Inlines.Add(new LineBreak());
            }
               
               DescriptionTB.Inlines.Add(new Run(" العلامة:  " + Score*20/Total + " /" + 20));
            /*********************************************************************/
            /*Affichage des étoiles selon le score obtenu*/
            comment = Score * 100 / Total;
            /*Si score<33%:on affiche une étoile*/
            if ((comment < 33) && (comment > 0))
            {
                img = this.FindName("image1") as Image;
                img.Source = GetImage("Images/star.png");
            }
            /********************************/
            /*Si 33%<score<66%: on affiche deux étoiles*/
            else if (comment < 66)
            {
                for (int i = 1; i <= 2; i++)
                {
                    img = this.FindName("image" + i) as Image;
                    img.Source = GetImage("Images/star.png");
                }
            }
            /********************************/
            /*Si score>66% : on affiche 3étoiles*/
            else
            {
                for (int i = 1; i <= 3; i++)
                {
                    img = this.FindName("image" + i) as Image;
                    img.Source = GetImage("Images/star.png");
                }
            }
            /********************************/

        }

        /*Methode pour afficher une image*/
        private static BitmapImage GetImage(string imageUri)
        {
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(imageUri, UriKind.RelativeOrAbsolute);
            bitmapImage.EndInit();
            return bitmapImage;
        }
        /**************************************/
        
       /*Methode pour Afficher le score*/
        private void Bonus_Click(object sender, RoutedEventArgs e)
        {   
            App.mainWindow.Opacity = 1;
            InterfaceBonus interfaceBonus = new InterfaceBonus();
            interfaceBonus.Show();
            this.Close();
        }
        /*****************************************************/
        /*Methode pour Fermer la boite de dialogue*/
        private void Fermer_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.Opacity = 1;
            this.Close();
        }
        /**********************************************/
    }
}
