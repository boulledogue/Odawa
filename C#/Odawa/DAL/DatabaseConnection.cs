using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odawa.DAL
{
    static class DatabaseConnection
    {
        public static OdawaDS odawa = new OdawaDS();

        public static void FillDataSet()
        {
            using (OdawaDSTableAdapters.typescuisineTableAdapter adpt = new OdawaDSTableAdapters.typescuisineTableAdapter())
            {
                adpt.Fill(DatabaseConnection.odawa.typescuisine); 
            }

            using (OdawaDSTableAdapters.restaurantsTableAdapter adpt = new OdawaDSTableAdapters.restaurantsTableAdapter())
            {
                adpt.Fill(DatabaseConnection.odawa.restaurants);
            }

            using (OdawaDSTableAdapters.restaurateursTableAdapter adpt = new OdawaDSTableAdapters.restaurateursTableAdapter())
            {
                adpt.Fill(DatabaseConnection.odawa.restaurateurs);
            }

            using (OdawaDSTableAdapters.reservationsTableAdapter adpt = new OdawaDSTableAdapters.reservationsTableAdapter())
            {
                adpt.Fill(DatabaseConnection.odawa.reservations);
            }
        }
    }
}
