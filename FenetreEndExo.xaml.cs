using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
namespace AlGeo
{
    
    public partial class FenetreEndExo : Window
    {
        int comment;//Commentaire sur le score.
        Image img;//Objet Image pour afficher les etoiles de score.

        // private int id_exercice; 
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
        /*Constructeur :Sert à récupperer les variables qui seront afficher*/
        public FenetreEndExo(int Choix, int Score, int Total, int id_exercice)
        {   
            InitializeComponent();
            App.mainWindow.Opacity = 0.5f;
            Exercice exercice = new Exercice();
            /*Sauvgarde de score dans la base de donnée*/
            if (Score != 0)
            { exercice.sauvegarderScore(id_exercice, Score);}
            /******************************************/
            /*Le premier choix correspond au temps écoulée*/
            if (Choix == 1)
            {
                CommentParagraph.Inlines.Add(new Run("  للاسف , انتهى الوقت"));
            }
            /*****************************************/
            /*Le deuxiéme Choix correspond à un exercice fini*/
            else if (Choix == 2)
            {
                CommentParagraph.Inlines.Add(new Run("احسنت ! , لقد انهيت التمرين."));
            }
            /*******************************************/
            /*Affichage du Score*/
            CommentParagraph.Inlines.Add(new LineBreak());
            CommentParagraph.Inlines.Add(new Run(" العلامة:  " + Total+ "/" +Score));
            /************************************************/
            /*Affichage des étoiles selon le score obtenu*/
            comment = Score * 100 / Total;
            /*Si score<33%:on affiche une étoile*/
            if ((comment < 33)&&(comment>0))
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
        /*Bouton Fermer la boite de dialogue*/
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.Opacity = 1;
            this.Close();
        }
        /***********************************/

        
    }
}