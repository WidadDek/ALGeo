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
    class Exercice
    {
        public int id_exercice { get; set; }
        public int score { get; set; }



        public void Supprimer_Ligne_Exercice(int id_exercice)
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
            string requete1 = "delete from Eleve_Exercice where id_eleve=N'" + id_eleve + "'and id_exercice='" + id_exercice + "'";
            SqlCommand cmd1 = new SqlCommand(requete1, connexion);

            /* SqlCommand Command = new SqlCommand(
              "DELETE FROM Eleve_Exercice WHERE id_eleve=N'@id_eleve'" + connexion);


             Command.Parameters.AddWithValue("@word", word);*/
            cmd1.ExecuteNonQuery();
            connexion.Close();
        }

        public int RecupererScore(int id_exercice)
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
            // return score_db;
            connexion.Close();
          //  MessageBox.Show("score =" + score);
            return score;
        }

        public void sauvegarderScore(int id_exercice, int score)
        {
            if (score != 0)
            {
                Supprimer_Ligne_Exercice(id_exercice);
            }
            try
            {

                /*
                 * il faut d'abord définir les éléments qu'on va insérer 
                 * dans notre cas; nom,prenom,id_eleve,password
                 * (definir la requete d'insetion avec les paramete)
                 */
                string insertStmt = "INSERT INTO Eleve_Exercice (id_eleve,id_exercice,score)" +
                                    "VALUES(@id_eleve, @id_exercice, @score)";


                string lines = System.IO.File.ReadAllText(@"userID.TMP");
                string id_eleve = lines.Trim();
                string path = System.IO.Directory.GetCurrentDirectory();
                string lien = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "\\Etudiant.mdf;Integrated Security=True";
                using (SqlConnection conn = new SqlConnection(lien))


                using (SqlCommand cmds = new SqlCommand())
                using (SqlCommand cmd = new SqlCommand(insertStmt, conn))
                {
                    //definir les parametres et mettre leurs valeurs
                    cmd.Parameters.Add("@id_eleve", SqlDbType.NVarChar, 50).Value = id_eleve.Trim();
                    cmd.Parameters.Add("@id_exercice", SqlDbType.Int).Value = id_exercice;
                    cmd.Parameters.Add("@score", SqlDbType.Int).Value = score;
                    // cmd.Parameters.Add("@prenom", SqlDbType.NVarChar, 50).Value = prenom.Text.Trim();

                    // open connection, execute query, close connection
                    conn.Open(); //ouvrir la connexion
                    int rowsInserted = cmd.ExecuteNonQuery(); //execution de la commande de l'instruction
                    conn.Close(); //fermer la connexion
                }
             //   InterfaceMessageBox interfaceMessageBox = new InterfaceMessageBox(" مرحبا ");
                // interfaceMessageBox.Show();
                // this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("            اوووووبس تاكد من معلوماتك \n\n\nلمزيد من المعلومات اضغط على زر المساعدة");
            }
        }


        public int ScoreTotal()
        {
            int i;
            int scoretotal = 0;
            for (i = 1; i <= 12; i++)
            {
                scoretotal = this.RecupererScore(i) + scoretotal;
            }
            return scoretotal;
        }
    }
}
