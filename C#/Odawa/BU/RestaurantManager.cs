using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odawa.DAL;
using Odawa.BU.Entities;

namespace Odawa.BU
{
    public static class RestaurantManager
    {
        public static void Create(Restaurant r)
        {
            RestaurantProvider.Create(r);
        }

        public static OdawaDS.restaurantsDataTable GetTable()
        {
            return RestaurantProvider.GetTable();
        }

        public static List<Restaurant> GetAll()
        {
            return RestaurantProvider.GetAll();
        }

        public static Restaurant GetOne(int id)
        {
            return RestaurantProvider.GetOne(id);
        }

        public static List<Restaurant> GetByTypeCuisineId(int id)
        {
            return RestaurantProvider.GetByTypeCuisineId(id);
        }

        public static List<Restaurant> SearchByName(string s)
        {
            return RestaurantProvider.SearchRestaurantNom(s);
        }

        public static List<Restaurant> SearchByZipCode(string s)
        {
            return RestaurantProvider.SearchRestaurantZipCode(s);
        }

        public static List<Restaurant> SearchByLocalite(string s)
        {
            return RestaurantProvider.SearchRestaurantLocalite(s);
        }

        public static void Update(Restaurant r)
        {
            RestaurantProvider.Update(r);
        }

        public static void Delete(int id)
        {
            RestaurantProvider.Delete(id);
        }
    }
}
