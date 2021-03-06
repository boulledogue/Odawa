﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BU;
using BU.Entities;

namespace OdawaService
{
    //Toutes les méthodes du web service appellent celles de la BU
    //Le cas échéant, un affinage des données est fait avec Linq (where, find, exists, orderby)

    public class OdawaService : IOdawaService
    {    
        public List<TypeCuisine> GetAllTypeCuisine()
        {
            return TypeCuisineManager.GetAll();
        }

        public TypeCuisine GetTypeCuisine(int id)
        {
            return TypeCuisineManager.GetAll().Find(x => x.id == id);
        }

        public List<Restaurant> GetAllRestaurant()
        {
            return RestaurantManager.GetAll().Where(x => x.genre == 1).OrderByDescending(y => y.premium).ToList();
        }

        public List<Restaurant> GetAllSnack()
        {
            return RestaurantManager.GetAll().Where(x => x.genre == 2).OrderByDescending(y => y.premium).ToList();
        }

        public List<Restaurant> GetRestaurantByRestaurateur(int id)
        {
            return RestaurantManager.GetAll().Where(x => x.idRestaurateur == id).OrderBy(y => y.nom).ToList();
        }

        public List<Restaurant> GetRestaurantByTypeCuisine(int id)
        {
            return RestaurantManager.GetAll().Where(x => x.idTypeCuisine == id).OrderByDescending(y => y.premium).ToList();
        }

        public List<Comment> GetCommentByRestaurant(int id)
        {
            return CommentManager.GetAll().Where(x => x.idRestaurant == id).ToList();
        }

        public Reservation GetReservation(int id)
        {
            return ReservationManager.GetAll().Find(x => x.id == id);
        }

        public List<Reservation> GetReservationByRestaurant(int id)
        {
            return ReservationManager.GetAll().Where(x => x.idRestaurant == id).Where(y => y.date >= DateTime.Now).OrderBy(z => z.date).ToList();
        }

        public List<Reservation> GetReservationsEnAttente(int id)
        {
            return GetReservationByRestaurant(id).Where(x => x.status == 1).ToList();
        }

        public List<Reservation> GetReservationsAcceptees(int id)
        {
            return GetReservationByRestaurant(id).Where(x => x.status == 2).ToList();
        }

        public List<Reservation> GetReservationsRefusees(int id)
        {
            return GetReservationByRestaurant(id).Where(x => x.status == 3).ToList();
        }

        public List<Reservation> GetReservationsArchivees(int id)
        {
            return ReservationManager.GetAll().Where(x => x.idRestaurant == id).Where(y => y.date < DateTime.Now).OrderByDescending(z => z.date).ToList();
        }

        public Restaurant GetRestaurant(int id)
        {
            return RestaurantManager.GetAll().Find(x => x.id == id);
        }

        public List<Restaurant> SearchRestaurant(string s)
        {
            if (s != null) return RestaurantManager.Search(s).OrderByDescending(y => y.premium).ToList();
            else return RestaurantManager.GetAll().OrderByDescending(y => y.premium).ToList();
        }

        public List<Restaurant> BestRestaurant()
        {
            return RestaurantManager.BestRestaurant();
        }

        public Restaurant RandomRestaurant()
        {
            return RestaurantManager.RandomRestaurant();
        }

        public Utilisateur GetUtilisateur(int id)
        {
            return UtilisateurManager.GetAll().Find(x => x.id == id);
        }

        public bool AcceptLoginRestaurateur(string username, string password)
        {
            if (RestaurateurManager.AcceptLogin(username, password)) return true;
            return false;
        }

        public Restaurateur GetRestaurateurByUsername(string username)
        {
            return RestaurateurManager.GetAll().Find(x => x.username == username);
        }

        public Restaurateur GetRestaurateurByRestaurant(int id)
        {
            int idRestaurateur = RestaurantManager.GetAll().Find(x => x.id == id).idRestaurateur;
            return RestaurateurManager.GetAll().Find(x => x.id == idRestaurateur);
        }

        public bool AcceptLoginUtilisateur(string username, string password)
        {
            if (UtilisateurManager.AcceptLogin(username, password)) return true;
            return false;
        }

        public Utilisateur GetUtilisateurByUsername(string username)
        {
            return UtilisateurManager.GetAll().Find(x => x.username == username);
        }

        public bool CreateUtilisateur(Utilisateur u)
        {
            if (UtilisateurManager.GetAll().Exists(x => x.username == u.username) || UtilisateurManager.GetAll().Exists(x => x.email == u.email)) return false;
            else
            {
                UtilisateurManager.Create(u);
                return true;
            }
        }

        public void UpdateUtilisateur(Utilisateur u)
        {
            UtilisateurManager.Update(u);
        }

        public void DeleteUtilisateur(int id)
        {
            UtilisateurManager.Delete(id);
        }

        public void CreateComment(Comment c)
        {
            CommentManager.Create(c);
        }

        public void UpdateComment(Comment c)
        {
            CommentManager.Update(c);
        }

        public void DeleteComment(int id)
        {
            CommentManager.Delete(id);
        }

        public void CreateReservation(Reservation r)
        {
            ReservationManager.Create(r);
        }
        
        public void UpdateReservation(Reservation r)
        {
            ReservationManager.Update(r);
        }

        public void CreateRestaurant(Restaurant r)
        {
            RestaurantManager.Create(r);
        }

        public void UpdateRestaurant(Restaurant r)
        {
            RestaurantManager.Update(r);
        }

        public void DeleteRestaurant(int id)
        {
            RestaurantManager.Delete(id);
        }

        public void UpdateRestaurateur(Restaurateur r)
        {
            RestaurateurManager.Update(r);
        }
    }
}
