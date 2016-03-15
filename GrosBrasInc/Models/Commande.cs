namespace GrosBrasInc
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Commande")]
    public partial class Commande
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Commande()
        {
            Articles = new HashSet<Article>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CommandeID { get; set; }

        [Column(TypeName = "money")]
        public decimal SousTotal { get; set; }

        [Column(TypeName = "money")]
        public decimal Taxes { get; set; }

        [Column(TypeName = "money")]
        public decimal Total { get; set; }

        public int ClientID { get; set; }

        public virtual Client Client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Article> Articles { get; set; }
    }
}
