using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odawa.BU.Entities;

namespace Odawa.DAL
{
    static class TypeCuisineProvider
    {
        public static List<TypeCuisine> GetTypeCuisine(int id=0)
        {
            List<TypeCuisine> lst = new List<TypeCuisine>();
            foreach (OdawaDS.typescuisineRow typeRow in DatabaseConnection.odawa.typescuisine.Rows)
            {
                if (id == 0 || id == typeRow.id)
                {
                    TypeCuisine type = new TypeCuisine();
                    type.id = typeRow.id;
                    type.type = typeRow.type;
                    lst.Add(type);
                }
            }
            return lst;
        }
    }
}
