using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BU.Entities
{
    public class Horaire
    {
        public int id { get; set; }
        public TimeSpan mondayOpen { get; set; }
        public TimeSpan mondayClose { get; set; }
        public TimeSpan tuesdayOpen { get; set; }
        public TimeSpan tuesdayClose { get; set; }
        public TimeSpan wednesdayOpen { get; set; }
        public TimeSpan wednesdayClose { get; set; }
        public TimeSpan thursdayOpen { get; set; }
        public TimeSpan thursdayClose { get; set; }
        public TimeSpan fridayOpen { get; set; }
        public TimeSpan fridayClose { get; set; }
        public TimeSpan saturdayOpen { get; set; }
        public TimeSpan saturdayClose { get; set; }
        public TimeSpan sundayOpen { get; set; }
        public TimeSpan sundayClose { get; set; }
    }
}
