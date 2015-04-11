using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odawa.BU.Entities;

namespace Odawa.DAL
{
    class AdministrateurProvider
    {
        OdawaDS odawa = new OdawaDS();

        public List<Administrateur> GetAll()
        {
            List<Administrateur> lst = new List<Administrateur>();

            using (OdawaDSTableAdapters.administrateursTableAdapter adpt = new OdawaDSTableAdapters.administrateursTableAdapter())
            { adpt.Fill(odawa.administrateurs); }

            foreach (OdawaDS.administrateursRow userRow in odawa.administrateurs.Rows)
            {
                Administrateur user = new Administrateur();
                user.id = userRow.id;
                user.nom = userRow.nom;
                user.prenom = userRow.prenom;
                user.username = userRow.username;
                user.password = userRow.password;
                user.phone = userRow.phone;
                lst.Add(user);
            }

            return lst;
        }

        public List<Administrateur> Search( int id, String nom, String prenom, String username, String password, String phone )
        {
            List<Administrateur> lst = new List<Administrateur>();

            using (OdawaDSTableAdapters.administrateursTableAdapter adpt = new OdawaDSTableAdapters.administrateursTableAdapter())
            { adpt.Fill(odawa.administrateurs); }

            foreach (OdawaDS.administrateursRow userRow in odawa.administrateurs.Rows)
            {
                if ((id == 0) || (userRow.id == id))
                {
                    if ((nom == null) || (userRow.nom == nom))
                    {
                        if ((prenom == null) || (userRow.prenom == prenom))
                        {
                            if ((username == null) || (userRow.username == username))
                            {
                                if ((password == null) || (userRow.password == password))
                                {
                                    if ((phone == null) || (userRow.phone == phone))
                                    {
                                        Administrateur user = new Administrateur();
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

        public Administrateur Search(int id)
        {
            Administrateur user = new Administrateur();
            List<Administrateur> lst = Search(id, null, null, null, null, null);
            user = lst.First();
            return user;
        }

        /*** Exist() ne retourne donc true que s'il existe un et un seul éléments. 
             C'est logique pour les utilisateurs ( Vu qu'un username ne peut exister qu'un un seul exemplaire dans la BDD ).
             Ca ne l'est pas spécialement  pour les autres tables. :)
        ***/

        public bool Exist(String username, String password)
        {
            bool exist = false;
            List<Administrateur> lst = new List<Administrateur>();
            lst = Search(0, null, null, username, password, null);
            exist = (lst.Count == 1) ? true : false;
            return exist;
        }

        public void Create(String nom, String prenom, String username, String password, String phone)
        {
            OdawaDS.administrateursRow newUserRow = odawa.administrateurs.NewadministrateursRow();

            newUserRow.nom = nom;
            newUserRow.prenom = prenom;
            newUserRow.username = username;
            newUserRow.password = password;
            newUserRow.phone = phone;
            odawa.administrateurs.Rows.Add(newUserRow);

            odawa.administrateurs.AcceptChanges();
        }

        public void Update(int id, String nom, String prenom, String username, String password, String phone)
        {
            OdawaDS.administrateursRow updUserRow = odawa.administrateurs.FindByid(id);

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
        }

        public void Delete(int id)
        {
            odawa.administrateurs.FindByid(id).Delete();
            odawa.administrateurs.AcceptChanges();
        }

    }
}
