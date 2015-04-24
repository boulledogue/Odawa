using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BU.Entities;
using System.Data;

namespace BU
{
    public static class UtilisateurManager
    {
        public static void Create(Utilisateur u)
        {
            
        }

        public static List<Utilisateur> GetAll()
        {
            OdawaDS.utilisateursDataTable dt = DataProvider.GetUtilisateurs();
            List<Utilisateur> lst = new List<Utilisateur>();
            foreach (OdawaDS.utilisateursRow utilRow in dt.Rows)
            {
                Utilisateur u = new Utilisateur();
                u.id = utilRow.id;
                u.nom = utilRow.nom;
                u.prenom = utilRow.prenom;
                u.username = utilRow.username;
                u.password = utilRow.password;
                u.email = utilRow.email;
                u.phone = utilRow.phone;
                lst.Add(u);
            }
            return lst;
        }

        public static Utilisateur GetOne(int id)
        {
            return GetAll().Find(x => x.id == id);
        }

        public static void Update(Utilisateur u)
        {
            
        }

        public static void Delete(int id)
        {
            
        }
    }
}
