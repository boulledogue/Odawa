using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
            DataTable dt = DatabaseConnection.GetDataSet().Tables["typescuisine"];
            List<TypeCuisine> lst = new List<TypeCuisine>();
            foreach (OdawaDS.typescuisineRow typeRow in dt.Rows)
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
