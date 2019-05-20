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
    /// Interaction logic for InterfaceAdministrateur.xaml
    /// </summary>
    public partial class InterfaceAdministrateur : Window
    {
        public InterfaceAdministrateur()
        {
            InitializeComponent();
        }

        private void setPAsswordLabelContent()
        {
            ConnexionToDataBase ctd = new ConnexionToDataBase();
            this.passwordLabel.Content = ctd.afficherMotDePasse(this.name.Text, this.surname.Text);
        }

        private void setLastPageLabel()
        {
            ConnexionToDataBase ctd = new ConnexionToDataBase();
            string id = ctd.getId_eleve(this.name.Text, this.surname.Text);
            int last1 = ctd.RecupererDernierePage(id, 1);
            int last2 = ctd.RecupererDernierePage(id, 2);
            int last3 = ctd.RecupererDernierePage(id, 3);
            this.lastpage1.Content = last1;
            this.lastpage2.Content = last2;
            this.lastpage3.Content = last3;
        }

        private void setScoreExercice()
        {
            ConnexionToDataBase ctd = new ConnexionToDataBase();
            string id = ctd.getId_eleve(this.name.Text, this.surname.Text);
            int score1 = ctd.RecupererScoreEtudiant(id, 1);
            int score2 = ctd.RecupererScoreEtudiant(id, 2);
            int score3 = ctd.RecupererScoreEtudiant(id, 3);
            int score4 = ctd.RecupererScoreEtudiant(id, 4);
            int score5 = ctd.RecupererScoreEtudiant(id, 5);
            int score6 = ctd.RecupererScoreEtudiant(id, 6);
            int score7 = ctd.RecupererScoreEtudiant(id, 7);
            int score8 = ctd.RecupererScoreEtudiant(id, 8);
            int score9 = ctd.RecupererScoreEtudiant(id, 9);
            int score10 = ctd.RecupererScoreEtudiant(id, 10);
            int score11 = ctd.RecupererScoreEtudiant(id, 11);
            int score12 = ctd.RecupererScoreEtudiant(id, 12);
            this.exo1.Content = score1;
            this.exo2.Content = score1;
            this.exo3.Content = score3;
            this.exo4.Content = score4;
            this.exo5.Content = score5;
            this.exo6.Content = score6;
            this.exo7.Content = score7;
            this.exo8.Content = score8;
            this.exo9.Content = score9;
            this.exo10.Content = score10;
            this.exo11.Content = score11;
            this.exo12.Content = score12;

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            setPAsswordLabelContent();
            setLastPageLabel();
            setScoreExercice();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ConnexionToDataBase ctd = new ConnexionToDataBase();
            ctd.changePassWord("ADMIN", this.pass.Text);
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.btnPassWord.IsEnabled = true;

        }

        private void pass_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.btnPassWord.IsEnabled = true;
        }

        private void surname_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.search.IsEnabled = true;
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
