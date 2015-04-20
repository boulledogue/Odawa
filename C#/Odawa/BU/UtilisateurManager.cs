using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odawa.DAL;
using Odawa.BU.Entities;

namespace Odawa.BU
{
    public static class UtilisateurManager
    {
        public static List<Utilisateur> GetAll()
        {
            return UtilisateurProvider.GetAll();
        }
    }
}
