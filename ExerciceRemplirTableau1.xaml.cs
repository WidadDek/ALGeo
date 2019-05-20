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
    /// Interaction logic for ExerciceRamplirTableau1.xaml
    /// </summary>
    public partial class ExerciceRemplirTableau1 :Page
    {
        private string lien;
        static private int z = 1;
        bool captured = false;
        double x_shape, x_canvas, y_shape, y_canvas;
        UIElement source = null;
        private int score2 = 0;
        private int ScoreFinal = 0;  // LA VARIABLE QUI CONTINET LE SCORE FINAL DE L'EXO   
        double top;
        double left;
        double top2, top3, top4, top5, top6, top7, top8;
        double left2, left3, left4, left5, left6, left7, left8;
        private int id_exercice;

        private int q = 0;
        DispatcherTimer timer = new DispatcherTimer();


        public ExerciceRemplirTableau1(int id_exercice)
        {
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            InitializeComponent();
            // valider.IsEnabled = false;
            this.id_exercice = id_exercice;
            corriger.IsEnabled = false;
            valider.IsEnabled = true;
            timer.Start();
            XmlDocument monFichier = new XmlDocument();
            this.lien = "c1.xml";
            monFichier.Load(lien);
            string g = "question";
            if (z < 3) z++;
            else z = 1;
            g = g + z;

            XmlNodeList lst = monFichier.GetElementsByTagName(g);
            //  l'affectation des mots  dans les textblocks a partir du fichier XAML
            
            mot1.Text = lst[0].InnerText;
            mot2.Text = lst[1].InnerText;
            mot3.Text = lst[2].InnerText;
            mot4.Text = lst[3].InnerText;
            mot5.Text = lst[4].InnerText;
            mot6.Text = lst[5].InnerText;
            mot7.Text = lst[6].InnerText;
            mot8.Text = lst[7].InnerText;
        }


        int time = 180; // LA VARIABLE QUI CONTIENT LA DUREE DE L'EXO
                        // la methode qui sauvergarde le scorefinal
        public void SauvergardeScoreFinal()
        {
            this.ScoreFinal = score2;
        }

        // la methode  pour le timer 
        /* private void timer_tick(object sender, EventArgs e)
         {

             Label1.Content = time.ToString();
             if (time > 0)
             {
                 time--;
                 if ((time) == 0)
                 {
                     MessageBox.Show("انتهى الوقت");
                     valider.IsEnabled = false;
                     corriger.IsEnabled = true;
                 }

             }


         } */
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

                else { CountDownTB.Foreground = Brushes.White; }
                CountDownTB.Inlines.Clear();
                TimeSpan t = TimeSpan.FromSeconds(time);
                string strtime = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
                CountDownTB.Inlines.Add("الوقت المتبقي: " + strtime);
            }
            else
            {

                App.fenetreEndExo = new FenetreEndExo(1, ScoreFinal, 8, id_exercice);
                App.fenetreEndExo.Show();
                timer.Stop();
            }
        }
        // la methode qui permet de drag un objet 
        private void shape_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            source = (UIElement)sender;
            Mouse.Capture(source);
            captured = true;
            x_shape = Canvas.GetLeft(source);
            x_canvas = e.GetPosition(canvasexercice).X;
            // la canvas canvasexercice est l'esoace danslequel on peut drag and drop un objet 
            y_shape = Canvas.GetTop(source);
            y_canvas = e.GetPosition(canvasexercice).Y;
            /*   top = Canvas.GetTop(mot1);
                left = Canvas.GetLeft(mot1); 
                position.Text = top.ToString() + "X" + left.ToString();
                 top2 = Canvas.GetTop(mot2);  
                left2 = Canvas.GetLeft(mot2); 
                position2.Text = top2.ToString() + "X" + left2.ToString();  */

        }


        // la methode qui permet de drag un objet 
        private void shape_MouseMove(object sender, MouseEventArgs e)
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
                TextBlock mot = (TextBlock)sender;
                top = Canvas.GetTop(mot1);  // ON RECUPERE LA POSITION DES QUE ON CLICK 
                left = Canvas.GetLeft(mot1);
                //position.Text = top.ToString() + "X" + left.ToString();
                top2 = Canvas.GetTop(mot2);
                left2 = Canvas.GetLeft(mot2);
                // position2.Text = top2.ToString() + "X" + left2.ToString();
                top3 = Canvas.GetTop(mot3);  // ON RECUPERE LA POSITION DES QUE ON CLICK 
                left3 = Canvas.GetLeft(mot3);
                top4 = Canvas.GetTop(mot4);  // ON RECUPERE LA POSITION DES QUE ON CLICK 
                left4 = Canvas.GetLeft(mot4);
                top5 = Canvas.GetTop(mot5);  // ON RECUPERE LA POSITION DES QUE ON CLICK 
                left5 = Canvas.GetLeft(mot5);
                top6 = Canvas.GetTop(mot6);  // ON RECUPERE LA POSITION DES QUE ON CLICK 
                left6 = Canvas.GetLeft(mot6);
                top7 = Canvas.GetTop(mot7);  // ON RECUPERE LA POSITION DES QUE ON CLICK 
                left7 = Canvas.GetLeft(mot7);
                top8 = Canvas.GetTop(mot8);  // ON RECUPERE LA POSITION DES QUE ON CLICK 
                left8 = Canvas.GetLeft(mot8);



                // on utilise cette variable q pour pouvoir valider unre seul fois saulement         
                if (q == 0)
                {

                    if (time <= 0)
                    {
                        timer.Stop();
                        valider.IsEnabled = false;


                    }
                    else
                    {
                        q = 1;
                    }
                }
            }
        }

        // LA METHODE QUI PERMET DE DROP UN OBJET 
        private void shape_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(null);
            captured = false;

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {


        }
        // LE BUTTON VALIDER ET LE CALCULE DE SCOREFINAL 
        private void Button_Click_2(object sender, RoutedEventArgs e)
        { // VALLIDER 
            Animations.AddSound(1);
            corriger.IsEnabled = true;
            timer.Stop();
            Exercice exercice = new Exercice();


            if ((257 < top) && (top < 437) && (574 < left) && (left < 935)) // IF LE MOT1 EST DANS LE POSITION CORRECTE DE TABLEAU 
            {
                score2 = score2 + 1;
                //   mot2.Fill = Brushes.DarkCyan ; 
                // mot2.Fill = Brushes.Red  ;
                mot1.Foreground = Brushes.Green;
                // mot2.FontSize = 28; 
            }
            else
            {
                mot1.Foreground = Brushes.Red;
            }

            if ((257 < top4) && (top4 < 437) && (574 < left4) && (left4 < 935)) // IF LE MOT1 EST DANS LE POSITION CORRECTE DE TABLEAU 
            {
                score2 = score2 + 1;

                mot4.Foreground = Brushes.Green;

            }
            else
            {
                mot4.Foreground = Brushes.Red;
            }


            if ((257 < top6) && (top6 < 437) && (574 < left6) && (left6 < 935)) // IF LE MOT1 EST DANS LE POSITION CORRECTE DE TABLEAU 
            {
                score2 = score2 + 1;

                mot6.Foreground = Brushes.Green;

            }
            else
            {
                mot6.Foreground = Brushes.Red;
            }



            if ((257 < top8) && (top8 < 437) && (574 < left8) && (left8 < 935)) // IF LE MOT1 EST DANS LE POSITION CORRECTE DE TABLEAU 
            {
                score2 = score2 + 1;

                mot8.Foreground = Brushes.Green;

            }
            else
            {
                mot8.Foreground = Brushes.Red;
            }



            if ((257 < top2) && (top2 < 437) && (116 < left2) && (left2 < 477))
            {
                score2++;
                mot2.Foreground = Brushes.Green;

            }
            else
            {
                mot2.Foreground = Brushes.Red;
            }

            if ((257 < top3) && (top3 < 437) && (116 < left3) && (left3 < 477))
            {
                score2++;
                mot3.Foreground = Brushes.Green;

            }
            else
            {
                mot3.Foreground = Brushes.Red;
            }

            if ((257 < top5) && (top5 < 437) && (116 < left5) && (left5 < 477))
            {
                score2++;
                mot5.Foreground = Brushes.Green;

            }
            else
            {
                mot5.Foreground = Brushes.Red;
            }

            if ((257 < top7) && (top7 < 437) && (116 < left7) && (left7 < 477))
            {
                score2++;
                mot7.Foreground = Brushes.Green;

            }
            else
            {
                mot7.Foreground = Brushes.Red;
            }

            SauvergardeScoreFinal();
            if (ScoreFinal != 0)
            {
                exercice.sauvegarderScore(id_exercice, ScoreFinal);
            }
            valider.IsEnabled = false;
            App.fenetreEndExo = new FenetreEndExo(2, ScoreFinal, 8, id_exercice);
            App.fenetreEndExo.Show();


        }
        // LE BUTTON CORRIGER AFFICHAGE DE CORRIGER EN POSITIONANT LES MOTS DANS LEURS PLACE EXACTE
        private void corriger_Click(object sender, RoutedEventArgs e)
        { //CORRIGER 
            Animations.AddSound(1);
            Canvas.SetLeft(mot1, 786);
            Canvas.SetTop(mot1, 287);

            Canvas.SetLeft(mot4, 605);
            Canvas.SetTop(mot4, 287);

            Canvas.SetLeft(mot6, 786);
            Canvas.SetTop(mot6, 350);

            Canvas.SetLeft(mot8, 605);
            Canvas.SetTop(mot8, 350);

            Canvas.SetLeft(mot2, 150);
            Canvas.SetTop(mot2, 287);

            Canvas.SetLeft(mot3, 312);
            Canvas.SetTop(mot3, 287);

            Canvas.SetLeft(mot5, 312);
            Canvas.SetTop(mot5, 350);

            Canvas.SetLeft(mot7, 150);
            Canvas.SetTop(mot7, 350);
        }


        // LE BUTTON RETOUR POUR RETOURNER A LA PAGE DES EXERCICES 
        private void button2_Click(object sender, RoutedEventArgs e)

        {
            Animations.AddSound(1);
            timer.Stop();
            this.NavigationService.Navigate(new InterfaceExercice(1));
        }
        private void ClickHelp(object sender, System.Windows.RoutedEventArgs e)
        {
            Animations.AddSound(1);
            HelpExo l = new HelpExo(3);
            l.Show();

        }
    }
}
