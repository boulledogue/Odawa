using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Odawa.BU.Entities;


namespace Odawa.DAL
{
    static class UtilisateurProvider
    {
        public static List<Utilisateur> GetAll()
        {
            DataTable dt = DatabaseConnection.GetUtilisateurs();
            List<Utilisateur> lst = new List<Utilisateur>();
            foreach (OdawaDS.utilisateursRow userRow in dt.Rows)
            {
                lst.Add(GetOne(userRow.id));
            }

            return lst;
        }

        public static OdawaDS.utilisateursDataTable GetTable()
        {
            return DatabaseConnection.GetUtilisateurs();
        }

        public static Utilisateur GetOne(int id)
        {
            Utilisateur t = new Utilisateur();
            t.id = DatabaseConnection.odawa.utilisateurs.FindByid(id).id;
            t.nom = DatabaseConnection.odawa.utilisateurs.FindByid(id).nom;
            t.prenom = DatabaseConnection.odawa.utilisateurs.FindByid(id).prenom;
            t.username = DatabaseConnection.odawa.utilisateurs.FindByid(id).username;
            t.password = DatabaseConnection.odawa.utilisateurs.FindByid(id).password;
            t.email = DatabaseConnection.odawa.utilisateurs.FindByid(id).email;
            t.phone = DatabaseConnection.odawa.utilisateurs.FindByid(id).phone;
            return t;
        }

        public static List<Utilisateur> Search( int id, String nom, String prenom, String username, String password, String phone )
        {
            DataTable dt = DatabaseConnection.GetUtilisateurs();
            List<Utilisateur> lst = new List<Utilisateur>();
            foreach (OdawaDS.utilisateursRow userRow in dt.Rows)
            {
                if( ( id == 0 ) || ( userRow.id == id ) )
                {
                    if( ( nom == null ) || ( userRow.nom == nom ) )
                    {
                        if( ( prenom == null ) || ( userRow.prenom == prenom ) )
                        {
                            if( ( username == null ) || ( userRow.username == username ) )
                            {
                                if( (password == null ) || ( userRow.password == password ) )
                                {
                                   if( (phone == null ) || ( userRow.phone == phone ) )
                                   {
                                       Utilisateur user = new Utilisateur();
                                       user.id = userRow.id;
                                       user.nom = userRow.nom;
                                       user.prenom = userRow.prenom;
                                       user.username = userRow.username;
                                       user.password = userRow.password;
                                       user.phone = userRow.phone;
                                       lst.Add(user);
                                   }
                                }
                            }
                        }
                    }
                }
            }

            return lst;
        }

        public static Utilisateur Search( int id )
        {
            Utilisateur user = new Utilisateur();
            List<Utilisateur> lst = Search(id, null, null, null, null, null);
            user = lst.First();
            return user;
        }

        public static bool Exist( String username, String password )
        {
            bool exist = false;
            List<Utilisateur> lst = new List<Utilisateur>();
            lst = Search(0, null, null, username, password, null);
            exist = (lst.Count == 1) ? true : false ;
            return exist;
        }

        public static void Create( Utilisateur utl )
        {
            OdawaDS.utilisateursRow newRow = DatabaseConnection.odawa.utilisateurs.NewutilisateursRow();
            newRow.nom = utl.nom;
            newRow.prenom = utl.prenom;
            newRow.username = utl.username;
            newRow.password = utl.password;
            newRow.email = utl.email;
            newRow.phone = utl.phone;
            DatabaseConnection.odawa.administrateurs.Rows.Add(newRow);
            WriteToDB();
        }

        public static void Update( Utilisateur utl )
        {
            DatabaseConnection.odawa.utilisateurs.FindByid(utl.id).nom = utl.nom;
            DatabaseConnection.odawa.utilisateurs.FindByid(utl.id).prenom = utl.prenom;
            DatabaseConnection.odawa.utilisateurs.FindByid(utl.id).username = utl.username;
            DatabaseConnection.odawa.utilisateurs.FindByid(utl.id).password = utl.password;
            DatabaseConnection.odawa.utilisateurs.FindByid(utl.id).email = utl.email;
            DatabaseConnection.odawa.utilisateurs.FindByid(utl.id).phone = utl.phone;
            WriteToDB();
        }

        public static void Delete( int id )
        {
            DatabaseConnection.odawa.utilisateurs.FindByid(id).Delete();
            WriteToDB();
        }

        private static void WriteToDB()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["odawaConnectionString"].ConnectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from utilisateurs", conn);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);
                da.Update(DatabaseConnection.odawa, "utilisateurs");
            }
            DatabaseConnection.odawa.utilisateurs.AcceptChanges();
        }

    }
}
