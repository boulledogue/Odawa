using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Odawa.BU.Entities
{
    [DataContract]
    public class Comment
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string commentaire { get; set; }
        [DataMember]
        public int idUtilisateur { get; set; }
        [DataMember]
        public int idRestaurant { get; set; }
    }
}
