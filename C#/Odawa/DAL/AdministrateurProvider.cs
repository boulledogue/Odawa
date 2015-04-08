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
    class AdministrateurProvider
    {        
        public List<Administrateur> LoadData()
        {
            List<Administrateur> list = new List<Administrateur>();

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["odawaConnectionString"].ConnectionString;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Select * from [administrateurs]";
                    cmd.Connection = cn;

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Administrateur a = new Administrateur();
                            a.id = (int) rdr["id"];
                            a.nom = rdr["nom"].ToString();
                            a.prenom = rdr["prenom"].ToString();
                            a.username = rdr["username"].ToString();
                            a.password = rdr["password"].ToString();
                            a.email = rdr["email"].ToString();
                            a.phone = rdr["phone"].ToString();
                            list.Add(a);
                        }
                    }
                }
            }
            return list;
        }
    }
}
