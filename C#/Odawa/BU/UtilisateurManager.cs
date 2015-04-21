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
    public static class UtilisateurManager
    {
        public static void Create(Utilisateur u)
        {
            UtilisateurProvider.Create(u);
        }

        public static DataTable GetTable()
        {
            return UtilisateurProvider.GetTable();
        }

        public static List<Utilisateur> GetAll()
        {
            return UtilisateurProvider.GetAll();
        }

        public static Utilisateur GetOne(int id)
        {
            return UtilisateurProvider.GetOne(id);
        }

        public static void Update(Utilisateur u)
        {
            UtilisateurProvider.Update(u);
        }

        public static void Delete(int id)
        {
            UtilisateurProvider.Delete(id);
        }
    }
}
