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
    /// Logique d'interaction pour FenetreQuitterCours.xaml
    /// </summary>
    public partial class FenetreQuitterCours : Window
    {
        private XmlDocument monFichier = new XmlDocument();
        private int currentPage;
        private string nomChapitre;
        bool homePage;
        private void SetCurrentPageToFile(int currentPage)
        {
            monFichier.Load("XmlFile.xml");
            XmlNode nbpage = monFichier.SelectSingleNode("//currentPage/" + nomChapitre);
            nbpage.InnerText = currentPage.ToString();
            monFichier.Save("XmlFile.xml");
        }

        public FenetreQuitterCours(string nomChapitre,int currentPage,bool homePage)
        {
            this.homePage = homePage;
            this.currentPage = currentPage;
            this.nomChapitre = nomChapitre;
            InitializeComponent();
        }

       

        private void Quitter_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);
            SetCurrentPageToFile(currentPage);
           if(homePage)
            { InterfaceHomePage interfacehomePage = new InterfaceHomePage();
                //interfacehomePage.Show(); 
            }
            this.Close();
        }

        private void Continuer_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);
            this.Close();
        }
    }
}