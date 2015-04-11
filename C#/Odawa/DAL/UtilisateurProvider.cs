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
    class UtilisateurProvider
    {
        public utilisateur GetOne(int id)
        {
            odawaEntities context = new odawaEntities();
            utilisateur fromDB = context.utilisateurs.Single(utilisateur => utilisateur.id == id);
            return fromDB;
        }

        public List<Utilisateur> GetAll()
        {
            List<Utilisateur> list = new List<Utilisateur>();

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["odawaConnectionString"].ConnectionString;
                cn.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Select * from [utilisateurs]";
                    cmd.Connection = cn;

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Utilisateur u = new Utilisateur();
                            u.id = (int)rdr["id"];
                            u.nom = rdr["nom"].ToString();
                            u.prenom = rdr["prenom"].ToString();
                            u.username = rdr["username"].ToString();
                            u.password = rdr["password"].ToString();
                            u.email = rdr["email"].ToString();
                            u.phone = rdr["phone"].ToString();
                            list.Add(u);
                        }
                    }
                }
            }
            return list;
        }
    }
}
