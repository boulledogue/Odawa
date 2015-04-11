﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Odawa.BU.Entities;


namespace Odawa.DAL
{
    class UtilisateurProvider
    {
        OdawaDS odawa = new OdawaDS();

        public List<Utilisateur> GetAll()
        {
            List<Utilisateur> lst = new List<Utilisateur>();

            using( OdawaDSTableAdapters.utilisateursTableAdapter adpt = new OdawaDSTableAdapters.utilisateursTableAdapter() )
            { adpt.Fill(odawa.utilisateurs); }

            foreach (OdawaDS.utilisateursRow userRow in odawa.utilisateurs.Rows)
            {
                Utilisateur user = new Utilisateur();
                user.id = userRow.id;
                user.nom = userRow.nom;
                user.prenom = userRow.prenom;
                user.username = userRow.username;
                user.password = userRow.password;
                user.phone = userRow.phone;
                lst.Add(user);
            }

            return lst;
        }


        public List<Utilisateur> Search( int id, String nom, String prenom, String username, String password, String phone )
        {
            List<Utilisateur> lst = new List<Utilisateur>();

            using (OdawaDSTableAdapters.utilisateursTableAdapter adpt = new OdawaDSTableAdapters.utilisateursTableAdapter())
            { adpt.Fill(odawa.utilisateurs); }

            foreach (OdawaDS.utilisateursRow userRow in odawa.utilisateurs.Rows)
            {
                if( ( id == 0 ) || ( userRow.id == id ) )
                {
                    if( ( nom == null ) || ( userRow.nom == nom ) )
                    {
                        if( ( prenom == null ) || ( userRow.prenom == prenom ) )
                        {
                            if( ( username == null ) || ( userRow.username == username ) )
                            {
                                if( (password == null ) || ( userRow.password == password ) )
                                {
                                   if( (phone == null ) || ( userRow.phone == phone ) )
                                   {
                                       Utilisateur user = new Utilisateur();
                                       user.id = userRow.id;
                                       user.nom = userRow.nom;
                                       user.prenom = userRow.prenom;
                                       user.username = userRow.username;
                                       user.password = userRow.password;
                                       user.phone = userRow.phone;
                                       lst.Add(user);
                                   }
                                }
                            }
                        }
                    }
                }
            }

            return lst;
        }

        public Utilisateur Search( int id )
        {
            Utilisateur user = new Utilisateur();
            List<Utilisateur> lst = Search(id, null, null, null, null, null);
            user = lst.First();
            return user;
        }

        /*** Exist() ne retourne donc true que s'il existe un et un seul éléments. 
             C'est logique pour les utilisateurs ( et les administrateurs ) ( Vu qu'un username ne peut exister qu'un un seul exemplaire dans la BDD ).
             Ca ne l'est pas spécialement  pour les autres tables. :)
        ***/

        public bool Exist( String username, String password )
        {
            bool exist = false;
            List<Utilisateur> lst = new List<Utilisateur>();
            lst = Search(0, null, null, username, password, null);
            exist = (lst.Count == 1) ? true : false ;
            return exist;
        }

        public void Create( String nom, String prenom, String username, String password, String phone )
        {
            OdawaDS.utilisateursRow newUserRow = odawa.utilisateurs.NewutilisateursRow();

            newUserRow.nom = nom;
            newUserRow.prenom = prenom;
            newUserRow.username = username;
            newUserRow.password = password;
            newUserRow.phone = phone;
            odawa.utilisateurs.Rows.Add(newUserRow);

            odawa.utilisateurs.AcceptChanges();
        }

        public void Update( int id, String nom, String prenom, String username, String password, String phone )
        {
            OdawaDS.utilisateursRow updUserRow = odawa.utilisateurs.FindByid(id);

            if (nom != null)
                updUserRow.nom = nom;
            if (prenom != null)
                updUserRow.prenom = prenom;
            if (username != null)
                updUserRow.username = username;
            if (password != null)
                updUserRow.password = password;
            if (phone != null)
                updUserRow.phone = phone;

            odawa.utilisateurs.AcceptChanges();
        }

        public void Delete( int id )
        {
            odawa.utilisateurs.FindByid(id).Delete();
            odawa.utilisateurs.AcceptChanges();
        }

    }
}
