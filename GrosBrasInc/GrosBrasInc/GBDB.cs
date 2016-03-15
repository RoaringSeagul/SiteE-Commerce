using System;
using System.Data.Entity;
using System.Linq;
using GrosBrasInc.Models;

namespace GrosBrasInc
{

    public class GBDB : DbContext
    {
        // Your context has been configured to use a 'GBDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'GrosBrasInc.GBDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'GBDB' 
        // connection string in the application configuration file.
        public GBDB()
            : base("name=GBDB")
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Panier> Paniers { get; set; }
        public virtual DbSet<Commande> Commandes { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<LigneCommande> LigneCommandes { get; set; }
        public virtual DbSet<Categorie> Categories { get; set; }
    }
}