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
        public static void Create(TypeCuisine t)
        {
            OdawaDS.typescuisineRow newRow = DataProvider.odawa.typescuisine.NewtypescuisineRow();
            newRow.type = t.type;
            newRow.description = t.description;
            DataProvider.CreateTypeCuisine(newRow);
        }

        public static List<TypeCuisine> GetAll()
        {
            OdawaDS.typescuisineDataTable dt = DataProvider.GetTypesCuisine();
            List<TypeCuisine> lst = new List<TypeCuisine>();
            foreach (OdawaDS.typescuisineRow typeRow in dt.Rows)
            {
                TypeCuisine t = new TypeCuisine();
                t.id = typeRow.id;
                t.type = typeRow.type;
                t.description = typeRow.description;
                lst.Add(t);
            }
            return lst;
        }
        
        public static void Update(TypeCuisine t)
        {
            OdawaDS.typescuisineDataTable dt = DataProvider.GetTypesCuisine();
            OdawaDS.typescuisineRow updRow = DataProvider.odawa.typescuisine.NewtypescuisineRow();
            updRow.id = t.id;
            updRow.type = t.type;
            updRow.description = t.description;
            DataProvider.UpdateTypeCuisine(updRow);
        }

        public static void Delete(int id)
        {
            DataProvider.DeleteTypeCuisine(id);
        }

        public static void isValid()
        {

        }
    }
}
