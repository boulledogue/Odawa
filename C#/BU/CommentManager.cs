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

        }

        public static void Delete(int id)
        {
                        
        }
    }
}
