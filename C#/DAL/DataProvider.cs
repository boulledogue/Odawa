using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DataProvider
    {
        //DataSet de l'application
        public static OdawaDS odawa = new OdawaDS();

        #region Obtention des DataTables

        //Obtention de la DataTable administrateurs 
        public static OdawaDS.administrateursDataTable GetAdministrateurs()
        {
            using (OdawaDSTableAdapters.administrateursTableAdapter adpt = new OdawaDSTableAdapters.administrateursTableAdapter())
            {
                adpt.Fill(odawa.administrateurs);
            }
            return odawa.administrateurs;
        }

        //Obtention de la DataTable commentaires
        public static OdawaDS.commentsDataTable GetComments()
        {
            using (OdawaDSTableAdapters.commentsTableAdapter adpt = new OdawaDSTableAdapters.commentsTableAdapter())
            {
                adpt.Fill(odawa.comments);
            }
            return odawa.comments;
        }

        //Obtention de la DataTable réservations
        public static OdawaDS.reservationsDataTable GetReservations()
        {
            using (OdawaDSTableAdapters.reservationsTableAdapter adpt = new OdawaDSTableAdapters.reservationsTableAdapter())
            {
                adpt.Fill(odawa.reservations);
            }
            return odawa.reservations;
        }

        //Obtention de la DataTable restaurants
        public static OdawaDS.restaurantsDataTable GetRestaurants()
        {
            using (OdawaDSTableAdapters.restaurantsTableAdapter adpt = new OdawaDSTableAdapters.restaurantsTableAdapter())
            {
                adpt.Fill(odawa.restaurants);
            }
            return odawa.restaurants;
        }

        //Obtention de la DataTable restaurateurs
        public static OdawaDS.restaurateursDataTable GetRestaurateurs()
        {
            using (OdawaDSTableAdapters.restaurateursTableAdapter adpt = new OdawaDSTableAdapters.restaurateursTableAdapter())
            {
                adpt.Fill(odawa.restaurateurs);
            }
            return odawa.restaurateurs;
        }

        //Obtention de la DataTable types de cuisine
        public static OdawaDS.typescuisineDataTable GetTypesCuisine()
        {
            using (OdawaDSTableAdapters.typescuisineTableAdapter adpt = new OdawaDSTableAdapters.typescuisineTableAdapter())
            {
                adpt.Fill(odawa.typescuisine);
            }
            return odawa.typescuisine;
        }

        //Obtention de la DataTable utilisateurs
        public static OdawaDS.utilisateursDataTable GetUtilisateurs()
        {
            using (OdawaDSTableAdapters.utilisateursTableAdapter adpt = new OdawaDSTableAdapters.utilisateursTableAdapter())
            {
                adpt.Fill(odawa.utilisateurs);
            }
            return odawa.utilisateurs;
        }

        #endregion Obtention des DataTables
        
        #region Administrateurs

        //Création administrateur
        public static void CreateAdministrateur(OdawaDS.administrateursRow a)
        {
            odawa.administrateurs.Rows.Add(a);
            WriteToDB("administrateurs");
        }

        //Mise à jour administrateur
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

        //Suppression administrateur
        public static void DeleteAdministrateur(int id)
        {
            odawa.administrateurs.FindByid(id).Delete();
            WriteToDB("administrateurs");
        }

        #endregion Administrateurs

        #region Commentaires

        //Création commentaire
        public static void CreateComment(OdawaDS.commentsRow c)
        {
            odawa.comments.Rows.Add(c);
            WriteToDB("comments");
        }

        //Mise à jour commentaire
        public static void UpdateComment(OdawaDS.commentsRow cr)
        {
            odawa.comments.FindByid(cr.id).commentaire = cr.commentaire;
            WriteToDB("comments");
        }

        //Suppression commentaire
        public static void DeleteComment(int id)
        {
            odawa.comments.FindByid(id).Delete();
            WriteToDB("comments");
        }

        #endregion Commentaires

        #region Réservations

        //Création réservation
        public static void CreateReservation(OdawaDS.reservationsRow r)
        {
            odawa.reservations.Rows.Add(r);
            WriteToDB("reservations");
        }

        //Mise à jour réservation
        public static void UpdateReservation(OdawaDS.reservationsRow r)
        {
            odawa.reservations.FindByid(r.id).status = r.status;
            WriteToDB("reservations");
        }

        //Suppression réservation
        public static void DeleteReservation(int id)
        {
            odawa.reservations.FindByid(id).Delete();
            WriteToDB("reservations");
        }

        #endregion Réservations

        #region Restaurants

        //Création restaurant
        public static void CreateRestaurant(OdawaDS.restaurantsRow r)
        {
            odawa.restaurants.Rows.Add(r);
            WriteToDB("restaurants");
        }
        
        //Mise à jour restaurant
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

        //Suppression restaurant
        public static void DeleteRestaurant(int id)
        {
            odawa.restaurants.FindByid(id).Delete();
            WriteToDB("restaurants");
        }

        //Obention d'une liste d'id des meilleurs restaurant
        public static List<int> BestRestaurant()
        {
            //Création d'une liste d'entiers vide
            List<int> lst = new List<int>();            
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["odawaConnectionString"].ConnectionString))
            {
                //Connexion à la DB
                conn.Open();
                SqlDataReader dr;
                //Exécution de la commande SQL qui récupère l'id des 3 restaurants ayant le plus de réservations triés dans l'ordre décroissant
                SqlCommand cm = new SqlCommand("select top 3 r.id from restaurants r left join reservations s on r.id=s.idRestaurant group by r.id order by count(s.id) DESC", conn);
                dr = cm.ExecuteReader();
                //Tant que le reader obtient une ligne
                while (dr.Read())
                {
                    //Ajout de l'id à la liste
                    lst.Add((int)dr["id"]);
                }                
            }
            //Retourne la liste
            return lst;
        }

        #endregion Restaurants

        #region Restaurateurs

        //Création d'un restaurateur
        public static void CreateRestaurateur(OdawaDS.restaurateursRow r)
        {
            odawa.restaurateurs.Rows.Add(r);
            WriteToDB("restaurateurs");
        }

        //Mise à jour d'un restaurateur
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

        //Suppression d'un restaurateur
        public static void DeleteRestaurateur(int id)
        {
            odawa.restaurateurs.FindByid(id).Delete();
            WriteToDB("restaurateurs");
        }

        #endregion Restaurateurs

        #region Types Cuisine

        //Création d'un type de cuisine
        public static void CreateTypeCuisine(OdawaDS.typescuisineRow t)
        {            
            odawa.typescuisine.Rows.Add(t);
            WriteToDB("typescuisine");
        }

        //Mise à jour d'un type de cuisine
        public static void UpdateTypeCuisine(OdawaDS.typescuisineRow t)
        {
            odawa.typescuisine.FindByid(t.id).type = t.type;
            odawa.typescuisine.FindByid(t.id).description = t.description;
            WriteToDB("typescuisine");
        }

        //Suppression d'un type de cuisine
        public static void DeleteTypeCuisine(int id)
        {
            odawa.typescuisine.FindByid(id).Delete();
            WriteToDB("typescuisine");
        }

        #endregion Types Cuisine

        #region Utilisateurs

        //Création d'un utilisateur
        public static void CreateUtilisateur(OdawaDS.utilisateursRow u)
        {
            odawa.utilisateurs.Rows.Add(u);
            WriteToDB("utilisateurs");
        }

        //Mise à jour d'un utilisateur
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

        //Suppression d'un utilisateur
        public static void DeleteUtilisateur(int id)
        {
            odawa.utilisateurs.FindByid(id).Delete();
            WriteToDB("utilisateurs");
        }

        #endregion Utilisateurs

        //Mise à jour des modifications entre le DataSet et la DB, le nom de la table à mettre à jour est passé en paramètre
        //Les modifications peuvent être indifféremment des suppressions, ajouts ou modifications
        public static void WriteToDB(string table)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["odawaConnectionString"].ConnectionString))
            {
                //Ouverture de la connexion à la DB
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from " + table, conn);
                //Génération des commandes utilisées pour harmoniser les modifications
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);
                //Appelle les instruction INSERT, UPDATE, DELETE sur la table passée en paramètre
                da.Update(odawa, table);
            }
            //Valide les modifications
            odawa.AcceptChanges();
        }

        //Vérifie la connexion à la DB
        public static bool DBConnectionStatus()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["odawaConnectionString"].ConnectionString))
            {
                conn.Open();
                //retourne true si l'état de la connexion est 'Open', false dans les autres cas (DB inaccessible)
                return (conn.State == ConnectionState.Open);
            }
        }
    }
}