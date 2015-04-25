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
        public static void Create(Horaire h)
        {
            OdawaDS.horairesRow newRow = DataProvider.odawa.horaires.NewhorairesRow();
            newRow.mondayOpen = h.mondayOpen;
            newRow.mondayClose = h.mondayClose;
            newRow.tuesdayOpen = h.tuesdayOpen;
            newRow.tuesdayClose = h.tuesdayClose;
            newRow.wednesdayOpen = h.wednesdayOpen;
            newRow.wednesdayClose = h.wednesdayClose;
            newRow.thursdayOpen = h.thursdayOpen;
            newRow.thursdayClose = h.thursdayClose;
            newRow.fridayOpen = h.fridayOpen;
            newRow.saturdayOpen = h.saturdayOpen;
            newRow.saturdayClose = h.saturdayClose;
            newRow.sundayOpen = h.sundayOpen;
            newRow.sundayClose = h.sundayClose;
            DataProvider.CreateHoraire(newRow);
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

        public static void Update(Horaire h)
        {
            OdawaDS.horairesRow updRow = DataProvider.odawa.horaires.NewhorairesRow();
            updRow.id = h.id;
            updRow.mondayOpen = h.mondayOpen;
            updRow.mondayClose = h.mondayClose;
            updRow.tuesdayOpen = h.tuesdayOpen;
            updRow.tuesdayClose = h.tuesdayClose;
            updRow.wednesdayOpen = h.wednesdayOpen;
            updRow.wednesdayClose = h.wednesdayClose;
            updRow.thursdayOpen = h.thursdayOpen;
            updRow.thursdayClose = h.thursdayClose;
            updRow.fridayOpen = h.fridayOpen;
            updRow.saturdayOpen = h.saturdayOpen;
            updRow.saturdayClose = h.saturdayClose;
            updRow.sundayOpen = h.sundayOpen;
            updRow.sundayClose = h.sundayClose;
            DataProvider.UpdateHoraires(updRow);
        }

        public static void Delete(int id)
        {
            DataProvider.DeleteHoraire(id);
        }
    }
}
