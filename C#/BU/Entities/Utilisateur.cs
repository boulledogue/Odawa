using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BU.Entities
{
    public class Utilisateur
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
