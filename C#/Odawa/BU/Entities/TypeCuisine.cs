using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Odawa.BU.Entities
{
    [DataContract]
    public class TypeCuisine
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string type { get; set; }        
    }
}
