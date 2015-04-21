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
    static class CommentProvider
    {
        public static void Create(Comment c)
        {
            OdawaDS.commentsRow newRow = DatabaseConnection.odawa.comments.NewcommentsRow();
            newRow.commentaire = c.commentaire;
            newRow.idRestaurant = c.idRestaurant;
            newRow.idUtilisateur = c.idUtilisateur;
            DatabaseConnection.odawa.comments.Rows.Add(newRow);
            WriteToDB();
        }

        public static List<Comment> GetAll()
        {
            DataTable dt = DatabaseConnection.GetComments();
            List<Comment> lst = new List<Comment>();
            foreach (OdawaDS.commentsRow commentRow in dt.Rows)
            {
                Comment comment = new Comment();
                comment.id = commentRow.id;
                comment.commentaire = commentRow.commentaire;
                comment.idRestaurant = commentRow.idRestaurant;
                comment.idUtilisateur = commentRow.idUtilisateur;
                lst.Add(comment);                
            }
            return lst;
        }

        public static Comment GetOne(int id)
        {
            Comment c = new Comment();
            c.id = DatabaseConnection.odawa.comments.FindByid(id).id;
            c.commentaire = DatabaseConnection.odawa.comments.FindByid(id).commentaire;
            c.idRestaurant = DatabaseConnection.odawa.comments.FindByid(id).idRestaurant;
            c.idUtilisateur = DatabaseConnection.odawa.comments.FindByid(id).idUtilisateur;
            return c;
        }

        public static List<Comment> GetByRestaurant(int id)
        {
            DataTable dt = DatabaseConnection.GetComments();
            List<Comment> lst = new List<Comment>();
            foreach (OdawaDS.commentsRow commentRow in dt.Rows)
            {
                if (commentRow.idRestaurant == id)
                {
                    Comment comment = new Comment();
                    comment.id = commentRow.id;
                    comment.commentaire = commentRow.commentaire;
                    comment.idRestaurant = commentRow.idRestaurant;
                    comment.idUtilisateur = commentRow.idUtilisateur;
                    lst.Add(comment);
                }
            }
            return lst;
        }

        public static void Update(Comment c)
        {
            DatabaseConnection.odawa.comments.FindByid(c.id).commentaire = c.commentaire;
            WriteToDB();
        }

        public static void Delete(int id)
        {
            DatabaseConnection.odawa.comments.FindByid(id).Delete();
            WriteToDB();
        }

        private static void WriteToDB()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["odawaConnectionString"].ConnectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from comments", conn);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);
                da.Update(DatabaseConnection.odawa, "comments");
            }
            DatabaseConnection.odawa.comments.AcceptChanges();
        }
    }
}
