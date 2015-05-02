using System;
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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
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
            return RestaurantManager.GetAll().Where(x => x.genre == 1).ToList();
        }

        public List<Restaurant> GetAllSnack()
        {
            return RestaurantManager.GetAll().Where(x => x.genre == 2).ToList();
        }

        public List<Restaurant> GetRestaurantByTypeCuisine(int id)
        {
            return RestaurantManager.GetAll().Where(x => x.idTypeCuisine == id).ToList();
        }

        public List<Comment> GetCommentByRestaurant(int id)
        {
            return CommentManager.GetAll().Where(x => x.idRestaurant == id).ToList();
        }

        public List<Reservation> GetReservationByRestaurant(int id)
        {
            return ReservationManager.GetAll().Where(x => x.idRestaurant == id).ToList();
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

        public Restaurant GetRestaurant(int id)
        {
            return RestaurantManager.GetAll().Find(x => x.id == id);
        }

        public List<Restaurant> SearchRestaurant(string s)
        {
            if (s != null) return RestaurantManager.Search(s);
            else return RestaurantManager.GetAll();
        }

        public List<Restaurant> BestRestaurant()
        {
            return RestaurantManager.BestRestaurant();
        }

        public bool AcceptLoginRestaurateur(string username, string password)
        {
            if (RestaurateurManager.AcceptLogin(username, password)) return true;
            return false;
        }

        public Restaurateur GetRestaurateur(string username)
        {
            return RestaurateurManager.GetAll().Find(x => x.username == username);
        }

        public bool AcceptLoginUtilisateur(string username, string password)
        {
            if (UtilisateurManager.AcceptLogin(username, password)) return true;
            return false;
        }

        public Utilisateur GetUtilisateur(string username)
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
    }
}
