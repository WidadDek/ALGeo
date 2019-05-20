using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace AlGeo
{
    class ConnexionToDataBase
    {
        public SqlConnection maconnexion { get; set; }

        /*------------------------------------------------------------------------------------*/
        public SqlConnection seConnecter(string lien)
        /*
         * cette méthode permet d'établir une connexion vers la base de données
         */
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            string lien1 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "\\Etudiant.mdf;Integrated Security=True";
            maconnexion = new SqlConnection(lien1);
            try
            {
                maconnexion.Open();
                Console.WriteLine("Connexion Réussi !");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Echec de connexion !" + ex.Message);
            }
            return maconnexion;
        }
        /*------------------------------------------------------------------------------------*/
        public void seDeconnecter(SqlConnection maconnexion)
        /*
         * cette méthode permet de se deconneter 
         */
        {
            try
            {
                maconnexion.Close();
                Console.WriteLine("Deconnexion reussie !");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Echec de deconnexion !" + ex.Message);

            }
        }
        /*------------------------------------------------------------------------------------*/
        public void changePassWord(string id_eleve, string passWord)
        {
            Eleve eleve = new Eleve();
            Securite securite = new Securite();
            string password = securite.EncryptPassword(passWord.ToUpper());
            string nom = "ADMIN";
            string prenom = "ADMIN";
            eleve.Supprimer_Ligne_Eleve(id_eleve);
            try
            {
                /*
                 * il faut d'abord définir les éléments qu'on va insérer 
                 * dans notre cas; nom,prenom,id_eleve,password
                 * (definir la requete d'insetion avec les paramete)
                 */
                string insertStmt = "INSERT INTO Eleve (id_eleve,password,nom,prenom)" +
                                    "VALUES(@id_eleve, @password, @nom, @prenom)";

                /*
                 *definir la connexion et la commande  
                 */
                string path = System.IO.Directory.GetCurrentDirectory();
                string lien = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "\\Etudiant.mdf;Integrated Security=True";
                using (SqlConnection conn = new SqlConnection(lien))
                using (SqlCommand cmd = new SqlCommand(insertStmt, conn))
                {
                    //definir les parametres et mettre leurs valeurs
                    cmd.Parameters.Add("@id_eleve", SqlDbType.NVarChar, 50).Value = id_eleve;
                    cmd.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = password;
                    cmd.Parameters.Add("@nom", SqlDbType.NVarChar, 50).Value = nom;
                    cmd.Parameters.Add("@prenom", SqlDbType.NVarChar, 50).Value = prenom;

                    // open connection, execute query, close connection
                    conn.Open(); //ouvrir la connexion
                    int rowsInserted = cmd.ExecuteNonQuery(); //execution de la commande de l'instruction
                    conn.Close(); //fermer la connexion
                }
               
            }
            catch (Exception)
            {
                MessageBox.Show("            اوووووبس تاكد من معلوماتك \n\n\nلمزيد من المعلومات اضغط على زر المساعدة");
            }
        }


        public string afficherMotDePasse(string name, string surname)
        {
            string password = " ";
            string path = System.IO.Directory.GetCurrentDirectory();
            string lien = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "\\Etudiant.mdf;Integrated Security=True";

            SqlConnection connexion = new SqlConnection(lien);
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

                string id = (string)r["id_eleve"];
                password = (string)r["password"];
                string nom = (string)r["nom"];
                string prenom = (string)r["prenom"];
                if ((name == nom) && (surname == prenom))
                {
                    stop = true;
                }
            }
            connexion.Close();
            Securite s = new Securite();
            
            return s.DecryptPassword(password);
        }

        public int RecupererScoreEtudiant(string id_eleve, int id_exercice)
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            string lien = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "\\Etudiant.mdf;Integrated Security=True";
            SqlConnection connexion = new SqlConnection(lien);
            connexion.Open();
            /*pour pouvoir executer une requete sqlon doit declarer un objet de la class sqlcommand */
            SqlCommand cmd1;
            cmd1 = new SqlCommand(); //le constructeur ne contient aucun paramètre
            cmd1.CommandText = "select * from Eleve_Exercice";// on passe la requte sql
            /*on definit le type de la commande commandtype.text pour une requete sql */
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = connexion; // on affecte la command a une connexion
            SqlDataReader r;
            r = cmd1.ExecuteReader();
            /*parcourir l’objet r on lecture la boucle s’arrete a la fin du parcour des enregistrements*/
            Boolean stop = false;
            int score = 0;
            while (r.Read() && !stop)
            {
                /* on affect les different colonne de la table a des variable 
                en utilisant le casting car r["nom du champ"] retour un objet de class OBJECT*/
                string id_eleve_db = (string)r["id_eleve"];
                int id_exercice_db = (int)r["id_exercice"];
                int score_db = (int)r["score"];
                if ((id_exercice == id_exercice_db) && (id_eleve_db == id_eleve))
                {
                    stop = true;
                    score = score_db;
                }
            }
            connexion.Close();
            MessageBox.Show("score =" + score);
            return score;
        }


        public int RecupererDernierePage(string id_eleve, int id_cours)
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            string lien = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "\\Etudiant.mdf;Integrated Security=True";
            SqlConnection connexion = new SqlConnection(lien);
            connexion.Open();
            /*pour pouvoir executer une requete sqlon doit declarer un objet de la class sqlcommand */
            SqlCommand cmd1;
            cmd1 = new SqlCommand(); //le constructeur ne contient aucun paramètre
            cmd1.CommandText = "select * from Eleve_Cours";// on passe la requte sql
            /*on definit le type de la commande commandtype.text pour une requete sql */
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = connexion; // on affecte la command a une connexion
            SqlDataReader r;
            r = cmd1.ExecuteReader();
            /*parcourir l’objet r on lecture la boucle s’arrete a la fin du parcour des enregistrements*/
            Boolean stop = false;
            int lastpage = 1;
            while (r.Read() && !stop)
            {
                /* on affect les different colonne de la table a des variable 
                en utilisant le casting car r["nom du champ"] retour un objet de class OBJECT*/
                string id_eleve_db = (string)r["id_eleve"];
                int id_cours_db = (int)r["id_cours"];
                int lastpage_db = (int)r["lastpage"];
                if ((id_cours == id_cours_db) && (id_eleve_db == id_eleve))
                {
                    stop = true;
                    lastpage = lastpage_db;
                }
            }
            connexion.Close();
            MessageBox.Show("lastpage =" + lastpage);
            return lastpage;
        }

        public string getId_eleve(string name, string surname)
        {
            string id = "";
            string path = System.IO.Directory.GetCurrentDirectory();
            string lien = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "\\Etudiant.mdf;Integrated Security=True";

            SqlConnection connexion = new SqlConnection(lien);
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

                id = (string)r["id_eleve"];
                string password = (string)r["password"];
                string nom = (string)r["nom"];
                string prenom = (string)r["prenom"];
                if ((name == nom) && (surname == prenom))
                {
                    stop = true;

                }
            }
            connexion.Close();
            return id;
        }


    }
}


