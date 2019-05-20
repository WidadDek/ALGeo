using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml;


namespace AlGeo
{
   
    public partial class FenetreHelp : Window
    {    /*Attribut*/
        private XmlDocument monFichier = new XmlDocument();//Pointeur vers le fichier xml qui contient les descriptions des interfaces.
        private string description;//Contient la Description de l'interface Affiché.
        private int pageTotalNumber;//Contient Le nombre total des pages à afficher.
        private int currentPage = 1;//Contient La page courante qui est affiché.

        Ellipse ellipse; //Forme geometrique:sera utilisé pour afficher le numero de page.
        /************************************************************/
        /*Methodes*/
        /*Une methode que sert à recupperer la description à partir du fichier,
         * ainsi que la capture d'interface correspondante
         *  et de les afficher*/     
        private void GeneratePage(int pageNumber)
        {    /*Recuperation de la description*/ 
            description = monFichier.SelectSingleNode("//Help/Page" + pageNumber).InnerText;
            /*********************************/
            /*Affichage de la description*/
            DescriptionParagraph.Inlines.Clear();
            DescriptionParagraph.Inlines.Add(description);
            /*****************************************/
            /*Affichage de la capture correspondante*/
            DescriptionImage.Source = Animations.GetImage(@"Images/descriptionImage" + pageNumber + ".jpg");
            /***************************************/

        }
        /*Remplir l'ellipse i qui correspond a la page numero i*/
        private void FillInEllipse(int pageNumber)
        {
            ellipse = this.FindName("Count" + pageNumber) as Ellipse;
            ellipse.Height = 35;
            ellipse.Width = 35;
            ellipse.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF2175CF"));
        }
        /****************************************/
        /*Vider l'ellipse i qui correspond a la page i*/
        private void FillOutEllipse(int pageNumber)
        {
            ellipse = this.FindName("Count" + pageNumber) as Ellipse;
            ellipse.Height = 20;
            ellipse.Width = 20;
            ellipse.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFF0EBEF"));
        }
        /******************************************/
        /*Constrcteur de l'aide*/
        public FenetreHelp()
        {
            InitializeComponent();
            /*Ouverture du fichier qui contient les descriptions*/
            monFichier.Load("HelpFile.xml");
            /***************************************************/
            /*Recupperer le nombre total des pages*/
            pageTotalNumber = int.Parse(monFichier.SelectSingleNode("//Help/PageTotalNumber").InnerText);
            /***************************************/
            /*Affichage de la page1 d'aide*/
            GeneratePage(currentPage);
            /********************************/
            /*Remplissage le l'ellipse correspondant*/
            FillInEllipse(currentPage);
            /**************************************/

        }
        /*Methode d'affichage de la page d'aide suivante*/
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);//Ajout du son
            FillOutEllipse(currentPage);//Vider l'ellipse de la page courante.
            currentPage++;//Passer a la page suivate.
            FillInEllipse(currentPage);//Remplir l'ellipse de la nouvelle page courante.
            /*Si c'est la derniere page de l'aide le bouton suivant est indisponible.*/
            if (currentPage == pageTotalNumber) Next.Visibility = Visibility.Hidden;
            /*************************************************************/
            /*Affichage de la page dont le numero=currentPage*/
            GeneratePage(currentPage);
            /***********************************************/
            /*Bouton de retours vers la page precedente disponible*/
            Previous.Visibility = Visibility.Visible;
            /*****************************************************/
        }
        /**************************************************/
        /*Methode d'affichage de la page d'aide précédente*/
        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);//Ajout du son
            FillOutEllipse(currentPage);//Vider l'ellipse de la page courante.
            currentPage--;//Passer a la page précedente.
            FillInEllipse(currentPage);//Remplir l'ellipse de la nouvelle page courante.
             /*Si c'est la toute premiere page de l'aide le bouton precedent est indisponible.*/
            if (currentPage == 1) Previous.Visibility = Visibility.Hidden;
            /*************************************************************/
            /*Affichage de la page dont le numero=currentPage*/
            GeneratePage(currentPage);
            /***********************************************/
            /*Bouton de retours vers la page suivante disponible*/
            Next.Visibility = Visibility.Visible;
            /**************************************************/
        }
        /*************************************************/
        /*Bouton Quitter l'aide*/
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();//Fermer la fenetre.
        }
        /*********************/
    }
}
