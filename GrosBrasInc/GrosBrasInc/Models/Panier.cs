using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GrosBrasInc.Models
{
    public class Panier
    {
        [Key]
        [ScaffoldColumn(false)]
        public int PanierID { get; set; }
        [ScaffoldColumn(false)]
        public string KeyPanier { get; set; }
        [ScaffoldColumn(false)]
        public int ArticleID { get; set; }
        [Display(ResourceType = typeof(GrosBrasInc.Ressource), Name = "Panier_Count")]
        public int Count { get; set; }
        [Display(ResourceType = typeof(GrosBrasInc.Ressource), Name = "Panier_DateCreated")]
        public DateTime DateCreated { get; set; }
        [Display(ResourceType = typeof(GrosBrasInc.Ressource), Name = "Panier_Article")]
        public virtual Article Article { get; set; }
    }
}