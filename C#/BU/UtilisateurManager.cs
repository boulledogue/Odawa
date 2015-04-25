﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BU.Entities;
using System.Data;

namespace BU
{
    public static class UtilisateurManager
    {
        public static void Create(Utilisateur u)
        {
            OdawaDS.utilisateursRow newRow = DataProvider.odawa.utilisateurs.NewutilisateursRow();
            newRow.nom = u.nom;
            newRow.prenom = u.prenom;
            newRow.username = u.username;
            newRow.password = u.password;
            newRow.email = u.email;
            newRow.phone = u.phone;
            DataProvider.CreateUtilisateur(newRow);
        }

        public static List<Utilisateur> GetAll()
        {
            OdawaDS.utilisateursDataTable dt = DataProvider.GetUtilisateurs();
            List<Utilisateur> lst = new List<Utilisateur>();
            foreach (OdawaDS.utilisateursRow utilRow in dt.Rows)
            {
                Utilisateur u = new Utilisateur();
                u.id = utilRow.id;
                u.nom = utilRow.nom;
                u.prenom = utilRow.prenom;
                u.username = utilRow.username;
                u.password = utilRow.password;
                u.email = utilRow.email;
                u.phone = utilRow.phone;
                lst.Add(u);
            }
            return lst;
        }

        public static Utilisateur GetOne(int id)
        {
            return GetAll().Find(x => x.id == id);
        }

        public static void Update(Utilisateur u)
        {
            OdawaDS.utilisateursRow updRow = DataProvider.odawa.utilisateurs.NewutilisateursRow();
            updRow.id = u.id;
            updRow.nom = u.nom;
            updRow.prenom = u.prenom;
            updRow.username = u.username;
            updRow.password = u.password;
            updRow.email = u.email;
            updRow.phone = u.phone;
            DataProvider.UpdateUtilisateur(updRow);
        }

        public static void Delete(int id)
        {
            CommentManager.DeleteByUtilisateur(id);
            DataProvider.DeleteUtilisateur(id);
        }
    }
}
