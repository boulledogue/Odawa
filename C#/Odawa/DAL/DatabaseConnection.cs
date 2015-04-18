using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odawa.DAL
{
    public static class DatabaseConnection
    {
        public static OdawaDS odawa;

        public static void FillDataSet()
        {
            odawa = new OdawaDS();

            using (OdawaDSTableAdapters.administrateursTableAdapter adpt = new OdawaDSTableAdapters.administrateursTableAdapter())
            {                
                adpt.Fill(odawa.administrateurs);
            }

            using (OdawaDSTableAdapters.utilisateursTableAdapter adpt = new OdawaDSTableAdapters.utilisateursTableAdapter())
            {
                adpt.Fill(odawa.utilisateurs);
            }

            using (OdawaDSTableAdapters.typescuisineTableAdapter adpt = new OdawaDSTableAdapters.typescuisineTableAdapter())
            {
                adpt.Fill(odawa.typescuisine); 
            }

            using (OdawaDSTableAdapters.restaurantsTableAdapter adpt = new OdawaDSTableAdapters.restaurantsTableAdapter())
            {
                adpt.Fill(odawa.restaurants);
            }

            using (OdawaDSTableAdapters.restaurateursTableAdapter adpt = new OdawaDSTableAdapters.restaurateursTableAdapter())
            {
                adpt.Fill(odawa.restaurateurs);
            }

            using (OdawaDSTableAdapters.reservationsTableAdapter adpt = new OdawaDSTableAdapters.reservationsTableAdapter())
            {
                adpt.Fill(odawa.reservations);
            }

            using (OdawaDSTableAdapters.commentsTableAdapter adpt = new OdawaDSTableAdapters.commentsTableAdapter())
            {
                adpt.Fill(odawa.comments);
            }
        }

        public static OdawaDS GetDataSet()
        {
            return odawa;
        }

        public static DataTable GetAdministrateurs()
        {
            return odawa.Tables["administrateurs"];
        }

        public static DataTable GetUtilisateurs()
        {
            return odawa.Tables["utilisateurs"];
        }

        public static DataTable GetTypesCuisine()
        {
            return odawa.Tables["typescuisine"];
        }

        public static DataTable GetRestaurants()
        {
            return odawa.Tables["restaurants"];
        }

        public static DataTable GetRestaurateurs()
        {
            return odawa.Tables["restaurateurs"];
        }

        public static DataTable GetReservations()
        {
            return odawa.Tables["reservations"];
        }

        public static DataTable GetComments()
        {
            return odawa.Tables["comments"];
        }
    }
}
