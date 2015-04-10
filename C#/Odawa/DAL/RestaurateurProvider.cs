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
    class RestaurateurProvider
    {
        public List<Restaurateur> GetAll()
        {
            List<Restaurateur> list = new List<Restaurateur>();

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["odawaConnectionString"].ConnectionString;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Select * from [restaurateurs]";
                    cmd.Connection = cn;

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Restaurateur r = new Restaurateur();
                            r.id = (int)rdr["id"];
                            r.nom = rdr["nom"].ToString();
                            r.prenom = rdr["prenom"].ToString();
                            r.username = rdr["username"].ToString();
                            r.password = rdr["password"].ToString();
                            r.email = rdr["email"].ToString();
                            r.phone = rdr["phone"].ToString();
                            list.Add(r);
                        }
                    }
                }
            }
            return list;
        }

        public void DeleteData(int id)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["odawaConnectionString"].ConnectionString;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "DELETE FROM [restaurateur] WHERE id = " + id;
                    cmd.Connection = cn;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
