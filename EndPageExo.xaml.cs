using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;


namespace AlGeo
{
    /// <summary>
    /// Logique d'interaction pour EndPageExo.xaml
    /// </summary>
    public partial class EndPageExo : Page
    {
        // private int id_exercice; 
        public EndPageExo(int Choix, int Score, int Total,int id_exercice)
        {
            InitializeComponent();
            Animations.AddSound(2);
            Exercice exercice = new Exercice();
            if (Score != 0)
            {
                exercice.sauvegarderScore(id_exercice, Score);
            }
            if (Choix == 1)
            {
                CommentParagraph.Inlines.Add(new Run("  للاسف , انتهى الوقت"));
            }
            else if (Choix == 2)
            {
                CommentParagraph.Inlines.Add(new Run("احسنت ! , لقد اجبت على كل الاسئلة"));
                CommentParagraph.Inlines.Add(new LineBreak());
            }

            ScoreTBlk.Inlines.Clear();
            ScoreTBlk.Inlines.Add(new Run(" العلامة:  " + Score + " /" + Total));
            ScoreTBlk.Inlines.Add(new LineBreak());
        }


        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            //this.NavigationService.Navigate(new StartPage());
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Content = null;
        }
    }
}
