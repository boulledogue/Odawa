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
    class TypeCuisineProvider
    {
        public void Create(TypeCuisine t)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["odawaConnectionString"].ConnectionString;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "INSERT INTO [typescuisine](id, type) VALUES(@param1,@param2)";
                    cmd.Parameters.AddWithValue("@param1", t.id);
                    cmd.Parameters.AddWithValue("@param2", t.type);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<TypeCuisine> GetTypeCuisine(int id=0)
        {
            List<TypeCuisine> list = new List<TypeCuisine>();

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["odawaConnectionString"].ConnectionString;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    if (id == 0)
                    {
                        cmd.CommandText = "SELECT * FROM [typescuisine]";
                        cmd.Connection = cn;
                    }
                    else
                    {
                        cmd.CommandText = "SELECT * FROM [typescuisine] WHERE id=" + id;
                        cmd.Connection = cn;
                    }

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            TypeCuisine t = new TypeCuisine();
                            t.id = (int)rdr["id"];
                            t.type = rdr["type"].ToString();
                            list.Add(t);
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
                    cmd.CommandText = "DELETE FROM [typescuisine] WHERE id=" + id;
                    cmd.Connection = cn;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
