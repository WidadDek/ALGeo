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
    public partial class ExoDevineMot : Page
    {
        //booléen indiquant si l'élément est capturée ou pas//
        bool captured = false;
        //contient les coordonnées des éléments concernées par le drag & drop//
        double x_shape, x_canvas, y_shape, y_canvas;
        UIElement source = null;

        //Sauvgarde des coordonées initiales des cases proposées
        private double[] CoordonéesLabel = { 165.5, 660.5, 414.5, 84.5, 579, 331.5, 496.5, 5.5, 248.5 };

        //Tableau contenant le code héxadecimale de couleurs de l'arrière plan
        private List<string> colorBrushesBackground = new List<string>() { "#FF125065", "#FF112F65", "#FF304354", "#FF112F65", "#FF125065" };
        private List<string> colorBrushesRTB = new List<string>() { "#FF1ABC9C", "#FF1ABC9C", "#FF455799" };

        //Instance d'un fichier xml
        private XmlDocument monFichier = new XmlDocument();

        //l’indice de la question courante ,est tirée aléatoirement du fichier XML
        static private int CurrentQuestion;
        private int m = 1;
        private int k = 0;

        //le nombre total de questions xistantes tirée du fichier XML
        private int totalQuestion;
        //le lien vers le fichier XML,dépend de l'indice CurrentQuestion
        private string path;
        private XmlNode quest;
        //Contient l'indice de la première question choisie
        private XmlNode questionChoisi;
        //Contient la réponse correcte de la question courante
        // est tirée du fichier XML
        private XmlNode rep;
        //Contient la mot donné par l'élève
        private string repEleve = "";
        //Tableau dont chaque case est le caractere choisi par l'élève
        private string[] MotDonné = new string[10];

        //Contient le score de l'élève dans l'exercice
        private int score = 0;
        //Indice indiquant le nombre de question proposées
        private int nbQuest = 0;

        //Contient un compte a rebours du temps de tout le test final
        private DispatcherTimer timer = new DispatcherTimer();

        /*_______Retourne le nombre de question de cette exercice___*/
        public int GetNbQuest()
        { return (nbQuest); }

        /*___ ___*/
        public void shape_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            source = (UIElement)sender;
            Mouse.Capture(source);
            captured = true;
            x_shape = Canvas.GetLeft(source);
            x_canvas = e.GetPosition(canvasexercice).X;
            y_shape = Canvas.GetTop(source);
            y_canvas = e.GetPosition(canvasexercice).Y;
        }

        /*___ ___*/
        public void shape_MouseMove(object sender, MouseEventArgs e)
        {
            if (captured)
            {
                double x = e.GetPosition(canvasexercice).X;
                double y = e.GetPosition(canvasexercice).Y;
                x_shape += x - x_canvas;
                Canvas.SetLeft(source, x_shape);
                x_canvas = x;
                y_shape += y - y_canvas;
                Canvas.SetTop(source, y_shape);
                y_canvas = y;
                Label ab = (Label)sender;
                double ta = Canvas.GetTop(ab);
                double la = Canvas.GetLeft(ab);
                if ((ta < 76 && ta > 02) && (la < 154.5 && la > 114.2) && (Rep1.Visibility == Visibility.Visible))
                {
                    Canvas.SetLeft(ab, 134.5);
                    Canvas.SetTop(ab, 12);
                }
                if ((ta < 76 && ta > 02) && (la < 288.5 && la > 188.5) && (Rep2.Visibility == Visibility.Visible))
                {
                    Canvas.SetLeft(ab, 208.5);
                    Canvas.SetTop(ab, 12);
                }
                if ((ta < 76 && ta > 02) && (la < 302.5 && la > 262.5) && (Rep3.Visibility == Visibility.Visible))
                {
                    Canvas.SetLeft(ab, 282.5);
                    Canvas.SetTop(ab, 12);
                }
                if ((ta < 76 && ta > 02) && (la < 376.5 && la > 336.5) && (Rep4.Visibility == Visibility.Visible))
                {
                    Canvas.SetLeft(ab, 356.5);
                    Canvas.SetTop(ab, 12);
                }
                if ((ta < 76 && ta > 02) && (la < 450 && la > 410) && (Rep5.Visibility == Visibility.Visible))
                {
                    Canvas.SetLeft(ab, 430.5);
                    Canvas.SetTop(ab, 12);
                }
                if ((ta < 76 && ta > 02) && (la < 524.5 && la > 484) && (Rep6.Visibility == Visibility.Visible))
                {
                    Canvas.SetLeft(ab, 504.5);
                    Canvas.SetTop(ab, 12);
                }
            }
        }

        /*___________*/
        public void shape_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(null);
            captured = false;
        }

        /*Initialise les cases a leur emplacement initial en tirant les coordonée a partir d'un tableau*/
        public void InitEmplacemntCases()
        {
            object control;
            int l;
            for (l = 1; l < 10; l++)
            {
                //Cherche le control selon son nom
                control = DevineMotGrid.FindName("L" + l);
                //Le convertie en Label
                Label L = (Label)control;
                //Le postitionne dans le canvas selon les coordonées données
                Canvas.SetTop(L, 124);
                Canvas.SetLeft(L, CoordonéesLabel[l - 1]);
            }
        }



        /*Affiche des images a partir d'un autre emplacement en donnant son chemin */
        public static BitmapImage GetImage(string imageUri)
        {
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(imageUri, UriKind.RelativeOrAbsolute);
            bitmapImage.EndInit();
            return bitmapImage;
        }

        /* Récupere la question et ses images associées a partir d'un fichier xml */
        public void GetQuestionFromFile(string path)
        {
            Question.Inlines.Clear();
            Question.Inlines.Add(new Run(monFichier.SelectSingleNode(path + "/Q").InnerText));
            String image1 = monFichier.SelectSingleNode(path + "/Prop1").InnerText;
            ImageProp1.Source = GetImage(@"Images/" + image1);
            String image2 = monFichier.SelectSingleNode(path + "/Prop2").InnerText;
            ImageProp2.Source = GetImage(@"Images/" + image2);
        }


        /*Récupère le contenu des cases donnée par l'élève*/
        public void SetMotDonné()
        {
            object control;
            int l;
            for (l = 1; l < 10; l++)
            {
                control = DevineMotGrid.FindName("L" + l);
                Label L = (Label)control;
                if ((Canvas.GetLeft(L) == 134.5) && (Canvas.GetTop(L) == 12))
                {
                    MotDonné[0] = L.Content.ToString();
                }

                if ((Canvas.GetLeft(L) == 208.5) && (Canvas.GetTop(L) == 12))
                {
                    MotDonné[1] = L.Content.ToString();
                }

                if ((Canvas.GetLeft(L) == 282.5) && (Canvas.GetTop(L) == 12))
                {
                    MotDonné[2] = L.Content.ToString();
                }

                if ((Canvas.GetLeft(L) == 356.5) && (Canvas.GetTop(L) == 12))
                {
                    MotDonné[3] = L.Content.ToString();
                }

                if ((Canvas.GetLeft(L) == 430.5) && (Canvas.GetTop(L) == 12))
                {
                    MotDonné[4] = L.Content.ToString();
                }

                if ((Canvas.GetLeft(L) == 504.5) && (Canvas.GetTop(L) == 12))
                {
                    MotDonné[5] = L.Content.ToString();
                }
            }
        }


        /*Sauvgarde la réponse de l'élève  dans une chaine de caractère*/
        public void SetRepEleve(string path)
        {
            int j;
            repEleve = "";

            SetMotDonné();
            XmlNode NbCases = monFichier.SelectSingleNode(path + "/NbCase");
            int NbCase = int.Parse(NbCases.InnerText);
            for (j = 0; j < NbCase; j++)
            {
                repEleve = repEleve + MotDonné[j];
            }
        }


        /* Récupère les cases contenant les caracteres proposées a l'élève a partir d'un fichier xml */
        public void SetChamps(string path)
        {
            object control;
            int j;
            //Récupere l
            string Cases = monFichier.SelectSingleNode(path + "/CasesPropose").InnerText;
            for (j = 1; j < 10; j++)
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
                //Cherche le control selon son nom
                control = DevineMotGrid.FindName("Rep" + j);
                //Le convertie en Rectangle
                Rectangle L = (Rectangle)control;
                //Le rend Visible
                L.Visibility = Visibility.Visible;
            }
        }

        /* Rend les "n" cases inutiles a la question courante invisible*/
        public void SetInvisibleCases(string path)
        {
            object control;
            //Récuperer le nombre de cases invisible
            int NbVisibleCase = int.Parse(monFichier.SelectSingleNode(path + "/NbCase").InnerText);
            int j;
            for (j = NbVisibleCase + 1; j < 7; j++)
            {
                //Cherche le control selon son nom
                control = DevineMotGrid.FindName("Rep" + j);
                //Le convertie en rectangle
                Rectangle L = (Rectangle)control;
                //Le rend invisible
                L.Visibility = Visibility.Hidden;
            }
        }


        /* Constructeur de l'exercice */
        public ExoDevineMot()
        {
            InitializeComponent();
            //Chargement du fichier XML
            monFichier.Load("DevineMot.xml");

            Next.Visibility = Visibility.Hidden;
            //Récupere le nombre de question de l'exercice a partir du fichier
            quest = monFichier.SelectSingleNode("//TestFinal/TotalQuestion");
            totalQuestion = int.Parse(quest.InnerText);

            //Selection d'une question Aléatoirement 
            if (CurrentQuestion > totalQuestion) { CurrentQuestion = 1; }
            else CurrentQuestion++;

            //Sauvgarde de l'indice de la premiere question "utile pour le corigé"
            questionChoisi = monFichier.SelectSingleNode("//TestFinal/DebutQuestionsFaites");
            questionChoisi.InnerText = CurrentQuestion.ToString();
            monFichier.Save("DevineMot.xml");

            path = "//TestFinal/Probleme" + CurrentQuestion;

            //Remplir le RichTextBox et le StackPanel par la question et les images
            GetQuestionFromFile(path);

            //Remplir les cases par des lettres aléatoire
            SetChamps(path);
            nbQuest++;

            //Affiche le numéro de la question courante
            ScoreTB.Inlines.Clear();
            ScoreTB.Inlines.Add(new Run("السؤال  :" + nbQuest + " /5"));

            //Affiche le nombre de cases selon la taille du mot
            SetVisibleCases(path);
            SetInvisibleCases(path);
        }


        /*Instruction relatif a la confirmation de la réponse */
        public void Ok_Click(object sender, RoutedEventArgs e)
        {
            Ok.Visibility = Visibility.Collapsed;
            //Vérifie la véracité de la réponse de l'eleve 
            //On la comparant avec la bonne réponse du fichier xml
            rep = monFichier.SelectSingleNode(path + "/R");
            if (nbQuest == 5)
            {
                //Le vérifie avec la bonne réponses
                if (rep.InnerText == repEleve)
                {
                    score++;
                }
                EndExoTestFinal endExoTestFinal = new EndExoTestFinal(2,score);
                endExoTestFinal.Show();
                App.interfaceTestFinal.GoToExoMenu.Visibility = Visibility.Visible;
                Next.Visibility = Visibility.Collapsed;
            }
            else
            {
                Next.Visibility = Visibility.Visible;
                //Concatène le mot entré par l'élève a partir des cases
                SetRepEleve(path);
                //Le vérifie avec la bonne réponses
                if (rep.InnerText == repEleve)
                {
                    score++;
                }
            }
        }

        /*Instruction relatif au passage a la prochaine question */
        public void Next_Click(object sender, RoutedEventArgs e)
        {
            Ok.Visibility = Visibility.Visible;
            MotDonné = new string[10];
            //Cache le button de la question suivante
            Next.Visibility = Visibility.Hidden;

            //Réinitialise les cases dans leur champs
            InitEmplacemntCases();

            //S'il est arrivé a la dernière case il remet i a 1
            if (CurrentQuestion == totalQuestion) { CurrentQuestion = 1; }
            else CurrentQuestion++;

            path = "//TestFinal/Probleme" + CurrentQuestion;
            //Remplir le RichTextBox et le StackPanel par la question et les images
            GetQuestionFromFile(path);
            //Remplir les cases par des lettres aléatoire
            SetChamps(path);

            //Incrémente le numéro de la question courante
            nbQuest++;

            //Affiche le numéro de la question courante
            ScoreTB.Inlines.Clear();
            ScoreTB.Inlines.Add(new Run("السؤال  :" + nbQuest + " /5"));

            //Affiche le nombre de cases selon la taille du mot
            SetVisibleCases(path);
            SetInvisibleCases(path);

            //Change la couleur de fond de la Question
            DevineMotGrid.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorBrushesBackground[m]));
            richTextBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorBrushesRTB[k]));
            canvasexercice.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorBrushesBackground[m]));
            k++;
            m++;
            if (k == colorBrushesRTB.Count) { k = 0; }
            if (m == colorBrushesBackground.Count) { m = 0; }

        }

        /*___Procure le help de l'exercice___*/
        public void ClickHelp(object sender, RoutedEventArgs e)
        {
            HelpExo l = new HelpExo(9);
            l.Show();
        }
    }
}



