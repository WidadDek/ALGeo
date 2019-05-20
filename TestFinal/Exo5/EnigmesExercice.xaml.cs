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
using System.Windows.Threading;
using System.Xml;

namespace AlGeo.TestFinal.Exo5
{
    /// <summary>
    /// Logique d'interaction pour EnigmesExercice.xaml
    /// </summary>
    public partial class EnigmesExercice : Page,IExerciceTypeQuestionnaire
    {


        /* animations des couleurs de la page */
        private List<string> colorBrushesBackground = new List<string>() { "#FF125065", "#FF112F65", "#FF304354", "#FF0C5192", "#FFFFE196", "#FF7DDCD4", "#FF112F65", "#FF125065" };
        private List<string> colorBrushesRTB = new List<string>() { "#FF1ABC9C", "#FF1ABC9C", "#FF455799" };
        /**************************************/

        /* conteneur du fichier */
        private XmlDocument monFichier = new XmlDocument();

        private int i = new Random().Next(5);//debut des questions l'indice de la premiere question
        private int j = 1;
        private int k = 0;
        private int totalQuestion; //nombre total de question 
        private string path; // chemin vers le fichier XML 
        private XmlNode quest; // numero de la question recupérée du noeud question ie Q du fichier XML
        private XmlNode rep; // reponse a la question récupérée a partir du fichier XML 
        private XmlNode questionChoisi;  // premiere question choisie 
        private String repEleve;  // reponse de l'eleve 
        int score = 0; 
        int nbQuest = 0; // nombre de question traitées ( condition d'arret ) 
        DispatcherTimer timer = new DispatcherTimer();  

        /*      recuperer le nombre de questions    */
        public int GetNbQuest() { return (nbQuest); }


       
        /* recuperer une question a partir d'un fichier xml selon les balises personnalisées */
        public void GetQuestionFromFile(string path)
        {
            Question.Inlines.Clear();
            /* recuperation de la question à partir de la balise personnalisée Q = question du fichier XML */
            Question.Inlines.Add(new Run(monFichier.SelectSingleNode(path + "/Q").InnerText));
            /* recuperation des choix proposés de cette question, contenus dans des balises  pesonnalisées : "choix" */
            String image1 = monFichier.SelectSingleNode(path + "/Choix1").InnerText;
            ImageChoix1.Source = Animations.GetImage(@"Images/" + image1);
            String image2 = monFichier.SelectSingleNode(path + "/Choix2").InnerText;
            ImageChoix2.Source = Animations.GetImage(@"Images/" + image2);
            String image3 = monFichier.SelectSingleNode(path + "/Choix3").InnerText;
            ImageChoix3.Source = Animations.GetImage(@"Images/" + image3); 

        }


        /******************             constructeur            ***********************/
        public EnigmesExercice()
        {
            InitializeComponent();
            /* recupeation du fichier XML a partir de son emplacement */
            monFichier.Load("Oneword3pics.xml");
            /* recuperation du nombre total de questions proposées dans cet exercice */
            quest = monFichier.SelectSingleNode("//Enigmes/TotalQuestion");
            totalQuestion = int.Parse(quest.InnerText);

            /* generation ALEATOIRE de la premiere question a poser et la sauvegarde de son
             *  num dansle fichier XML dans la balise debutQuestionFaites pour s'en servir 
             * lors de  l'affichage de la correction
             *  */
            while ((i > totalQuestion) || (i <= 0)) { i = new Random().Next(totalQuestion); }
            monFichier.Load("Oneword3pics.xml");
            quest = monFichier.SelectSingleNode("//Enigmes/TotalQuestion");
            totalQuestion = int.Parse(quest.InnerText);
            path = "//Enigmes/Probleme" + i;
            GetQuestionFromFile(path);
            nbQuest++;
            ScoreTB.Inlines.Clear();
            ScoreTB.Inlines.Add(new Run("السؤال  :" + nbQuest + " /10"));
            questionChoisi = monFichier.SelectSingleNode("//Enigmes/DebutQuestionsFaites");
            questionChoisi.InnerText = Convert.ToString(i);
            monFichier.Save("Oneword3pics.xml");  

        }
        /********************************************************************************/




        /** l'eleve choisi l'image 1  **/
        private void ImageChoix1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Animations.AddSound(1); // son click 
            Ok.Visibility = Visibility.Visible;
            repEleve = "1";
        }


        /** l'eleve choisi l'image 2 **/
        private void ImageChoix2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Animations.AddSound(1); // son click
            Ok.Visibility = Visibility.Visible;
            repEleve = "2";
        }


        /** l'eleve choisi l'image 3 **/
        private void ImageChoix3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Animations.AddSound(1); // son click
            Ok.Visibility = Visibility.Visible;
            repEleve = "3";

        }


        /*******************       تاكيد الاجابة                ********************/ 
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1); // son click
            /* recuperation de la reponse a la question posée a partir du fichier XML 
             * elle est contenue dans la balise R */
            rep = monFichier.SelectSingleNode(path + "/R");
            if (nbQuest == 10)  // fin de l'exercice 
            {
                if (rep.InnerText == repEleve) { score++; }  // bonne reponse - incrementation du score
                /* affichage de la  fenetre fin de l'exercice  */
                EndExoTestFinal endExoTestFinal = new EndExoTestFinal(2,score);
                endExoTestFinal.Show();
                Ok.Visibility= Visibility.Hidden;
                timer.Stop();  // arreter le temps 
                /* affichage de la fenetre retour au menu test final, elle sert de guide */
                App.interfaceTestFinal.GoToExoMenu.Visibility = Visibility.Visible;
            }
            else // ce n'est pas encore la fin de l'exercice 
            {   
                /* desactiver les images ( choix ) car l'eleve n'a plus le droit de 
                 * changer son choix apres avoir validé */
                ImageChoix1.IsEnabled = false;
                ImageChoix2.IsEnabled = false;
                ImageChoix3.IsEnabled = false;
                if (rep.InnerText == repEleve) { score++; } // bonne reponse - incrementation du score
                Ok.Visibility = Visibility.Hidden;
                Next.Visibility = Visibility.Visible;
            } 
        }
        /*****************************************************************************/



        /*******************          السؤال التالي          ***********************/
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1); // son click 
            Ok.Visibility = Visibility.Hidden;
            Next.Visibility = Visibility.Hidden;

            /* reactiver les images */
            ImageChoix1.IsEnabled = true;
            ImageChoix2.IsEnabled = true;
            ImageChoix3.IsEnabled = true;

            /* recuperation de la prochaine question */
            if (i == totalQuestion) { i = 1; }
            else i++;
            path = "//Enigmes/Probleme" + i;
            GetQuestionFromFile(path);
            nbQuest++;
            ScoreTB.Inlines.Clear();
            ScoreTB.Inlines.Add(new Run("السؤال  :" + nbQuest + " /10"));

            /* animations des couleurs de la fenetre */
            ExoGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorBrushesBackground[j]));  
            QuestionRtb.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorBrushesRTB[k])); 
            j++;
            if (k == colorBrushesRTB.Count) { k = 0; }
            if (j == colorBrushesBackground.Count) { j = 0; } 
        }
        /*******************************************************************************/



       /** affichage de l'aide de l'exercice **/
       private void ClickHelp(object sender, System.Windows.RoutedEventArgs e)
        {
            Animations.AddSound(1);
            HelpExo l = new HelpExo (6) ;
			l.Show () ;
				
        }

    }
}
