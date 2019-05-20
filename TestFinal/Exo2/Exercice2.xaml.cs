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
using System.Windows.Threading;
using System.Windows.Shapes;

namespace AlGeo.TestFinal.Exo2
{
    /// <summary>
    /// Interaction logic for Exercice2.xaml
    /// </summary>
    public partial class Exercice2 : Page
    {
        private int i = 0;

        public Exercice2()
        {
            InitializeComponent();
            // les images de X sont invesibles au debut 
            f1.Visibility = Visibility.Hidden;
            f2.Visibility = Visibility.Hidden;
            f3.Visibility = Visibility.Hidden;
            f4.Visibility = Visibility.Hidden;
            f5.Visibility = Visibility.Hidden;
            f7.Visibility = Visibility.Hidden;


        }





        // le button valider et calcule de score de l'exercice 
        private void valider_Click_1(object sender, RoutedEventArgs e)
        {
            // VALIDER 
            
            App.interfaceTestFinal.GoToExoMenu.Visibility = Visibility.Visible;//Bouton de retour vers le menu des exercices du test final est disponible.

            // des qu'il valide il ne peut rien faire encore il ne peut pas ajouter des choses
            t1.IsEnabled = false;
            t2.IsEnabled = false;
            t4.IsEnabled = false;
            t5.IsEnabled = false;
            t6.IsEnabled = false;
            t3.IsEnabled = false;
            int score = 0; // LA VARIABLE QUI CONTIENT LE SCORE FINAL DE L'EXO
            Valider.IsEnabled = false;
            // Le calcule de score 
            if (t1.Content.ToString() == "مرجان")
            {
                score++;

            }
            if (t3.Content.ToString() == "سمك")
            {
                score++;
            }

            if (t2.Content.ToString() == "زنك")
            {
                score++;

            }


            if (t4.Content.ToString() == "غاز")
            {
                score++;
            }


            if (t5.Content.ToString() == "بترول")
            {
                score++;
            }

            if (t6.Content.ToString() == "ذهب")
            {
                score++;
            }

            EndExoTestFinal endExoTestFinal = new EndExoTestFinal(2,score);
            endExoTestFinal.Show();

        }
        // lb est la liste box qui contint les propositions 
        private void lb_changed(object sender, SelectionChangedEventArgs e)
        {

            if (IsLoaded)
            {
                string txt = "";
                foreach (ListBoxItem lbi in lb.SelectedItems)
                {

                    txt = lbi.Content + "";
                }
                // le copier de contenue de textblock dans la case de carte corespondante a la selection 
                if (i == 1) { t1.Content = txt; }
                if (i == 2) { t2.Content = txt; }
                if (i == 3) { t3.Content = txt; }
                if (i == 4) { t4.Content = txt; }
                if (i == 5) { t5.Content = txt; }
                if (i == 6) { t6.Content = txt; }

                t1.Background = Brushes.White;
                t2.Background = Brushes.White;
                t3.Background = Brushes.White;
                t4.Background = Brushes.White;
                t5.Background = Brushes.White;
                t6.Background = Brushes.White;

                // la visibilitè de  X  dans les cases coches 
                if ((t1.Content.ToString() == "سمك") || (t2.Content.ToString() == "سمك") || (t3.Content.ToString() == "سمك") || (t4.Content.ToString() == "سمك") || (t5.Content.ToString() == "سمك") || (t6.Content.ToString() == "سمك"))
                {
                    f7.Visibility = Visibility.Visible;
                }
                else
                {
                    f7.Visibility = Visibility.Hidden;

                }

                // la visibilitè de  X  dans les cases coches 

                if ((t1.Content.ToString() == "ذهب") || (t2.Content.ToString() == "ذهب") || (t3.Content.ToString() == "ذهب") || (t4.Content.ToString() == "ذهب") || (t5.Content.ToString() == "ذهب") || (t6.Content.ToString() == "ذهب"))
                {
                    f1.Visibility = Visibility.Visible;

                }
                else
                {
                    f1.Visibility = Visibility.Hidden;
                }

                // la visibilitè de  X  dans les cases coches 
                if ((t1.Content.ToString() == "مرجان") || (t2.Content.ToString() == "مرجان") || (t3.Content.ToString() == "مرجان") || (t4.Content.ToString() == "مرجان") || (t5.Content.ToString() == "مرجان") || (t6.Content.ToString() == "مرجان"))
                {
                    f2.Visibility = Visibility.Visible;
                }
                else
                {
                    f2.Visibility = Visibility.Hidden;
                }

                // la visibilitè de  X  dans les cases coches 
                if ((t1.Content.ToString() == "بترول") || (t2.Content.ToString() == "بترول") || (t3.Content.ToString() == "بترول") || (t4.Content.ToString() == "بترول") || (t5.Content.ToString() == "بترول") || (t6.Content.ToString() == "بترول"))
                {
                    f3.Visibility = Visibility.Visible;
                }
                else
                {
                    f3.Visibility = Visibility.Hidden;
                }

                // la visibilitè de  X  dans les cases coches 
                if ((t1.Content.ToString() == "زنك") || (t2.Content.ToString() == "زنك") || (t3.Content.ToString() == "زنك") || (t4.Content.ToString() == "زنك") || (t5.Content.ToString() == "زنك") || (t6.Content.ToString() == "زنك"))
                {
                    f5.Visibility = Visibility.Visible;
                }
                else
                {
                    f5.Visibility = Visibility.Hidden;
                }

                // la visibilitè de  X  dans les cases coches 
                if ((t1.Content.ToString() == "غاز") || (t2.Content.ToString() == "غاز") || (t3.Content.ToString() == "غاز") || (t4.Content.ToString() == "غاز") || (t5.Content.ToString() == "غاز") || (t6.Content.ToString() == "غاز"))
                {
                    f4.Visibility = Visibility.Visible;
                }
                else
                {
                    f4.Visibility = Visibility.Hidden;
                }



            }

        }

        private void Item1_Selected(object sender, RoutedEventArgs e)
        {
            //f1.Visibility = Visibility.Visible;

        }


        //la methode qui permet de copier le contenue de Textblock dans la case de carte 
        private void txt1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            t1.Content = "";
            i = 1;
            t1.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF27C04C"));
        }
        //la methode qui permet de copier le contenue de Textblock dans la case de carte 
        private void txt3(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // TODO: Add event handler implementation here.
            t3.Content = "";
            i = 3;
            t3.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF27C04C"));
        }
        //la methode qui permet de copier le contenue de Textblock dans la case de carte 
        private void txt6(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // TODO: Add event handler implementation here.
            t6.Content = "";
            i = 6;
            t6.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF27C04C"));
        }
        //la methode qui permet de copier le contenue de Textblock dans la case de carte 
        private void txt5(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            t5.Content = "";
            i = 5;
            t5.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF27C04C"));// TODO: Add event handler implementation here.
        }
        //la methode qui permet de copier le contenue de Textblock dans la case de carte 
        private void txt2(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            t2.Content = "";
            i = 2;
            t2.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF27C04C"));// TODO: Add event handler implementation here.
        }
        //la methode qui permet de copier le contenue de Textblock dans la case de carte 

        private void txt4(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            t4.Content = "";
            i = 4;
            t4.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF27C04C"));  // TODO: Add event handler implementation here.
        }


        // l'affichage de la fenetre du help 
        private void ClickHelp(object sender, System.Windows.RoutedEventArgs e)
        {

            AlGeo.HelpExo l = new AlGeo.HelpExo(7);
            l.Show();

        }





    }
}