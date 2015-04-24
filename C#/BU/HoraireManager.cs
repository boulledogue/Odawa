using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BU.Entities;
using System.Data;

namespace BU
{
    public static class HoraireManager
    {
        public static void Create()
        {

        }

        public static List<Horaire> GetAll()
        {
            OdawaDS.horairesDataTable dt = DataProvider.GetHoraires();
            List<Horaire> lst = new List<Horaire>();
            foreach (OdawaDS.horairesRow horaireRow in dt.Rows)
            {
                Horaire h = new Horaire();
                h.id = horaireRow.id;
                h.mondayOpen = horaireRow.mondayOpen;
                h.mondayClose = horaireRow.mondayClose;
                h.tuesdayOpen = horaireRow.tuesdayOpen;
                h.tuesdayClose = horaireRow.tuesdayClose;
                h.wednesdayOpen = horaireRow.wednesdayOpen;
                h.wednesdayClose = horaireRow.wednesdayClose;
                h.thursdayOpen = horaireRow.thursdayOpen;
                h.thursdayClose = horaireRow.thursdayClose;
                h.fridayOpen = horaireRow.fridayOpen;
                h.saturdayOpen = horaireRow.saturdayOpen;
                h.saturdayClose = horaireRow.saturdayClose;
                h.sundayOpen = horaireRow.sundayOpen;
                h.sundayClose = horaireRow.sundayClose;
                lst.Add(h);
            }
            return lst;
        }

        public static Horaire GetOne(int id)
        {
            return GetAll().Find(x => x.id == id);
        }

        public static void Update()
        {
            
        }

        public static void Delete(int id)
        {
            
        }
    }
}
