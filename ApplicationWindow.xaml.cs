using System.Windows;
namespace AlGeo
{    /*Fenetre Principale D'affichage de toutes les parge de l'application AlGeo.*/
    public partial class ApplicationWindow : Window
    {  /*Constructeur*/
        public ApplicationWindow()
        {
            InitializeComponent();
            /*Ouverture de la page de connexion*/
            mainFrame.NavigationService.Navigate(new InterfaceConnexion());
            /**********************************/
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            /*Quitter l'application:ouverture d'une fenetre de dialogue*/
            InterfaceExitApp interfaceExitApp = new InterfaceExitApp(1);
            interfaceExitApp.Show();
            /************************/
        }

    }
}
