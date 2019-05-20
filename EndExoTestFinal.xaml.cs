using System.Windows;
using System.Windows.Documents;

namespace AlGeo
{
    /*Boite de dialogue a chaque fin d'exercice*/
    public partial class EndExoTestFinal : Window       
    {
        Exercice exercice = new Exercice();
        /*Constructeur: sert à initialiser definir le commentaire a afficher
        selon si le temps est ecoulé ou pas*/
        public EndExoTestFinal(int Choix,int Score)
        {
            Score = exercice.RecupererScore(13) + Score;
            exercice.sauvegarderScore(13, Score);
            App.mainWindow.Opacity = 0.5f;
            InitializeComponent();
            Animations.AddSound(2);//Ajout du son
            /*Le temps est ecoulé*/
            if (Choix == 1)
            {
                CommentParagraph.Inlines.Clear();
                CommentParagraph.Inlines.Add(new Run("  للاسف , انتهى الوقت"));
            }
            /*************************/
            /*Il reste encore du temps*/
            else if (Choix == 2)
            {   /*Affichage d'un petit commentaire qui oriente l'éléve quoi faire*/
                CommentParagraph.Inlines.Clear();
                CommentParagraph.Inlines.Add(new Run("احسنت ! , لقد اكملت التمرين."));
                CommentParagraph.Inlines.Add(new LineBreak());
                CommentParagraph.Inlines.Add(new Run("اضغط على الزر اسفله لاختيار التمرين التالي."));

            }
            /********************************/

        }

        
        /*Bouton de Fermeture de la boite de dialogue*/
         private void Exit_Click(object sender, RoutedEventArgs e)
          {
            this.Close();
            App.mainWindow.Opacity = 1;
         }
    }
}
