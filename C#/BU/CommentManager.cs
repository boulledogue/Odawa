using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BU.Entities;
using System.Data;

namespace BU
{
    public static class CommentManager
    {
        public static void Create(Comment c)
        {
            OdawaDS.commentsDataTable dt = DataProvider.GetComments();
            OdawaDS.commentsRow newRow = DataProvider.odawa.comments.NewcommentsRow();
            newRow.commentaire = c.commentaire;
            newRow.idUtilisateur = c.idUtilisateur;
            newRow.idRestaurant = c.idRestaurant;
            DataProvider.CreateComment(newRow);
        }

        public static List<Comment> GetAll()
        {
            OdawaDS.commentsDataTable dt = DataProvider.GetComments();
            List<Comment> lst = new List<Comment>();
            foreach (OdawaDS.commentsRow commentRow in dt.Rows)
            {
                Comment c = new Comment();
                c.id = commentRow.id;
                c.commentaire = commentRow.commentaire;
                c.idUtilisateur = commentRow.idUtilisateur;
                c.idRestaurant = commentRow.idRestaurant;
                lst.Add(c);
            }
            return lst;
        }

        public static void Update(Comment c)
        {
            OdawaDS.commentsDataTable dt = DataProvider.GetComments();
            OdawaDS.commentsRow updRow = DataProvider.odawa.comments.NewcommentsRow();
            updRow.id = c.id;
            updRow.idRestaurant = c.idRestaurant;
            updRow.idUtilisateur = c.idUtilisateur;
            updRow.commentaire = c.commentaire;
            DataProvider.UpdateComment(updRow);
        }

        public static void Delete(int id)
        {
            DataProvider.DeleteComment(id);                
        }

        public static void DeleteByRestaurant(int id)
        {
            List<Comment> lst = GetAll().Where(x => x.idRestaurant == id).ToList();
            if (lst.Count() > 0)
            {
                foreach(Comment c in lst)
                {
                    Delete(c.id);
                }
            }
        }

        public static void DeleteByUtilisateur(int id)
        {
            List<Comment> lst = GetAll().Where(x => x.idUtilisateur == id).ToList();
            if (lst.Count() > 0)
            {
                foreach (Comment c in lst)
                {
                    Delete(c.id);
                }
            }
        }

        public static bool isValid(Comment c)
        {
            bool b = false ;
            if (c.idRestaurant != null && c.idRestaurant > 0)
                if (c.idUtilisateur != null && c.idUtilisateur > 0)
                    if (c.commentaire != null)
                        b = true;
            return b;
        }
    }
}
