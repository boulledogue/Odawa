using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odawa.DAL;
using Odawa.BU.Entities;

namespace Odawa.BU
{
    class UtilisateurManager
    {
        public static List<Utilisateur> LoadData()
        {
            return new UtilisateurProvider().LoadData();
        }
    }
}
