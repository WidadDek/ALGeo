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
using System.Xml;
namespace AlGeo
{
    /// <summary>
    /// Logique d'interaction pour FenetreDeDialogueCours.xaml
    /// </summary>
    public partial class FenetreDeDialogueCours : Window
    {
        private XmlDocument monFichier = new XmlDocument();
        private int currentPage;
        private string nomChapitre;
        private int id_cours;
        public FenetreDeDialogueCours(string nomChapitre, int id_cours)
        {
            this.nomChapitre = nomChapitre;
            this.id_cours = id_cours;
            SetOpacityChapterWindow(0.5f);
            InitializeComponent();
            Animations.AddSound(2);

        }
        private void SetOpacityChapterWindow(float opacity)
        {
            App.mainWindow.Opacity = opacity;
        }
        private void StartCurrentPage_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);
            /*InterfaceCours interfaceCours = new InterfaceCours(nomChapitre, true, id_cours);
            interfaceCours.Show();*/
            this.Close();
            App.interfaceCours = new InterfaceCours(nomChapitre, true, id_cours);
            App.mainWindow.mainFrame.NavigationService.Navigate(App.interfaceCours);
            SetOpacityChapterWindow(1);
        }
        private void StartFirstPage_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);
            /*InterfaceCours interfaceCours = new InterfaceCours(nomChapitre, false,id_cours);
            interfaceCours.Show();*/
            this.Close();
            SetOpacityChapterWindow(1);
            App.interfaceCours = new InterfaceCours(nomChapitre, false, id_cours);
            App.mainWindow.mainFrame.NavigationService.Navigate(App.interfaceCours);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            SetOpacityChapterWindow(1);
            this.Close();

        }
    }
}
