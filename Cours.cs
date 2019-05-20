using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AlGeo
{
    class Cours
    {
        public int id_cours { get; set; }
        public int lastPage { get; set; }

        public void sauvegarderLastPage(int id_cours, int lastpage)
        /*
         * Cette méthode permet la sauvegarde de la 
         * page courante « lastPage » (dernière page visitée) dans la 
         * table « Eleve_Cours » dans la base de doonées. 
         */
        {
            Supprimer_Ligne_Cours(id_cours);
            try
            {
                /*
                 * il faut d'abord définir les éléments qu'on va insérer 
                 * dans notre cas; id_eleve,id_cours,lastpage
                 * (definir la requete d'insetion avec les paramete)
                 */
                string insertStmt = "INSERT INTO Eleve_Cours (id_eleve,id_cours,lastpage)" +
                                    "VALUES(@id_eleve, @id_cours, @lastpage)";

                /*
                 *definir la connexion et la commande  
                 */
                string lines = System.IO.File.ReadAllText(@"userID.TMP");
                string id_eleve = lines.Trim();
                string path = System.IO.Directory.GetCurrentDirectory();
                string lien = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "\\Etudiant.mdf;Integrated Security=True";
                using (SqlConnection conn = new SqlConnection(lien))
                using (SqlCommand cmd = new SqlCommand(insertStmt, conn))
                {
                    //definir les parametres et mettre leurs valeurs
                    cmd.Parameters.Add("@id_eleve", SqlDbType.NVarChar, 50).Value = id_eleve.Trim();
                    cmd.Parameters.Add("@id_cours", SqlDbType.Int).Value = id_cours;
                    cmd.Parameters.Add("@lastpage", SqlDbType.Int).Value = lastpage;

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
        public int RecupererLastPage(int id_cours)
        /*
         Cette méthode permet la récupération de la dernière 
         page visitée de la base de données et la retourner.
         */
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            string lien = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "\\Etudiant.mdf;Integrated Security=True";
            string lines = System.IO.File.ReadAllText(@"userID.TMP");
            string id_eleve = lines.Trim();
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
            return lastpage;
        }
        public void Supprimer_Ligne_Cours(int id_cours)
        /*
         * Cette méthode permet de supprimer la ligne 
         * correspondante à « id_cours » de la table « Eleve_Cours » 
         * de la base de données. (elle nous permet de faire la 
         * mise à jours, lorsque on veut sauvegarder la nouvelle
         *  valeur de la dernière page 
         * visité dans le cours correspondant à id_cours) 
         */
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            string lien = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "\\Etudiant.mdf;Integrated Security=True";
            string lines = System.IO.File.ReadAllText(@"userID.TMP");
            string id_eleve = lines.Trim();
            SqlConnection connexion = new SqlConnection(lien);
            connexion.Open();
            /*
            *definir la connexion et la commande  
            */
            string requete1 = "delete from Eleve_Cours where id_eleve=N'" + id_eleve + "'and id_cours='" + id_cours + "'";
            SqlCommand cmd1 = new SqlCommand(requete1, connexion);
            cmd1.ExecuteNonQuery();
            connexion.Close();
        }
    
        
      public int RecupererNbPage(int id_cours)
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            string lien = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "\\Etudiant.mdf;Integrated Security=True";
            SqlConnection connexion = new SqlConnection(lien);
            connexion.Open();
            /*pour pouvoir executer une requete sqlon doit declarer un objet de la class sqlcommand */
            SqlCommand cmd1;
            cmd1 = new SqlCommand(); //le constructeur ne contient aucun paramètre
            cmd1.CommandText = "select * from Cours";// on passe la requte sql
            /*on definit le type de la commande commandtype.text pour une requete sql */
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = connexion; // on affecte la command a une connexion
            SqlDataReader r;
            r = cmd1.ExecuteReader();
            /*parcourir l’objet r on lecture la boucle s’arrete a la fin du parcour des enregistrements*/
            Boolean stop = false;
            int lastpage = 0;
            while (r.Read() && !stop)
            {
                /* on affect les different colonne de la table a des variable 
                en utilisant le casting car r["nom du champ"] retour un objet de class OBJECT*/
                int id_cours_db = (int)r["id_cours"];
                int lastpage_db = (int)r["nbr_page"];
                if (id_cours == id_cours_db)
                {
                    stop = true;
                    lastpage = lastpage_db;
                }
            }
            connexion.Close();
            return lastpage;
        }
    }

}
