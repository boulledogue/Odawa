using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BU.Entities;
using DAL;
using System.Data;

namespace BU
{
    public static class AdministrateurManager
    {
        //Création administrateur avec l'objet "a" passé en paramètre
        public static bool Create(Administrateur a)
        {
            //Création d'une administrateursRow et remplissage avec les attributs de "a"
            OdawaDS.administrateursRow newRow = DataProvider.odawa.administrateurs.NewadministrateursRow();
            newRow.nom = a.nom.ToUpper();
            newRow.prenom = a.prenom;
            newRow.username = a.username.ToLower();
            newRow.password = a.password;
            newRow.email = a.email.ToLower();
            newRow.phone = a.phone;
            //Envoi à la DAL
            try
            {
                DataProvider.CreateAdministrateur(newRow);
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

        //Obtention de tous les administrateurs
        public static List<Administrateur> GetAll()
        {
            //Obtention de la dataTable
            OdawaDS.administrateursDataTable dt = DataProvider.GetAdministrateurs();
            //Création d'une liste vide
            List<Administrateur> lst = new List<Administrateur>();
            //Pour chaque administrateur dans la dataTable
            foreach (OdawaDS.administrateursRow adminRow in dt.Rows)
            {
                Administrateur a = new Administrateur();
                a.id = adminRow.id;
                a.nom = adminRow.nom;
                a.prenom = adminRow.prenom;
                a.username = adminRow.username;
                a.password = adminRow.password;
                a.email = adminRow.email;
                a.phone = adminRow.phone;
                //Ajout à la liste
                lst.Add(a);
            }
            //retourne la liste
            return lst;
        }

        //Mise à jour d'un administrateur "a" passé en paramètre
        public static bool Update(Administrateur a)
        {
            OdawaDS.administrateursDataTable dt = DataProvider.GetAdministrateurs();
            //Création d'une administrateursRow et remplissage avec les attributs de "a"
            OdawaDS.administrateursRow updRow = DataProvider.odawa.administrateurs.NewadministrateursRow();
            updRow.id = a.id;
            updRow.nom = a.nom.ToUpper();
            updRow.prenom = a.prenom;
            updRow.username = a.username.ToLower();
            updRow.password = a.password.ToLower();
            updRow.email = a.email;
            updRow.phone = a.phone;
            //envoi à la DAL
            try
            {
                DataProvider.UpdateAdministrateur(updRow);
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

        //Suppression de l'administrateur avec son id passé en paramètre
        public static bool Delete(int id)
        {
            //Si un administrateur avec cet id existe
            if (GetAll().Exists(x => x.id == id))
            {
                try
                {
                    //Passage de l'id à la DAL pour suppression de l'administrateur
                    DataProvider.DeleteAdministrateur(id);
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
            //Si l'administrateur n'existe pas, renvoie false
            else return false;
        }
    }
}
