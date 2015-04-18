using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odawa.BU.Entities;

namespace Odawa.DAL
{
    static class RestaurantProvider
    {
        public static void Create(Restaurant r)
        {
            OdawaDS.restaurantsRow newRow = DatabaseConnection.odawa.restaurants.NewrestaurantsRow();
            newRow.nom = r.nom;
            newRow.adresse = r.adresse;
            newRow.numero = r.numero;
            newRow.zipCode = r.zipCode;
            newRow.localite = r.localite;
            newRow.description = r.description;
            newRow.horaire = r.horaire;
            newRow.budget = r.budget;
            newRow.premium = r.premium;
            newRow.idTypeCuisine = r.idTypeCuisine;
            newRow.idRestaurateur = r.idRestaurateur;
            DatabaseConnection.odawa.restaurants.Rows.Add(newRow);
            WriteToDB();
        }

        public static List<Restaurant> GetAll()
        {
            DataTable dt = DatabaseConnection.GetRestaurants();
            List<Restaurant> lst = new List<Restaurant>();
            foreach (OdawaDS.restaurantsRow restaurantRow in dt.Rows)
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

        public static void Update(Restaurant r)
        {
            DatabaseConnection.odawa.restaurants.FindByid(r.id).nom = r.nom;
            DatabaseConnection.odawa.restaurants.FindByid(r.id).adresse = r.adresse;
            DatabaseConnection.odawa.restaurants.FindByid(r.id).numero = r.numero;
            DatabaseConnection.odawa.restaurants.FindByid(r.id).zipCode = r.zipCode;
            DatabaseConnection.odawa.restaurants.FindByid(r.id).localite = r.localite;
            DatabaseConnection.odawa.restaurants.FindByid(r.id).description = r.description;
            DatabaseConnection.odawa.restaurants.FindByid(r.id).horaire = r.horaire;
            DatabaseConnection.odawa.restaurants.FindByid(r.id).budget = r.budget;
            DatabaseConnection.odawa.restaurants.FindByid(r.id).premium = r.premium;
            DatabaseConnection.odawa.restaurants.FindByid(r.id).idTypeCuisine = r.idTypeCuisine;
            DatabaseConnection.odawa.restaurants.FindByid(r.id).idRestaurateur = r.idRestaurateur;
            WriteToDB();
        }

        public static void Delete(int id)
        {
            DatabaseConnection.odawa.restaurants.FindByid(id).Delete();
            WriteToDB();
        }

        private static void WriteToDB()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["odawaConnectionString"].ConnectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from restaurants", conn);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);
                da.Update(DatabaseConnection.odawa, "restaurants");
            }
            DatabaseConnection.odawa.restaurants.AcceptChanges();
        }
    }
}
