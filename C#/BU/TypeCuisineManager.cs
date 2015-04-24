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
                lst.Add(t);
            }
            return lst;
        }

        public static TypeCuisine GetOne(int id)
        {
            return GetAll().Find(x => x.id == id);
        }
        
        public static void Update(TypeCuisine t)
        {
            
        }

        public static void Delete(int id)
        {
            DataProvider.DeleteTypeCuisine(id);
        }        
    }
}
