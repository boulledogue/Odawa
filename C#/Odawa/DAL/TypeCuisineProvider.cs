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
            DataTable dt = DatabaseConnection.GetTypesCuisine();
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

        public static void Create(TypeCuisine t)
        {
            OdawaDS.typescuisineRow newRow = DatabaseConnection.odawa.typescuisine.NewtypescuisineRow();
            newRow.id = t.id;
            newRow.type = t.type;
            DatabaseConnection.odawa.typescuisine.Rows.Add(newRow);
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["odawaConnectionString"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM typescuisine";
                SqlDataAdapter adpt = new SqlDataAdapter();
                adpt.SelectCommand = cmd;
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adpt);
                adpt.UpdateCommand = cmdBuilder.GetUpdateCommand();
                adpt.Update(DatabaseConnection.odawa.typescuisine);
                DatabaseConnection.odawa.typescuisine.AcceptChanges();
            }
        }
    }
}
