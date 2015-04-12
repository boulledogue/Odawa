using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odawa.DAL;
using Odawa.BU.Entities;

namespace Odawa.BU
{
    class TypeCuisineManager
    {
        public static List<TypeCuisine> GetAll()
        {
            return new TypeCuisineProvider().GetTypeCuisine();
        }

        public static List<TypeCuisine> GetOne(int id)
        {
            return new TypeCuisineProvider().GetTypeCuisine(id);
        }

        public static void DeleteData(int id)
        {
            
        }
    }
}
