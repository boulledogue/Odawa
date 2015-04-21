using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odawa.DAL;
using Odawa.BU.Entities;
using System.Data;

namespace Odawa.BU
{
    public static class AdministrateurManager
    {
        public static void Create(Administrateur a)
        {
            AdministrateurProvider.Create(a);
        }

        public static DataTable GetTable()
        {
            return AdministrateurProvider.GetTable();
        }

        public static List<Administrateur> GetAll()
        {
            return AdministrateurProvider.GetAll();
        }

        public static Administrateur GetOne(int id)
        { 
            return AdministrateurProvider.GetOne(id);
        }

        public static void Update(Administrateur a)
        {
            AdministrateurProvider.Update(a);
        }

        public static void Delete(int id)
        {
            AdministrateurProvider.Delete(id);
        }
    }
}
