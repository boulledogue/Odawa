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
        //Création commentaire avec l'objet "c" passé en paramètre
        public static void Create(Comment c)
        {
            //Vérification de l'objet c: il est transmis par le web service et n'est pas sûr
            if (isValid(c)) 
            {
                OdawaDS.commentsDataTable dt = DataProvider.GetComments();
                //Création d'une commentsRow et remplissage avec les attributs de "c"
                OdawaDS.commentsRow newRow = DataProvider.odawa.comments.NewcommentsRow();
                newRow.commentaire = c.commentaire;
                newRow.idUtilisateur = c.idUtilisateur;
                newRow.idRestaurant = c.idRestaurant;
                //Envoi à la DAL de la commentsRow pour ajout au DataSet
                try
                {                    
                    DataProvider.CreateComment(newRow);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    //si SqlException, log
                    LogManager.LogSQLException(ex.Message);
                }
            }
        }

        //Obtention de tous les commentaires
        public static List<Comment> GetAll()
        {
            //Obtention de la DataTable
            OdawaDS.commentsDataTable dt = DataProvider.GetComments();
            //Création d'une liste vide
            List<Comment> lst = new List<Comment>();
            //Pour chaque commentaire dans la dataTable
            foreach (OdawaDS.commentsRow commentRow in dt.Rows)
            {
                Comment c = new Comment();
                c.id = commentRow.id;
                c.commentaire = commentRow.commentaire;
                c.idUtilisateur = commentRow.idUtilisateur;
                c.idRestaurant = commentRow.idRestaurant;
                //Ajout à la liste
                lst.Add(c);
            }
            //Retourne la liste
            return lst;
        }

        //Mise à jour d'un commentaire "c" passé en paramètre
        public static void Update(Comment c)
        {
            //Vérification de l'objet c: il est transmis par le web service et n'est pas sûr
            if (isValid(c)) 
            {
                OdawaDS.commentsDataTable dt = DataProvider.GetComments();
                //Création d'une commentsRow et remplissage avec les attributs de "c"
                OdawaDS.commentsRow updRow = DataProvider.odawa.comments.NewcommentsRow();
                updRow.id = c.id;
                updRow.idRestaurant = c.idRestaurant;
                updRow.idUtilisateur = c.idUtilisateur;
                updRow.commentaire = c.commentaire;                
                //Envoi à la DAL de la commentsRow pour mise à jour du DataSet
                try
                {
                    DataProvider.UpdateComment(updRow);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    //si SqlException, log
                    LogManager.LogSQLException(ex.Message);
                }
            }
        }

        //Suppression d'un commentaire avec son id passé en paramètre
        public static void Delete(int id)
        {
            //Si le commentaire avec l'id passé en paramètre existe, passage de l'id à la DAL pour suppression
            if (GetAll().Exists(x => x.id == id))
            {
                try
                {
                    DataProvider.DeleteComment(id);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    //si SqlException, log
                    LogManager.LogSQLException(ex.Message);
                }
            }
        }

        //Suppression des commentaires avec l'id du restaurant
        public static void DeleteByRestaurant(int id)
        {
            //Obtention d'une liste des commentaires du restaurant avec l'id passé en paramètre
            List<Comment> lst = GetAll().Where(x => x.idRestaurant == id).ToList();
            //Si la liste n'est pas vide
            if (lst.Count() > 0)
            {
                //Pour chaque commentaire de la liste
                foreach(Comment c in lst)
                {
                    //Passage de l'id du commentaire à la méthode Delete
                    Delete(c.id);
                }
            }
        }

        //Suppression des commentaires avec l'id de l'utilisateur
        public static void DeleteByUtilisateur(int id)
        {
            //Obtention d'une liste des commentaires de l'utilisateur avec l'id passé en paramètre
            List<Comment> lst = GetAll().Where(x => x.idUtilisateur == id).ToList();
            //Si la liste n'est pas vide
            if (lst.Count() > 0)
            {
                //Pour chaque commentaire de la liste
                foreach (Comment c in lst)
                {
                    //Passage de l'id du commentaire à la méthode Delete
                    Delete(c.id);
                }
            }
        }

        //Test du caractère non null des paramètres du commentaire (vérification des données envoyées par le web service)
        //si tout est ok, renvoie true,
        //sinon, log et renvoie false
        public static bool isValid(Comment c)
        {
            bool b = false ;
            if (RestaurantManager.GetAll().Exists(x => x.id == c.idRestaurant))
                if (UtilisateurManager.GetAll().Exists(x => x.id == c.idUtilisateur))
                    if (c.commentaire != null) b = true;
                    else LogManager.LogNullException("Comment Add/Update : Commentaire est Null ");
                else LogManager.LogNullException("Comment Add/Update : IdUtilisateur est Null ou Non-associable");
            else LogManager.LogNullException("Comment Add/Update : IdRestaurateur est Null ou Non-associable");
            return b;
        }
    }
}
