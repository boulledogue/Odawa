//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Odawa.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class restaurant
    {
        public restaurant()
        {
            this.comments = new HashSet<comment>();
            this.reservations = new HashSet<reservation>();
        }
    
        public int id { get; set; }
        public string nom { get; set; }
        public string adresse { get; set; }
        public string numero { get; set; }
        public string zipCode { get; set; }
        public string localite { get; set; }
        public string description { get; set; }
        public string horaire { get; set; }
        public Nullable<int> budget { get; set; }
        public bool premium { get; set; }
        public Nullable<int> idTypeCuisine { get; set; }
        public Nullable<int> idRestaurateur { get; set; }
    
        public virtual ICollection<comment> comments { get; set; }
        public virtual ICollection<reservation> reservations { get; set; }
        public virtual restaurateur restaurateur { get; set; }
        public virtual typescuisine typescuisine { get; set; }
    }
}
