using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for InterfaceHomePage.xaml
    /// </summary>
    public partial class InterfaceHomePage : Page
    {
        private string name;

        public InterfaceHomePage()
        {
            InitializeComponent();
            InitializeComponent();
            string lines = System.IO.File.ReadAllText(@"userID.TMP");
            this.name = lines.Trim();
            setLabelName();
            setButtonTestFinal();
        }
        


        private void setButtonTestFinal()
        {
            Exercice exercice = new Exercice();
            int acces = exercice.ScoreTotal();

            /* condition d'acces au test final */
            if (acces <= 60)
            {
                this.TestFinal.IsEnabled = false;
            }
            else
            {
                this.TestFinal.IsEnabled = true;
            }

            /* conditions de positionnement des etoiles selon le score realisé
             * acces etant le score global de ts les chapitres
             *  */
            if (acces >= 0 && acces <= 10)
            {
                StarsText.Text = "لإجتياز الإمتحان النهائي عليك الحصول على كل النجمات الذهبية و ذلك بحل التمارين";
                this.star1.Source = Animations.GetImage(@"Images/gstar.png");
                this.star2.Source = Animations.GetImage(@"Images/gstar.png");
                this.star3.Source = Animations.GetImage(@"Images/gstar.png");
                this.star4.Source = Animations.GetImage(@"Images/gstar.png");
                this.star5.Source = Animations.GetImage(@"Images/gstar.png");
                this.star6.Source = Animations.GetImage(@"Images/gstar.png");
            }
            else if (acces > 10 && acces <= 20)
            {
                StarsText.Text = " باقي 5 نجمات أحسنت ";
                this.star1.Source = Animations.GetImage(@"Images/star.png");
                this.star2.Source = Animations.GetImage(@"Images/gstar.png");
                this.star3.Source = Animations.GetImage(@"Images/gstar.png");
                this.star4.Source = Animations.GetImage(@"Images/gstar.png");
                this.star5.Source = Animations.GetImage(@"Images/gstar.png");
                this.star6.Source = Animations.GetImage(@"Images/gstar.png");
            }
            else if (acces > 20 && acces <= 30)
            {
                StarsText.Text = "  باقي 4 نجمات أحسنت ";
                this.star1.Source = Animations.GetImage(@"Images/star.png");
                this.star2.Source = Animations.GetImage(@"Images/star.png");
                this.star3.Source = Animations.GetImage(@"Images/gstar.png");
                this.star4.Source = Animations.GetImage(@"Images/gstar.png");
                this.star5.Source = Animations.GetImage(@"Images/gstar.png");
                this.star6.Source = Animations.GetImage(@"Images/gstar.png");
            }
            else if (acces > 30 && acces <= 40)
            {
                StarsText.Text = "  باقي 3 نجمات أحسنت ";
                this.star1.Source = Animations.GetImage(@"Images/star.png");
                this.star2.Source = Animations.GetImage(@"Images/star.png");
                this.star3.Source = Animations.GetImage(@"Images/star.png");
                this.star4.Source = Animations.GetImage(@"Images/gstar.png");
                this.star5.Source = Animations.GetImage(@"Images/gstar.png");
                this.star6.Source = Animations.GetImage(@"Images/gstar.png");
            }

            else if (acces > 40 && acces <= 50)
            {
                StarsText.Text = " لم يبقى أمامك الكثير أحسنت ";
                this.star1.Source = Animations.GetImage(@"Images/star.png");
                this.star2.Source = Animations.GetImage(@"Images/star.png");
                this.star3.Source = Animations.GetImage(@"Images/star.png");
                this.star4.Source = Animations.GetImage(@"Images/star.png");
                this.star5.Source = Animations.GetImage(@"Images/gstar.png");
                this.star6.Source = Animations.GetImage(@"Images/gstar.png");
            }

            else if (acces > 50 && acces <= 60)
            {
                StarsText.Text = " لم يبقى أمامك الكثير أحسنت ";
                this.star1.Source = Animations.GetImage(@"Images/star.png");
                this.star2.Source = Animations.GetImage(@"Images/star.png");
                this.star3.Source = Animations.GetImage(@"Images/star.png");
                this.star4.Source = Animations.GetImage(@"Images/star.png");
                this.star5.Source = Animations.GetImage(@"Images/star.png");
                this.star6.Source = Animations.GetImage(@"Images/gstar.png");
            }

            else if (acces > 60)
            {
                StarsText.Text = " لقد تحصلت على العلامة الكاملة ! يمكنك الآن إجتياز الإمتحان النهائي  ";
                this.star1.Source = Animations.GetImage(@"Images/star.png");
                this.star2.Source = Animations.GetImage(@"Images/star.png");
                this.star3.Source = Animations.GetImage(@"Images/star.png");
                this.star4.Source = Animations.GetImage(@"Images/star.png");
                this.star5.Source = Animations.GetImage(@"Images/star.png");
                this.star6.Source = Animations.GetImage(@"Images/star.png");
            }

        }




        private void setLabelName()
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            string lien = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "\\Etudiant.mdf;Integrated Security=True";

            SqlConnection connexion = new SqlConnection(lien);
            // ConnexionToDataBase ctdb = new ConnexionToDataBase();
            // connexion = ctdb.seConnecter(lien);

            connexion.Open();
            /*pour pouvoir executer une requete sqlon doit declarer un objet de la class sqlcommand */

            SqlCommand cmd1;
            cmd1 = new SqlCommand(); //le constructeur ne contient aucun paramètre

            cmd1.CommandText = "select * from Eleve";// on passe la requte sql

            /*on definit le type de la commande commandtype.text pour une requete sql */

            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = connexion; // on affecte la command a une connexion
            SqlDataReader r;
            r = cmd1.ExecuteReader();
            /*parcourir l’objet r on lecture la boucle s’arrete a la fin du parcour des enregistrements*/
            Boolean stop = false;
            while (r.Read() && !stop)
            {
                /* on affect les different colonne de la table a des variable 
                en utilisant le casting car r["nom du champ"] retour un objet de class OBJECT*/

                string id = (string)r[@"Id_eleve"];
                string password = (string)r["password"];
                string nom = (string)r["nom"];
                string prenom = (string)r["prenom"];



                //Eleve eleve = new Eleve(id, password, nom, prenom);
                /*afficher les variable qui contient un enregistrement dans un messagebox
                MessageBox.Show(nom + " " + id + " " + prenom);*/

                // if (this.name == id)
                if (this.name == id)
                {
                    this.labelNomPrenom_Copy.Content = nom + " " + prenom;
                    stop = true;
                }

            }
            connexion.Close();
        }




        private void buttonChap1_Click(object sender, RoutedEventArgs e)
        {

            Animations.AddSound(1);
            this.NavigationService.Navigate(new InterfaceChapitre1());

        }

        private void buttonChap2_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);
            this.NavigationService.Navigate(new InterfaceChapitre2());
        }

        private void buttonChap3_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);
            this.NavigationService.Navigate(new InterfaceChapitre3());

        }

        private void GoToFinalTest_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);
            App.interfaceTestFinal = new InterfaceTestFinal();
            this.NavigationService.Navigate(App.interfaceTestFinal);
        }

      



        private void Bonus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Animations.AddSound(1);
            InterfaceBonus win = new InterfaceBonus();
            App.mainWindow.Opacity=0.5f;
            win.Show();
            
        }
    }
}
