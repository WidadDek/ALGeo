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

namespace AlGeo.TestFinal.Exo3
{
    public partial class CorrigeExoDevineMot : Page
    {
        private List<string> colorBrushesBackground = new List<string>() { "#FF125065", "#FF112F65", "#FF304354", "#FF112F65", "#FF125065" };
        private List<string> colorBrushesRTB = new List<string>() { "#FF1ABC9C", "#FF1ABC9C", "#FF455799" };
        private XmlDocument monFichier = new XmlDocument();

        static private int CurrentQuestion;
        private int m = 1;
        private int k = 0;
        private int totalQuestion;
        private string path;
        private XmlNode quest;
        private XmlNode questionChoisi;

        int nbQuest = 1;
        DispatcherTimer timer = new DispatcherTimer();

        public int GetNbQuest()
        { return (nbQuest); }


        /*Affiche des images a partir d'un autre emplacement en donnant son chemin */
        private static BitmapImage GetImage(string imageUri)
        {
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(imageUri, UriKind.RelativeOrAbsolute);
            bitmapImage.EndInit();
            return bitmapImage;
        }

        /* Récupere la question et ses images associées a partir d'un fichier xml */
        private void GetQuestionFromFile(string path)
        {
            Question.Inlines.Clear();
            Question.Inlines.Add(new Run(monFichier.SelectSingleNode(path + "/Q").InnerText));
            String image1 = monFichier.SelectSingleNode(path + "/Prop1").InnerText;
            ImageProp1.Source = GetImage(@"Images/" + image1);
            String image2 = monFichier.SelectSingleNode(path + "/Prop2").InnerText;
            ImageProp2.Source = GetImage(@"Images/" + image2);
        }


        /*Récupère la question et ses images associées a partir d'un fichier xml */
        public void SetChamps(string path)
        {
            object control;
            int j;
            int NbVisibleCase = int.Parse(monFichier.SelectSingleNode(path + "/NbCase").InnerText);
            string Cases = monFichier.SelectSingleNode(path + "/R").InnerText;
            for (j = 1; j <= NbVisibleCase; j++)
            {
                control = DevineMotGrid.FindName("L" + j);
                Label L = (Label)control;
                L.Content = Cases.Substring(j - 1, 1);
            }
        }



        /* Rend les "n" cases Utiles a la question courante Visible*/
        /*le nombre n est lu a partir d'un fichier xml*/
        public void SetVisibleCases(string path)
        {
            //Récuperer le nombre de cases visible
            object control;
            int j;
            int NbVisibleCase = int.Parse(monFichier.SelectSingleNode(path + "/NbCase").InnerText);
            for (j = 1; j <= NbVisibleCase; j++)
            {
                control = DevineMotGrid.FindName("L" + j);
                Label L = (Label)control;
                L.Visibility = Visibility.Visible;
            }
        }


        /* Rend les "n" cases inutiles a la question courante invisible*/
        /*le nombre n est lu a partir d'un fichier xml*/
        public void SetInvisibleCases(string path)
        {
            //Récuperer le nombre de cases invisible
            object control;
            int NbVisibleCase = int.Parse(monFichier.SelectSingleNode(path + "/NbCase").InnerText);
            int j;
            for (j = NbVisibleCase + 1; j < 7; j++)
            {
                control = DevineMotGrid.FindName("L" + j);
                Label L = (Label)control;
                L.Visibility = Visibility.Collapsed;
            }
        }

        /*
                //Constructeur de l'exercice 
                public CorrigeExoDevineMot()
                {
                    InitializeComponent();
                    //Chargement du fichier XML
                    monFichier.Load("DevineMot.xml");

                    //Sauvgarde de l'indice de la premiere question "utile pour le corigé"
                    questionChoisi = monFichier.SelectSingleNode("//TestFinal/DebutQuestionsFaites");
                    CurrentQuestion = int.Parse(questionChoisi.InnerText);
                    path = "//TestFinal/Probleme" + CurrentQuestion;

                    //Remplir le RichTextBox et le StackPanel par la question et les images
                    GetQuestionFromFile(path);
                    SetChamps(path);

                    //Affiche le numéro de la question courante
                    ScoreTB.Inlines.Clear();
                    ScoreTB.Inlines.Add(new Run("السؤال  :" + nbQuest + " /5"));

                    //Affiche le nombre de cases selon la taille du mot
                    SetVisibleCases(path);
                    SetInvisibleCases(path);
                    Previous.IsEnabled = false;
                }


                //Instruction relatif au passage a la question précedente
                private void Previous_Click(object sender, RoutedEventArgs e)
                {
                    Next.IsEnabled = true;
                    if (nbQuest == 0)
                    {
                        //Cache le button de la question precedente
                        Previous.IsEnabled = false;
                    }
                    else
                    {
                        if (nbQuest == 6) nbQuest = 5;
                        //S'il est arrivé a la première case il remet i au nombre total de questions
                        if (CurrentQuestion == 1) { CurrentQuestion = totalQuestion; }
                        else CurrentQuestion--;

                        path = "//TestFinal/Probleme" + CurrentQuestion;
                        //Remplir le RichTextBox et le StackPanel par la question et les images
                        GetQuestionFromFile(path);
                        SetChamps(path);

                        //Decrémente le numéro de la question courante
                        nbQuest--;

                        //Affiche le numéro de la question courante
                        ScoreTB.Inlines.Clear();
                        ScoreTB.Inlines.Add(new Run("السؤال  :" + nbQuest + " /5"));

                        //Affiche le nombre de cases selon la taille du mot
                        SetVisibleCases(path);
                        SetInvisibleCases(path);

                       //Change la couleur de fond de la Question
                        DevineMotGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorBrushesBackground[m]));
                        richTextBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorBrushesRTB[k]));
                        k--;
                        m--;
                        if (k == colorBrushesRTB.Count) { k = 0; }
                        if (m == colorBrushesBackground.Count) { m = 0; } 
                    }

                }

              //  Instruction relatif au passage a la prochaine question 
                private void Next_Click(object sender, RoutedEventArgs e)
                {
                    Previous.IsEnabled = true;

                    if (nbQuest == 6)
                    {
                        //Cache le button de la question suivante
                        Next.IsEnabled = false;
                    }
                    else
                    {
                        if (nbQuest == 0)
                        {
                            nbQuest = 1;
                            Previous.IsEnabled = false;
                        }
                        else
                        {
                            if (CurrentQuestion == totalQuestion) { CurrentQuestion = 1; }
                            else CurrentQuestion++;
                            //Incrémente le numéro de la question courante
                            nbQuest++;

                            path = "//TestFinal/Probleme" + CurrentQuestion;
                            //Remplir le RichTextBox et le StackPanel par la question et les images
                            GetQuestionFromFile(path);
                            SetChamps(path);



                            //Affiche le numéro de la question courante
                            ScoreTB.Inlines.Clear();
                            ScoreTB.Inlines.Add(new Run("السؤال  :" + nbQuest + " /5"));

                            //Affiche le nombre de cases selon la taille du mot
                            SetVisibleCases(path);
                            SetInvisibleCases(path);

                                     //Change la couleur de fond de la Question
                                     DevineMotGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorBrushesBackground[m]));
                                     richTextBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorBrushesRTB[k]));
                                     k++;
                                     m++;
                                     if (k == colorBrushesRTB.Count) { k = 0; }
                                     if (m == colorBrushesBackground.Count) { m = 0; } 
                            //S'il est arrivé a la dernière case il remet i a 1

                        }
                    }
                } */
        /*Constructeur:initialiser les variables totalQuestion,path,et afficher  la premiére Question et sa correction.*/

        public CorrigeExoDevineMot()
        {
            InitializeComponent();
            /*Ouverture du fichier des questions*/
            monFichier.Load("DevineMot.xml");
            /************************************/
            /*Recuperer le nombre total de question à partir du fichier*/
            quest = monFichier.SelectSingleNode("//TestFinal/TotalQuestion");
            totalQuestion = int.Parse(quest.InnerText);
            /*******************************************************/
            /*Recuperer l'indice de la premiere question choisit par la fonction random pour generer les questions aleatoirement.*/
            questionChoisi = monFichier.SelectSingleNode("//TestFinal/DebutQuestionsFaites");
            CurrentQuestion = int.Parse(questionChoisi.InnerText);
            /****************************************************/
            /*Reccuperation de la question et de sa correction et on les affichent. */
            path = "//TestFinal/Probleme" + CurrentQuestion;
            GetQuestionFromFile(path);
            SetChamps(path);
            //Affiche le nombre de cases selon la taille du mot
            SetVisibleCases(path);
            SetInvisibleCases(path);

            Previous.IsEnabled = false;
            /****************************************************/
        }

        /*Methode d'affichage de la correction de la question suivante*/
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);//Ajout du son.
            Previous.IsEnabled = true;//retour vers la question précedente disponible
            /*Si la correction de la question courante affiché n'est pas la plus derniere (dixéme)*/
            if (nbQuest < 5)
            {
                Next.IsEnabled = true;//Bouton suivant toujours disponible.
                nbQuest++;//Incrementation du nombre de questions deja corrigées et affichée.
                CurrentQuestion++;//passant à la question suivante dans le fichier.
                /*Si la fin du fichier est ateinte  et le nombre de question deja faites < 10 alors on revient au debut du fichier.*/
                if (CurrentQuestion == (totalQuestion + 1)) { CurrentQuestion = 1; }
                /********************************************************/
                /*Reccuperation de la question et de sa correction et on les affichent. */
                path = "//TestFinal/Probleme" + CurrentQuestion;
                GetQuestionFromFile(path);
                SetChamps(path);
                SetInvisibleCases(path);
                SetVisibleCases(path);
                /*****************************************************************/
                /*Changement de couleurs du background est du conteneur de la  question.
                VFGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorBrushesBackground[j]));
                richTextBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorBrushesRTB[k]));
                responsertb.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorBrushesRTB[k]));
                image.Source = Animations.GetImage(@"Images/image" + k + ".png");
                /***********************************************************/

                /*  k++;//parcours de la premiere liste de couleurs.
                  j++;//parcours de la deuxieme liste de couleurs.
                  if (k == colorBrushesRTB.Count) { k = 0; }//reinialiser si fin de liste
                  if (j == colorBrushesBackground.Count) { j = 0; }//reinialiser si fin de liste
                  /**************************************************************************/
            }
            /*Si toutes les questions sont corrigées on ne peut pas passer à la question suivante.*/
            if (nbQuest == 5) { Next.IsEnabled = false; }


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
                CurrentQuestion--;//revenant à la question précedente dans le fichier.
                                  /*Si on est arrivé au debut du fichier: on revient a la derniére  question dans le fichier xml*/
                if (CurrentQuestion == 0)
                { CurrentQuestion = totalQuestion; }
                /*********************************************************************************/
                /*Reccuperation de la question et de sa correction et on les affichent. */
                path = "//TestFinal/Probleme" + CurrentQuestion;
                GetQuestionFromFile(path);
                SetChamps(path);
                SetInvisibleCases(path);
                SetVisibleCases(path);
                if (nbQuest == 1) { Previous.IsEnabled = false; }

            }
        }
    }
}
