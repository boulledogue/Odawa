using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BU
{
    public static class CommonManager
    {
        //Test de la connexion à la base de données
        public static bool CheckDBConnection()
        {
            //Essai
            try
            {
                //si connexion ouverte, retourne true
                if (DataProvider.DBConnectionStatus()) return true;
            }
            catch (Exception ex)
            {
                //si une exception se produit, log et ...
                LogManager.LogException(ex);
            }
            //... retourne false;
            return false;
        }
    }
}
