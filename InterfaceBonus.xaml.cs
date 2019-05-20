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
    /// Logique d'interaction pour InterfaceBonus.xaml
    /// </summary>
    public partial class InterfaceBonus : Window
    {
        Exercice exercice = new Exercice();
        public InterfaceBonus()
        {
           
            InitializeComponent();
            Animations.AddSound(2);
            if (exercice.RecupererScore(13) >=20) { btnMemoryGame.IsEnabled = true; }
            else btnMemoryGame.IsEnabled = false;

        }



        private void btnMemoryGame_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);
            MemoryGame w = new MemoryGame();
            w.Show();
            App.mainWindow.Opacity=1;
            App.mainWindow.Hide();
            this.Close();
        }

        private void btnMap_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);
            WilayaInforamation w = new WilayaInforamation();
            App.mainWindow.Opacity = 1;
            App.mainWindow.Hide();
            w.Show();
            this.Close();
            
        }

        private void btnPainting_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);
            Coloriage game = new Coloriage();
            App.mainWindow.Opacity = 1;
            App.mainWindow.Hide();
            game.Show();
            this.Close();

        }


        private void btnEquation_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);
            InterfaceExo1TestFinal game = new InterfaceExo1TestFinal();
            App.mainWindow.Opacity = 1;
            game.Show();
            this.Close();

        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.Opacity = 1;
            this.Close();

        }
    }
}
