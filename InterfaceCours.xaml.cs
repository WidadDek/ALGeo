using System;
using System.Windows;
using System.Windows.Controls;
using System.Xml;



namespace AlGeo
{

    public partial class InterfaceCours : Page
    {   /*Attributs*/
        private XmlDocument fichierNbPage = new XmlDocument();//Pointeur vers un fichier xml.
        private int currentPage = 1;//contient le numero de la  page actuellement affiché.
        private string nomChapitre;//Contient le nom de chapitre.ex:Chapitre1.
        private int id_cours;//c'est l'indetificateur du cours dans la BDD.
        private int nombrePage;//contient le nombre de page total du cours.
        Cours co = new Cours();
        /****************************************************************/
        /* Les Methodes*/
        /*Recupperer l'identificateur du cours dans la BDD.*/
        public int GetIdCours() { return (id_cours); }
        /**********************************************/
        /*Recupperer la dernière page consulté:page courante*/
        public int GetLastPage() { return (currentPage); }

        /*Recupperer la page consulté de la base de donnée*/
        private int GetCurrentPageFromBase()
        {
            int lastpage = co.RecupererLastPage(this.id_cours);
            return lastpage;
        }

        /* Permet la navigation entre les pages du cours*/
        private void GoToPage(int pageNumber)
        {
            string path = nomChapitre + "/Cours/Page" + pageNumber + ".xaml";
            Chapitre.NavigationService.Navigate(new Uri(path, UriKind.Relative));
            PageNumberTextBlock.Text = nombrePage + " / " + currentPage + "الصفحة  ";
        }

        /*Sauvgarder la derniere page visitée dans la base de donée*/
        private void SetCurrentPageToBase(int currentPage)
        {
            Cours co = new Cours();
            co.sauvegarderLastPage(id_cours, currentPage);
        }
        /*Récuperer le nombre de page du chapitre courant de la base d donnes*/
        private int GetNombrePageFromFile()
        {
            /*fichierNbPage.Load("NombreDePageParChapitre.xml");
            XmlNode nbpage = fichierNbPage.SelectSingleNode("//nombrePage/" + nomChapitre);
            return (int.Parse(nbpage.InnerText));*/
            return co.RecupererNbPage(this.id_cours);
        }
        /*******************************************************************************/
        /* Constructeur, Sert à initialiser les variables nomChapitre IsCurrentPage et id_cours
        * et à Afficher le cours « nomChapitre » commençant de la dernière page consulté*/
        public InterfaceCours(string nomChapitre, int id_cours)
        {

            /*initialisation des variables*/
            this.nomChapitre = nomChapitre;
            this.id_cours = id_cours;
            nombrePage = GetNombrePageFromFile();
            /**************************/

            InitializeComponent();
            /*Recupperation de la derniere page consulté de la BDD*/
            currentPage = GetCurrentPageFromBase();
            /**********************************/
            /*Affichage de la page*/
            GoToPage(currentPage);
            /***********************/

        }
        /* Constructeur, Sert à initialiser les variables nomChapitre IsCurrentPage et id_cours
         * et à Afficher le cours « nomChapitre » commençant soit de la dernière page consulté
         *  si « IsCurrentPage=vrai » soit du début du chapitre si « IsCurrentPage=faux »*/
        public InterfaceCours(string nomChapitre, Boolean IsCurrentPage, int id_cours)
        {   /*initialisation des variables*/
            this.nomChapitre = nomChapitre;
            this.id_cours = id_cours;
            nombrePage = GetNombrePageFromFile();
            /**************************/
            InitializeComponent();
            /*Si on veut commencer de la derniére page consulté dans le cours*/
            if (IsCurrentPage)
            {   /*Recupperation de la derniere page consulté de la BDD*/
                currentPage = GetCurrentPageFromBase();
                /**********************************/
                /*Affichage de la page*/
                GoToPage(currentPage);
                /***********************/
            }
            /********************************/
            /*Si on veut commencer la consultation du debut*/
            else
            {
                currentPage = 1;
                /*Affichage de la page*/
                GoToPage(currentPage);
            }
        }

        /* Instructions relatif au click sur le button de navigation aller a la premiere page du cours*/
        private void FirstPage_Click(object sender, RoutedEventArgs e)
        {
            //Rajout d'un son lors du click
            Animations.AddSound(1);
            //Recuperer le chemin de la première page du chapitre courant
            string path = nomChapitre + "/Cours/Page1.xaml";
            //Passer a la premiere page
            GoToPage(currentPage);
            //Mettre a jour le numéro de la page courante
            currentPage = 1;
        }

        /* Instructions relatif au click sur le button de navigation aller a la page précedente*/
        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            //Rajout d'un son lors du click
            Animations.AddSound(1);

            if (currentPage > 1)
            {
                //Décrementer le numéro de la page courante
                currentPage--;
                //Passer a la page precendente
                GoToPage(currentPage);
            }

        }

        /* Instructions relatif au click sur le button de navigation aller a la page suivante*/
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            //Rajout d'un son lors du click
            Animations.AddSound(1);
            if (currentPage < nombrePage)
            {
                //Incrémenter le numéro de la page courante
                currentPage++;
                //Passer a la page suivante 
                GoToPage(currentPage);
            }
        }

        /* Instructions relatif au click sur le button de navigation aller a la page d'acceuil */
        private void Accueil_Click(object sender, RoutedEventArgs e)
        {
            //Rajout d'un son lors du click
            Animations.AddSound(1);
            //Mettre a jour la page courante en la sauvgardant dans la base de donnée
            SetCurrentPageToBase(currentPage);
            //Passer a la page d'acceuil
            this.NavigationService.Navigate(new InterfaceHomePage());
        }
    }
}