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
        public virtual IEnumerable<Article> Articles { get; set; }
    }
}