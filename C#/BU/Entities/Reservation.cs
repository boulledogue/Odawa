using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BU.Entities
{    
    public class Reservation
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public DateTime date { get; set; }
        public bool typeService { get; set; }
        public int nbPersonnes { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int idRestaurant { get; set; }
        public int status { get; set; }
        public DateTime encodedDateTime { get; set; }
    }
}
