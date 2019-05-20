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
    class Eleve
    /*
     * Cette classe permet de la gestion
     *  de tout ce que l’élève peut faire, 
     *  se connecter, s’inscrire …etc
     */
    {
        public string id { get; set; }
        //L’identificateur de l’élève, il doit être unique
        public string password { get; set; }
        /*Chaque élève est caractérisé par son
         *  mot de passe qui lui donne accès à l’application
         */
        public string nom { get; set; }
        //Représente le nom de l’élève
        public string prenom { get; set; }
        //Représente le prénom de l’élève
        public Cours cours = new Cours();
        /*
         Chaque élève doit suivre son cours, 
         pour cela on doit lui attribuer la classe cours. 
         */
        public Exercice exercice = new Exercice();
         /*
         * Chaque élève est caractérisé par ses exercices, 
         * pour cela on doit lui attribuer l’attribut « Exercice » 
         */


        public Eleve() {}

        public Eleve(string id,string password,string nom,string prenom)
        {
            this.id = id;
            this.password = password;
            this.nom = nom;
            this.prenom = prenom;
        }

        
        public void Supprimer_Ligne_Eleve(string id_eleve)
        /*Cette méthode permet de supprimer une ligne de
         *  la table « Eleve » de la base de données 
         *  afin de pourvoir faire la mise à jour des 
         *  attributs de l’élève
          */
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            string lien = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "\\Etudiant.mdf;Integrated Security=True";
            // string lines = System.IO.File.ReadAllText(@"userID.TMP");
            // string id_eleve = lines.Trim();
            SqlConnection connexion = new SqlConnection(lien);
            connexion.Open();
            /*
            *definir la connexion et la commande  
            */
            string requete1 = "delete from Eleve where id_eleve=N'" + id_eleve + "'";
            SqlCommand cmd1 = new SqlCommand(requete1, connexion);

            /* SqlCommand Command = new SqlCommand(
              "DELETE FROM Eleve_Exercice WHERE id_eleve=N'@id_eleve'" + connexion);


             Command.Parameters.AddWithValue("@word", word);*/
            cmd1.ExecuteNonQuery();
            connexion.Close();
        }

        

        public void CreerCompte(string id_eleve, string passWord, string nom, string prenom)
        {
            /*Cette méthode permet la création d’un compte
             *  pour l’élève qui lui permet de se connecter 
             *  et avoir accès à ses cours et ses exercices, 
             *  en ajoutant tous ses coordonnées dans la base 
             *  de données, et qui initialise son score dans 
             *  les différents types des exercices à 0 et
             *  la dernière page visitée dans ses cours à 1 
             */
            Securite securite = new Securite();
            string password = securite.EncryptPassword(passWord);
            if (this.CompteExistant(id_eleve)==false)
            {
                InterfaceMessageBox mb = new InterfaceMessageBox("حساب موجود");
                mb.Show();
            }
            else {
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
                    string[] lines = { id_eleve };
                    System.IO.File.WriteAllLines(@"userID.TMP", lines);
                    // ConnexionToDataBase co = new ConnexionToDataBase();
                    for (int i = 1; i <= 12; i++)
                    {
                        exercice.sauvegarderScore(i, 0);
                    }


                    cours.sauvegarderLastPage(1, 1);
                    cours.sauvegarderLastPage(2, 1);
                    cours.sauvegarderLastPage(3, 1);
                    InterfaceMessageBox interfaceMessageBox = new InterfaceMessageBox(" مرحبا " + prenom + " " + nom);
                    interfaceMessageBox.Show();

                }
                catch (Exception)
                {
                    MessageBox.Show("            اوووووبس تاكد من معلوماتك \n\n\nلمزيد من المعلومات اضغط على زر المساعدة");
                }

            }
           
        }


        public int Connecter(string userID, string passWord)
        /*Cette méthode retourne 1 si l’étudiant
         *  peut se connecter si ses coordonnées 
         *  existent dans la base de données, retourne -1 
         *  si le compte existe mais le mot de passe est faux, 
         *  retourne 0 si le compte est inexistant. Bien sûr 
         *  pour la sécurité, cette classe permet d’encrypté le mot 
         *  de passe dans la base de données, comme ça personne 
         *  n’aura accès (ou pourra savoir le mot de passe d’un 
         *  autre étudiant) au compte d’un autre étudiant. 
         */
        {
            Securite securite = new Securite();
            string password = securite.EncryptPassword(passWord);
            /* obtenir le chemin courant */
            string path = System.IO.Directory.GetCurrentDirectory();

            string lien = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "\\Etudiant.mdf;Integrated Security=True";
            SqlConnection connexion = new SqlConnection(lien);
            connexion.Open();
            string requete = "select id_eleve,password from Eleve where id_eleve=N'" + userID + "'and password=N'" + password + "'";
            SqlCommand cmd = new SqlCommand(requete, connexion);
            /*Initialise une nouvelle instance de la 
             * SqlDataAdapter classe avec l’objet SqlCommand
             *  comme le SelectCommand propriété.*/
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string[] lines = { userID };
                System.IO.File.WriteAllLines(@"userID.TMP", lines);
                connexion.Close();
                return 1;

            }
            else
            {
                string requete1 = "select id_eleve from Eleve where id_eleve=N'" + userID + "'";
                SqlCommand cmd1 = new SqlCommand(requete1, connexion);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    connexion.Close();
                    return -1;

                }
                else
                {
                    connexion.Close();
                    return 0;
                }
            }

        }

        public Boolean CompteExistant(string userID)
        {
            /*
             Cette méthode retourne vrai si le compte 
             existe déjà dans la base de données, 
             sinon elle retourne faux si le compte est 
             inexistant. */


            /* obtenir le chemin courant */
            string path = System.IO.Directory.GetCurrentDirectory();

            string lien = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "\\Etudiant.mdf;Integrated Security=True";
            SqlConnection connexion = new SqlConnection(lien);
            connexion.Open();
            string requete = "select id_eleve from Eleve where id_eleve=N'" + userID +"'";
            SqlCommand cmd = new SqlCommand(requete, connexion);
            /*Initialise une nouvelle instance de la 
             * SqlDataAdapter classe avec l’objet SqlCommand
             *  comme le SelectCommand propriété.*/
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                connexion.Close();
                return false;//si compte existant 
            }
            else
            {
                    connexion.Close();
                    return true;//compte non existant
            }
         }

        }
    }
