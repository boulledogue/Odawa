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
    public static class ReservationManager
    {
        public static void Create(Reservation r)
        {
            ReservationProvider.Create(r);
        }

        public static DataTable GetTable()
        {
            return ReservationProvider.GetTable();
        }

        public static List<Reservation> GetAll()
        {
            return ReservationProvider.GetAll();
        }

        public static Reservation GetOne(int id)
        {
            return ReservationProvider.GetOne(id);
        }

        public static void Update(Reservation r)
        {
            ReservationProvider.Update(r);
        }

        public static void Delete(int id)
        {
            ReservationProvider.Delete(id);
        }
    }
}
