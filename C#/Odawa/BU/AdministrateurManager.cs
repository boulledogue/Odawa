using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odawa.DAL;
using Odawa.BU.Entities;

namespace Odawa.BU
{
    class AdministrateurManager
    {
        public static List<Administrateur> LoadData()
        {
            return new AdministrateurProvider().LoadData();
        }
    }
}
