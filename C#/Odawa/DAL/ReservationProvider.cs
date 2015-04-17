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
    }
}
