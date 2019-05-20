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

namespace AlGeo.TestFinal.Exo4
{
    /// <summary>
    /// Interaction logic for ExerciceRelier.xaml
    /// </summary>
    public partial class ExerciceRelier : Page
    {

        DispatcherTimer timer = new DispatcherTimer();
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
        public ExerciceRelier()
        {
            InitializeComponent();
            valider.Visibility = Visibility.Hidden;
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
            this.x = Canvas.GetTop(l1) + 27;//la récupération des coordoonnées
            this.y = Canvas.GetLeft(l1) + 261;//la récupération des coordoonnées
            if (ligne1 == 0) l2.IsEnabled = true;//si la premiere ligne est déssinée alors l'étudiant ne peut pas relier le mot une autre fois 
            if (ligne2 == 0) l6.IsEnabled = true;//si la 2éme ligne est déssinée alors l'étudiant ne peut pas relier le mot une autre fois 
            if (ligne3 == 0) l5.IsEnabled = true;//si la 3éme ligne est déssinée alors l'étudiant ne peut pas relier le mot une autre fois 
            if (ligne4 == 0) l4.IsEnabled = true;//si la 4éme ligne est déssinée alors l'étudiant ne peut pas relier le mot une autre fois 
            l1.Background = System.Windows.Media.Brushes.Pink;
        }

        private void label2(object sender, MouseButtonEventArgs e)//méthode qui sera executer en appuyant sur le 2éme mot (label2)
        {
            Animations.AddSound(1);//le son
            i = 2;//le 2éme mot
            this.x = Canvas.GetTop(l8) + 27;//la récupération des coordoonéees
            this.y = Canvas.GetLeft(l8) + 261;//la récupération des coordoonéees
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
            this.x = Canvas.GetTop(l7) + 27;//la récupération des coordoonéees
            this.y = Canvas.GetLeft(l7) + 261;//la récupération des coordoonéees
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
            this.x = Canvas.GetTop(l3) + 27;//la récupération des coordoonéees
            this.y = Canvas.GetLeft(l3) + 261;//la récupération des coordoonéees
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
            line1.Y2 = Canvas.GetTop(l2) + 27;//initialiser les paramétres de la ligne (y)
            line1.X1 = y;
            line1.X2 = Canvas.GetLeft(l2);
            line1.Stroke = System.Windows.Media.Brushes.DarkCyan;
            line1.StrokeThickness = 3;//dessiner la ligne
            canvaslines.Children.Add(line1);
            if (ligne == 4)//si le nombre de ligne est égale a 4 
            {
                valider.Visibility = Visibility.Visible;//permettre a l'étudiant de valider
            }

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
            line2.Y2 = Canvas.GetTop(l6) + 27;
            line2.X1 = y;//initialiser les paramétres de la ligne (y)
            line2.X2 = Canvas.GetLeft(l6);
            line2.Stroke = System.Windows.Media.Brushes.Yellow;
            line2.StrokeThickness = 3;//dessiner la ligne
            canvaslines.Children.Add(line2);
            if (ligne == 4) { valider.Visibility = Visibility.Visible; }//permettre a l'étudiant de valider
            l6.IsEnabled = false;

        }



        private void label7(object sender, MouseButtonEventArgs e)//méthode qui sera executer en appuyant sur le 7éme mot (label7)
        {// la mme chose que la méthode précedente
            Animations.AddSound(1);
            rep[i] = 3;
            ligne++;
            ligne3 = 1;
            line3.Y1 = x;
            line3.Y2 = Canvas.GetTop(l5) + 27;
            line3.X1 = y;
            line3.X2 = Canvas.GetLeft(l5);
            line3.Stroke = System.Windows.Media.Brushes.Orange;
            line3.StrokeThickness = 3;
            canvaslines.Children.Add(line3);
            if (ligne == 4) { valider.Visibility = Visibility.Visible; }
            l5.IsEnabled = false;

        }
        private void label8(object sender, MouseButtonEventArgs e)//méthode qui sera executer en appuyant sur le 8éme mot (label8)
        {// la mme chose que la méthode précedente
            Animations.AddSound(1);
            rep[i] = 4;
            ligne++;
            ligne4 = 1;
            line4.Y1 = x;
            line4.Y2 = Canvas.GetTop(l4) + 27;
            line4.X1 = y;
            line4.X2 = Canvas.GetLeft(l4);
            line4.Stroke = System.Windows.Media.Brushes.White;
            line4.StrokeThickness = 3;
            canvaslines.Children.Add(line4);
            if (ligne == 4) { valider.Visibility = Visibility.Visible; }
            l4.IsEnabled = false;

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {//valider
            Animations.AddSound(1);
            App.interfaceTestFinal.GoToExoMenu.Visibility = Visibility.Visible;
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

                score++;//incrémenter le score
            }

            if (rep[1] == cor[1])//si la réponse de l'étudiant est juste
            {

                score++;//incrémenter le score
            }

            if (rep[2] == cor[2])//si la réponse de l'étudiant est juste
            {

                score++;//incrémenter le score
            }

            if (rep[3] == cor[3])//si la réponse de l'étudiant est juste
            {

                score++;//incrémenter le score
            }

            EndExoTestFinal endExoTestFinal = new EndExoTestFinal(2,score);
            endExoTestFinal.Show();
            timer.Stop();
        }
        private void ClickHelp(object sender, System.Windows.RoutedEventArgs e)//affichage du help de l'exercice
        {
            Animations.AddSound(1);
            HelpExo l = new HelpExo(4);//affichage du help
            l.Show();
        }


    }
}
