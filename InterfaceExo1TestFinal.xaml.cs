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
using System.Windows.Markup;
using System.IO;
using System.Xml;

namespace AlGeo
{

    public partial class InterfaceExo1TestFinal : Window
    {
        private string LienQuestionGame = @"JeuBonus/CartesAnimes/Page1.xaml";
        public InterfaceExo1TestFinal()
        {
            InitializeComponent();
            Loaded += Questions_Loaded;
        }

        private void Questions_Loaded(object sender, RoutedEventArgs e)
        {
            Questions.NavigationService.Navigate(new Uri(LienQuestionGame, UriKind.Relative));
        }


        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.mainFrame.NavigationService.Navigate(new InterfaceHomePage());
            App.mainWindow.Show();        
            this.Close();
        }
    }
}