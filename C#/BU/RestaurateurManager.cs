using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BU.Entities;

namespace BU
{
    public static class RestaurateurManager
    {
        public static void Create(Restaurateur r)
        {
            
        }

        public static List<Restaurateur> GetAll()
        {
            OdawaDS.restaurateursDataTable dt = DataProvider.GetRestaurateurs();
            List<Restaurateur> lst = new List<Restaurateur>();
            foreach (OdawaDS.restaurateursRow restRow in dt.Rows)
            {
                Restaurateur r = new Restaurateur();
                r.id = restRow.id;
                r.nom = restRow.nom;
                r.prenom = restRow.prenom;
                r.username = restRow.username;
                r.password = restRow.password;
                r.email = restRow.email;
                r.phone = restRow.phone;
                lst.Add(r);
            }
            return lst;
        }

        public static Restaurateur GetOne(int id)
        {
            return GetAll().Find(x => x.id == id);
        }

        public static void Update(Restaurateur r)
        {
            
        }

        public static void Delete(int id)
        {
            
        }
    }
}
