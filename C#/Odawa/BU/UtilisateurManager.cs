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
        public static Utilisateur GetAll()
        {
            return new UtilisateurProvider().GetAll();
        }
    }
}
