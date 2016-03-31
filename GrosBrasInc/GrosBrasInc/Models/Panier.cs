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
        public int PanierID { get; set; }
        public string KeyPanier { get; set; }
        public int ArticleID { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Article Article { get; set; }
    }
}