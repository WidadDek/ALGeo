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
    /// Interaction logic for InterfaceConnexion.xaml
    /// </summary>
    public partial class InterfaceConnexion : Page
        /*
         * L'interface ou l'étudiant peut se connecter
         */
    {
        public InterfaceConnexion()
        {
            InitializeComponent();
            Animations.AddSound(2);
            errorImage.Visibility = System.Windows.Visibility.Hidden;

        }

        private void btnCreerCompte_Click(object sender, RoutedEventArgs e)
        // Lorsque on clique sur le bouton pour creer un compte 
        {
            Animations.AddSound(1);

            InterfaceCreateAccount interfaceCreateAccount = new InterfaceCreateAccount();

            interfaceCreateAccount.Show();



        }
        private void btnConnexion_Click(object sender, RoutedEventArgs e)
        //lorsque on clique sur le bouton pour se connecter
        {
            Animations.AddSound(1);
            if (txtUserName.Text.ToUpper() == "ADMIN")
            //Dans le cas ou l'administrateur se connecte on affiche l'interface d'administartion 
            {
                Eleve ctd = new Eleve();
                int c = ctd.Connecter(txtUserName.Text.ToUpper(), txtPassword.Password.ToUpper());
                if (c == 1)
                {
                    InterfaceAdministrateur interfaceadmin = new InterfaceAdministrateur();
                    interfaceadmin.Show();
                   
                }
                else
                {
                    if (c == -1)
                    {
                        InterfaceMessageBox interfaceMessageBox = new InterfaceMessageBox(" كلمة السر خاطئ");
                        interfaceMessageBox.Show();
                        errorImage.Visibility = System.Windows.Visibility.Visible;
                    }
                    else if (c == 0)
                    {
                        InterfaceMessageBox interfaceMessageBox = new InterfaceMessageBox("اسم المستخدم خاطئ" + "\n" + " قم بفتح حساب جديد");
                        interfaceMessageBox.Show();

                    }
                }
            }
            else
            {
                if ((txtUserName.Text == "") || (txtPassword.Password == ""))
                {
                    InterfaceMessageBox interfaceMessageBox = new InterfaceMessageBox("عليك ملء كل الخانات");
                    interfaceMessageBox.Show();
                }
                else
                {
                    Eleve ctd = new Eleve();
                    int c = ctd.Connecter(txtUserName.Text, txtPassword.Password);
                    if (c == 1)
                    //  si le nom d'utilisateur et le mot de passe sont justes
                    {
                        this.NavigationService.Navigate(new InterfaceHomePage());
                    }
                    else
                    {
                        if (c == -1)
                        // si le mot de passe est erroné 
                        {
                            InterfaceMessageBox interfaceMessageBox = new InterfaceMessageBox(" كلمة السر خاطئ");
                            interfaceMessageBox.Show();
                            errorImage.Visibility = System.Windows.Visibility.Visible;
                        }
                        else if (c == 0)
                        //si le compte est inexistant 
                        {
                            InterfaceMessageBox interfaceMessageBox = new InterfaceMessageBox("اسم المستخدم خاطئ" + "\n" + " قم بفتح حساب جديد");
                            interfaceMessageBox.Show();

                        }
                    }

                }
            }
        }


        private void txtPassword_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            errorImage.Visibility = System.Windows.Visibility.Hidden;
        }

      

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        //on affiche le Help 
        {
            Animations.AddSound(1);
            FenetreHelp fenetreHelp = new FenetreHelp();
            fenetreHelp.Show();
        }

        private void buttonAPropos_Click(object sender, RoutedEventArgs e)
        //on affiche la page a propos 
        {

            Apropos apropos = new Apropos();
            apropos.Show();
        }

        private void txtPassword_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            errorImage.Visibility = System.Windows.Visibility.Hidden;
        }

        private void txtPassword_TextInput(object sender, TextCompositionEventArgs e)
        {
            errorImage.Visibility = System.Windows.Visibility.Hidden;
        }

    }
}
