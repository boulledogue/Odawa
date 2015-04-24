using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BU.Entities;
using DAL;
using System.Data;

namespace BU
{
    public static class AdministrateurManager
    {
        public static void Create(Administrateur a)
        {
            
        }

        public static List<Administrateur> GetAll()
        {
            OdawaDS.administrateursDataTable dt = DataProvider.GetAdministrateurs();
            List<Administrateur> lst = new List<Administrateur>();
            foreach (OdawaDS.administrateursRow adminRow in dt.Rows)
            {
                Administrateur a = new Administrateur();
                a.id = adminRow.id;
                a.nom = adminRow.nom;
                a.prenom = adminRow.prenom;
                a.username = adminRow.username;
                a.password = adminRow.password;
                a.email = adminRow.email;
                a.phone = adminRow.phone;
                lst.Add(a);
            }
            return lst;
        }

        public static Administrateur GetOne(int id)
        {
            return GetAll().Find(x => x.id == id);
        }

        public static void Update(Administrateur a)
        {
            
        }

        public static void Delete(int id)
        {
            
        }
    }
}
