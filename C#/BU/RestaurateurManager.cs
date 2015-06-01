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
        public static bool Create(Restaurateur r)
        {
            OdawaDS.restaurateursRow newRow = DataProvider.odawa.restaurateurs.NewrestaurateursRow();
            newRow.nom = r.nom.ToUpper();
            newRow.prenom = r.prenom;
            newRow.username = r.username.ToLower();
            newRow.password = r.password;
            newRow.email = r.email.ToLower();
            newRow.phone = r.phone;
            try
            {
                DataProvider.CreateRestaurateur(newRow);
                try
                {
                    EmailManager.EmailCreateRestaurateur(r);
                }
                catch
                {
                    //on ne fait rien ici, ne peut pas bloquer l'application
                }
                return true;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                LogManager.LogSQLException(e.Message);
                return false;
            }
            
        }

        public static List<Restaurateur> GetAll()
        {
            OdawaDS.restaurateursDataTable dt = DataProvider.GetRestaurateurs();
            List<Restaurateur> lst = new List<Restaurateur>();
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
                lst.Add(r);
            }
            return lst;
        }

        public static bool Update(Restaurateur r)
        {
            OdawaDS.restaurateursDataTable dt = DataProvider.GetRestaurateurs();
            OdawaDS.restaurateursRow updRow = DataProvider.odawa.restaurateurs.NewrestaurateursRow();
            updRow.id = r.id;
            updRow.nom = r.nom.ToUpper();
            updRow.prenom = r.prenom;
            updRow.username = r.username.ToLower();
            updRow.password = r.password;
            updRow.email = r.email.ToLower();
            updRow.phone = r.phone;
            try
            {
                DataProvider.UpdateRestaurateur(updRow);
                return true;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                LogManager.LogSQLException(e.Message);
                return false;
            }
        }

        public static bool Delete(int id)
        {
            try
            {
                DataProvider.DeleteRestaurateur(id);
                return true;
            }
            catch(System.Data.SqlClient.SqlException e)
            {
                LogManager.LogSQLException(e.Message);
                return false;
            }
        }

        public static bool AcceptLogin(string username, string password)
        {
            if (username != null && password != null)
            {
                Restaurateur r = GetAll().Find(x => x.username == username);
                if (r != null && r.password == password) return true;
            }
            return false;
        }
    }
}
