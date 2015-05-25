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
            OdawaDS.administrateursRow newRow = DataProvider.odawa.administrateurs.NewadministrateursRow();
            newRow.nom = a.nom.ToUpper();
            newRow.prenom = a.prenom;
            newRow.username = a.username.ToLower();
            newRow.password = a.password;
            newRow.email = a.email.ToLower();
            newRow.phone = a.phone;
            DataProvider.CreateAdministrateur(newRow);
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

        public static void Update(Administrateur a)
        {
            OdawaDS.administrateursDataTable dt = DataProvider.GetAdministrateurs();
            OdawaDS.administrateursRow updRow = DataProvider.odawa.administrateurs.NewadministrateursRow();
            updRow.id = a.id;
            updRow.nom = a.nom.ToUpper();
            updRow.prenom = a.prenom;
            updRow.username = a.username.ToLower();
            updRow.password = a.password.ToLower();
            updRow.email = a.email;
            updRow.phone = a.phone;
            DataProvider.UpdateAdministrateur(updRow);
        }

        public static void Delete(int id)
        {
            DataProvider.DeleteAdministrateur(id);
        }

        public static void isValid()
        { 
            
        }
    }
}
