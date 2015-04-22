using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Odawa.BU.Entities
{
    [DataContract]
    public class Reservation
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string nom { get; set; }
        [DataMember]
        public string prenom { get; set; }
        [DataMember]
        public DateTime date { get; set; }
        [DataMember]
        public bool typeService { get; set; }
        [DataMember]
        public int nbPersonnes { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string phone { get; set; }
        [DataMember]
        public int idRestaurant { get; set; }
    }
}
