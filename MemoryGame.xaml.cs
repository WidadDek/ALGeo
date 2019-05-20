using AlGeo.ViewModels;
using AlGeo.Views;
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
    /// Interaction logic for MemoryGame.xaml
    /// </summary>
    public partial class MemoryGame : Window
    /*
     * Ceci est un code  open source, après 
     * avoir parlé avec le developpeur  il nous a donné la
     * permission pour utiliser ce code 
     * (vous pouvez nous contactez pour vous passez son 
     * nom et la discussion via le mail) 
     */
    {
        public MemoryGame()
        {
            InitializeComponent();
            DataContext = new StartMenuViewModel(this);
        }
       

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.StopBackgroundMusic();
            App.mainWindow.Show();
            this.Close();

        }
    }
}
