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
        public static List<Reservation> GetAll()
        {
            DataTable dt = DatabaseConnection.GetReservations();
            List<Reservation> lst = new List<Reservation>();
            foreach (OdawaDS.reservationsRow reservationRow in dt.Rows)
            {
                Reservation r = new Reservation();
                r.id = reservationRow.id;
                r.nom = reservationRow.nom;
                r.prenom = reservationRow.prenom;
                r.date = reservationRow.date;
                r.typeService = reservationRow.typeService;
                r.nbPersonnes = reservationRow.nbPersonnes;
                r.email = reservationRow.email;
                r.phone = reservationRow.phone;
                lst.Add(r);                
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
    }
}
