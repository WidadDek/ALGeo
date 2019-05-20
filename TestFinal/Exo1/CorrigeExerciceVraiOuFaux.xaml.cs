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

    public partial class CorrigeExerciceVraiOuFaux : Page, IExerciceTypeQuestionnaire
    {  /*Attributs*/
        /*Listes de couleurs*/
        private List<string> colorBrushesBackground = new List<string>() { "#FF125065", "#FF112F65", "#FF304354", "#d35400", "#f1c40f", "#e74c3c", "#FF112F65", "#FF125065" };
        private List<string> colorBrushesRTB = new List<string>() { "#FF1ABC9C", "#FF1ABC9C", "#FF455799" };
        /*Indices de parcours de listes*/
        private int j = 1;
        private int k = 0;
        private XmlDocument monFichier = new XmlDocument();//Pointeur vers le fichier xml qui contient les questions.
        private int i;//Indice de parcours de Questions.
        private int totalQuestion;// le nombre max de question à faire dans un seul essai.
        private string path;// Le chemin vers une Balise bien précise dans le fichier xml.
        private XmlNode quest;//Pointeur vers une balise de question dans le fichier xml.
        private XmlNode rep;//Pointeur vers une balise de reponse dans le fichier xml.
        private int questionChoisi;//indice du parcours des questions dans le fichier.
        int nbQuest = 1;//contient le nombre de question corrigée deja affiché.

        /**Methodes**/
        /**********************Implémentation de l'interface IExerciceTypeQuestionnaire*********************/

        /****GetQuestionFromFile: Recuperer une question à partir d'un fichier xml en utilisant son chemin
                 *Pour Afficher sa correction.
                 * Exemple: Recuperer question'i' du fichier:
                 * path= "//Chapitre3/Probleme'i'/".
                 * recuperer question : path+"/Q".
                 * recupperer sa reponse:path+"/R"  ****/
        public void GetQuestionFromFile(string path)
        {   /*Reccuperer la question et l'afficher*/
            quest = monFichier.SelectSingleNode(path + "/Q");
            Question.Inlines.Clear();
            Question.Inlines.Add(new Run(quest.InnerText));
            /*************************************/
            /*Reccuperer la reponse et l'afficher*/
            rep = monFichier.SelectSingleNode(path + "/R");
            Response.Inlines.Clear();
            if (rep.InnerText == "true")
            { Response.Inlines.Add(new Run("صحيح")); }
            else { Response.Inlines.Add(new Run("خطا")); }
            /************************************/

            /*Afficher le nombre de question deja corrigé*/
            ScoreTB.Inlines.Clear();
            ScoreTB.Inlines.Add(new Run("السؤال  :" + nbQuest + " /10"));
            /*******************************************/
        }
        /***********************************************************************************************/
        /*Constructeur:initialiser les variables totalQuestion,path,et afficher  la premiére Question et sa correction.*/

        public CorrigeExerciceVraiOuFaux()
        {
            InitializeComponent();
            /*Ouverture du fichier des questions*/
            monFichier.Load("VraiOuFauxFile.xml");
            /************************************/
            /*Recuperer le nombre total de question à partir du fichier*/
            quest = monFichier.SelectSingleNode("//TestFinal/TotalQuestion");
            totalQuestion = int.Parse(quest.InnerText);
            /*******************************************************/
            /*Recuperer l'indice de la premiere question choisit par la fonction random pour generer les questions aleatoirement.*/
            questionChoisi = int.Parse(monFichier.SelectSingleNode("//TestFinal/DebutQuestionsFaites").InnerText);
            /****************************************************/
            /*Reccuperation de la question et de sa correction et on les affichent. */
            path = "//TestFinal/Probleme" + questionChoisi;
            GetQuestionFromFile(path);
            Previous.IsEnabled = false;
            /****************************************************/
        }

        /*Methode d'affichage de la correction de la question suivante*/
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);//Ajout du son.
            Previous.IsEnabled = true;//retour vers la question précedente disponible
            /*Si la correction de la question courante affiché n'est pas la plus derniere (dixéme)*/
            if (nbQuest < 10)
            {
                Next.IsEnabled = true;//Bouton suivant toujours disponible.
                nbQuest++;//Incrementation du nombre de questions deja corrigées et affichée.
                questionChoisi++;//passant à la question suivante dans le fichier.
                /*Si la fin du fichier est ateinte  et le nombre de question deja faites < 10 alors on revient au debut du fichier.*/
                if (questionChoisi == (totalQuestion + 1)) { questionChoisi = 1; }
                /********************************************************/
                /*Reccuperation de la question et de sa correction et on les affichent. */
                path = "//TestFinal/Probleme" + questionChoisi;
                GetQuestionFromFile(path);
                /*****************************************************************/
                /*Changement de couleurs du background est du conteneur de la  question.*/
                VFGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorBrushesBackground[j]));
                richTextBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorBrushesRTB[k]));
                responsertb.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorBrushesRTB[k]));
                image.Source = Animations.GetImage(@"Images/image" + k + ".png");
                /***********************************************************/

                k++;//parcours de la premiere liste de couleurs.
                j++;//parcours de la deuxieme liste de couleurs.
                if (k == colorBrushesRTB.Count) { k = 0; }//reinialiser si fin de liste
                if (j == colorBrushesBackground.Count) { j = 0; }//reinialiser si fin de liste
                /**************************************************************************/
            }
            /*Si toutes les questions sont corrigées on ne peut pas passer à la question suivante.*/
            if (nbQuest == 10) { Next.IsEnabled = false; }


        }
        /*Methode d'affichage de la correction de la question précedente*/
        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);//Ajout du son.
            Next.IsEnabled = true;//L'aller vers la question suivante disponible.
            /*Si la correction de la question courante affiché n'est pas la premiere*/
            if (nbQuest > 1)
            {
                Previous.IsEnabled = true;//Bouton précédent toujours disponible.
                nbQuest--;//Decrementation du nombre de questions deja corrigées et affichées.
                questionChoisi--;//revenant à la question précedente dans le fichier.
                /*Si on est arrivé au debut du fichier: on revient a la derniére  question dans le fichier xml*/
                if (questionChoisi == 0)
                { questionChoisi = totalQuestion; }
                /*********************************************************************************/
                /*Reccuperation de la question et de sa correction et on les affichent. */
                path = "//TestFinal/Probleme" + questionChoisi;
                GetQuestionFromFile(path);
                /*****************************************************************/
                /*Changement de couleurs du background est du conteneur de la  question.*/
                VFGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorBrushesBackground[j]));
                richTextBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorBrushesRTB[k]));
                responsertb.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorBrushesRTB[k]));
                image.Source = Animations.GetImage(@"Images/image" + k + ".png");
                /***********************************************************/

                k++;//parcours de la premiere liste de couleurs.
                j++;//parcours de la deuxieme liste de couleurs.
                if (k == colorBrushesRTB.Count) { k = 0; }//reinialiser si fin de liste
                if (j == colorBrushesBackground.Count) { j = 0; }//reinialiser si fin de liste
                /**************************************************************************/
                if (nbQuest == 1) { Previous.IsEnabled = false; }


            }
        }
    }
}
