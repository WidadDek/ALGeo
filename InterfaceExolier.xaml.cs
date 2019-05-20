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
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;

namespace AlGeo
    {
        /// <summary>
        /// Interaction logic for InterfaceExolier.xaml
        /// </summary>
        public partial class InterfaceExolier : Page//interface de l'exercice lier
        {
            private string nomfichier;//le nom de fichier qui contient les mots de l'exercice
            private int id_exercice;//l' id de l'exercice relier
            private double x, y;//les coordonnées d'un mot dans la page
            private int i;//c'est un entier qui contient le numerp de la version qui sera récupérer a partir du fichier xml pour etre traité par l'étudiant
            private int ligne1 = 0, ligne2 = 0, ligne3 = 0, ligne4 = 0; //des variables qui permettre de savoir si les lignes sont déssinées
            private int[] rep = new int[20];//un tableau dans lequel on sauvegarde les réponses de l'étudiant
            private int[] cor = { 0, 2, 3, 4, 1 };//un tableau qui contient la coorection il sera util quand l'étudiant valide sa réponse
            Line line1 = new Line();//la déclaration de la premiere ligne
            Line line2 = new Line();//la déclaration de la 2éme ligne
            Line line3 = new Line();//la déclaration de la 3éme ligne
            Line line4 = new Line();//la déclaration de la 4éme ligne
            private int score = 0;//un entier qui contient le score de l'étudiant
            private int scoreFinal;//le score finale de l'exercice qui sera sauvegarder dans la base de donnée
            int ligne = 0;//un entier qui désignera le nombre de ligne déja déssinées
            DispatcherTimer timer = new DispatcherTimer();//la varaible de type timer 
            int time = 180;//le temps de l'exercice en secondes 
            private int indice_mot = 0;//l'indice du mot pour l'affectation des mots dans les labels
            private string num = "question";//le numéro de la version qui sera traitée
            private int alea_version = new Random().Next(3);//le numero de la version qui sera générer aléatoirement
            private int numChapitre;//le numero de chapitre
            FenetreEndExo fenetreEndExo;//fenetre de la fin de l'exercice 
            public InterfaceExolier(int numChapitre, int id_exercice)
            {

                InitializeComponent();
                this.numChapitre = numChapitre;//le numero du chapitre
                this.nomfichier = "chap" + numChapitre + ".xml";//le nom du fichier xml 
                this.id_exercice = id_exercice;
                valider.Visibility = Visibility.Hidden;//remettre le boutton de validation des réponses invissible
                Refaire.Visibility = Visibility.Hidden;//remettre le boutton de la correction des réponses invissible
                correction.Visibility = Visibility.Hidden;//remettre le boutton refaire invissible


                alea_version = alea_version + 1;//indice aléatoire de la version de l'exercice
                num = num + alea_version;
                XmlDocument monFichier = new XmlDocument();//poiteur vers un fichier xml
                monFichier.Load(nomfichier);//ouverture du fichier xml
                XmlNodeList lst = monFichier.GetElementsByTagName(num);//la construction d'une liste qui contient les mots de l'exercice

                foreach (XmlNode c in lst)
                {
                    indice_mot++;//incrémentation de l'indice du mot pour passer au mot suivant
                    if (indice_mot == 1) { l1.Text = c.InnerText; }//affecter le premier mot dans le label
                    if (indice_mot == 2) { l8.Text = c.InnerText; }//affecter le 2éme mot dans le label
                    if (indice_mot == 3) { l7.Text = c.InnerText; }//affecter le 3éme mot dans le label
                    if (indice_mot == 4) { l3.Text = c.InnerText; }//affecter le 4éme mot dans le label
                    if (indice_mot == 5) { l2.Text = c.InnerText; }//affecter le 5éme mot dans le label
                    if (indice_mot == 6) { l6.Text = c.InnerText; }//affecter le 6éme mot dans le label
                    if (indice_mot == 7) { l5.Text = c.InnerText; }//affecter le 7éme mot dans le label
                    if (indice_mot == 8) { l4.Text = c.InnerText; }//affecter le 8éme mot dans le label

                }


                timer.Tick += new EventHandler(Timer_Tick);
                timer.Interval = new TimeSpan(0, 0, 1);
                timer.Start();//le début de timer
                l3.IsEnabled = true;//donner l'accés a l'étudiant pour séléctionner le premier mot
                l8.IsEnabled = true;//donner l'accés a l'étudiant pour séléctionner le 2éme mot
                l7.IsEnabled = true;//donner l'accés a l'étudiant pour séléctionner le 3éme mot
                l1.IsEnabled = true;//donner l'accés a l'étudiant pour séléctionner le 4éme mot
                l2.IsEnabled = false;//donner l'accés a l'étudiant pour séléctionner le 5éme mot
                l6.IsEnabled = false;//donner l'accés a l'étudiant pour séléctionner le 6éme mot
                l5.IsEnabled = false;//donner l'accés a l'étudiant pour séléctionner le 7éme mot
                l4.IsEnabled = false;//donner l'accés a l'étudiant pour séléctionner le 8éme mot

            }


            private void label1(object sender, MouseButtonEventArgs e)//méthode qui sera executer en appuyant sur le premier mot (label1)
            {
                Animations.AddSound(1);
                i = 1;//pour dire que c'est le premier mot
                this.x = Canvas.GetTop(l1) + 32;//la récupération des coordoonnées
                this.y = Canvas.GetLeft(l1) + 220;//la récupération des coordoonnées
                if (ligne1 == 0) l2.IsEnabled = true;//si la premiere ligne est déssinée alors l'étudiant ne peut pas relier le mot une autre fois 
                if (ligne2 == 0) l6.IsEnabled = true;//si la 2éme ligne est déssinée alors l'étudiant ne peut pas relier le mot une autre fois 
                if (ligne3 == 0) l5.IsEnabled = true;//si la 3éme ligne est déssinée alors l'étudiant ne peut pas relier le mot une autre fois 
                if (ligne4 == 0) l4.IsEnabled = true;//si la 4éme ligne est déssinée alors l'étudiant ne peut pas relier le mot une autre fois 
                l1.Background = System.Windows.Media.Brushes.Pink;

            }

        private void Timer_Tick(object sender, EventArgs e)
        {

            if (time > 0)
            {
                ScorePB.Value += 120 - time;
                time--;
                if (time <= 10)
                {
                    CountDownTB.Foreground = Brushes.Red;
                    //ScorePB.Foreground = Brushes.Red;
                }

                else
                {
                    CountDownTB.Foreground = Brushes.White;
                }
                CountDownTB.Inlines.Clear();
                TimeSpan t = TimeSpan.FromSeconds(time);
                string strtime = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
                CountDownTB.Inlines.Add("الوقت المتبقي: " + strtime);
            }
            else
            {

                fenetreEndExo = new FenetreEndExo(1, score, 4, id_exercice);
                fenetreEndExo.Show();
                timer.Stop();
            }
        }
        private void label2(object sender, MouseButtonEventArgs e)//méthode qui sera executer en appuyant sur le 2éme mot (label2)
            {
                Animations.AddSound(1);//le son
                i = 2;//le 2éme mot
                this.x = Canvas.GetTop(l8) + 32;//la récupération des coordoonéees
                this.y = Canvas.GetLeft(l8) + 220;//la récupération des coordoonéees
                if (ligne1 == 0) l2.IsEnabled = true;//si la premiere ligne est déssinée alors l'étudiant ne peut pas relier le mot une autre fois 
                if (ligne2 == 0) l6.IsEnabled = true;//si la 2éme ligne est déssinée alors l'étudiant ne peut pas relier le mot une autre fois 
                if (ligne3 == 0) l5.IsEnabled = true;//si la 3éme ligne est déssinée alors l'étudiant ne peut pas relier le mot une autre fois 
                if (ligne4 == 0) l4.IsEnabled = true;//si la 4éme ligne est déssinée alors l'étudiant ne peut pas relier le mot une autre fois 
                l8.Background = System.Windows.Media.Brushes.Pink;//colorier le mot

            }
            private void label3(object sender, MouseButtonEventArgs e)//méthode qui sera executer en appuyant sur le 3éme mot (label3)
            {// le 3
                Animations.AddSound(1);
                i = 3;
                this.x = Canvas.GetTop(l7) + 32;//la récupération des coordoonéees
                this.y = Canvas.GetLeft(l7) + 220;//la récupération des coordoonéees
                if (ligne1 == 0) l2.IsEnabled = true;//si la premiere ligne est déssinée alors l'étudiant ne peut pas relier le mot une autre fois
                if (ligne2 == 0) l6.IsEnabled = true;//si la 2éme ligne est déssinée alors l'étudiant ne peut pas relier le mot une autre fois
                if (ligne3 == 0) l5.IsEnabled = true;//si la 3éme ligne est déssinée alors l'étudiant ne peut pas relier le mot une autre fois
                if (ligne4 == 0) l4.IsEnabled = true;//si la 4éme ligne est déssinée alors l'étudiant ne peut pas relier le mot une autre fois
                l7.Background = System.Windows.Media.Brushes.Pink;

            }
            private void label4(object sender, MouseButtonEventArgs e)//méthode qui sera executer en appuyant sur le 4éme mot (label4)
            {//le 4
                Animations.AddSound(1);//le son
                i = 4;
                this.x = Canvas.GetTop(l3) + 32;//la récupération des coordoonéees
                this.y = Canvas.GetLeft(l3) + 220;//la récupération des coordoonéees
                if (ligne1 == 0) l2.IsEnabled = true;//si la premiere ligne est déssinée alors l'étudiant ne peut pas relier le mot une autre fois
                if (ligne2 == 0) l6.IsEnabled = true;//si la 2éme ligne est déssinée alors l'étudiant ne peut pas relier le mot une autre fois
                if (ligne3 == 0) l5.IsEnabled = true;//si la 3éme ligne est déssinée alors l'étudiant ne peut pas relier le mot une autre fois
                if (ligne4 == 0) l4.IsEnabled = true;//si la 4éme ligne est déssinée alors l'étudiant ne peut pas relier le mot une autre fois
                l3.Background = System.Windows.Media.Brushes.Pink;

            }
            private void label5(object sender, MouseButtonEventArgs e)//méthode qui sera executer en appuyant sur le 5éme mot (label5)
            {
                Animations.AddSound(1);
                rep[i] = 1;//sauvegarde de la réponse
                ligne++;//incrémenter le nombre de ligne
                line1.Y1 = x;//initialiser les paramétres de la ligne (x)
                line1.Y2 = Canvas.GetTop(l2) + 32;//initialiser les paramétres de la ligne (y)
                line1.X1 = y;
                line1.X2 = Canvas.GetLeft(l2);
                line1.Stroke = System.Windows.Media.Brushes.DarkCyan;
                line1.StrokeThickness = 3;//dessiner la ligne
                canvaslines.Children.Add(line1);
                if (ligne == 4)//si le nombre de ligne est égale a 4 
                {
                    valider.Visibility = Visibility.Visible;//permettre a l'étudiant de valider
                }
                Refaire.Visibility = Visibility.Visible;//permettre a l'étudiant de refaire l'exercice
                ligne1 = 1;//pour dire que la ligne1 est déssinée
                l2.IsEnabled = false;
            }


            private void label6(object sender, MouseButtonEventArgs e)//méthode qui sera executer en appuyant sur le 6éme mot (label6)
            {
                Animations.AddSound(1);
                rep[i] = 2;//sauvegarde de la réponse
                ligne++;//incrémenter le nombre de ligne
                ligne2 = 1;//pour dire que la ligne2 est déssinée
                line2.Y1 = x;//initialiser les paramétres de la ligne (x)
                line2.Y2 = Canvas.GetTop(l6) + 32;
                line2.X1 = y;//initialiser les paramétres de la ligne (y)
                line2.X2 = Canvas.GetLeft(l6);
                line2.Stroke = System.Windows.Media.Brushes.Yellow;
                line2.StrokeThickness = 3;//dessiner la ligne
                canvaslines.Children.Add(line2);
                if (ligne == 4) { valider.Visibility = Visibility.Visible; }//permettre a l'étudiant de valider
                l6.IsEnabled = false;
                Refaire.Visibility = Visibility.Visible;//permettre a l'étudiant de refaire l'exercice
            }



            private void label7(object sender, MouseButtonEventArgs e)//méthode qui sera executer en appuyant sur le 7éme mot (label7)
            {// la mme chose que la méthode précedente
                Animations.AddSound(1);
                rep[i] = 3;
                ligne++;
                ligne3 = 1;
                line3.Y1 = x;
                line3.Y2 = Canvas.GetTop(l5) + 32;
                line3.X1 = y;
                line3.X2 = Canvas.GetLeft(l5);
                line3.Stroke = System.Windows.Media.Brushes.Orange;
                line3.StrokeThickness = 3;
                canvaslines.Children.Add(line3);
                if (ligne == 4) { valider.Visibility = Visibility.Visible; }
                l5.IsEnabled = false;
                Refaire.Visibility = Visibility.Visible;
            }
            private void label8(object sender, MouseButtonEventArgs e)//méthode qui sera executer en appuyant sur le 8éme mot (label8)
            {// la mme chose que la méthode précedente
                Animations.AddSound(1);
                rep[i] = 4;
                ligne++;
                ligne4 = 1;
                line4.Y1 = x;
                line4.Y2 = Canvas.GetTop(l4) + 32;
                line4.X1 = y;
                line4.X2 = Canvas.GetLeft(l4);
                line4.Stroke = System.Windows.Media.Brushes.White;
                line4.StrokeThickness = 3;
                canvaslines.Children.Add(line4);
                if (ligne == 4) { valider.Visibility = Visibility.Visible; }
                l4.IsEnabled = false;
                Refaire.Visibility = Visibility.Visible;
            }


            private void Button_Click_1(object sender, RoutedEventArgs e)//méthode qui sera executer si l'étudiant valide sa réponse
            {//valider
                Animations.AddSound(1);
                timer.Stop();
                Refaire.Visibility = Visibility.Hidden;//le boutton refaire devient invissible
                correction.Visibility = Visibility.Visible;//le boutton de correction devient vissible
                valider.Visibility = Visibility.Hidden;//le boutton de validation devient invissible
                l6.IsEnabled = false;//l'étudiant ne peut pas appuyer sur le label
                l2.IsEnabled = false;//l'étudiant ne peut pas appuyer sur le label
                l5.IsEnabled = false;//l'étudiant ne peut pas appuyer sur le label
                l4.IsEnabled = false;//l'étudiant ne peut pas appuyer sur le label
                l3.IsEnabled = false;//l'étudiant ne peut pas appuyer sur le label
                l8.IsEnabled = false;//l'étudiant ne peut pas appuyer sur le label
                l7.IsEnabled = false;//l'étudiant ne peut pas appuyer sur le label
                l1.IsEnabled = false;//l'étudiant ne peut pas appuyer sur le label
                if (rep[4] == cor[4]) //si la réponse de l'étudiant est juste
                {
                    line1.Stroke = System.Windows.Media.Brushes.Green; //afficher la ligne en vert
                    score++;//incrémenter le score
                }
                else { line1.Stroke = System.Windows.Media.Brushes.Red; }
                if (rep[1] == cor[1])//si la réponse de l'étudiant est juste
                {
                    line2.Stroke = System.Windows.Media.Brushes.Green;
                    score++;//incrémenter le score
                }
                else { line2.Stroke = System.Windows.Media.Brushes.Red; }
                if (rep[2] == cor[2])//si la réponse de l'étudiant est juste
                {
                    line3.Stroke = System.Windows.Media.Brushes.Green;
                    score++;//incrémenter le score
                }
                else { line3.Stroke = System.Windows.Media.Brushes.Red; }
                if (rep[3] == cor[3])//si la réponse de l'étudiant est juste
                {
                    line4.Stroke = System.Windows.Media.Brushes.Green;
                    score++;//incrémenter le score
                }
                else { line4.Stroke = System.Windows.Media.Brushes.Red; }
                sauvegardeScore();//sauvegarde de score
                Exercice exercice = new Exercice();
                if (scoreFinal != 0)
                {
                    exercice.sauvegarderScore(id_exercice, scoreFinal);//la sauvegarde de score dans la bdd
                }
                fenetreEndExo = new FenetreEndExo(2, score, 4, id_exercice);
                fenetreEndExo.Show();//afficher la fenetre de la fin de l'exercice

            }
            private void sauvegardeScore()//méthode pour sauvegarder le score
            {
                this.scoreFinal = score;
            }
            private void Button_Click_2(object sender, RoutedEventArgs e)//une méthode qui affiche la correction de l'exercice
            {//correction
                Animations.AddSound(1);
                canvaslines.Children.Remove(line1);//supprimer les lignes 
                canvaslines.Children.Remove(line2);
                canvaslines.Children.Remove(line3);
                canvaslines.Children.Remove(line4);
                line1.Y1 = Canvas.GetTop(l3) + 32;//redéssiner la ligne1
                line1.Y2 = Canvas.GetTop(l2) + 32;
                line1.X1 = Canvas.GetLeft(l3) + 220;
                line1.X2 = Canvas.GetLeft(l2);
                line1.Stroke = System.Windows.Media.Brushes.Pink;
                line1.StrokeThickness = 3;
                canvaslines.Children.Add(line1);

                line2.Y1 = Canvas.GetTop(l1) + 32;//redéssiner la ligne2
                line2.Y2 = Canvas.GetTop(l6) + 32;
                line2.X1 = Canvas.GetLeft(l1) + 220;
                line2.X2 = Canvas.GetLeft(l6);
                line2.Stroke = System.Windows.Media.Brushes.Pink;
                line2.StrokeThickness = 3;
                canvaslines.Children.Add(line2);

                line3.Y1 = Canvas.GetTop(l8) + 32;//redéssiner la ligne3
                line3.Y2 = Canvas.GetTop(l5) + 32;
                line3.X1 = Canvas.GetLeft(l8) + 220;
                line3.X2 = Canvas.GetLeft(l5);
                line3.Stroke = System.Windows.Media.Brushes.Pink;
                line3.StrokeThickness = 3;
                canvaslines.Children.Add(line3);

                line4.Y1 = Canvas.GetTop(l7) + 32;//redéssiner la ligne4
                line4.Y2 = Canvas.GetTop(l4) + 32;
                line4.X1 = Canvas.GetLeft(l7) + 220;
                line4.X2 = Canvas.GetLeft(l4);
                line4.Stroke = System.Windows.Media.Brushes.Pink;
                line4.StrokeThickness = 3;
                canvaslines.Children.Add(line4);
            }

            private void Refaire_Click(object sender, RoutedEventArgs e)//méthode qui permet a l'étudiant de refaire l'exercice
            {//refaire
                Animations.AddSound(1);
                canvaslines.Children.Remove(line1);//supprimer la ligne1
                canvaslines.Children.Remove(line2);//supprimer la ligne2
                canvaslines.Children.Remove(line3);//supprimer la ligne3
                canvaslines.Children.Remove(line4);//supprimer la ligne4
                valider.Visibility = Visibility.Hidden;//remettre le boutton de validation invissible

                ligne1 = 0;//pour dire que la premier ligne n'est pas encore déssinée
                ligne2 = 0;//pour dire que la 2éme ligne n'est pas encore déssinée
                ligne3 = 0;//pour dire que la 3éme ligne n'est pas encore déssinée
                ligne4 = 0;//pour dire que la 4éme ligne n'est pas encore déssinée
                ligne = 0;//rénitialiser le nombre de ligne par 0
                l1.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF1ABC9C"));
                l8.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF1ABC9C"));
                l7.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF1ABC9C"));
                l3.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF1ABC9C"));

            }

            private void ClickHelp(object sender, System.Windows.RoutedEventArgs e)//affichage du help de l'exercice
            {
                Animations.AddSound(1);
                HelpExo l = new HelpExo(4);//affichage du help
                l.Show();
            }

            private void Exit_Click(object sender, RoutedEventArgs e)//méthode qui permet de sortir de l'exercice
            {
                Animations.AddSound(1);//le son
                timer.Stop();//arreter le temps
                switch (numChapitre)//pour revenir a la fenetre précédente
                {
                    case 1:
                        this.NavigationService.Navigate(new InterfaceExercice(1));
                        break;
                    case 2:
                        this.NavigationService.Navigate(new InterfaceExercice(2));
                        break;
                    case 3:
                        this.NavigationService.Navigate(new InterfaceExercice(3));
                        break;

                }

            }
        }
    }



