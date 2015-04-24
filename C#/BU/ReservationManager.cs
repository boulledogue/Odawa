using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BU.Entities;
using System.Data;

namespace BU
{
    public static class ReservationManager
    {
        public static void Create()
        {
            
        }
        
        public static List<Reservation> GetAll()
        {
            OdawaDS.reservationsDataTable dt = DataProvider.GetReservations();
            List<Reservation> lst = new List<Reservation>();
            foreach (OdawaDS.reservationsRow resRow in dt.Rows)
            {
                Reservation r = new Reservation();
                r.id = resRow.id;
                r.nom = resRow.nom;
                r.prenom = resRow.prenom;
                r.date = resRow.date;
                r.typeService = resRow.typeService;
                r.nbPersonnes = resRow.nbPersonnes;
                r.email = resRow.email;
                r.phone = resRow.phone;
                r.idRestaurant = resRow.idRestaurant;
                lst.Add(r);
            }
            return lst;
        }

        public static Reservation GetOne(int id)
        {
            return GetAll().Find(x => x.id == id);
        }

        public static void Update(Reservation r)
        {
            
        }

        public static void Delete(int id)
        {
            
        }
    }
}
