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

        public List<Restaurant> GetRestaurantByTypeCuisine(int id)
        {
            return RestaurantManager.GetByTypeCuisine(id);
        }

        public List<Comment> GetCommentByRestaurant(int id)
        {
            return CommentManager.GetByRestaurant(id);
        }

        public List<Reservation> GetReservationByRestaurant(int id)
        {
            return ReservationManager.GetByRestaurant(id);
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

        public bool AcceptLoginRestaurateur(string username, string password)
        {
            if (RestaurateurManager.AcceptLogin(username, password)) return true;
            return false;
        }

        public Restaurateur GetRestaurateur(string username)
        {
            return RestaurateurManager.GetByUsername(username);
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
    }
}
