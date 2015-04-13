using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odawa.BU.Entities;

namespace Odawa.DAL
{
    static class RestaurantProvider
    {
        public static List<Restaurant> GetAll()
        {
            List<Restaurant> lst = new List<Restaurant>();
            foreach (OdawaDS.restaurantsRow restaurantRow in DatabaseConnection.odawa.restaurants.Rows)
            {                
                Restaurant resto = new Restaurant();
                resto.id = restaurantRow.id;
                resto.nom = restaurantRow.nom;
                resto.adresse = restaurantRow.adresse;
                resto.numero = restaurantRow.numero;
                resto.zipCode = restaurantRow.zipCode;
                resto.localite = restaurantRow.localite;
                resto.description = restaurantRow.description;
                resto.horaire = restaurantRow.horaire;
                resto.budget = restaurantRow.budget;
                resto.premium = restaurantRow.premium;
                resto.idTypeCuisine = restaurantRow.idTypeCuisine;
                resto.idRestaurateur = restaurantRow.idRestaurateur;
                lst.Add(resto);                
            }
            return lst;
        }        
    }
}
