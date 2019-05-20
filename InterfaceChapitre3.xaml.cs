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

namespace AlGeo
{
    /// <summary>
    /// Logique d'interaction pour InterfaceChapitre3.xaml
    /// </summary>
    public partial class InterfaceChapitre3 : Page
    // interface chapitre 03 pour accéder 
    //aux cours et exercices du 1er chapitre
    {
        public InterfaceChapitre3()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            /*InterfaceCours interfaceCours = new InterfaceCours("Chapitre3");
            interfaceCours.Show();
            this.Close();*/
            Animations.AddSound(1);
            FenetreDeDialogueCours fenetreDeDialogueCours = new FenetreDeDialogueCours("Chapitre3", 3);
            fenetreDeDialogueCours.Show();

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);
            this.NavigationService.Navigate(new InterfaceExercice(3));

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);
            this.NavigationService.Navigate(new InterfaceHomePage());
        }
    }
}



