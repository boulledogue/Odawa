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
            return TypeCuisineManager.GetOne(id);
        }

        public List<Restaurant> GetAllRestaurant()
        {
            return RestaurantManager.GetAll();
        }

        public Restaurant GetRestaurant(int id)
        {
            return RestaurantManager.GetOne(id);
        }

        public List<Restaurant> SearchRestaurantByName(string s)
        {
            if (s != null) return RestaurantManager.SearchByName(s);
            else return RestaurantManager.GetAll();
        }

        public List<Restaurant> SearchRestaurantByZipCode(string s)
        {
            if (s != null) return RestaurantManager.SearchByZipCode(s);
            else return RestaurantManager.GetAll();
        }

        public List<Restaurant> SearchRestaurantByLocalite(string s)
        {
            if (s != null) return RestaurantManager.SearchByLocalite(s);
            else return RestaurantManager.GetAll();
        }
    }
}
