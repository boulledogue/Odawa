using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DataProvider
    {
        public static OdawaDS odawa = new OdawaDS();
        
        public static OdawaDS.administrateursDataTable GetAdministrateurs()
        {
            using (OdawaDSTableAdapters.administrateursTableAdapter adpt = new OdawaDSTableAdapters.administrateursTableAdapter())
            {
                adpt.Fill(odawa.administrateurs);
            }
            return odawa.administrateurs;
        }

        public static OdawaDS.commentsDataTable GetComments()
        {
            using (OdawaDSTableAdapters.commentsTableAdapter adpt = new OdawaDSTableAdapters.commentsTableAdapter())
            {
                adpt.Fill(odawa.comments);
            }
            return odawa.comments;
        }

        public static OdawaDS.horairesDataTable GetHoraires()
        {
            using (OdawaDSTableAdapters.horairesTableAdapter adpt = new OdawaDSTableAdapters.horairesTableAdapter())
            {
                adpt.Fill(odawa.horaires);
            }
            return odawa.horaires;
        }

        public static OdawaDS.reservationsDataTable GetReservations()
        {
            using (OdawaDSTableAdapters.reservationsTableAdapter adpt = new OdawaDSTableAdapters.reservationsTableAdapter())
            {
                adpt.Fill(odawa.reservations);
            }
            return odawa.reservations;
        }

        public static OdawaDS.restaurantsDataTable GetRestaurants()
        {
            using (OdawaDSTableAdapters.restaurantsTableAdapter adpt = new OdawaDSTableAdapters.restaurantsTableAdapter())
            {
                adpt.Fill(odawa.restaurants);
            }
            return odawa.restaurants;
        }

        public static OdawaDS.restaurateursDataTable GetRestaurateurs()
        {
            using (OdawaDSTableAdapters.restaurateursTableAdapter adpt = new OdawaDSTableAdapters.restaurateursTableAdapter())
            {
                adpt.Fill(odawa.restaurateurs);
            }
            return odawa.restaurateurs;
        }

        public static OdawaDS.typescuisineDataTable GetTypesCuisine()
        {
            using (OdawaDSTableAdapters.typescuisineTableAdapter adpt = new OdawaDSTableAdapters.typescuisineTableAdapter())
            {
                adpt.Fill(odawa.typescuisine);
            }
            return odawa.typescuisine;
        }

        public static OdawaDS.utilisateursDataTable GetUtilisateurs()
        {
            using (OdawaDSTableAdapters.utilisateursTableAdapter adpt = new OdawaDSTableAdapters.utilisateursTableAdapter())
            {
                adpt.Fill(odawa.utilisateurs);
            }
            return odawa.utilisateurs;
        }

        public static void DeleteTypeCuisine(int id)
        {
            odawa.typescuisine.FindByid(id).Delete();
            WriteToDB("typescuisine");
        }

        private static void WriteToDB(string table)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["odawaConnectionString"].ConnectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from " + table, conn);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);
                da.Update(odawa, table);
            }
            odawa.AcceptChanges();
        }
    }
}
