﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BU.Entities
{
    public class Restaurant
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string adresse { get; set; }
        public string numero { get; set; }
        public string zipCode { get; set; }
        public string localite { get; set; }
        public string description { get; set; }
        public int budgetLow { get; set; }
        public int budgetHigh { get; set; }
        public string horaire { get; set; }
        public bool premium { get; set; }
        public int genre { get; set; }
        public int idTypeCuisine { get; set; }
        public int idRestaurateur { get; set; }
    }
}
