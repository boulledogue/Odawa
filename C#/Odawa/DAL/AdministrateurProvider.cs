using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odawa.BU.Entities;

namespace Odawa.DAL
{
    static class AdministrateurProvider
    {
        public static List<Administrateur> GetAll()
        {
            DataTable dt = DatabaseConnection.GetAdministrateurs();
            List<Administrateur> lst = new List<Administrateur>();
            foreach (OdawaDS.administrateursRow adminRow in dt.Rows)
            {
                lst.Add(GetOne(adminRow.id));
            }

            return lst;
        }

        public static Administrateur GetOne(int id)
        {
            Administrateur a = new Administrateur();
            a.id = DatabaseConnection.odawa.administrateurs.FindByid(id).id;
            a.nom = DatabaseConnection.odawa.administrateurs.FindByid(id).nom;
            a.prenom = DatabaseConnection.odawa.administrateurs.FindByid(id).prenom;
            a.username = DatabaseConnection.odawa.administrateurs.FindByid(id).username;
            a.password = DatabaseConnection.odawa.administrateurs.FindByid(id).password;
            a.email = DatabaseConnection.odawa.administrateurs.FindByid(id).email;
            a.phone = DatabaseConnection.odawa.administrateurs.FindByid(id).phone;
            return a;
        }

        public static List<Administrateur> Search( int id, String nom, String prenom, String username, String password, String phone )
        {
            DataTable dt = DatabaseConnection.GetDataSet().Tables["administrateurs"];
            List<Administrateur> lst = new List<Administrateur>();
            foreach (OdawaDS.administrateursRow adminRow in dt.Rows)
            {
                if ((id == 0) || (adminRow.id == id))
                {
                    if ((nom == null) || (adminRow.nom == nom))
                    {
                        if ((prenom == null) || (adminRow.prenom == prenom))
                        {
                            if ((username == null) || (adminRow.username == username))
                            {
                                if ((password == null) || (adminRow.password == password))
                                {
                                    if ((phone == null) || (adminRow.phone == phone))
                                    {
                                        Administrateur admin = new Administrateur();
                                        admin.id = adminRow.id;
                                        admin.nom = adminRow.nom;
                                        admin.prenom = adminRow.prenom;
                                        admin.username = adminRow.username;
                                        admin.password = adminRow.password;
                                        admin.email = adminRow.email;
                                        admin.phone = adminRow.phone;
                                        lst.Add(admin);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return lst;
        }

        public static Administrateur Search(int id)
        {
            Administrateur admin = new Administrateur();
            List<Administrateur> lst = Search(id, null, null, null, null, null);
            admin = lst.First();
            return admin;
        }

        public static bool Exist(String username, String password)
        {
            bool exist = false;
            List<Administrateur> lst = new List<Administrateur>();
            lst = Search(0, null, null, username, password, null);
            exist = (lst.Count == 1) ? true : false;
            return exist;
        }

        public static void Create( Administrateur adm )
        {
            OdawaDS.administrateursRow newRow = DatabaseConnection.odawa.administrateurs.NewadministrateursRow();
            newRow.nom = adm.nom;
            newRow.prenom = adm.prenom;
            newRow.username = adm.username;
            newRow.password = adm.password;
            newRow.email = adm.email;
            newRow.phone = adm.phone;
            DatabaseConnection.odawa.administrateurs.Rows.Add(newRow);
            WriteToDB();
        }

        public static void Update( Administrateur adm )
        {
            DatabaseConnection.odawa.administrateurs.FindByid(adm.id).nom = adm.nom;
            DatabaseConnection.odawa.administrateurs.FindByid(adm.id).prenom = adm.prenom;
            DatabaseConnection.odawa.administrateurs.FindByid(adm.id).username = adm.username;
            DatabaseConnection.odawa.administrateurs.FindByid(adm.id).password = adm.password;
            DatabaseConnection.odawa.administrateurs.FindByid(adm.id).email = adm.email;
            DatabaseConnection.odawa.administrateurs.FindByid(adm.id).phone = adm.phone;
            WriteToDB();
        }

        public static void Delete( int id )
        {
            DatabaseConnection.odawa.administrateurs.FindByid(id).Delete();
            WriteToDB();
        }

        private static void WriteToDB()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["odawaConnectionString"].ConnectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from administrateurs", conn);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);
                da.Update(DatabaseConnection.odawa, "administrateurs");
            }
            DatabaseConnection.odawa.administrateurs.AcceptChanges();
        }

    }
}
