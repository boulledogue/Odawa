using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BU.Entities
{
    public class Comment
    {        
        public int id { get; set; }        
        public string commentaire { get; set; }        
        public int idUtilisateur { get; set; }        
        public int idRestaurant { get; set; }
    }
}
