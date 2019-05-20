using System;
using System.Collections.Generic;
using System.Windows;

namespace AlGeo
{
    /// <summary>
    /// Logique d'interaction pour InterfaceExitApp.xaml
    /// </summary>
    public partial class InterfaceExitApp : Window
    {
        private int choix;//variable qui indique si on veut quitter l'app ou pas.
        /*Constructeur:sert à initialiser la variable choix selon le choix de l'utilisateur:il veut quitter ou pas*/
        public InterfaceExitApp(int choix)
        {   /*Initialser les variables*/
            this.choix = choix;
            /**************************/
            App.mainWindow.Opacity = 0.5f;
            InitializeComponent();
        }


        /* quitter l'application */
        private void Quitter_Click(object sender, RoutedEventArgs e)
        {  switch (choix)
            {
                case 1:
                    {    /*Quitter*/
                        this.Close();
                        Application.Current.Shutdown();
                        /***************************/
                        /*Cas ou on consulte le cours et  on veut quitter */
                        if (App.mainWindow.mainFrame.Content == App.interfaceCours)
                        {   /*Sauvgarde de la derniere page consulté*/
                            Cours co = new Cours();
                            co.sauvegarderLastPage(App.interfaceCours.GetIdCours(), App.interfaceCours.GetLastPage());
                            /*******************************************/
                        }
                        break;
                    }
                /* Annuler l'operation : continuer a  jouer */
                case 2:
                    {
                        App.mainWindow.mainFrame.NavigationService.Navigate(new InterfaceHomePage());
                        App.mainWindow.Opacity = 1;
                        this.Close();
                        break;
                    }
            }

        }
        /***********************************************/
        /*Methode pour Fermer la boite de dialogue et continuer a jouer*/
        private void Continuer_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.Opacity = 1;
            this.Close();

        }
    }
}
