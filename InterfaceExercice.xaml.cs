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

namespace AlGeo
{
    /// <summary>
    /// Interaction logic for InterfaceExercice1.xaml
    /// </summary>
    public partial class InterfaceExercice : Page
    {
        private int numChapitre;
        private int idExercice;
        public InterfaceExercice(int numChapitre)
        {
            this.numChapitre = numChapitre;
            InitializeComponent();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);
            string path = "InterfaceChapitre" + numChapitre + ".xaml";
            this.NavigationService.Navigate(new Uri(path, UriKind.RelativeOrAbsolute));


        }





        private void buttonAccueil_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);
            this.NavigationService.Navigate(new InterfaceHomePage());

        }


        /* exercice Qcm */
        private void Qcm_Click(object sender, RoutedEventArgs e)

        {
            Animations.AddSound(1);
            switch (numChapitre)
            {
                case 1: { idExercice = 1; break; }
                case 2: { idExercice = 5; break; }
                case 3: { idExercice = 9; break; }

            }

            StartExoWindow startExoWindow = new StartExoWindow(numChapitre, 1,idExercice);
            startExoWindow.Show();


        }


        /* Exercice Remplir les champs */
        private void RemplirLesChamps_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);
            switch (numChapitre)
            {
                case 1: { idExercice = 2; break; }
                case 2: { idExercice = 6; break; }
                case 3: { idExercice = 10; break; }

            }

            StartExoWindow startExoWindow = new StartExoWindow(numChapitre, 2,idExercice);
            startExoWindow.Show();


        }


        /* Exercice Remplir Tableau */
        private void RemplirTableau_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);
            switch (numChapitre)
            {
                case 1: { idExercice = 3; break; }
                case 2: { idExercice = 7; break; }
                case 3: { idExercice = 11; break; }

            }
            StartExoWindow startExoWindow = new StartExoWindow(numChapitre, 3,idExercice);
            startExoWindow.Show();


        }

        private void relier(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);
            switch (numChapitre)
            {
                case 1: { idExercice = 4; break; }
                case 2: { idExercice = 8; break; }
                case 3: { idExercice = 12; break; }

            }
            StartExoWindow startExoWindow = new StartExoWindow(numChapitre, 4,idExercice);
            startExoWindow.Show();




        }
    }
}