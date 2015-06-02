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
        //Création réservation avec l'objet "r" passé en paramètre
        public static void Create(Reservation r)
        {
            //Vérification de l'objet r: il est transmis par le web service et n'est pas sûr
            if (isValid(r)) 
            {
                //Création d'une reservationsRow et remplissage avec les attributs de "r"
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
                //Envoi à la DAL de la reservationsRow pour ajout au DataSet
                try
                {
                    DataProvider.CreateReservation(newRow);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    //si SqlException, log
                    LogManager.LogSQLException(ex.Message);
                }                
            }
        }

        //Obtention de toutes les réservations
        public static List<Reservation> GetAll()
        {
            //Obtention de la DataTable
            OdawaDS.reservationsDataTable dt = DataProvider.GetReservations();
            //Création d'une liste vide
            List<Reservation> lst = new List<Reservation>();
            //Pour chaque réservation dans la dataTable
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
                //Ajout à la liste
                lst.Add(r);
            }
            //Retourne la liste
            return lst;
        }

        //Mise à jour d'une réservation "r" passée en paramètre
        public static void Update(Reservation r)
        {
            //Vérification de l'objet r: il est transmis par le web service et n'est pas sûr
            if (isValid(r))
            {
                OdawaDS.reservationsDataTable dt = DataProvider.GetReservations();
                //Création d'une reservationsRow et remplissage avec les attributs de "r"
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
                //Envoi à la DAL de la commentsRow pour mise à jour du DataSet
                try
                {
                    DataProvider.UpdateReservation(updRow);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    //si SqlException, log
                    LogManager.LogSQLException(ex.Message);
                }                
            }
        }

        //Suppression d'une réservation avec son id passé en paramètre
        public static void Delete(int id)
        {
            //Si une réservation avec cet id existe
            if (GetAll().Exists(x => x.id == id))
            {
                //Envoi de l'id à la DAL pour suppression
                try
                {
                    DataProvider.DeleteReservation(id);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    //si SqlException, log
                    LogManager.LogSQLException(ex.Message);
                }
            }
        }

        //Suppression des réservations avec l'id du restaurant
        public static void DeleteByRestaurant(int id)
        {
            //Obtention d'une liste des réservations du restaurant avec l'id passé en paramètre
            List<Reservation> lst = GetAll().Where(x => x.idRestaurant == id).ToList();
            //Si la liste n'est pas vide
            if (lst.Count() > 0)
            {
                //Pour chaque réservation de la liste
                foreach (Reservation r in lst)
                {
                    //Passage de l'id de la réservation à la méthode Delete
                    Delete(r.id);
                }
            }
        }

        //Test du caractère non null des paramètres de la réservation (vérification des données envoyées par le web service)
        //si tout est ok, renvoie true,
        //sinon, log et renvoie false
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
