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
    public static class TypeCuisineManager
    {
        //Création TypeCuisine avec l'objet "t" passé en paramètre
        public static bool Create(TypeCuisine t)
        {
            //Création d'une typescuisineRow et remplissage avec les attributs de "t"
            OdawaDS.typescuisineRow newRow = DataProvider.odawa.typescuisine.NewtypescuisineRow();
            newRow.type = t.type;
            newRow.description = t.description;
            //Envoi à la DAL
            try
            {
                DataProvider.CreateTypeCuisine(newRow);
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

        //Obtention de tous les TypeCuisine
        public static List<TypeCuisine> GetAll()
        {
            //Obtention de la dataTable
            OdawaDS.typescuisineDataTable dt = DataProvider.GetTypesCuisine();
            //Création d'une liste vide
            List<TypeCuisine> lst = new List<TypeCuisine>();
            //Pour chaque restaurant dans la dataTable
            foreach (OdawaDS.typescuisineRow typeRow in dt.Rows)
            {
                TypeCuisine t = new TypeCuisine();
                t.id = typeRow.id;
                t.type = typeRow.type;
                t.description = typeRow.description;
                //Ajout à la liste
                lst.Add(t);
            }
            //Retourne la liste
            return lst;
        }

        //Mise à jour d'un TypeCuisine "t" passé en paramètre
        public static bool Update(TypeCuisine t)
        {
            OdawaDS.typescuisineDataTable dt = DataProvider.GetTypesCuisine();
            //Création d'une typescuisineRow et remplissage avec les attributs de "t"
            OdawaDS.typescuisineRow updRow = DataProvider.odawa.typescuisine.NewtypescuisineRow();
            updRow.id = t.id;
            updRow.type = t.type;
            updRow.description = t.description;
            //Envoi à la DAL
            try
            {
                DataProvider.UpdateTypeCuisine(updRow);
                //Si update ok, renvoie true
                return true;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //Si SqlException, log et renvoie false
                LogManager.LogSQLException(ex.Message);
                return false;
            }
        }

        //Suppression d'un TypeCuisine avec son id passé en paramètre
        public static bool Delete(int id)
        {
            //Si un TypeCuisine avec cet id existe
            if (GetAll().Exists(x => x.id == id))
            {
                try
                {
                    //Passage de l'id à la DAL pour suppression du TypeCuisine
                    DataProvider.DeleteTypeCuisine(id);
                    //Si ok, renvoie true
                    return true;
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    //Si SqlException, log et renvoie false
                    LogManager.LogSQLException(ex.Message);
                    return false;
                }
            }
            //Si le TypeCuisine n'existe pas, renvoie false
            else return false;
        }

    }
}
