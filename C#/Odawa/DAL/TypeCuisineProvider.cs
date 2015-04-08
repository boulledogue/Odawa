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
        public List<TypeCuisine> LoadData()
        {
            List<TypeCuisine> list = new List<TypeCuisine>();

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["odawaConnectionString"].ConnectionString;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Select * from [typescuisine]";
                    cmd.Connection = cn;

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
    }
}
