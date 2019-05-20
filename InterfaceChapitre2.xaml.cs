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
    /// Logique d'interaction pour InterfaceChapitre2.xaml
    /// </summary>
    public partial class InterfaceChapitre2 : Page
    // interface chapitre 02 pour accéder 
    //aux cours et exercices du 1er chapitre
    {
        public InterfaceChapitre2()
        {
            InitializeComponent();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            /*InterfaceCours interfaceCours = new InterfaceCours("Chapitre2");
            interfaceCours.Show();
            this.Close();*/
            Animations.AddSound(1);
            FenetreDeDialogueCours fenetreDeDialogueCours = new FenetreDeDialogueCours("Chapitre2", 2);
            fenetreDeDialogueCours.Show();


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);
            this.NavigationService.Navigate(new InterfaceExercice(2));

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);
            this.NavigationService.Navigate(new InterfaceHomePage());
        }

    }
}
