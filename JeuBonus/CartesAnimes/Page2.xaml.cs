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
using System.Windows.Markup;
using System.IO;
using System.Xml;
using System.Windows.Media.Animation;

namespace AlGeo.JeuBonus.CartesAnimes
{
    public partial class Page2 : Page
    {
        //Attribut pour la stockage de la reponse courante de l'eleve
        private int Answer = 0;

        //Attribut du lien du fichier xml de stockage des differentes données relative a l'exercice
        private string LienGame = @"ExoCarteAnime.xml";

        //Attribut contenant le pointeur sur le fichier xml de stockage de cette exercice
        private XmlDocument myFile = new XmlDocument();

        private DoubleAnimation animation1 = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(2));
        private DoubleAnimation animation2 = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(2));



        /*________Instructions relative au constructeur de la page _________*/
        public Page2()
        {
            //Initialisation du contenu de la page
            InitializeComponent();

            True.Visibility = Visibility.Collapsed;
            False.Visibility = Visibility.Collapsed;
            //Désactivation du button de confirmation de la reponse tant qu'aucune reponse n'a été selctionné
            Confirm.IsEnabled = false;
            Next.IsEnabled = false;

            myFile.Load(LienGame);

            //Chargement des propostion contenu dans fichier xml 
            string g = "prop2";
            XmlNodeList liste = myFile.GetElementsByTagName(g);
            //Remplissage de la liste des propositions a partir du noeud 'prop' du fichier xml
            Rep1.Content = liste[0].InnerText;
            Rep2.Content = liste[1].InnerText;
            Rep3.Content = liste[2].InnerText;

            //Remplissage de la bulle du help
            XmlDocument monFichier = new XmlDocument();

            monFichier.Load("HelpExoBonus.xml");
            string i = "Conseil4";
            int indicHelp;
            object obj;
            XmlNodeList lst = monFichier.GetElementsByTagName(i);
            for (indicHelp = 1; indicHelp < 5; indicHelp++)
            {
                obj = CarteAnimeGrid.FindName("Help" + indicHelp);
                Span L = (Span)obj;
                L.Inlines.Clear();
                L.Inlines.Add(new Run(lst[indicHelp - 1].InnerText));
            }
        }


        /*________Instructions relative au Click sur le button de Confirmation "تأكيد" de la page _________*/
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            //Désactivation du button de confirmation pour interdire le reconfirmation d'un autre reponse
            Confirm.IsEnabled = false;
            Next.IsEnabled = true;
            Rep2.IsSelected = false;
            //Chacher le help de l'exercice ainsi que le tuteur
            image.Visibility = Visibility.Hidden;
            object obj;
            int indicHelp;
            for (indicHelp = 1; indicHelp < 5; indicHelp++)
            {
                obj = CarteAnimeGrid.FindName("richTextBox" + indicHelp);
                RichTextBox L = (RichTextBox)obj;
                L.Visibility = Visibility.Hidden;
            }

            //Chargement du Corrigé de la question courante a partir du fichier xml
            myFile.Load(LienGame);
            string CorrectAnswer = "rep2";
            XmlNodeList liste = myFile.GetElementsByTagName(CorrectAnswer);
            int RightAnswer = int.Parse(liste[0].InnerText);

            //Verification de la véracité de la réponse coché par l'élève
            if (Answer == RightAnswer) //Si c'est Vrai ...
            {
                //On affiche le symbole Vrai
                True.Visibility = Visibility.Visible;
                True.BeginAnimation(Image.OpacityProperty, animation1);
                True.BeginAnimation(Image.OpacityProperty, animation2);

                XmlNode Score = myFile.SelectSingleNode("//Score");
                String i = Score.InnerText;
                int score = int.Parse(i);
                //Le Score est incrementé et Stocké
                score++;
                Score.InnerText = score.ToString();
                myFile.Save(LienGame);
            }
            else //Sinon on affiche le symbole Faux
            {
                False.Visibility = Visibility.Visible;
                False.BeginAnimation(Image.OpacityProperty, animation1);
                False.BeginAnimation(Image.OpacityProperty, animation2);
            }
        }


        /*________Instructions relative au Click sur le button Suivant "التالي" de la page__________*/
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            True.Visibility = Visibility.Collapsed;
            False.Visibility = Visibility.Collapsed;

            //Passage a la prochaine question
            this.NavigationService.Navigate(new Page3());
        }



        /*________Instructions relative au choix de la premiere Proposition  _________*/
        private void Rep1_Selected(object sender, RoutedEventArgs e)
        {
            Answer = 1; //Récuperation de la réponse choisie
            Confirm.IsEnabled = true; //Activation de la confirmation de la réponse
        }

        /*________Instructions relative au choix de la deuxieme Proposition  _________*/
        private void Rep2_Selected(object sender, RoutedEventArgs e)
        {
            Answer = 2; //Récuperation de la réponse choisie
            Confirm.IsEnabled = true; //Activation de la confirmation de la réponse
        }

        /*________Instructions relative au choix de la troisieme Proposition  _________*/
        private void Rep3_Selected(object sender, RoutedEventArgs e)
        {
            Answer = 3; //Récuperation de la réponse choisie
            Confirm.IsEnabled = true; //Activation de la confirmation de la réponse
        }
    }
}

