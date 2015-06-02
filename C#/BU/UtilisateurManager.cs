using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BU.Entities;
using System.Data;

namespace BU
{
    public static class UtilisateurManager
    {
        //Création utilisateur avec l'objet "u" passé en paramètre
        public static bool Create(Utilisateur u)
        {
            //Vérification de l'objet u: il est transmis par le web service et n'est pas sûr
            if (isValid(u)) 
            {
                //Création d'une utilisateursRow et remplissage avec les attributs de "u"
                OdawaDS.utilisateursRow newRow = DataProvider.odawa.utilisateurs.NewutilisateursRow();
                newRow.nom = u.nom.ToUpper();
                newRow.prenom = u.prenom;
                newRow.username = u.username.ToLower();
                newRow.password = u.password;
                newRow.email = u.email.ToLower();
                newRow.phone = u.phone;
                //Envoi à la DAL
                try
                {
                    DataProvider.CreateUtilisateur(newRow);
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

        //Obtention de tous les utilisateurs
        public static List<Utilisateur> GetAll()
        {
            //Obtention de la dataTable
            OdawaDS.utilisateursDataTable dt = DataProvider.GetUtilisateurs();
            //Création d'une liste vide
            List<Utilisateur> lst = new List<Utilisateur>();
            //Pour chaque utilisateur dans la dataTable
            foreach (OdawaDS.utilisateursRow utilRow in dt.Rows)
            {
                Utilisateur u = new Utilisateur();
                u.id = utilRow.id;
                u.nom = utilRow.nom;
                u.prenom = utilRow.prenom;
                u.username = utilRow.username;
                u.password = utilRow.password;
                u.email = utilRow.email;
                u.phone = utilRow.phone;
                //Ajout à la liste
                lst.Add(u);
            }
            //retourne la liste
            return lst;
        }

        //Mise à jour d'un utilisateur "u" passé en paramètre
        public static bool Update(Utilisateur u)
        {
            //Vérification de l'objet u: il est transmis par le web service et n'est pas sûr
            if (isValid(u)) 
            {
                OdawaDS.utilisateursDataTable dt = DataProvider.GetUtilisateurs();
                //Création d'une utilisateursRow et remplissage avec les attributs de "u"
                OdawaDS.utilisateursRow updRow = DataProvider.odawa.utilisateurs.NewutilisateursRow();
                updRow.id = u.id;
                updRow.nom = u.nom.ToUpper();
                updRow.prenom = u.prenom;
                updRow.username = u.username.ToLower();
                updRow.password = u.password;
                updRow.email = u.email.ToLower();
                updRow.phone = u.phone;
                //Envoi à la DAL
                try
                {
                    DataProvider.UpdateUtilisateur(updRow);
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
            //Si pas validé, renvoie false
            return false;
        }

        //Suppression d'un utilisateur avec son id passé en paramètre
        public static bool Delete(int id)
        {
            //Si un utilisateur avec cet id existe
            if (GetAll().Exists(x => x.id == id)) 
            {
                try
                {
                    //Suppression des commentaires de cet utilisateur (foreign key constraint)
                    CommentManager.DeleteByUtilisateur(id);
                    //Passage de l'id à la DAL pour suppression de l'utilisateur
                    DataProvider.DeleteUtilisateur(id);
                    //si ok, retourne true
                    return true;
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    //si SQLException, log et renvoie false
                    LogManager.LogSQLException(e.Message);
                    return false;
                }                        
            }
            //Si l'utilisateur n'existe pas, renvoie false
            else return false;
        }

        //Vérification couple username-password, renvoie true ou false
        public static bool AcceptLogin(string username, string password)
        {            
            if (username != null && password != null)
            {                
                Utilisateur u = GetAll().Find(x => x.username == username);
                //Si un utilisateur avec ce username existe et que le mot de passe correspond, renvoie true, connexion acceptée
                if (u != null && u.password == password) return true;
            }
            //dans les autres cas, renvoie false, connexion refusée
            return false;
        }

        //Test du caractère non null des paramètres de l'utilisateur (vérification des données envoyées par le web service)
        //si tout est ok, renvoie true,
        //sinon, log et renvoie false
        public static bool isValid(Utilisateur r)
        {
            bool b = false;
            if (r.nom != null)
                if (r.prenom != null)
                    if (r.username != null)
                        if (r.password != null)
                            if (r.email != null)
                                if (r.phone != null) b = true;
                                else LogManager.LogNullException("Utilisateur Add/Update : Phone est Null");
                            else LogManager.LogNullException("Utilisateur Add/Update : Email est Null");
                        else LogManager.LogNullException("Utilisateur Add/Update : Password est Null");
                    else LogManager.LogNullException("Utilisateur Add/Update : Username est Null");
                else LogManager.LogNullException("Utilisateur Add/Update : Prenom est Null");
            else LogManager.LogNullException("Utilisateur Add/Update : Nom est Null");
            return b;
        }
    }
}
