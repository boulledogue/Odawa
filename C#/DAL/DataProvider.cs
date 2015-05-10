using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DataProvider
    {
        public static OdawaDS odawa = new OdawaDS();
        
        public static OdawaDS.administrateursDataTable GetAdministrateurs()
        {
            using (OdawaDSTableAdapters.administrateursTableAdapter adpt = new OdawaDSTableAdapters.administrateursTableAdapter())
            {
                adpt.Fill(odawa.administrateurs);
            }
            return odawa.administrateurs;
        }

        public static OdawaDS.commentsDataTable GetComments()
        {
            using (OdawaDSTableAdapters.commentsTableAdapter adpt = new OdawaDSTableAdapters.commentsTableAdapter())
            {
                adpt.Fill(odawa.comments);
            }
            return odawa.comments;
        }

        public static OdawaDS.reservationsDataTable GetReservations()
        {
            using (OdawaDSTableAdapters.reservationsTableAdapter adpt = new OdawaDSTableAdapters.reservationsTableAdapter())
            {
                adpt.Fill(odawa.reservations);
            }
            return odawa.reservations;
        }

        public static OdawaDS.restaurantsDataTable GetRestaurants()
        {
            using (OdawaDSTableAdapters.restaurantsTableAdapter adpt = new OdawaDSTableAdapters.restaurantsTableAdapter())
            {
                adpt.Fill(odawa.restaurants);
            }
            return odawa.restaurants;
        }

        public static OdawaDS.restaurateursDataTable GetRestaurateurs()
        {
            using (OdawaDSTableAdapters.restaurateursTableAdapter adpt = new OdawaDSTableAdapters.restaurateursTableAdapter())
            {
                adpt.Fill(odawa.restaurateurs);
            }
            return odawa.restaurateurs;
        }

        public static OdawaDS.typescuisineDataTable GetTypesCuisine()
        {
            using (OdawaDSTableAdapters.typescuisineTableAdapter adpt = new OdawaDSTableAdapters.typescuisineTableAdapter())
            {
                adpt.Fill(odawa.typescuisine);
            }
            return odawa.typescuisine;
        }

        public static OdawaDS.utilisateursDataTable GetUtilisateurs()
        {
            using (OdawaDSTableAdapters.utilisateursTableAdapter adpt = new OdawaDSTableAdapters.utilisateursTableAdapter())
            {
                adpt.Fill(odawa.utilisateurs);
            }
            return odawa.utilisateurs;
        }

        public static void WriteToDB(string table)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["odawaConnectionString"].ConnectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from " + table, conn);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);
                da.Update(odawa, table);
            }
            odawa.AcceptChanges();
        }

        //------------- Administrateurs

        public static void CreateAdministrateur(OdawaDS.administrateursRow a)
        {
            odawa.administrateurs.Rows.Add(a);
            WriteToDB("administrateurs");
        }

        public static void UpdateAdministrateur(OdawaDS.administrateursRow a)
        {
            odawa.administrateurs.FindByid(a.id).nom = a.nom;
            odawa.administrateurs.FindByid(a.id).prenom = a.prenom;
            odawa.administrateurs.FindByid(a.id).username = a.username;
            odawa.administrateurs.FindByid(a.id).password = a.password;
            odawa.administrateurs.FindByid(a.id).email = a.email;
            odawa.administrateurs.FindByid(a.id).phone = a.phone;
            WriteToDB("administrateurs");
        }

        public static void DeleteAdministrateur(int id)
        {
            odawa.administrateurs.FindByid(id).Delete();
            WriteToDB("administrateurs");
        }
        //------------- Comments
        
        public static void CreateComment(OdawaDS.commentsRow c)
        {
            odawa.comments.Rows.Add(c);
            WriteToDB("comments");
        }

        public static void UpdateComment(OdawaDS.commentsRow cr)
        {
            odawa.comments.FindByid(cr.id).commentaire = cr.commentaire;
            WriteToDB("comments");
        }

        public static void DeleteComment(int id)
        {
            odawa.comments.FindByid(id).Delete();
            WriteToDB("comments");
        }

        //-------------- Réservations

        public static void CreateReservation(OdawaDS.reservationsRow r)
        {
            odawa.reservations.Rows.Add(r);
            WriteToDB("reservations");
        }

        public static void UpdateReservation(OdawaDS.reservationsRow r)
        {
            odawa.reservations.FindByid(r.id).status = r.status;
            WriteToDB("reservations");
        }
        public static void DeleteReservation(int id)
        {
            odawa.reservations.FindByid(id).Delete();
            WriteToDB("reservations");
        }

        //---------------- Restaurants

        public static void CreateRestaurant(OdawaDS.restaurantsRow r)
        {
            odawa.restaurants.Rows.Add(r);
            WriteToDB("restaurants");
        }
        
        public static void UpdateRestaurant(OdawaDS.restaurantsRow r)
        {
            odawa.restaurants.FindByid(r.id).nom = r.nom;
            odawa.restaurants.FindByid(r.id).adresse = r.adresse;
            odawa.restaurants.FindByid(r.id).numero = r.numero;
            odawa.restaurants.FindByid(r.id).zipCode = r.zipCode;
            odawa.restaurants.FindByid(r.id).localite = r.localite;
            odawa.restaurants.FindByid(r.id).description = r.description;
            odawa.restaurants.FindByid(r.id).budgetLow = r.budgetHigh;
            odawa.restaurants.FindByid(r.id).horaire = r.horaire;
            odawa.restaurants.FindByid(r.id).premium = r.premium;
            odawa.restaurants.FindByid(r.id).genre = r.genre;
            odawa.restaurants.FindByid(r.id).idTypeCuisine = r.idTypeCuisine;
            odawa.restaurants.FindByid(r.id).idRestaurateur = r.idRestaurateur;
            WriteToDB("restaurants");
        }

        public static void DeleteRestaurant(int id)
        {
            odawa.restaurants.FindByid(id).Delete();
            WriteToDB("restaurants");
        }

        public static List<int> BestRestaurant()
        {
            List<int> lst = new List<int>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["odawaConnectionString"].ConnectionString))
            {
                conn.Open();
                SqlDataReader dr;                
                SqlCommand cm = new SqlCommand("select top 3 r.id from restaurants r left join reservations s on r.id=s.idRestaurant group by r.id order by count(s.id) DESC", conn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    lst.Add((int)dr["id"]);
                }                
            }
            return lst;
        }

        //------------- Restaurateurs

        public static void CreateRestaurateur(OdawaDS.restaurateursRow r)
        {
            odawa.restaurateurs.Rows.Add(r);
            WriteToDB("restaurateurs");
        }

        public static void UpdateRestaurateur(OdawaDS.restaurateursRow r)
        {
            odawa.restaurateurs.FindByid(r.id).nom = r.nom;
            odawa.restaurateurs.FindByid(r.id).prenom = r.prenom;
            odawa.restaurateurs.FindByid(r.id).username = r.username;
            odawa.restaurateurs.FindByid(r.id).password = r.password;
            odawa.restaurateurs.FindByid(r.id).email = r.email;
            odawa.restaurateurs.FindByid(r.id).phone = r.phone;
            WriteToDB("restaurateurs");
        }

        public static void DeleteRestaurateur(int id)
        {
            odawa.restaurateurs.FindByid(id).Delete();
            WriteToDB("restaurateurs");
        }

        //------------- Types Cuisine

        public static void CreateTypeCuisine(OdawaDS.typescuisineRow t)
        {            
            odawa.typescuisine.Rows.Add(t);
            WriteToDB("typescuisine");
        }

        public static void UpdateTypeCuisine(OdawaDS.typescuisineRow t)
        {
            odawa.typescuisine.FindByid(t.id).type = t.type;
            WriteToDB("typescuisine");
        }

        public static void DeleteTypeCuisine(int id)
        {
            odawa.typescuisine.FindByid(id).Delete();
            WriteToDB("typescuisine");
        }
        
        //------------ Utilisateurs

        public static void CreateUtilisateur(OdawaDS.utilisateursRow u)
        {
            odawa.utilisateurs.Rows.Add(u);
            WriteToDB("utilisateurs");
        }

        public static void UpdateUtilisateur(OdawaDS.utilisateursRow u)
        {
            odawa.utilisateurs.FindByid(u.id).nom = u.nom;
            odawa.utilisateurs.FindByid(u.id).prenom = u.prenom;
            odawa.utilisateurs.FindByid(u.id).username = u.username;
            odawa.utilisateurs.FindByid(u.id).password = u.password;
            odawa.utilisateurs.FindByid(u.id).email = u.email;
            odawa.utilisateurs.FindByid(u.id).phone = u.phone;
            WriteToDB("utilisateurs");
        }

        public static void DeleteUtilisateur(int id)
        {
            odawa.utilisateurs.FindByid(id).Delete();
            WriteToDB("utilisateurs");
        }        
    }
}
