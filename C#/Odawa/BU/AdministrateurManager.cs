using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odawa.DAL;
using Odawa.BU.Entities;

namespace Odawa.BU
{
    public static class AdministrateurManager
    {
        public static List<Administrateur> GetAll()
        {
            return AdministrateurProvider.GetAll();
        }

        public static Administrateur GetOne(int id)
        { 
            return AdministrateurProvider.GetOne(id);
        }
    }
}
