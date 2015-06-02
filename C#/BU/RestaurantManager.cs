using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BU.Entities;

namespace BU
{
    public static class RestaurantManager
    {
        //Création restaurant avec l'objet "r" passé en paramètre
        public static bool Create(Restaurant r)
        {
            //Vérification de l'objet r: il peut être transmis par le web service et n'est pas sûr
            if (isValid(r)) 
            {
                //Création d'une restaurantsRow et remplissage avec les attributs de "r"
                OdawaDS.restaurantsRow newRow = DataProvider.odawa.restaurants.NewrestaurantsRow();
                newRow.nom = r.nom;
                newRow.adresse = r.adresse;
                newRow.numero = r.numero;
                newRow.zipCode = r.zipCode;
                newRow.localite = r.localite;
                newRow.description = r.description;
                newRow.budgetLow = r.budgetLow;
                newRow.budgetHigh = r.budgetHigh;
                newRow.horaire = r.horaire;
                newRow.premium = r.premium;
                newRow.genre = r.genre;
                newRow.idTypeCuisine = r.idTypeCuisine;
                newRow.idRestaurateur = r.idRestaurateur;
                //Envoi à la DAL
                try
                {
                    DataProvider.CreateRestaurant(newRow);
                    //Si création ok, renvoie true
                    return true;
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    //si SqlException, log et renvoie false
                    LogManager.LogSQLException(ex.Message);
                    return false;
                }
            }
            //si pas vérifié, renvoie false
            else return false;
        }

        //Obtention de tous les restaurants
        public static List<Restaurant> GetAll()
        {
            //Obtention de la dataTable
            OdawaDS.restaurantsDataTable dt = DataProvider.GetRestaurants();
            //Création d'une liste vide
            List<Restaurant> lst = new List<Restaurant>();
            //Pour chaque restaurant dans la dataTable
            foreach (OdawaDS.restaurantsRow restoRow in dt.Rows)
            {
                Restaurant r = new Restaurant();
                r.id = restoRow.id;
                r.nom = restoRow.nom;
                r.adresse = restoRow.adresse;
                r.numero = restoRow.numero;
                r.zipCode = restoRow.zipCode;
                r.localite = restoRow.localite;
                r.description = restoRow.description;
                r.budgetLow = restoRow.budgetLow;
                r.budgetHigh = restoRow.budgetHigh;
                r.horaire = restoRow.horaire;
                r.premium = restoRow.premium;
                r.genre = restoRow.genre;
                r.idTypeCuisine = restoRow.idTypeCuisine;
                r.idRestaurateur = restoRow.idRestaurateur;
                //Ajout à la liste
                lst.Add(r);
            }
            //retourne la liste
            return lst;
        }

        //Mise à jour d'un restaurant "r" passé en paramètre
        public static bool Update(Restaurant r)
        {
            //Vérification de l'objet r: il peut être transmis par le web service et n'est pas sûr
            if (isValid(r)) {
                OdawaDS.restaurantsDataTable dt = DataProvider.GetRestaurants();
                //Création d'une restaurantsRow et remplissage avec les attributs de "r"
                OdawaDS.restaurantsRow updRow = DataProvider.odawa.restaurants.NewrestaurantsRow();
                updRow.id = r.id;
                updRow.nom = r.nom;
                updRow.adresse = r.adresse;
                updRow.numero = r.numero;
                updRow.zipCode = r.zipCode;
                updRow.localite = r.localite;
                updRow.description = r.description;
                updRow.budgetLow = r.budgetLow;
                updRow.budgetHigh = r.budgetHigh;
                updRow.horaire = r.horaire;
                updRow.premium = r.premium;
                updRow.genre = r.genre;
                updRow.idTypeCuisine = r.idTypeCuisine;
                updRow.idRestaurateur = r.idRestaurateur;
                //Envoi à la DAL
                try
                {
                    DataProvider.UpdateRestaurant(updRow);
                    //si ok, renvoie true
                    return true;
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    //si SqlException, log et renvoie false
                    LogManager.LogSQLException(ex.Message);
                    return false;
                }
            }
            //si pas validé, renvoie false
            else return false;
        }

        //Suppression d'un restaurant avec son id passé en paramètre
        public static bool Delete(int id)
        {
            //Si un restaurant avec cet id existe
            if (GetAll().Exists(x => x.id == id))
            {
                try
                {
                    //suppression des commentaires de ce restaurant (foreign key constraint)
                    CommentManager.DeleteByRestaurant(id);
                    //suppression des réservations de ce restaurant (foreign key constraint)
                    ReservationManager.DeleteByRestaurant(id);
                    //Passage de l'id à la DAL pour suppression du restaurant
                    DataProvider.DeleteRestaurant(id);
                    //si ok, renvoie true
                    return true;
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    //si SqlException, log et renvoie false
                    LogManager.LogSQLException(ex.Message);
                    return false;
                }
            }
            //si le restaurant n'existe pas, renvoie false
            else return false;
        }

        //Renvoie une liste des restaurants sur base d'un string passé en paramètre (nom, code postal ou localité)
        public static List<Restaurant> Search(string s)
        {
            //Obtention de la dataTable
            OdawaDS.restaurantsDataTable dt = DataProvider.GetRestaurants();
            //Création d'une liste vide
            List<Restaurant> lst = new List<Restaurant>();            
            s = s.ToUpper();
            //Pour chaque restaurant dans la dataTable
            foreach (OdawaDS.restaurantsRow restoRow in dt.Rows)
            {
                //Si le nom OU le code postal OU la localité contiennent le string passé en paramètre
                if (restoRow.nom.ToUpper().Contains(s) || restoRow.zipCode.Contains(s) || restoRow.localite.ToUpper().Contains(s))
                {
                    Restaurant r = new Restaurant();
                    r.id = restoRow.id;
                    r.nom = restoRow.nom;
                    r.adresse = restoRow.adresse;
                    r.numero = restoRow.numero;
                    r.zipCode = restoRow.zipCode;
                    r.localite = restoRow.localite;
                    r.description = restoRow.description;
                    r.budgetLow = restoRow.budgetLow;
                    r.budgetHigh = restoRow.budgetHigh;
                    r.horaire = restoRow.horaire;
                    r.premium = restoRow.premium;
                    r.genre = restoRow.genre;
                    r.idTypeCuisine = restoRow.idTypeCuisine;
                    r.idRestaurateur = restoRow.idRestaurateur;
                    //ajout du restaurant à la liste
                    lst.Add(r);
                }
            }
            //Retourne la liste
            return lst;
        }

        //Obtention de la liste des meilleurs restaurants
        public static List<Restaurant> BestRestaurant()
        {
            //Création d'une liste vide
            List<Restaurant> lst = new List<Restaurant>();
            //Pour chaque id renvoyé par la DAL
            foreach (int id in DataProvider.BestRestaurant())
            {
                //Ajout à la liste du restaurant avec cet id
                lst.Add(GetAll().Find(x => x.id == id));
            }
            //Retourne la liste
            return lst;
        }

        //Obtention d'un restaurant "au hasard"
        public static Restaurant RandomRestaurant()
        {
            //Obtention de la liste des restaurants
            List<Restaurant> lst = GetAll();
            //Comptage de la liste
            int count = lst.Count();
            //Obtention d'une position aléatoire comprise entre 0 et la somme des restaurants de la liste (non inclus)
            Random rnd = new Random();            
            int randomIndex = rnd.Next(0, count);
            //récupération du restaurant à la position aléatoire
            Restaurant r = lst[randomIndex];
            //retourne le restaurant
            return r;
        }

        //Test du caractère non null des paramètres du restaurant (vérification des données envoyées par le web service)
        //si tout est ok, renvoie true,
        //sinon, log et renvoie false
        public static bool isValid(Restaurant r)
        {
            bool b = false;
            if (r.nom != null)
                if (r.adresse != null)
                    if (r.numero != null)
                        if (r.zipCode != null)
                            if (r.localite != null)
                                if (r.description != null)
                                    if (r.budgetLow > 0)
                                        if (r.budgetHigh > 0)
                                            if (r.horaire != null)
                                                if (r.premium != null)
                                                    if (r.genre != null)
                                                        if (RestaurateurManager.GetAll().Exists(x => x.id == r.idRestaurateur))
                                                            if (TypeCuisineManager.GetAll().Exists(x => x.id == r.idTypeCuisine)) b = true;
                                                            else LogManager.LogNullException("Restaurant Add/Update : IdTypeCuisine est Null ou Non-associable");
                                                        else LogManager.LogNullException("Restaurant Add/Update : IdRestaurateur est Null ou Non-associable");
                                                    else LogManager.LogNullException("Restaurant Add/Update : Genre est Null");
                                                else LogManager.LogNullException("Restaurant Add/Update : Premium est Null");
                                            else LogManager.LogNullException("Restaurant Add/Update : Horaire est Null");
                                        else LogManager.LogNullException("Restaurant Add/Update : BudgetHigh est Null");
                                    else LogManager.LogNullException("Restaurant Add/Update : BudgetLow est Null");
                                else LogManager.LogNullException("Restaurant Add/Update : Description est Null");
                            else LogManager.LogNullException("Restaurant Add/Update : Localite est Null");
                        else LogManager.LogNullException("Restaurant Add/Update : Zipcode est Null");
                    else LogManager.LogNullException("Restaurant Add/Update : Numero est Null");
                else LogManager.LogNullException("Restaurant Add/Update : Adresse est Null");
            else LogManager.LogNullException("Restaurant Add/Update : Nom est Null");


            return b;
        }
    }
}
