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

namespace AlGeo
{
    /// <summary>
    /// Logique d'interaction pour InterfaceExerciceQCM.xaml
    /// </summary>
    public partial class InterfaceExerciceQCM : Page,IExerciceTypeQuestionnaire
    {
        /*Attributs*/
        /*Listes de couleurs*/
        private List<string> colorBrushesBackground = new List<string>() { "#FF125065", "#FF112F65", "#FF304354", "#FF0C5192", "#FFFFE196", "#FF112F65", "#FF125065" };
        private List<string> colorBrushesRTB = new List<string>() { "#FF1ABC9C", "#FF1ABC9C", "#FF455799", "#e74c3c" };
        /*Indices de parcours de listes*/
        private int j = 1;
        private int k = 0;

        private int numChapitre;//Le numero du Chapitre
        private XmlDocument monFichier = new XmlDocument();//Pointeur vers le fichier xml qui contient les questions.
        private int id_Exercice;
        private int i;//Indice de parcours de Questions.
        private int totalQuestion;// le nombre max de question à faire dans un seul essai.
        private string path;// Le chemin vers une Balise bien précise dans le fichier xml.
        private XmlNode choix;//Pointeur vers une balise du choix dans le fichier xml.
        private XmlNode quest;//Pointeur vers une balise de question dans le fichier xml.
        private XmlNode rep;//Pointeur vers une balise de reponse dans le fichier xml.
        private int repEleve;// la reponse de l'eleve.
        int score = 0;//variable de score
        int nbQuest = 0;//contient le combre de question deja faite par l'etudiant.
        FenetreEndExo fenetreEndExo;//instance de la fenetre de fin d'exercice
        DispatcherTimer timer = new DispatcherTimer();
        int time = 240;// Le temps max de l'exo.



        /**Methodes**/
/**********************Implémentation de l'interface IExerciceTypeQuestionnaire*********************/

/****GetQuestionFromFile: Recuperer une question à partir d'un fichier xml en utilisant son chemin
         * Exemple: Recuperer question'i' du fichier:
         * path= "//Chapitre3/Probleme'i'/".
         * recuperer question : path+"/Q".
         * recuperer choix: path+"Choix'j'. j={1,2,3}.***/
        public void GetQuestionFromFile(string path)
        {    /*Reccuperer la question et l'afficher*/
            Question.Inlines.Clear();
            Question.Inlines.Add(new Run(monFichier.SelectSingleNode(path + "/Q").InnerText));
            /*Recuperer les choix et les afficher*/
            Choix1.Inlines.Clear();
            Choix1.Inlines.Add(new Run(monFichier.SelectSingleNode(path + "/Choix1").InnerText));
            Choix2.Inlines.Clear();
            Choix2.Inlines.Add(new Run(monFichier.SelectSingleNode(path + "/Choix2").InnerText));
            Choix3.Inlines.Clear();
            Choix3.Inlines.Add(new Run(monFichier.SelectSingleNode(path + "/Choix3").InnerText));

        }
/**********************************************************************************************/
        
/*Constructeur:initialiser les variables numChapitre,id_Exercice et Afficher la premiére Question.*/
        public InterfaceExerciceQCM(int numChapitre, int id_Exercice)

        {   /*Initialiser les variables*/
            this.numChapitre = numChapitre;
            this.id_Exercice = id_Exercice;
            /***************************/
            InitializeComponent();

            /*Ouverture du fichier des questions*/
            monFichier.Load("Chapitre" + numChapitre + ".xml");
            /***********************************************/

            /*Recuperer le nombre total de question à partir du fichier*/
            totalQuestion = int.Parse(monFichier.SelectSingleNode("//Chapitre" + numChapitre + "/TotalQuestion").InnerText);
            /*********************************************************************************************************/

            /*Choix Aleatoire de question utilisant la fonction "RANDOM"*/
            while ((i > totalQuestion) || (i <= 0)) { i = new Random().Next(totalQuestion); }
            /***************************************************************************/

            /*Initialiser le temp*/
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
            /*******************************/

            /*Reccuperation de la question et de ces choix*/
            path = "//Chapitre" + numChapitre + "/Probleme" + i;
            GetQuestionFromFile(path);
            /********************************************/

            nbQuest++;//incrémenter le nombre de questions deja faites.

            /*Affichage du score actuel ainsi que le nombre de la question actuel*/
            ScoreTB.Inlines.Clear();
            ScoreTB.Inlines.Add(new Run("السؤال  :  " + nbQuest + " /8"));
            ScoreShowTB.Inlines.Clear();
            ScoreShowTB.Inlines.Add(new Run("النتيجة  :  " + score + " /8"));
            /*******************************************************************/
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            /*Si l'éléve répond à toutes les questions avant que le temps finisse*/
            if (nbQuest == 9)

            {    /*Affichage du fenetre que lui indique le score*/
                fenetreEndExo = new FenetreEndExo(2, score, 8,id_Exercice); fenetreEndExo.Show();
                /****************************************************/
                
                timer.Stop();//Le temps s'arrete.

                /*modification de l'interface*/

                /*Images de correction cachées.*/
                for (int k = 1; k <= 3; k++)
                {
                    Image comment = this.FindName("comment" + k) as Image;
                    comment.Source = null;                 
                }
                /*****************************/
                GoToMenu.Visibility = Visibility.Visible;//Bouton de retour au menu visible.
                Next.Visibility = Visibility.Hidden;//Bouton de passage a une autre question chaché.
                Ok.Visibility = Visibility.Hidden;//Bouton de validation caché.
                /**********************************************************/
            }
            /**********************************************************************/
            /*S'il reste encore de temps*/

            if (time >= 0)
            {
                /*Si temps<=10 on l'affiche en rouge:ALERT*/
                if (time <= 10)
                {
                    CountDownTB.Foreground = Brushes.Red;
                    ScorePB.Foreground = Brushes.Red;
                }
                /*Sinon on l'affiche en blanc.*/
                else { CountDownTB.Foreground = Brushes.White; }
                CountDownTB.Inlines.Clear();
                TimeSpan t = TimeSpan.FromSeconds(time);
                string strtime = string.Format("{0:D2}:{1:D2}",t.Minutes,t.Seconds);
                CountDownTB.Inlines.Add("الوقت المتبقي: " + strtime);
                time--;//Dans les deux cas on le décremonte. 
            }
            /*********************************************************************/
            /*S'il ne reste pas de temps*/
            else
            {   /*S'il tremine toutes les questions juste juste avec le temps:*/
                if (nbQuest == 8)
                {
                    /*Affichage du fenetre que lui indique le score*/
                    fenetreEndExo = new FenetreEndExo(2, score, 8, id_Exercice); fenetreEndExo.Show();
                    /****************************************************/
                }

                else
                { 
                    /*Affichage du fenetre que lui indique le score et que le temp a fini avant qu'il termine.*/
                    fenetreEndExo = new FenetreEndExo(1, score, 8,id_Exercice); fenetreEndExo.Show();
                    /****************************************************/
                }

                timer.Stop();//Le temps s'arrete.
                /*****************************/
                GoToMenu.Visibility = Visibility.Visible;//Bouton de retour au menu visible.
                Next.Visibility = Visibility.Hidden;//Bouton de passage a une autre question chaché.
                Ok.Visibility = Visibility.Hidden;//Bouton de validation caché.
                /**********************************************************/
            }
        }
        /*******************************************************************/
        /*Le bouton valider*/
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);//son du bouton
            Ok.Visibility = Visibility.Hidden;//le btn valider indisponible.on ne valide qu'une seule fois.
            /*Si le nombre de question <nombre de question total:le btn aller a la question suivante est disponible*/
            if (nbQuest < 8) Next.Visibility = Visibility.Visible;
            /******************************************************/
            /*Reinitialiser les boutons radios*/
            for (int nb = 1; nb <= 3; nb++)
            {
                RadioButton r = this.FindName("r" + nb) as RadioButton;
                r.IsEnabled = false;
            }
            /************************************/
            /*Reccupération de la raponse de la question courante du fichier*/
            rep = monFichier.SelectSingleNode(path + "/R");
            /************************************************************/
            /*Affichage de la correction*/
            CorrectionQcm(int.Parse(rep.InnerText), repEleve);
            /*******************************/
            nbQuest++;//nombre de questions deja faites est incrementé.





        }


        /****************************************************************************************/
        /*La méthode CorrectionQcm  affiche la correction de la question courante : 
         * Si la réponse de l’élève  correspond à la réponse type « rep=repEleve » 
         * on affiche de plus un commentaire ‘réponse juste ‘, 
         * Sinon on affiche ‘réponse fausse’. 
         * Elle ne retourne rien.*/
        private void CorrectionQcm(int rep, int repEleve)
        {  
            /*Modification de l'interface selon la reponse type rep
              Si rep==i ,i={1,2,3} alors on affiche devant le choix 'i' l'image "vrai" 
              et sa couleur devient vert. la couleur de choix de l'eleve  devient rouge
               si il est faux et on affiche devant eux l'image "faux"*/
            if (rep == 1)
            {   
                Choix1Rtb.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF27C04C"));
                comment1.Source = Animations.GetImage(@"Images/True.png");
                comment2.Source = Animations.GetImage(@"Images/False.png");
                comment3.Source = Animations.GetImage(@"Images/False.png");
            }
            else if (rep == 2)
            {
                Choix2Rtb.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF27C04C"));
                comment2.Source = Animations.GetImage(@"Images/True.png");
                comment1.Source = Animations.GetImage(@"Images/False.png");
                comment3.Source = Animations.GetImage(@"Images/False.png");
            }
            else
            {
                Choix3Rtb.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF27C04C"));
                comment3.Source = Animations.GetImage(@"Images/True.png");
                comment2.Source = Animations.GetImage(@"Images/False.png");
                comment1.Source = Animations.GetImage(@"Images/False.png");
            }
            /***********************************************************/
            /*Si la reponse de l'eleve est juste*/
            if (rep == repEleve)
            {
                score++;//on incrémonte le score.
                /*on Affiche le score.*/
                ScoreShowTB.Inlines.Clear();
                ScoreShowTB.Inlines.Add(new Run("النتيجة  :  " + score + " /8"));
                /***********************/
                /*on affiche un commentaire: bonne reponse*/
                Question.Inlines.Clear();
                Question.Inlines.Add(new Run("احسنت!اجابة صحيحة."));
                /******************************************/
            }
            /*********************************/
            /*Si la reponse de l'eleve est fausse*/
            else
            {    /*on affiche un commentaire: bonne reponse*/
                Question.Inlines.Clear();
                Question.Inlines.Add(new Run("للاسف!اجابة خاطئة."));
                /****************************************************/
                /*Le choix de l'eleve sera en rouge */
                if (repEleve == 1) Choix1Rtb.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFEC0C0C"));
                else if (repEleve == 2) Choix2Rtb.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFEC0C0C"));
                else Choix3Rtb.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFEC0C0C"));
                /************************************/
            }

        }
        /*Traitement si l'eleve choisit la premiere reponse*/
        private void r1_Checked(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);//le son 
            repEleve = 1;//Sauvgarde du choix de l'eleve.
            Ok.Visibility = Visibility.Visible;// bouton valider est mnt disponible.

        }
        /************************************************/
        /*Traitement si l'eleve choisit la deuxiéme reponse*/
        private void r2_Checked(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);
            repEleve = 2;
            Ok.Visibility = Visibility.Visible;

        }
        /*************************************************/
        /*Traitement si l'eleve choisit la troisiéme reponse*/
        private void r3_Checked(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);
            repEleve = 3;
            Ok.Visibility = Visibility.Visible;
        }
        /***************************************************/
        /*Bouton Aller a la prochaine question*/
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);//Ajout de son
            Ok.Visibility = Visibility.Hidden;//bouton valider indisponible
            Next.Visibility = Visibility.Hidden;//bouton Aller a la prochaine question indisponible
            /*Si la fin du fichier est atieinte  et le nombre de question deja faites < 8 alors on revient au debut du fichier*/
            if (i == totalQuestion) { i = 1; }
            /***********************************/
            /*Sinon on continu*/
            else i++;
            /*****************/
            /*Reccuperation de la question et de ces choix*/
            path = "//Chapitre" + numChapitre + "/Probleme" + i;
            GetQuestionFromFile(path);
            /********************************************/
            /*Affichage du score actuel ainsi que le nombre de la question actuel*/
            ScoreTB.Inlines.Clear();
            ScoreTB.Inlines.Add(new Run("السؤال  :  " + nbQuest + " /8"));
            /*******************************************/
            for (int nb = 1; nb <= 3; nb++)
            {   /*Reinitialisation des  boutons radios*/
                RadioButton r = this.FindName("r" + nb) as RadioButton;
                r.IsEnabled = true;
                r.IsChecked = false;
                /**************************************/
                /*Reinitialisation des images commentaires*/     
                Image comment = this.FindName("comment" + nb) as Image;
                comment.Source = null;
                /********************************************/
            }
            /*Changement de couleurs du background est des conteneurs des la  question et de ces choix*/
            QcmGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorBrushesBackground[j]));
            QuestionRtb.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorBrushesRTB[k]));
            Choix1Rtb.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorBrushesRTB[k]));
            Choix2Rtb.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorBrushesRTB[k]));
            Choix3Rtb.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorBrushesRTB[k]));
            image.Source = Animations.GetImage(@"Images/image" + k + ".png");
            /*************************************************************************************/
            k++;//parcours de la premiere liste de couleurs.
            j++;//parcours de la deuxieme liste de couleurs.
            if (k == colorBrushesRTB.Count) { k = 0; }//reinialiser si fin de liste
            if (j == colorBrushesBackground.Count) { j = 0; }//reinialiser si fin de liste
        }
        /*************************************************************************************/
        /*Le bouton de retour a la page des exercices*/
        private void GoToMenu_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);//Son du bouton
            timer.Stop();//le temps s'arrete quelque soit.
            /*Choix des exercices selon le chapitre courant*/
            switch (numChapitre)
            {
                case 1://on est dans le premier chapitre.le bouton de retour nous guide vers la page des exercice du premier chapitre.
                    this.NavigationService.Navigate(new InterfaceExercice(1));                    
                    break;
                case 2://on est dans le deuxiemee chapitre.le bouton de retour nous guide vers la page des exercice du deuxieme chapitre.
                    this.NavigationService.Navigate(new InterfaceExercice(2));
                    break;
                case 3://on est dans le troisiéme chapitre.le bouton de retour nous guide vers la page des exercice du troisiéme chapitre.
                    this.NavigationService.Navigate(new InterfaceExercice(3));
                    break;
            }
        }

    }


}

