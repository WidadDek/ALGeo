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
    /// Interaction logic for InterfaceExerciceRemplirChamp3.xaml
    /// </summary>
    public partial class InterfaceExerciceRemplirChamp3 : Page//interface de l'exercice remplir les champs

    {
        private string motchoisi;//une chaine de caractére qui contient le mot courant qui été choisi par l'étudiant
        private int id_exercice;//un entier qui contient l'id de l'exercice afin de sauvegarder le score
        private int score = 0;//un entier pour calculer le score de l'étudiant dans l'exercice
        private int scoreFinal;//le score fianle de l'étudiant dans l'exercice
        FenetreEndExo fenetreEndExo;//une fenetres qui s'affiche a la fin de l'exercice ;
        private string[] tabRep = new string[] { "", "      طبيعية", "       موارد", "      البحرية", "       الثروة", "       الحديد", "      البترول", "       نسبة", "", "" };//le tableau qui contient les réponses de l'exercice
        DispatcherTimer timer = new DispatcherTimer();//la variable de temps
        int time = 240;//une variable qui contient le temps le l'exercice
        public InterfaceExerciceRemplirChamp3(int id_exercice)//interface de l'exercice remplir les champs
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 1);//choisir l'intervale du temps i.e le timer s'incrémente a chaque seconde
            timer.Tick += Timer_Tick;//incrémenter le variable du temps 
            this.id_exercice = id_exercice;//initialiser le id de l'exercice par l'entier envoyer en paramétre
            timer.Start();//déclencher le timer au début de l'exercice
            b1.IsEnabled = true;//donner l'accée a l'étudiant au  mot 1 de la liste
            b2.IsEnabled = true;//donner l'accée a l'étudiant au  mot 2 de la liste
            b3.IsEnabled = true;//donner l'accée a l'étudiant au  mot 3 de la liste
            b4.IsEnabled = true;//donner l'accée a l'étudiant au  mot 4 de la liste
            b5.IsEnabled = true;//donner l'accée a l'étudiant au  mot 5 de la liste
            b6.IsEnabled = true;//donner l'accée a l'étudiant au  mot 6 de la liste
            b7.IsEnabled = true;//donner l'accée a l'étudiant au  mot 7 de la liste
            l1.IsEnabled = true;//donner l'accée a l'étudiant pour remplir le vide de block1 dans le text proposé
            l2.IsEnabled = true;//donner l'accée a l'étudiant pour remplir le vide de block2 dans le text proposé
            l3.IsEnabled = true;//donner l'accée a l'étudiant pour remplir le vide de block3 dans le text proposé
            l4.IsEnabled = true;//donner l'accée a l'étudiant pour remplir le vide de block4 dans le text proposé
            l5.IsEnabled = true;//donner l'accée a l'étudiant pour remplir le vide de block5 dans le text proposé
            l6.IsEnabled = true;//donner l'accée a l'étudiant pour remplir le vide de block6 dans le text proposé
            l7.IsEnabled = true;//donner l'accée a l'étudiant pour remplir le vide de block7 dans le text proposé
            int indiceMot = 0;//l'indice du mot courant pour la récupération des mots a partir du fichier
            XmlDocument monFichier = new XmlDocument();//une variable de type fichier xml afin d'ouvrir le fichier
            monFichier.Load("FichRemplirChamps.xml");//ouverture de fichier qui contient les mots de l'exercice
            XmlNodeList lst = monFichier.GetElementsByTagName("chapitre3");//la récupération des mots dans une liste afin de les affecter dans les labels
            foreach (XmlNode c in lst)//on parcours la liste élément par élément pour affecter les mots
            {
                indiceMot++;//on incrémente la variable pour passer au mot suivant
                if (indiceMot == 1) { l1.Content = c.InnerText; }//affecter le mot dans le label1 (le premier mot dans la liste proposée)
                if (indiceMot == 2) { l2.Content = c.InnerText; }//affecter le mot dans le label2
                if (indiceMot == 3) { l3.Content = c.InnerText; }//affecter le mot dans le label3
                if (indiceMot == 4) { l4.Content = c.InnerText; }//affecter le mot dans le label4
                if (indiceMot == 5) { l5.Content = c.InnerText; }//affecter le mot dans le label5
                if (indiceMot == 6) { l6.Content = c.InnerText; }//affecter le mot dans le label6
                if (indiceMot == 7) { l7.Content = c.InnerText; }//affecter le mot dans le label7


            }
            valider.Visibility = Visibility.Hidden;//remettre le boutton de validation invisible
            corriger.Visibility = Visibility.Hidden;//remettre le boutton de correction invisible

        }
        private void Timer_Tick(object sender, EventArgs e)
        {




            if (time > 0)
            {
                // ScorePB.Value += 120 - time;
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
                //time--;
            }
            else
            {

                App.fenetreEndExo = new FenetreEndExo(1, scoreFinal, 7, id_exercice);
                App.fenetreEndExo.Show();
                timer.Stop();
            }
        }

        private void lab1(object sender, MouseButtonEventArgs e)//méthode qui sera executer En appuyant sur le premier mot de la liste
        {
            Animations.AddSound(1);//le son 
            motchoisi = l1.Content.ToString();//on affecte le mot du label dans la variable motChoisi qui contient de dernier mot sélectionner
            l1.Background = System.Windows.Media.Brushes.Pink;//on modifie la couleur du mot pour montrer a l'éléve que le mot a été déja séléctionner
        }


        private void lab2(object sender, MouseButtonEventArgs e)//méthode qui sera executer En appuyant sur le deuxiéme mot de la liste
        {
            Animations.AddSound(1);//le son 
            motchoisi = l2.Content.ToString();//on affecte le mot du label dans la variable motChoisi qui contient de dernier mot sélectionner
            l2.Background = System.Windows.Media.Brushes.Pink;//on modifie la couleur du mot pour montrer a l'éléve que le mot a été déja séléctionner
        }

        private void lab3(object sender, MouseButtonEventArgs e)//méthode qui sera executer En appuyant sur le troisiéme mot de la liste
        {
            Animations.AddSound(1);//le son
            motchoisi = l3.Content.ToString();//on affecte le mot du label dans la variable motChoisi qui contient de dernier mot sélectionner
            l3.Background = System.Windows.Media.Brushes.Pink;//on modifie la couleur du mot pour montrer a l'éléve que le mot a été déja séléctionner

        }

        private void lab4(object sender, MouseButtonEventArgs e)//méthode qui sera executer En appuyant sur le quatriéme mot de la liste
        {
            Animations.AddSound(1);//le son
            motchoisi = l4.Content.ToString();//on affecte le mot du label dans la variable motChoisi qui contient de dernier mot sélectionner
            l4.Background = System.Windows.Media.Brushes.Pink;//on modifie la couleur du mot pour montrer a l'éléve que le mot a été déja séléctionner
        }

        private void lab5(object sender, MouseButtonEventArgs e)//méthode qui sera executer En appuyant sur le cinqiéme mot de la liste
        {
            Animations.AddSound(1);//le son
            motchoisi = l5.Content.ToString();//on affecte le mot du label dans la variable motChoisi qui contient de dernier mot sélectionner
            l5.Background = System.Windows.Media.Brushes.Pink;//on modifie la couleur du mot pour montrer a l'éléve que le mot a été déja séléctionner
        }

        private void lab6(object sender, MouseButtonEventArgs e)//méthode qui sera executer En appuyant sur le 6iéme mot de la liste
        {
            Animations.AddSound(1);//le son
            motchoisi = l6.Content.ToString();//on affecte le mot du label dans la variable motChoisi qui contient de dernier mot sélectionner
            l6.Background = System.Windows.Media.Brushes.Pink;//on modifie la couleur du mot pour montrer a l'éléve que le mot a été déja séléctionner
        }

        private void lab7(object sender, MouseButtonEventArgs e)//méthode qui sera executer En appuyant sur le 7iéme mot de la liste
        {
            Animations.AddSound(1);//le son
            motchoisi = l7.Content.ToString();//on affecte le mot du label dans la variable motChoisi qui contient de dernier mot sélectionner
            l7.Background = System.Windows.Media.Brushes.Pink;//on modifie la couleur du mot pour montrer a l'éléve que le mot a été déja séléctionner
        }


        private void block1(object sender, MouseButtonEventArgs e)//méthode qui sera executer en appuyant sur le premier vide dans le text
        {
            b1.Text = motchoisi;//affecter le mot qui a été récupérer de la liste dans le premier vide

            b1.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF1ABC9C"));//colorier le vide
            if (b1.Text != "" && b2.Text != "" && b3.Text != "" && b4.Text != "" && b5.Text != "" && b6.Text != "" && b7.Text != "") //tester si tout les vides sont remplis
            {
                valider.Visibility = Visibility.Visible; //remettre le boutton de validation a vrai pour que l'étudiant peut valider ses réponses
            }
        }

        private void block2(object sender, MouseButtonEventArgs e)//méthode qui sera executer en appuyant sur le 2iéme vide dans le text
        {
            b2.Text = motchoisi;//affecter le mot qui a été récupérer de la liste dans le 2iéme vide
            b2.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF1ABC9C"));
            if (b1.Text != "" && b2.Text != "" && b3.Text != "" && b4.Text != "" && b5.Text != "" && b6.Text != "" && b7.Text != "")
            {
                valider.Visibility = Visibility.Visible;//remettre le boutton de validation a vrai pour que l'étudiant peut valider ses réponses
            }
        }

        private void block3(object sender, MouseButtonEventArgs e)//méthode qui sera executer en appuyant sur le 3iéme vide dans le text
        {
            b3.Text = motchoisi;//affecter le mot qui a été récupérer de la liste dans le 3iéme vide
            b3.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF1ABC9C"));//colorier le vide
            if (b1.Text != "" && b2.Text != "" && b3.Text != "" && b4.Text != "" && b5.Text != "" && b6.Text != "" && b7.Text != "")
            {
                valider.Visibility = Visibility.Visible; //remettre le boutton de validation a vrai pour que l'étudiant peut valider ses réponses
            }
        }

        private void block4(object sender, MouseButtonEventArgs e)//méthode qui sera executer en appuyant sur le 4iéme vide dans le text
        {
            b4.Text = motchoisi;//affecter le mot qui a été récupérer de la liste dans le 4iéme vide
            b4.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF1ABC9C"));//colorier le vide
            if (b1.Text != "" && b2.Text != "" && b3.Text != "" && b4.Text != "" && b5.Text != "" && b6.Text != "" && b7.Text != "")
            {
                valider.Visibility = Visibility.Visible; //remettre le boutton de validation a vrai pour que l'étudiant peut valider ses réponses
            }
        }

        private void block5(object sender, MouseButtonEventArgs e)//méthode qui sera executer en appuyant sur le 5iéme vide dans le text
        {
            b5.Text = motchoisi;//affecter le mot qui a été récupérer de la liste dans le 5iéme vide
            b5.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF1ABC9C"));
            if (b1.Text != "" && b2.Text != "" && b3.Text != "" && b4.Text != "" && b5.Text != "" && b6.Text != "" && b7.Text != "")
            {
                valider.Visibility = Visibility.Visible; //remettre le boutton de validation a vrai pour que l'étudiant peut valider ses réponses
            }
        }

        private void block6(object sender, MouseButtonEventArgs e)//méthode qui sera executer en appuyant sur le 6iéme vide dans le text
        {
            b6.Text = motchoisi;//affecter le mot qui a été récupérer de la liste dans le 6iéme vide
            b6.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF1ABC9C"));
            if (b1.Text != "" && b2.Text != "" && b3.Text != "" && b4.Text != "" && b5.Text != "" && b6.Text != "" && b7.Text != "")
            {
                valider.Visibility = Visibility.Visible;//remettre le boutton de validation a vrai pour que l'étudiant peut valider ses réponses
            }
        }

        private void block7(object sender, MouseButtonEventArgs e)//méthode qui sera executer en appuyant sur le 7iéme vide dans le text
        {
            b7.Text = motchoisi;//affecter le mot qui a été récupérer de la liste dans le 7iéme vide
            b7.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF1ABC9C"));
            if (b1.Text != "" && b2.Text != "" && b3.Text != "" && b4.Text != "" && b5.Text != "" && b6.Text != "" && b7.Text != "")
            {
                valider.Visibility = Visibility.Visible;//remettre le boutton de validation a vrai pour que l'étudiant peut valider ses réponses
            }
        }

        private void valider_Click(object sender, RoutedEventArgs e)//cette méthode sera executé quand l'étudiant valide ses réponses
        {//validation de la réponse
            Animations.AddSound(1);//le son
            timer.Stop();//arreter le temps
            if (b1.Text == tabRep[1])//tester si la réponse de l'éléve est juste
            {
                b1.Foreground = Brushes.Green; //le mot sera afficher en vert pour montere a l'étudiant que sa réponse est juste
                score++;//incrémenter le score
            }
            else//si la réponse est fausse 
            {
                b1.Foreground = Brushes.Red;//afficher le mot en rouge
            }
            if (b2.Text == tabRep[2])//tester si la réponse de l'éléve est juste
            {
                b2.Foreground = Brushes.Green; //le mot sera afficher en vert pour montere a l'étudiant que sa réponse est juste
                score++;//incrémenter le score
            }
            else
            {
                b2.Foreground = Brushes.Red; //afficher le mot en rouge
            }
            if (b3.Text == tabRep[3])//tester si la réponse de l'éléve est juste
            {
                b3.Foreground = Brushes.Green; //le mot sera afficher en vert pour montere a l'étudiant que sa réponse est juste
                score++; //incrémenter le score
            }
            else
            {
                b3.Foreground = Brushes.Red; //afficher le mot en rouge
            }
            if (b4.Text == tabRep[4])//tester si la réponse de l'éléve est juste
            {
                b4.Foreground = Brushes.Green; //le mot sera afficher en vert pour montere a l'étudiant que sa réponse est juste
                score++; //incrémenter le score
            }
            else
            {
                b4.Foreground = Brushes.Red; //afficher le mot en rouge
            }
            if (b5.Text == tabRep[5]) //tester si la réponse de l'éléve est juste
            {
                b5.Foreground = Brushes.Green;//le mot sera afficher en vert pour montere a l'étudiant que sa réponse est juste
                score++; //incrémenter le score
            }
            else
            {
                b5.Foreground = Brushes.Red; //afficher le mot en rouge
            }
            if (b6.Text == tabRep[6])//tester si la réponse de l'éléve est juste
            {
                b6.Foreground = Brushes.Green;//le mot sera afficher en vert pour montere a l'étudiant que sa réponse est juste
                score++;//incrémenter le score
            }
            else
            {
                b6.Foreground = Brushes.Red; //afficher le mot en rouge
            }
            if (b7.Text == tabRep[7]) //tester si la réponse de l'éléve est juste
            {
                b7.Foreground = Brushes.Green;//le mot sera afficher en vert pour montere a l'étudiant que sa réponse est juste 
                score++; //incrémenter le score
            }
            else
            {
                b7.Foreground = Brushes.Red;//afficher le mot en rouge
            }
            sauvegardeScore();//sauvegarder le score de l'éléve dans une variable
            Exercice exercice = new Exercice();
            if (scoreFinal != 0)
            {
                exercice.sauvegarderScore(id_exercice, scoreFinal);//sauvegarde de score dans la base de donnée
            }

            button2.Visibility = Visibility.Visible;//remettre le boutton de retour a la page précédente visible
            valider.Visibility = Visibility.Hidden;//remettre le boutton de validation non visible
            corriger.Visibility = Visibility.Visible;//remettre le boutton de la correction non visible
            fenetreEndExo = new FenetreEndExo(2, score, 7, id_exercice);
            fenetreEndExo.Show();//afficher la fenetre de la fin de l'exercice

        }


        private void sauvegardeScore()//une méthode qui permet de sauvegarder le score de l'exercice 
        {
            this.scoreFinal = score;
        }

        private void corriger_Click(object sender, RoutedEventArgs e)//une méthode qui sera exécuter quand l'étudiant veut voir la correction
        {//corriger
            Animations.AddSound(1);//le son
            b1.Text = tabRep[1];//affecter le mot juste dans le vide de texte(la réponse)
            b1.Foreground = Brushes.Green;//afficher le mot en vert
            b2.Text = tabRep[2];//affecter le mot juste dans le vide de texte(la réponse)
            b2.Foreground = Brushes.Green;//afficher le mot en vert
            b3.Text = tabRep[3];//affecter le mot juste dans le vide de texte(la réponse)
            b3.Foreground = Brushes.Green;//afficher le mot en vert
            b4.Text = tabRep[4];//affecter le mot juste dans le vide de texte(la réponse)
            b4.Foreground = Brushes.Green;//afficher le mot en vert
            b5.Text = tabRep[5];//affecter le mot juste dans le vide de texte(la réponse)
            b5.Foreground = Brushes.Green;//afficher le mot en vert
            b6.Text = tabRep[6];//affecter le mot juste dans le vide de texte(la réponse)
            b6.Foreground = Brushes.Green;//afficher le mot en vert
            b7.Text = tabRep[7];//affecter le mot juste dans le vide de texte(la réponse)
            b7.Foreground = Brushes.Green;//afficher le mot en vert

        }


        private void button2_Click(object sender, RoutedEventArgs e)//méthode pour le retour a la page précédente
        {
            Animations.AddSound(1);//le son
            timer.Stop();//arreter le temps
            this.NavigationService.Navigate(new InterfaceExercice(3));//ouvrir l'interface des exercices des chapitres
        }

        private void ClickHelp(object sender, System.Windows.RoutedEventArgs e)//méthode pour l'affichage du help
        {
            Animations.AddSound(1);//le son
            HelpExo l = new HelpExo(2);//afficher le help
            l.Show();

        }

    }
}
