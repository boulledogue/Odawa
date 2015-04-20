using System;
using System.Collections.Generic;
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

        public static List<Restaurant> GetAll()
        {
            return RestaurantProvider.GetAll();
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
