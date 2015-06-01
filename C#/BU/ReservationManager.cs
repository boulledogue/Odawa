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
        public static void Create(Reservation r)
        {
            if (isValid(r)) {
                OdawaDS.reservationsRow newRow = DataProvider.odawa.reservations.NewreservationsRow();
                newRow.nom = r.nom;
                newRow.prenom = r.prenom;
                newRow.date = r.date;
                newRow.typeService = r.typeService;
                newRow.nbPersonnes = r.nbPersonnes;
                newRow.email = r.email;
                newRow.phone = r.phone;
                newRow.idRestaurant = r.idRestaurant;
                newRow.status = r.status;
                newRow.encodedDateTime = r.encodedDateTime;
                DataProvider.CreateReservation(newRow);
            }
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
                r.status = resRow.status;
                r.encodedDateTime = resRow.encodedDateTime;
                lst.Add(r);
            }
            return lst;
        }

        public static void Update(Reservation r)
        {
            if (isValid(r)) {
                OdawaDS.reservationsDataTable dt = DataProvider.GetReservations();
                OdawaDS.reservationsRow updRow = DataProvider.odawa.reservations.NewreservationsRow();
                updRow.id = r.id;
                updRow.nom = r.nom;
                updRow.prenom = r.prenom;
                updRow.date = r.date;
                updRow.typeService = r.typeService;
                updRow.nbPersonnes = r.nbPersonnes;
                updRow.email = r.email;
                updRow.phone = r.phone;
                updRow.idRestaurant = r.idRestaurant;
                updRow.status = r.status;
                DataProvider.UpdateReservation(updRow);
            }
        }

        public static void Delete(int id)
        {
            if (GetAll().Exists(x => x.id == id)) {
                DataProvider.DeleteReservation(id);
            }
        }

        public static void DeleteByRestaurant(int id)
        {
            List<Reservation> lst = GetAll().Where(x => x.idRestaurant == id).ToList();
            if (lst.Count() > 0)
            {
                foreach (Reservation r in lst)
                {
                    Delete(r.id);
                }
            }
        }

        public static bool isValid(Reservation r)
        {
            bool b = false;
            if (r.nom != null)
                if (r.prenom != null)
                    if (r.date != null)
                        if (r.typeService != null)
                            if (r.nbPersonnes > 0)
                                if (r.email != null)
                                    if (r.phone != null)
                                        if (r.idRestaurant > 0 && RestaurantManager.GetAll().Exists(x => x.id == r.idRestaurant))
                                            if (r.status != null)
                                                if (r.encodedDateTime != null) b = true;
                                                else LogManager.LogNullException("Reservation Add/Update : EncodedDateTime est Null ");
                                            else LogManager.LogNullException("Reservation Add/Update : Status est Null ");
                                        else LogManager.LogNullException("Reservation Add/Update : IdRestaurateur est Null ou Non-associable ");
                                    else LogManager.LogNullException("Reservation Add/Update : Phone est Null ");
                                else LogManager.LogNullException("Reservation Add/Update : Email est Null ");
                            else LogManager.LogNullException("Reservation Add/Update : nbPersonnes est Null ");
                        else LogManager.LogNullException("Reservation Add/Update : typeService est Null ");
                    else LogManager.LogNullException("Reservation Add/Update : Date est Null ");
                else LogManager.LogNullException("Reservation Add/Update : Prenom est Null ");
            else LogManager.LogNullException("Reservation Add/Update : Nom est Null ");
            return b;
        }
    }
}
