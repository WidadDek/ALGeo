using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Xml;
namespace AlGeo
{
    /// <summary>
    /// Logique d'interaction pour StartExoWindow.xaml
    /// </summary>
    public partial class StartExoWindow : Window
    {    /*Attributs*/
        private XmlDocument monFichier = new XmlDocument();//Pointeur vers le fichier xml qui contient les questions.
        private string path;
        private int numChapitre;//Le numero du Chapitre
        private int numeroExo;//Le numero de l'exo dans le Chapitre.ie 1,2,3 ou 4.
        private int id_exercice;//l'identificateur de l'exercice dans la BDD.
        private int score;//Contient le score de l'exercice.
        Exercice exercice = new Exercice();//Instance de la classe Exercice.
         /*Methode pour afficher une image*/
        private static BitmapImage GetImage(string imageUri)
        {
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(@"Images/" + imageUri, UriKind.RelativeOrAbsolute);
            bitmapImage.EndInit();
            return bitmapImage;
        }
        /*******************************/
        /*Constructeur:Sert à initialiser les variables numChapitre numeroExo et id_exercice
         * et d'afficher le score du dernier essai*/
        public StartExoWindow(int numChapitre, int numeroExo, int id_exercice)
        {
            App.mainWindow.Hide();
            InitializeComponent();
            /*Initialisation des variables*/
            this.numChapitre = numChapitre;
            this.numeroExo = numeroExo;
            this.id_exercice = id_exercice;
            /*****************************/
            /*Reccupération du score de l'exercice courant de la BDD utilisant le id_exercice.*/
            this.score = exercice.RecupererScore(id_exercice);
            /********************************************************************************/
            /*Ouverture Du ficher xml qui contient la descriptions des exercices*/
            monFichier.Load("StartExerciceDescriptionFile.xml");
            /*******************************************************************/
            /*Affichage de la description de l'exercice dont le numero est egal à numeroExo*/
            path = "//Description/Exercice";
            DescriptionParagraph.Inlines.Add(new Run(monFichier.SelectSingleNode(path + numeroExo).InnerText));
            /******************************************************************************/
            /*Affichage du score non nul et d'un commentaire:Voulez vous refaire*/
            if (score != 0)
            {
                CommentTBlk.Inlines.Add(new Run(" لقد تحصلت على العلامة " + score + " في اخر محاولة."));
                CommentTBlk.Inlines.Add(new LineBreak());
                CommentTBlk.Inlines.Add(new Run("هل تريد المحاولة مرة اخرى؟ "));
            }
            image.Source = GetImage("StartImage" + numeroExo + ".png");
            /**************************************************************************/
        }
        /**********************************************************************************/
        /*Methode qui correspond au refus de refaire:on retourne à la page des exercices.*/
        private void False_Click(object sender, RoutedEventArgs e)
        {  /*Selon le numero de chapitre*/
            switch (numChapitre)
            {
                case 1://Si c'est le premier chapitre.
                    {   /*Affichage de l'interface des exos du premier chapitre.*/
                        App.mainWindow.mainFrame.NavigationService.Navigate(new InterfaceExercice(1));
                        break;
                    }

                case 2://Si C'est le deuxiéme chapitre.
                    {  /*Affichage de l'interface des exos du deuxiéme chapitre.*/
                        App.mainWindow.mainFrame.NavigationService.Navigate(new InterfaceExercice(2));
                        break;
                    }
                case 3://Si c'est la troisiéme chapitre.
                    {    /*Affichage de l'interface des exos du troisiéme chapitre.*/
                        App.mainWindow.mainFrame.NavigationService.Navigate(new InterfaceExercice(3));
                        break;
                    }
            }
            /*Affichage de la fenetre principale.*/
            App.mainWindow.Show();
            this.Close();//Fermer cette boite de dialogue.
        }
        /********************************************************************************/
        /*Methode pour refaire l'exo.*/
        private void True_Click(object sender, RoutedEventArgs e)
        {
            AfficherExercice(numChapitre);
            this.Close();
        }
        /*********************************************/
        /*Cette Methode sert à  Afficher l'exercice correspondant au numero du chapitre donnée
         * et à son numero dans ce chapitre.
         * Exemple: numChapitre=1,numeroExo=1 correspond à l'affichage du QCM du premier chapitre.
         ****/     
        private void AfficherExercice(int numChapitre)
        {
            /*Selon le numero d'exercice dans un chapitre*/
            switch (numeroExo)
            {
                case 1://Affichage du QCM du chapitre du numero=numChapitre         
                        App.mainWindow.mainFrame.NavigationService.Navigate(new InterfaceExerciceQCM(numChapitre,id_exercice));
                        break; 
               /********************/            
                case 2://Affichage de l'exercice RemplirLesChamps
                        /*Selon le numero de Chapitre.*/
                        switch (numChapitre)
                        { 
                            case 1://Chapitre1                             
                                    App.mainWindow.mainFrame.NavigationService.Navigate(new InterfaceExerciceRemplirChamp1(id_exercice));
                                    break;
                            case 2://Chapitre2                   
                                    App.mainWindow.mainFrame.NavigationService.Navigate(new InterfaceExerciceRemplirChamp2(id_exercice));
                                    break;                               
                            case 3://Chapitre3                               
                                    App.mainWindow.mainFrame.NavigationService.Navigate(new InterfaceExerciceRemplirChamp3(id_exercice));
                                    break;                               
                        }
                        break;
                 /*****************************/  
                case 3://Affichage De l'exo RemplirTableau.
                     /*Selon le numero de Chapitre.*/
                    switch (numChapitre)
                        {
                            case 1://Chapitre1
                            App.mainWindow.mainFrame.NavigationService.Navigate(new ExerciceRemplirTableau1(id_exercice));
                                    break;
                            case 2://Chapitre2
                            App.mainWindow.mainFrame.NavigationService.Navigate(new ExerciceRemplirTableau2(id_exercice));
                                    break;
                            case 3://Chapitre3
                            App.mainWindow.mainFrame.NavigationService.Navigate(new ExerciceRemplirTableau3(id_exercice));
                                    break;
                        }
                        break;
                /******************************/
                case 4://Affichage De l'exo Lier.
                       App.mainWindow.mainFrame.NavigationService.Navigate(new InterfaceExolier(numChapitre,id_exercice));
                        break;
              /*************************************/
            }
            /*Affichage de la fenetre qui contiendra l'exercice*/
            App.mainWindow.Show();
            /********************************/
        }
        /*Bouton fermer*/
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.Show();
            this.Close();
        }
    }
}
