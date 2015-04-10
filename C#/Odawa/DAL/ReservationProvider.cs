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
    class ReservationProvider
    {
        public List<Reservation> GetAll()
        {
            List<Reservation> list = new List<Reservation>();

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["odawaConnectionString"].ConnectionString;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Select * from [reservations]";
                    cmd.Connection = cn;

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Reservation r = new Reservation();
                            r.id = (int)rdr["id"];
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
                    cmd.CommandText = "DELETE FROM [reservations] WHERE id = " + id;
                    cmd.Connection = cn;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
