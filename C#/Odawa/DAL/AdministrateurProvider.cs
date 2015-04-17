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
            DataTable dt = DatabaseConnection.GetDataSet().Tables["administrateurs"];
            List<Administrateur> lst = new List<Administrateur>();
            foreach (OdawaDS.administrateursRow adminRow in dt.Rows)
            {
                Administrateur admin = new Administrateur();
                admin.id = adminRow.id;
                admin.nom = adminRow.nom;
                admin.prenom = adminRow.prenom;
                admin.username = adminRow.username;
                admin.password = adminRow.password;
                admin.phone = adminRow.phone;
                lst.Add(admin);
            }

            return lst;
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

        /*** Exist() ne retourne donc true que s'il existe un et un seul éléments. 
             C'est logique pour les utilisateurs ( Vu qu'un username ne peut exister qu'un un seul exemplaire dans la BDD ).
             Ca ne l'est pas spécialement  pour les autres tables. :)
        ***/

        public static bool Exist(String username, String password)
        {
            bool exist = false;
            List<Administrateur> lst = new List<Administrateur>();
            lst = Search(0, null, null, username, password, null);
            exist = (lst.Count == 1) ? true : false;
            return exist;
        }

        public static void Create(String nom, String prenom, String username, String password, String phone)
        {
            /*
            OdawaDS.administrateursRow newUserRow = odawa.administrateurs.NewadministrateursRow();

            newUserRow.nom = nom;
            newUserRow.prenom = prenom;
            newUserRow.username = username;
            newUserRow.password = password;
            newUserRow.phone = phone;
            odawa.administrateurs.Rows.Add(newUserRow);

            odawa.administrateurs.AcceptChanges();
            */
        }

        public static void Update(int id, String nom, String prenom, String username, String password, String phone)
        {
            /*
            OdawaDS.administrateursRow updUserRow = DatabaseConnection.odawa.administrateurs.FindByid(id);

            if (nom != null)
                updUserRow.nom = nom;
            if (prenom != null)
                updUserRow.prenom = prenom;
            if (username != null)
                updUserRow.username = username;
            if (password != null)
                updUserRow.password = password;
            if (phone != null)
                updUserRow.phone = phone;

            odawa.administrateurs.AcceptChanges();
            */
        }

        public static void Delete(int id)
        {
            /*
            odawa.administrateurs.FindByid(id).Delete();
            odawa.administrateurs.AcceptChanges();
            */ 
        }

    }
}
