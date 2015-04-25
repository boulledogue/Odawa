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
            OdawaDS.restaurantsRow newRow = DataProvider.odawa.restaurants.NewrestaurantsRow();
            newRow.nom = r.nom;
            newRow.adresse = r.adresse;
            newRow.numero = r.numero;
            newRow.zipCode = r.zipCode;
            newRow.localite = r.localite;
            newRow.description = r.description;
            newRow.budgetLow = r.budgetLow;
            newRow.budgetHigh = r.budgetHigh;
            newRow.premium = r.premium;
            newRow.idTypeCuisine = r.idTypeCuisine;
            newRow.idRestaurateur = r.idRestaurateur;
            newRow.idHoraire = r.idHoraire;
            DataProvider.CreateRestaurant(newRow);
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

        public static List<Restaurant> GetByTypeCuisine(int id)
        {
            OdawaDS.restaurantsDataTable dt = DataProvider.GetRestaurants();
            List<Restaurant> lst = new List<Restaurant>();
            foreach (OdawaDS.restaurantsRow restoRow in dt.Rows)
            {
                if (restoRow.idTypeCuisine == id)
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
            }
            return lst;
        }
        

        public static void Update(Restaurant r)
        {
            OdawaDS.restaurantsRow updRow = DataProvider.odawa.restaurants.NewrestaurantsRow();
            updRow.id = r.id;
            updRow.nom = r.nom;
            updRow.adresse = r.adresse;
            updRow.numero = r.numero;
            updRow.zipCode = r.zipCode;
            updRow.localite = r.localite;
            updRow.description = r.description;
            updRow.budgetLow = r.budgetLow;
            updRow.budgetHigh = r.budgetHigh;
            updRow.premium = r.premium;
            updRow.idTypeCuisine = r.idTypeCuisine;
            updRow.idRestaurateur = r.idRestaurateur;
            updRow.idHoraire = r.idHoraire;
            DataProvider.UpdateRestaurant(updRow);
        }

        public static void Delete(int id)
        {            
            Restaurant resto = RestaurantManager.GetOne(id);
            CommentManager.DeleteByRestaurant(id);
            ReservationManager.DeleteByRestaurant(id);
            DataProvider.DeleteRestaurant(id);
            HoraireManager.Delete(resto.idHoraire);
        }

        public static List<Restaurant> Search(string s)
        {
            OdawaDS.restaurantsDataTable dt = DataProvider.GetRestaurants();
            List<Restaurant> lst = new List<Restaurant>();
            s = s.ToUpper();
            foreach (OdawaDS.restaurantsRow restoRow in dt.Rows)
            {
                if (restoRow.nom.ToUpper().Contains(s) || restoRow.zipCode.Contains(s) || restoRow.localite.ToUpper().Contains(s))
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
            }
            return lst;
        }
    }
}
