namespace GrosBrasInc
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GrosBrasModel : DbContext
    {
        public GrosBrasModel()
            : base("name=GBModel")
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Commande> Commandes { get; set; }
        public virtual DbSet<Panier> Paniers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .Property(e => e.Prix)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Article>()
                .HasMany(e => e.Paniers)
                .WithRequired(e => e.Article)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Article>()
                .HasMany(e => e.Commandes)
                .WithMany(e => e.Articles)
                .Map(m => m.ToTable("LigneCommande").MapLeftKey("ArticleID").MapRightKey("CommandeID"));

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Commandes)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Commande>()
                .Property(e => e.SousTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Commande>()
                .Property(e => e.Taxes)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Commande>()
                .Property(e => e.Total)
                .HasPrecision(19, 4);
        }
    }
}
