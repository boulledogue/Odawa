using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odawa.DAL;
using Odawa.BU.Entities;

namespace Odawa.BU
{
    public static class TypeCuisineManager
    {
        public static void Create(TypeCuisine t)
        {
            if (t.type != null)
            {
                t.type = t.type.ToUpper();
                TypeCuisineProvider.Create(t);
            }

        }

        public static List<TypeCuisine> GetAll()
        {
            return TypeCuisineProvider.GetTypeCuisine();
        }

        public static List<TypeCuisine> GetOne(int id)
        {
            return TypeCuisineProvider.GetTypeCuisine(id);
        }
        
        public static void Update(TypeCuisine t)
        {
            if (t.type != null)
            {
                t.type = t.type.ToUpper();
                TypeCuisineProvider.Update(t);                
            }
        }

        public static void Delete(int id)
        {
            TypeCuisineProvider.Delete(id);            
        }
    }
}
