﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class odawaEntities : DbContext
    {
        public odawaEntities()
            : base("name=odawaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<administrateur> administrateurs { get; set; }
        public virtual DbSet<comment> comments { get; set; }
        public virtual DbSet<reservation> reservations { get; set; }
        public virtual DbSet<restaurant> restaurants { get; set; }
        public virtual DbSet<restaurateur> restaurateurs { get; set; }
        public virtual DbSet<typescuisine> typescuisines { get; set; }
        public virtual DbSet<utilisateur> utilisateurs { get; set; }
    }
}
