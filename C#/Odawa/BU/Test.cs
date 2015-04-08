using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odawa.DAL;
using Odawa.BU.Entities;

namespace Odawa.BU
{
    class Test
    {
        public static List<Administrateur> LoadData()
        {
            return new DAL.Test().LoadData();
        }
    }
}
