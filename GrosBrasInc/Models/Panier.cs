namespace GrosBrasInc
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Panier")]
    public partial class Panier
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PanierID { get; set; }

        public int ArticleID { get; set; }

        public virtual Article Article { get; set; }
    }
}
