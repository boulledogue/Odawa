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

        public static OdawaDS.restaurantsDataTable GetTable()
        {
            return DatabaseConnection.GetRestaurants();
        }

        public static List<Restaurant> GetAll()
        {
            DataTable dt = GetTable();
            List<Restaurant> lst = new List<Restaurant>();
            foreach (OdawaDS.restaurantsRow restaurantRow in dt.Rows)
            {                
                lst.Add(GetOne(restaurantRow.id));                
            }
            return lst;
        }

        public static Restaurant GetOne(int id)
        {
            Restaurant r = new Restaurant();
            r.id = DatabaseConnection.odawa.restaurants.FindByid(id).id;
            r.nom = DatabaseConnection.odawa.restaurants.FindByid(id).nom;
            r.adresse = DatabaseConnection.odawa.restaurants.FindByid(id).adresse;
            r.numero = DatabaseConnection.odawa.restaurants.FindByid(id).numero;
            r.zipCode = DatabaseConnection.odawa.restaurants.FindByid(id).zipCode;
            r.localite = DatabaseConnection.odawa.restaurants.FindByid(id).localite;
            r.description = DatabaseConnection.odawa.restaurants.FindByid(id).description;
            r.horaire = DatabaseConnection.odawa.restaurants.FindByid(id).horaire;
            r.budget = DatabaseConnection.odawa.restaurants.FindByid(id).budget;
            r.premium = DatabaseConnection.odawa.restaurants.FindByid(id).premium;
            r.idTypeCuisine = DatabaseConnection.odawa.restaurants.FindByid(id).idTypeCuisine;
            r.idRestaurateur = DatabaseConnection.odawa.restaurants.FindByid(id).idRestaurateur;
            return r;
        }

        public static List<Restaurant> GetByTypeCuisineId(int id)
        {
            DataTable dt = GetTable();
            List<Restaurant> lst = new List<Restaurant>();
            foreach (OdawaDS.restaurantsRow restaurantRow in dt.Rows)
            {
                if (restaurantRow.idTypeCuisine == id) lst.Add(GetOne(restaurantRow.id));
            }
            return lst;
        }

        public static List<Restaurant> SearchRestaurantNom(string s)
        {
            DataTable dt = GetTable();
            List<Restaurant> lst = new List<Restaurant>();
            string nom;
            foreach (OdawaDS.restaurantsRow restaurantRow in dt.Rows)
            {
                nom = restaurantRow.nom.ToUpper();
                if (nom.Contains(s.ToUpper())) 
                    lst.Add(GetOne(restaurantRow.id));
            }
            return lst;
        }

        public static List<Restaurant> SearchRestaurantZipCode(string s)
        {
            DataTable dt = GetTable();
            List<Restaurant> lst = new List<Restaurant>();
            foreach (OdawaDS.restaurantsRow restaurantRow in dt.Rows)
            {
                if (restaurantRow.zipCode.Contains(s))
                    lst.Add(GetOne(restaurantRow.id));
            }
            return lst;
        }

        public static List<Restaurant> SearchRestaurantLocalite(string s)
        {
            DataTable dt = GetTable();
            List<Restaurant> lst = new List<Restaurant>();
            string localite;
            foreach (OdawaDS.restaurantsRow restaurantRow in dt.Rows)
            {
                localite = restaurantRow.localite.ToUpper();
                if (localite.Contains(s.ToUpper()))
                    lst.Add(GetOne(restaurantRow.id));
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
