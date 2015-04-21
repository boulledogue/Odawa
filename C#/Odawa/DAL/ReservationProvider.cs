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
    static class ReservationProvider
    {
        public static void Create(Reservation r)
        {
            OdawaDS.reservationsRow newRow = DatabaseConnection.odawa.reservations.NewreservationsRow();
            newRow.nom = r.nom;
            newRow.prenom = r.prenom;
            newRow.date = r.date;
            newRow.typeService = r.typeService;
            newRow.nbPersonnes = r.nbPersonnes;
            newRow.email = r.email;
            newRow.phone = r.phone;
            DatabaseConnection.odawa.reservations.Rows.Add(newRow);
            WriteToDB();
        }

        public static OdawaDS.reservationsDataTable GetTable()
        {
            return DatabaseConnection.GetReservations();
        }

        public static List<Reservation> GetAll()
        {
            DataTable dt = GetTable();
            List<Reservation> lst = new List<Reservation>();
            foreach (OdawaDS.reservationsRow reservationRow in dt.Rows)
            {
                lst.Add(GetOne(reservationRow.id));                
            }
            return lst;
        }

        public static Reservation GetOne(int id)
        {
            Reservation r = new Reservation();
            r.id = DatabaseConnection.odawa.reservations.FindByid(id).id;
            r.nom = DatabaseConnection.odawa.reservations.FindByid(id).nom;
            r.prenom = DatabaseConnection.odawa.reservations.FindByid(id).prenom;
            r.date = DatabaseConnection.odawa.reservations.FindByid(id).date;
            r.typeService = DatabaseConnection.odawa.reservations.FindByid(id).typeService;
            r.nbPersonnes = DatabaseConnection.odawa.reservations.FindByid(id).nbPersonnes;
            r.email = DatabaseConnection.odawa.reservations.FindByid(id).email;
            r.phone = DatabaseConnection.odawa.reservations.FindByid(id).phone;
            return r;
        }

        public static List<Reservation> GetByRestaurantId(int id)
        {
            DataTable dt = GetTable();
            List<Reservation> lst = new List<Reservation>();
            foreach (OdawaDS.reservationsRow reservationRow in dt.Rows)
            {
                if (reservationRow.idRestaurant == id)
                {
                    lst.Add(GetOne(reservationRow.id));
                }
            }
            return lst;
        }

        public static void Update(Reservation r)
        {
            DatabaseConnection.odawa.reservations.FindByid(r.id).nom = r.nom;
            DatabaseConnection.odawa.reservations.FindByid(r.id).prenom = r.prenom;
            DatabaseConnection.odawa.reservations.FindByid(r.id).date = r.date;
            DatabaseConnection.odawa.reservations.FindByid(r.id).typeService = r.typeService;
            DatabaseConnection.odawa.reservations.FindByid(r.id).nbPersonnes = r.nbPersonnes;
            DatabaseConnection.odawa.reservations.FindByid(r.id).email = r.email;
            DatabaseConnection.odawa.reservations.FindByid(r.id).phone = r.phone;
            WriteToDB();
        }

        public static void Delete(int id)
        {
            DatabaseConnection.odawa.reservations.FindByid(id).Delete();
            WriteToDB();
        }

        private static void WriteToDB()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["odawaConnectionString"].ConnectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from reservations", conn);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);
                da.Update(DatabaseConnection.odawa, "reservations");
            }
            DatabaseConnection.odawa.reservations.AcceptChanges();
        }
    }
}
