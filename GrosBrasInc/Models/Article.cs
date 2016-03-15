namespace GrosBrasInc
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Article")]
    public partial class Article
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Article()
        {
            Paniers = new HashSet<Panier>();
            Commandes = new HashSet<Commande>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ArticleID { get; set; }

        [Required]
        public string NomArticle { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "money")]
        public decimal Prix { get; set; }

        public int? PanierID { get; set; }

        public int? CategorieID { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Panier> Paniers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Commande> Commandes { get; set; }
    }
}
