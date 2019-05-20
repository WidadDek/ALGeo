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

namespace AlGeo.TestFinal.Exo1
{
    /// <summary>
    /// Logique d'interaction pour ExerciceVraiOuFaux.xaml
    /// </summary>
    public partial class ExerciceVraiOuFaux : Page,IExerciceTypeQuestionnaire
    {   /*Attributs*/
        /*Listes de couleurs*/
        private List<string> colorBrushesBackground = new List<string>() { "#FF125065", "#FF112F65", "#FF304254", "#d35400", "#f1c40f", "#e74c3c", "#FF112F65", "#FF125065" };
        private List<string> colorBrushesRTB = new List<string>() { "#FF1ABC9C", "#FF1ABC9C", "#FF455799" };
        /*Indices de parcours de listes*/
        private int j = 1;
        private int k = 0;
        private XmlDocument monFichier = new XmlDocument();//Pointeur vers le fichier xml qui contient les questions.
        private int i;//Indice de parcours de Questions.
        private int totalQuestion;// le nombre max de question à faire dans un seul essai.
        private string path;// Le chemin vers une Balise bien précise dans le fichier xml.
        private XmlNode choix;//Pointeur vers une balise du choix dans le fichier xml.
        private XmlNode quest;//Pointeur vers une balise de question dans le fichier xml.
        private XmlNode rep;//Pointeur vers une balise de reponse dans le fichier xml.
        private string repEleve;// la reponse de l'eleve.
        int score = 0;//variable de score
        int nbQuest = 0;//contient le combre de question deja faite par l'etudiant.
        private XmlNode questionChoisi;//Pointeur vers une balise qui contient l'indice de la premiere question faite dans le fichier xml.

        /**Methodes**/
        /**********************Implémentation de l'interface IExerciceTypeQuestionnaire*********************/

        /****GetQuestionFromFile: Recuperer une question à partir d'un fichier xml en utilisant son chemin
                 * Exemple: Recuperer question'i' du fichier:
                 * path= "//Chapitre3/Probleme'i'/".
                 * recuperer question : path+"/Q".***/
        public void GetQuestionFromFile(string path)
        {   /*Reccuperer la question et l'afficher*/
            quest = monFichier.SelectSingleNode(path + "/Q");
            Question.Inlines.Clear();
            Question.Inlines.Add(new Run(quest.InnerText));
            /*************************************/
            nbQuest++;//nombre de question faites est incrementé.
            /*afficher le nombre de question deja faite*/
            ScoreTB.Inlines.Clear();
            ScoreTB.Inlines.Add(new Run("السؤال  :" + nbQuest + " /10"));
            /******************************************/
        }
        /***********************************************************************************************/
        /*Constructeur:initialiser les variables totalQuestion,path,et afficher  la premiére Question et sauvegarder son indice dans le fichier.*/

        public ExerciceVraiOuFaux()
        {
            InitializeComponent();
            /*Ouverture du fichier des questions*/
            monFichier.Load("VraiOuFauxFile.xml");
            /************************************/
            /*Recuperer le nombre total de question à partir du fichier*/
            quest = monFichier.SelectSingleNode("//TestFinal/TotalQuestion");
            totalQuestion = int.Parse(quest.InnerText);
            /*******************************************************/
            /*Choix Aleatoire de question utilisant la fonction "RANDOM"*/
            while ((i > totalQuestion) || (i <= 0)) { i = new Random().Next(totalQuestion); }
            /***********************************************************/
            /*Reccuperation de la question du fichier*/
            path = "//TestFinal/Probleme" + i;
            GetQuestionFromFile(path);
            /***************************************/
            /*Sauvgarde de la premiere question choisit dans le fichier xml*/
            questionChoisi = monFichier.SelectSingleNode("//TestFinal/DebutQuestionsFaites");
            questionChoisi.InnerText = Convert.ToString(i);
            monFichier.Save("VraiOuFauxFile.xml");
            /**************************************************************/
        }
        /************************************************************/

        /*Traitement si l'eleve choisit la reponse "Vrai"*/
        private void True_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);//Ajout du son.
            Ok.Visibility = Visibility.Visible;//Bouton Valider devient disponible.
            repEleve = "true";//Sauvegarde de la reponse de l'élève.


        }
        /***********************************************************/

        /*Traitement si l'eleve choisit la reponse "Faux"*/
        private void False_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);//Ajout du son.
            Ok.Visibility = Visibility.Visible;//Bouton Valider devient disponible.
            repEleve = "false";//Sauvegarde de la reponse de l'élève.
        }
        /*******************************************************************/
        /*Le bouton valider*/
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);//son du bouton
            /*Recupperation de la reponse de la question courante du fichier*/
            rep = monFichier.SelectSingleNode(path + "/R");
            /*************************************************************/
            /*Si l'éléve répond à toutes les questions.*/
            if (nbQuest == 10)
            {   /* APPLAUSE */
                /*Calcul du score*/
                /*Si la reponse de l'eleve est correcte on incremente le score sinon on fait rien*/
                if (rep.InnerText == repEleve) { score++; }
                /*************************************************************************/
                EndExoTestFinal endExoTestFinal =new EndExoTestFinal(2,score);
                endExoTestFinal.Show();
                Ok.Visibility = Visibility.Hidden;// le btn valider indisponible.on ne valide qu'une seule fois.
                True.Visibility = Visibility.Hidden;//Le btn Vrai cachée pour ne pas changer la reponse.
                False.Visibility = Visibility.Hidden;//Le btn Faux cachée pour ne pas changer la reponse.
                App.interfaceTestFinal.GoToExoMenu.Visibility = Visibility.Visible;//Bouton de retour vers le menu des exercices du test final est disponible.
            }
            /*Si le nombre de question <nombre de question total*/
            else
            {  
                /*Calcul du score*/
                /*Si la reponse de l'eleve est correcte on incremente le score sinon on fait rien*/
                if (rep.InnerText == repEleve) { score++; }
                /*Reinitialiser les boutons De reponse: ils sont de nouveau disponible pour repondre a la prochaine question*/
                True.Visibility = Visibility.Visible;
                False.Visibility = Visibility.Visible;
                Ok.Visibility = Visibility.Hidden;
                /********************************************************/
                /*Si la fin du fichier est ateinte  et le nombre de question deja faites < 10 alors on revient au debut du fichier*/
                if (i == totalQuestion) { i = 1; }
                /***********************************/
                /*Sinon on continu*/
                else i++;
                /*****************/
                /*Reccuperation de la question du fichier*/
                path = "//TestFinal/Probleme" + i;
                GetQuestionFromFile(path);
                /***************************************/
                /*Changement de couleurs du background est du conteneur de la  question.*/
                VFGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorBrushesBackground[j]));
                richTextBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorBrushesRTB[k]));
                image.Source = Animations.GetImage(@"Images/image" + k + ".png");
                /*********************************************************************/
                k++;//parcours de la premiere liste de couleurs.
                j++;//parcours de la deuxieme liste de couleurs.
                if (k == colorBrushesRTB.Count) { k = 0; }//reinialiser si fin de liste
                if (j == colorBrushesBackground.Count) { j = 0; }//reinialiser si fin de liste
                /**************************************************************************/
            }
        }
          /*Bouton d'aide de l'exercice*/
		  private void ClickHelp(object sender, System.Windows.RoutedEventArgs e)
        {
            Animations.AddSound(1);//Ajout du son.
            /*L'affichage de l'aide.*/
            HelpExo l = new HelpExo (5) ;
			l.Show () ;
            /************************/
				
        } 
        /***************************************/
		
		
		

       
    }
}
