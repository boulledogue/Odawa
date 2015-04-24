using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BU.Entities;

namespace BU
{
    public static class RestaurantManager
    {
        public static void Create(Restaurant r)
        {
            
        }

        public static List<Restaurant> GetAll()
        {
            OdawaDS.restaurantsDataTable dt = DataProvider.GetRestaurants();
            List<Restaurant> lst = new List<Restaurant>();
            foreach (OdawaDS.restaurantsRow restoRow in dt.Rows)
            {
                Restaurant r = new Restaurant();
                r.id = restoRow.id;
                r.nom = restoRow.nom;
                r.adresse = restoRow.adresse;
                r.numero = restoRow.numero;
                r.zipCode = restoRow.zipCode;
                r.localite = restoRow.localite;
                r.description = restoRow.description;
                r.budgetLow = restoRow.budgetLow;
                r.budgetHigh = restoRow.budgetHigh;
                r.premium = restoRow.premium;
                r.idTypeCuisine = restoRow.idTypeCuisine;
                r.idRestaurateur = restoRow.idRestaurateur;
                r.idHoraire = restoRow.idHoraire;
                lst.Add(r);
            }
            return lst;
        }

        public static Restaurant GetOne(int id)
        {
            return GetAll().Find(x => x.id == id);
        }

        public static void Update(Restaurant r)
        {
            
        }

        public static void Delete(int id)
        {
            
        }
    }
}
