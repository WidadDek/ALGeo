using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Threading;

namespace AlGeo
{
    /*Cette classe s’occupe de l’affichage des exercices de Test Final, de la gestion de temps, de la correction et de son affichage.*/
    public partial class InterfaceTestFinal : Page
    {
        private string path;// Contient Le chemin vers l'exo choisit.
        private string description;//Contient la Description de l'exercice choisit.
        private DispatcherTimer timer = new DispatcherTimer();
        private int time = 1800;// Le temps max de l'exo.
        Exercice exercice = new Exercice();
        FenetreAffichageScoreTestFinal fenetreAffichageScoreTestFinal;
        /***********************************************/
        /**Methodes**/
        /*Constructeur de la classe test final.*/
        public InterfaceTestFinal()
        {
            InitializeComponent();
            /*Commentaire affiché*/
            CommentTB.Inlines.Clear();
            CommentTB.Inlines.Add(new Run(" اختر تمرينا لتحله."));
            CommentTB.Visibility = Visibility.Visible;
            /**************************************/
            /*Instancion des variables de temps***/
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            /***********************************/
            /*Initialiser le score du test final dans la bdd a zero*/
            exercice.Supprimer_Ligne_Exercice(13);
            exercice.sauvegarderScore(13, 0);
            /*****************************************************/

        }

        /*Methode pour reinitialiser la page de la correction dans le but d'afficher la correction des exercices.*/
        private void MettreAJourPageCorrection(string path, string description)
        {
            CommentTB.Inlines.Clear();
            CommentTB.Inlines.Add(new Run(description));
            CommentTB.Visibility = Visibility.Visible;
            menuGrid.Visibility = Visibility.Hidden;
            imageMenuGrid.Visibility = Visibility.Hidden;
            imageCorrectionMenuGrid.Visibility = Visibility.Hidden;
            corrigemMenuGrid.Visibility = Visibility.Hidden;
            CountDownWrapper.Visibility = Visibility.Hidden;
            GoToCorrectionMenu.Visibility = Visibility.Visible;
            ExoFrame.NavigationService.Navigate(new Uri(path, UriKind.Relative));//Affichage
        }
        /********************************************************************************/
        /*Methode pour reinitialiser la page des exercices dans le but de les afficher.*/
        private void MettreAJourPageExercice(int numExo, string path)
        {
            menuGrid.Visibility = Visibility.Hidden;
            imageMenuGrid.Visibility = Visibility.Hidden;
            CountDownWrapper.Visibility = Visibility.Visible;
            CommentTB.Visibility = Visibility.Hidden;
            Button exo = this.FindName("Exo" + numExo) as Button;
            exo.IsEnabled = false;
            ExoFrame.NavigationService.Navigate(new Uri(path, UriKind.Relative));//Affichage.
            timer.Start();
            GoToExoMenu.Visibility = Visibility.Hidden;
            Back.Visibility = Visibility.Hidden;
        }
        /********************************************************************************/
        /*Aller a l'exo1*/
        private void GoToExo1_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);//Son du bouton.
            path = "TestFinal/Exo1/ExerciceVraiOuFaux.xaml";//Le chemin vers le 1ier exercice.
            MettreAJourPageExercice(1, path);//
        }
        /****************/
        /*Aller a l'exo2*/
        private void GoToExo2_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);//Son du bouton.
            path = "TestFinal/Exo2/Exercice2.xaml";//Le chemin vers le 2ier exercice.
            MettreAJourPageExercice(2, path);
        }
        /****************/
        /*Aller a l'exo3*/
        private void GoToExo3_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);//Son du bouton.
            path = "TestFinal/Exo3/ExoDevineMot.xaml";//Le chemin vers le 3ier exercice.
            MettreAJourPageExercice(3, path);
        }
        /****************/
        /*Aller a l'exo4*/
        private void GoToExo4_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);//Son du bouton.
            path = "TestFinal/Exo4/ExerciceRelier.xaml";//Le chemin vers le 4ier exercice.
            MettreAJourPageExercice(4, path);
        }
        /****************/
        /*Aller a l'exo5*/
        private void GoToExo5_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);//Son du bouton.
            path = "TestFinal/Exo5/EnigmesExercice.xaml";//Le chemin vers le 5ier exercice.
            MettreAJourPageExercice(5, path);
        }
        /****************/
        /*Retourner a la page des exercices.*/
        private void GoToExoMenu_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);//Son du bouton.
            timer.Stop();//Le temps s'arrete dans cette page:attend l'effectation d'un autre choix d'exercice.
            /*Reinitialisation de l'interface de la page*/
            ExoFrame.Content = null;
            menuGrid.Visibility = Visibility.Visible;
            imageMenuGrid.Visibility = Visibility.Visible;
            GoToExoMenu.Visibility = Visibility.Hidden;
            Back.Visibility = Visibility.Visible;
            CommentTB.Visibility = Visibility.Hidden;
            /*******************************************/
            /*Condition d'affichage de la correction du test Final:on Affiche SSI tout les exos sont faits.*/
            if ((!Exo1.IsEnabled)&&(!Exo2.IsEnabled)&&(!Exo3.IsEnabled)&&(!Exo4.IsEnabled)&& (!Exo5.IsEnabled))
            {  /*Reinitialisation de l'interface pour Afficher la correction*/
                Back.Visibility = Visibility.Visible;
                GoToExoMenu.Visibility = Visibility.Collapsed;
                CountDownWrapper.Visibility = Visibility.Collapsed;
                menuGrid.Visibility = Visibility.Hidden;
                corrigemMenuGrid.Visibility = Visibility.Visible;
                imageCorrectionMenuGrid.Visibility = Visibility.Visible;
                imageMenuGrid.Visibility = Visibility.Hidden;
                /**************************************************/
                /*Affichage De la fenetre fin de test final*/
                fenetreAffichageScoreTestFinal = new FenetreAffichageScoreTestFinal(2);
                fenetreAffichageScoreTestFinal.Show();    
                /*******************************************/
            }
         /********************************************************************************************/

        }
        /**************************************/
        private void Timer_Tick(object sender, EventArgs e)
        {
            /*S'il reste encore de temps*/
            if (time >= 0)
            {
                /*Si temps<=10 on l'affiche en rouge:ALERT*/
                if (time <= 10)
                { CountDownTB.Foreground = Brushes.Red; }
                /*Sinon on l'affiche en blanc.*/
                else
                { CountDownTB.Foreground = Brushes.White; }
                /*Affichage du temp*/
                CountDownTB.Inlines.Clear();
                TimeSpan t = TimeSpan.FromSeconds(time);
                string strtime = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
                CountDownTB.Inlines.Add("الوقت المتبقي: " + strtime);
                time--;//Dans les deux cas on le décremonte.

            }
            /*S'il ne reste pas de temps*/
            else
            {
                timer.Stop();
                /*Affichage du fenetre que lui indique le score et que le temps est écoulé*/
                fenetreAffichageScoreTestFinal = new FenetreAffichageScoreTestFinal(1);
                fenetreAffichageScoreTestFinal.Show();             
                /*********************************************/
                menuGrid.Visibility = Visibility.Hidden;
            }

        }
        /***********************************/
        /*Aller a la correction de  l'exo1*/
        private void CorrectionExo1_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);//Son du bouton.
            description = " تصحيح التمرين 1 : اجب بصحيح ام خطا.";
            path = "TestFinal/Exo1/CorrigeExerciceVraiOuFaux.xaml";
            MettreAJourPageCorrection(path, description);
            ExoFrame.NavigationService.Navigate(new Uri(path, UriKind.Relative));

        }
        /************************************/
        /*Aller a la correction de  l'exo2*/
        private void CorrectionExo2_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);//Son du bouton.
            description = "  تصحيح التمرين 2 : خريطة الموارد الطبيعية";
            path = "TestFinal/Exo2/CorrigerExercice2.xaml";
            MettreAJourPageCorrection(path, description);
            ExoFrame.NavigationService.Navigate(new Uri(path, UriKind.Relative));


        }
        /***********************************/
        /*Aller a la correction de  l'exo3*/        
        private void CorrectionExo3_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);//Son du bouton.
            description = " تصحيح التمرين 3 : اكتشاف الكلمات";
            path = "TestFinal/Exo3/CorrigeExoDevineMot.xaml";
            MettreAJourPageCorrection(path, description);
            ExoFrame.NavigationService.Navigate(new Uri(path, UriKind.Relative));
        }
        /***********************************/
        /*Aller a la correction de  l'exo4*/
        private void CorrectionExo4_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);//Son du bouton.
            description = " تصحيح التمرين 4 : الربط بين الكلمات";
            path = "TestFinal/Exo4/CorrigerRelier.xaml";
            MettreAJourPageCorrection(path, description);
            ExoFrame.NavigationService.Navigate(new Uri(path, UriKind.Relative));

        }
        /**********************************/
        /*Aller a la correction de  l'exo5*/
        private void CorrectionExo5_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);//Son du bouton.
            description = " تصحيح التمرين 5 :  اختر الصورة المناسبة";
            path = "TestFinal/Exo5/EnigmesCorrection.xaml";
            MettreAJourPageCorrection(path, description);
            ExoFrame.NavigationService.Navigate(new Uri(path, UriKind.Relative));

        }
        /*********************************/
        private void ExoFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
        /*Retourner a la page de correction des exercices.*/
        private void GoToCorrectionMenu_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);//Son du bouton.
           /*Reinitialisation de l'interface de la page*/
            ExoFrame.Content = null;
            GoToCorrectionMenu.Visibility = Visibility.Hidden;
            corrigemMenuGrid.Visibility = Visibility.Visible;
            imageCorrectionMenuGrid.Visibility = Visibility.Visible;
            CommentTB.Visibility = Visibility.Hidden;
            /*******************************************/
        }
        /*Bouton pour quitter le test final*/
        private void Back_Click(object sender, RoutedEventArgs e)
        {   /*Affichage de boite de dialogue pour confirmer*/
            InterfaceExitApp interfaceExitApp = new InterfaceExitApp(2);
            interfaceExitApp.Show();
            /*********************************************/
        }
    }
}
