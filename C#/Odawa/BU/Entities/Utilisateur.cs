using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Odawa.BU.Entities
{
    [DataContract]
    public class Utilisateur
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string nom { get; set; }
        [DataMember]
        public string prenom { get; set; }
        [DataMember]
        public string username { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string phone { get; set; }
    }
}
