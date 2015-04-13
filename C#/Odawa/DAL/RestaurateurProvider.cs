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
    static class RestaurateurProvider
    {
        public static List<Restaurateur> GetAll()
        {
            List<Restaurateur> lst = new List<Restaurateur>();
            foreach (OdawaDS.restaurateursRow restaurateurRow in DatabaseConnection.odawa.restaurateurs.Rows)
            {
                Restaurateur r = new Restaurateur();
                r.id = restaurateurRow.id;
                r.nom = restaurateurRow.nom;
                r.prenom = restaurateurRow.prenom;
                r.username = restaurateurRow.username;
                r.password = restaurateurRow.password;
                r.email = restaurateurRow.email;
                r.phone = restaurateurRow.phone;
                lst.Add(r);
            }
            return lst;
        }
    }
}
