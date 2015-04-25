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

        public static Comment GetOne(int id)
        {
            return GetAll().Find(x => x.id == id);
        }

        public static void Update(Comment c)
        {
            OdawaDS.commentsRow updRow = DataProvider.odawa.comments.NewcommentsRow();
            updRow.id = c.id;
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

        public static List<Comment> GetByRestaurant(int id)
        {
            OdawaDS.commentsDataTable dt = DataProvider.GetComments();
            List<Comment> lst = new List<Comment>();
            foreach (OdawaDS.commentsRow commentRow in dt.Rows)
            {
                if (commentRow.idRestaurant == id)
                {
                    Comment c = new Comment();
                    c.id = commentRow.id;
                    c.commentaire = commentRow.commentaire;
                    c.idUtilisateur = commentRow.idUtilisateur;
                    c.idRestaurant = commentRow.idRestaurant;
                    lst.Add(c);
                }
            }
            return lst;
        }
    }
}
