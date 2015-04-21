using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odawa.DAL;
using Odawa.BU.Entities;

namespace Odawa.BU
{
    public static class RestaurateurManager
    {
        public static void Create(Restaurateur r)
        {
            RestaurateurProvider.Create(r);
        }

        public static List<Restaurateur> GetAll()
        {
            return RestaurateurProvider.GetAll();
        }

        public static Restaurateur GetOne(int id)
        {
            return RestaurateurProvider.GetOne(id);
        }

        public static void Update(Restaurateur r)
        {
            RestaurateurProvider.Update(r);
        }

        public static void Delete(int id)
        {
            RestaurateurProvider.Delete(id);
        }
    }
}
