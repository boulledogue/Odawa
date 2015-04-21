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
    public static class TypeCuisineProvider
    {
        public static void Create(TypeCuisine t)
        {
            OdawaDS.typescuisineRow newRow = DatabaseConnection.odawa.typescuisine.NewtypescuisineRow();
            newRow.type = t.type;
            DatabaseConnection.odawa.typescuisine.Rows.Add(newRow);
            WriteToDB();
        }

        public static List<TypeCuisine> GetAll()
        {
            DataTable dt = DatabaseConnection.GetTypesCuisine();
            List<TypeCuisine> lst = new List<TypeCuisine>();
            foreach (OdawaDS.typescuisineRow typeRow in dt.Rows)
            {
                lst.Add(GetOne(typeRow.id));                
            }
            return lst;
        }

        public static TypeCuisine GetOne(int id)
        {
            TypeCuisine t = new TypeCuisine();
            t.id = DatabaseConnection.odawa.typescuisine.FindByid(id).id;
            t.type = DatabaseConnection.odawa.typescuisine.FindByid(id).type;
            return t;
        }

        public static void Update(TypeCuisine t)
        {
            DatabaseConnection.odawa.typescuisine.FindByid(t.id).type = t.type;
            WriteToDB();
        }

        public static void Delete(int id)
        {
            DatabaseConnection.odawa.typescuisine.FindByid(id).Delete();
            WriteToDB();
        }

        private static void WriteToDB()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["odawaConnectionString"].ConnectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from typescuisine", conn);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);
                da.Update(DatabaseConnection.odawa, "typescuisine");
            }
            DatabaseConnection.odawa.typescuisine.AcceptChanges();
        }
    }
}
