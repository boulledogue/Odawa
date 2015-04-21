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
    static class RestaurateurProvider
    {
        public static void Create(Restaurateur r)
        {
            OdawaDS.restaurateursRow newRow = DatabaseConnection.odawa.restaurateurs.NewrestaurateursRow();
            newRow.nom = r.nom;
            newRow.prenom = r.prenom;
            newRow.username = r.username;
            newRow.password = r.password;
            newRow.email = r.email;
            newRow.phone = r.phone;
            DatabaseConnection.odawa.restaurateurs.Rows.Add(newRow);
            WriteToDB();
        }

        public static List<Restaurateur> GetAll()
        {
            DataTable dt = DatabaseConnection.GetRestaurateurs();
            List<Restaurateur> lst = new List<Restaurateur>();
            foreach (OdawaDS.restaurateursRow restaurateurRow in dt.Rows)
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

        public static Restaurateur GetOne(int id)
        {
            Restaurateur r = new Restaurateur();
            r.id = DatabaseConnection.odawa.restaurateurs.FindByid(id).id;
            r.nom = DatabaseConnection.odawa.restaurateurs.FindByid(id).nom;
            r.prenom = DatabaseConnection.odawa.restaurateurs.FindByid(id).prenom;
            r.username = DatabaseConnection.odawa.restaurateurs.FindByid(id).username;
            r.password = DatabaseConnection.odawa.restaurateurs.FindByid(id).password;
            r.email = DatabaseConnection.odawa.restaurateurs.FindByid(id).email;
            r.phone = DatabaseConnection.odawa.restaurateurs.FindByid(id).phone;
            return r;
        }

        public static void Update(Restaurateur r)
        {
            DatabaseConnection.odawa.restaurateurs.FindByid(r.id).nom = r.nom;
            DatabaseConnection.odawa.restaurateurs.FindByid(r.id).prenom = r.prenom;
            DatabaseConnection.odawa.restaurateurs.FindByid(r.id).username = r.username;
            DatabaseConnection.odawa.restaurateurs.FindByid(r.id).password = r.password;
            DatabaseConnection.odawa.restaurateurs.FindByid(r.id).email = r.email;
            DatabaseConnection.odawa.restaurateurs.FindByid(r.id).phone = r.phone;
            WriteToDB();
        }

        public static void Delete(int id)
        {
            DatabaseConnection.odawa.restaurateurs.FindByid(id).Delete();
            WriteToDB();
        }

        private static void WriteToDB()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["odawaConnectionString"].ConnectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from restaurateurs", conn);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);
                da.Update(DatabaseConnection.odawa, "restaurateurs");
            }
            DatabaseConnection.odawa.restaurateurs.AcceptChanges();
        }
    }
}
