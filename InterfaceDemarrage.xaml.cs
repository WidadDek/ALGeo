using System.Data.SqlClient;
using System.Windows;


namespace AlGeo
{
    
    public partial class InterfaceDemarrage : Window
    {
        /*
         * dans cette interface on fait le chargement da la base de données
         *  à partir de la mémoire vers la mémoire centrale 
         */
      

        public InterfaceDemarrage()
        {
            InitializeComponent();
            string path = System.IO.Directory.GetCurrentDirectory();
            string lien = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "\\Etudiant.mdf;Integrated Security=True";
            string lines = System.IO.File.ReadAllText(@"userID.TMP");
            string id_eleve = lines.Trim();
            SqlConnection connexion = new SqlConnection(lien);
            connexion.Open();
            connexion.Close();

        }
        private void startProgram()
        {

            App.mainWindow = new ApplicationWindow();
            App.mainWindow.Show();
            this.Close();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Animations.AddSound(1);
            startProgram();
        }
    }
}
