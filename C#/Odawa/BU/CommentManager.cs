using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odawa.DAL;
using Odawa.BU.Entities;
using System.Data;

namespace Odawa.BU
{
    public static class CommentManager
    {
        public static void Create(Comment c)
        {
            if (c.commentaire != null)
            {
                CommentProvider.Create(c);
            }
        }

        public static OdawaDS.commentsDataTable GetTable()
        {
            return CommentProvider.GetTable();
        }

        public static List<Comment> GetAll()
        {
            return CommentProvider.GetAll();
        }

        public static Comment GetOne(int id)
        {
            return CommentProvider.GetOne(id);
        }

        public static List<Comment> GetByRestaurant(int id)
        {
            return CommentProvider.GetByRestaurant(id);
        }
        
        public static void Update(Comment c)
        {
            if (c.commentaire != null)
            {
                CommentProvider.Update(c);                
            }
        }

        public static void Delete(int id)
        {
            CommentProvider.Delete(id);            
        }
    }
}
