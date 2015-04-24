using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BU.Entities
{
    public class Administrateur
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
}
