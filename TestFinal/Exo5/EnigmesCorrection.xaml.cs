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
using System.Xml;

namespace AlGeo.TestFinal.Exo5
{
    /// <summary>
    /// Logique d'interaction pour EnigmesCorrection.xaml
    /// </summary>
    public partial class EnigmesCorrection : Page
    {

        /* animations des couleurs de la page ( changement des couleurs ) */
        private List<string> colorBrushesBackground = new List<string>() { "#FF125065", "#FF112F65", "#FF304354", "#FF0C5192", "#FFFFE196", "#FF7DDCD4", "#FF112F65", "#FF125065" };
        private List<string> colorBrushesRTB = new List<string>() { "#FF1ABC9C", "#FF1ABC9C", "#FF455799" };
        /*******************************************************************/

        /* conteneur du fichier */
        private XmlDocument monFichier = new XmlDocument();

        private int i = new Random().Next(5);//debut des questions ie l'indice de la premiere question géneré aleatoirement
        private int j = 1;
        private int k = 0;
        private int totalQuestion; // nombre total de questions se trouvant dans le fichier xml attribué a cet exercice
        private string path;  // chemin vers le fichier xml contenant les données associées a cet exercice 
        private XmlNode quest;

        private int questionChoisi; // premiere question choisie et donc a afficher 
        int nbQuest = 1;  // nombre de questions affichées - condition d'arret 

        /* recuperer le nombre de questions */
        public int GetNbQuest() { return (nbQuest); }


       

        /* recuperer une question a partir d'un fichier xml selon les balises personnalisées contenues dans ce dernier 
         * Q : recuperer la question 
         * R : recuperer la Bonne reponse ( image dans ce cas ) 
         * C : titre de l'image la decrivant  */
        private void GetAnswerFromFile(string path)
        {
            Question.Inlines.Clear();
            Question.Inlines.Add(new Run(monFichier.SelectSingleNode(path + "/Q").InnerText));
            String rep = monFichier.SelectSingleNode(path + "/R").InnerText;
            String image = monFichier.SelectSingleNode(path + "/Choix" + rep).InnerText;
            ImageChoix.Source = Animations.GetImage(@"Images/" + image);
            comment.Text = monFichier.SelectSingleNode(path + "/C").InnerText;

        }
        /******************************************************************************************/


        /**********************                  Constructeur                  ********************/
        public EnigmesCorrection()
        {
            InitializeComponent();

            /* recupeation du fichier XML a partir de son emplacement */
            monFichier.Load("Oneword3pics.xml");

            /* recuperer le nombre total des questions a partir du fichier */
            quest = monFichier.SelectSingleNode("//Enigmes/TotalQuestion");
            totalQuestion = int.Parse(quest.InnerText);

            /* recuperer l'indice de la premiere question qui a été traité en premier dans l'exercice 
            * ( celle générée aleatoirement ) et afficher la question et reponse associés */
            questionChoisi = int.Parse(monFichier.SelectSingleNode("//Enigmes/DebutQuestionsFaites").InnerText);
            path = "//Enigmes/Probleme" + questionChoisi;
            GetAnswerFromFile(path);
            Previous.IsEnabled = false; //bouton precedant
            ScoreTB.Inlines.Clear();
            ScoreTB.Inlines.Add(new Run("السؤال  :" + nbQuest + " /10"));
        }
        /*******************************************************************************************/



        /**    Reafficher la correction de la question precedante dans le cas
         *  ou l'eleve clique sur le bouton precedant    **/
        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1); // son click 
            Next.IsEnabled = true;  

            if (nbQuest > 1)
            {   
                Previous.IsEnabled = true;
                questionChoisi--;
                if (questionChoisi == 0)
                { questionChoisi = totalQuestion; }
                /* recuperation de la question precedante  */
                path = "//Enigmes/Probleme" + questionChoisi;
                GetAnswerFromFile(path);
                nbQuest--;
                ScoreTB.Inlines.Clear();
                ScoreTB.Inlines.Add(new Run("السؤال  :" + nbQuest + " /10"));
                /* animation des couleurs */
                ExoGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorBrushesBackground[j]));
                QuestionRtb.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorBrushesRTB[k]));
                k++;
                j++;
                if (k == colorBrushesRTB.Count) { k = 0; }
                if (j == colorBrushesBackground.Count) { j = 0; }
                /**************************/
            }
            if (nbQuest == 1) { Previous.IsEnabled = false; }
        }
        /*****************************************************************************/


        /**    Afficher la correction de la question suivante  dans le cas ou
         *     l'eleve clique sur le bouton suivant    **/
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);
            Previous.IsEnabled = true;
            if (nbQuest < 10)
            {
                Next.IsEnabled = true;
                questionChoisi++;
                if (questionChoisi == (totalQuestion+1)) { questionChoisi = 1; }
                /* chemin vers le fichier XML */
                path = "//Enigmes/Probleme" + questionChoisi;
                /* recupeation de la question */ 
                GetAnswerFromFile(path);
                nbQuest++;
                ScoreTB.Inlines.Clear();
                ScoreTB.Inlines.Add(new Run("السؤال  :" + nbQuest + " /10"));
                /* animations  des couleurs de la fenetre  */
                ExoGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorBrushesBackground[j]));
                QuestionRtb.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorBrushesRTB[k]));
                k++;
                j++;
                if (k == colorBrushesRTB.Count) { k = 0; }
                if (j == colorBrushesBackground.Count) { j = 0; }
                /*******************************************/
            }
            if (nbQuest == 10) { Next.IsEnabled = false; }  //fin de l'exercice - condition d'arret 
        }
        /*********************************************************************************/




    }
}
