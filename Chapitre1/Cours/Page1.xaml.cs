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

namespace AlGeo.Chapitre1.Cours
{
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        /*  private void Previous_Click(object sender, RoutedEventArgs e)
 {
     Previous.IsEnabled = false;

 }

 private void Next_Click(object sender, RoutedEventArgs e)
 {
     this.NavigationService.Navigate(new Page2C1());
     XmlDocument monFichier = new XmlDocument();
     monFichier.Load("XmlFile.xml");
     XmlNode nbpage = monFichier.SelectSingleNode("//currentPage");
     int currentPage = 2;
     nbpage.InnerText = currentPage.ToString();
     monFichier.Save("XmlFile.xml");
 }*/

    }

}
