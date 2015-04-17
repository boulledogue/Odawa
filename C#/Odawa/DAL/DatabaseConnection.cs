using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odawa.DAL
{
    public static class DatabaseConnection
    {
        private static OdawaDS odawa;

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
    }
}
