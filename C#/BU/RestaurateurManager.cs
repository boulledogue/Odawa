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
    public static class RestaurateurManager
    {
        //Création restaurateur avec l'objet "r" passé en paramètre
        public static bool Create(Restaurateur r)
        {
            //Création d'une restaurateursRow et remplissage avec les attributs de "r"
            OdawaDS.restaurateursRow newRow = DataProvider.odawa.restaurateurs.NewrestaurateursRow();
            newRow.nom = r.nom.ToUpper();
            newRow.prenom = r.prenom;
            newRow.username = r.username.ToLower();
            newRow.password = r.password;
            newRow.email = r.email.ToLower();
            newRow.phone = r.phone;
            //Envoi à la DAL
            try
            {
                DataProvider.CreateRestaurateur(newRow);
                //Envoi du mail de bienvenue contenant les codes d'accès au restaurateur
                try
                {
                    EmailManager.EmailCreateRestaurateur(r);
                }
                catch
                {
                    //on ne fait rien ici, ne peut pas bloquer l'application
                }
                //Si création ok, renvoie true
                return true;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                //Si SqlException, log et renvoie false
                LogManager.LogSQLException(e.Message);
                return false;
            }
            
        }

        //Obtention de tous les restaurateurs
        public static List<Restaurateur> GetAll()
        {
            //Obtention de la dataTable
            OdawaDS.restaurateursDataTable dt = DataProvider.GetRestaurateurs();
            //Création d'une liste vide
            List<Restaurateur> lst = new List<Restaurateur>();
            //Pour chaque restaurateur dans la dataTable
            foreach (OdawaDS.restaurateursRow restRow in dt.Rows)
            {
                Restaurateur r = new Restaurateur();
                r.id = restRow.id;
                r.nom = restRow.nom;
                r.prenom = restRow.prenom;
                r.username = restRow.username;
                r.password = restRow.password;
                r.email = restRow.email;
                r.phone = restRow.phone;
                //Ajout à la liste
                lst.Add(r);
            }
            //retourne la liste
            return lst;
        }

        //Mise à jour d'un restaurateur "r" passé en paramètre
        public static bool Update(Restaurateur r)
        {
            //Vérification de l'objet r: il peut être transmis par le web service et n'est pas sûr
            if (isValid(r))
            {
                OdawaDS.restaurateursDataTable dt = DataProvider.GetRestaurateurs();
                //Création d'une restaurateursRow et remplissage avec les attributs de "r"
                OdawaDS.restaurateursRow updRow = DataProvider.odawa.restaurateurs.NewrestaurateursRow();
                updRow.id = r.id;
                updRow.nom = r.nom.ToUpper();
                updRow.prenom = r.prenom;
                updRow.username = r.username.ToLower();
                updRow.password = r.password;
                updRow.email = r.email.ToLower();
                updRow.phone = r.phone;
                //Envoi à la DAL
                try
                {
                    DataProvider.UpdateRestaurateur(updRow);
                    //si ok, renvoie true
                    return true;
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    //si SQLException, log et renvoie false
                    LogManager.LogSQLException(e.Message);
                    return false;
                }
            }
            //si pas validé, renvoie false
            else return false;
        }

        //Suppression d'un restaurateur avec son id passé en paramètre
        public static bool Delete(int id)
        {
            //Si un restaurateur avec cet id existe
            if (GetAll().Exists(x => x.id == id))
            {
                try
                {
                    //Passage de l'id à la DAL pour suppression du restaurateur
                    DataProvider.DeleteRestaurateur(id);
                    //si ok, renvoie true
                    return true;
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    //si SQLException, log et renvoie false
                    LogManager.LogSQLException(e.Message);
                    return false;
                }
            }
            //Si le restaurateur n'existe pas, renvoie false
            else return false;
        }

        //Vérification couple username-password, renvoie true ou false
        public static bool AcceptLogin(string username, string password)
        {
            if (username != null && password != null)
            {
                Restaurateur r = GetAll().Find(x => x.username == username);
                //Si un restaurateur avec ce username existe et que le mot de passe correspond, renvoie true, connexion acceptée
                if (r != null && r.password == password) return true;
            }
            //dans les autres cas, renvoie false, connexion refusée
            return false;
        }

        //Test du caractère non null des paramètres du restaurateur (vérification des données envoyées par le web service)
        //si tout est ok, renvoie true,
        //sinon, log et renvoie false
        public static bool isValid(Restaurateur r)
        {
            bool b = false;
            if (r.nom != null)
                if (r.prenom != null)
                    if (r.username != null)
                        if (r.password != null)
                            if (r.email != null)
                                if (r.phone != null) b = true;
                                else LogManager.LogNullException("Restaurateur Add/Update : Phone est Null");
                            else LogManager.LogNullException("Restaurateur Add/Update : Email est Null");
                        else LogManager.LogNullException("Restaurateur Add/Update : Password est Null");
                    else LogManager.LogNullException("Restaurateur Add/Update : Username est Null");
                else LogManager.LogNullException("Restaurateur Add/Update : Prenom est Null");
            else LogManager.LogNullException("Restaurateur Add/Update : Nom est Null");
            return b;
        }
    }
}
