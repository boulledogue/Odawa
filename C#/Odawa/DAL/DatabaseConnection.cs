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

        public static OdawaDS.administrateursDataTable GetAdministrateurs()
        {
            return odawa.administrateurs;
        }

        public static OdawaDS.utilisateursDataTable GetUtilisateurs()
        {
            return odawa.utilisateurs;
        }

        public static OdawaDS.typescuisineDataTable GetTypesCuisine()
        {
            return odawa.typescuisine;
        }

        public static OdawaDS.restaurantsDataTable GetRestaurants()
        {
            return odawa.restaurants;
        }

        public static OdawaDS.restaurateursDataTable GetRestaurateurs()
        {
            return odawa.restaurateurs;
        }

        public static OdawaDS.reservationsDataTable GetReservations()
        {
            return odawa.reservations;
        }

        public static OdawaDS.commentsDataTable GetComments()
        {
            return odawa.comments;
        }
    }
}
