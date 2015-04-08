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
    class RestaurantProvider
    {
        public List<Restaurant> LoadData()
        {
            List<Restaurant> list = new List<Restaurant>();

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["odawaConnectionString"].ConnectionString;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Select * from [restaurants]";
                    cmd.Connection = cn;

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Restaurant r = new Restaurant();
                            r.id = (int)rdr["id"];
                            r.nom = rdr["nom"].ToString();
                            r.adresse = rdr["adresse"].ToString();
                            r.numero = rdr["numero"].ToString();
                            r.zipCode = rdr["zipCode"].ToString();
                            r.localite = rdr["localite"].ToString();
                            r.description = rdr["description"].ToString();
                            r.horaire = rdr["horaire"].ToString();
                            r.budget = (int)rdr["budget"];
                            r.premium = (bool)rdr["premium"];
                            r.idTypeCuisine = (int)rdr["idTypeCuisine"];
                            r.idRestaurateur = (int)rdr["idRestaurateur"];
                            list.Add(r);
                        }
                    }
                }
            }
            return list;
        }
    }
}
