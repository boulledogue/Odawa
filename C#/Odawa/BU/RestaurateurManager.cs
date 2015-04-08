using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odawa.DAL;
using Odawa.BU.Entities;

namespace Odawa.BU
{
    class RestaurateurManager
    {
        public static List<Restaurateur> LoadData()
        {
            return new RestaurateurProvider().LoadData();
        }
    }
}
