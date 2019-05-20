using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace AlGeo
{
    /// <summary>
    /// Interaction logic for InterfaceCreateAccount.xaml
    /// </summary>
    public partial class InterfaceCreateAccount : Window
    {
        //Cette interface nous permet de creer un compte
        public InterfaceCreateAccount()
        {
            InitializeComponent();
            Animations.AddSound(2);


        }



        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);

            if (id_eleve.Text == "" || nom.Text == "" || prenom.Text == "" || password.Text == "")
            {
                InterfaceMessageBox interfaceMessageBox = new InterfaceMessageBox("عليك بملئ جميع الخانات");
                interfaceMessageBox.Show();


            }
            else
            {
                //Instancier un nouveau eleve et on le sauvegarde 
                Eleve eleve = new Eleve();
                eleve.CreerCompte(id_eleve.Text.Trim(), password.Text.Trim(), nom.Text.Trim(), prenom.Text.Trim());
                this.Close();
            }


        }

        private void password_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void buttonExitCreateAcccount_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void id_eleve_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            this.InfoBulleGridIdUser.Visibility = Visibility.Visible;
            //on lui un affiche un message que le id_eleve est important
            // et qu'il ne faut pas l'oublier pour la prochaine connexion
        }

        private void password_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            //on lui affiche une message que le mot de passe il ne faut pas l'oublier
            this.InfoBulleGridPassword.Visibility = Visibility.Visible;
        }

        private void id_eleve_LostFocus(object sender, RoutedEventArgs e)
        {
            this.InfoBulleGridIdUser.Visibility = Visibility.Hidden;
        }

        private void password_LostFocus(object sender, RoutedEventArgs e)
        {
            this.InfoBulleGridPassword.Visibility = Visibility.Hidden;

        }
    }
}
