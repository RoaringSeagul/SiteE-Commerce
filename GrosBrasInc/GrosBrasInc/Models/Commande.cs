using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrosBrasInc.Models
{
    public class Commande
    {
        [Key]
        [ScaffoldColumn(false)]
        public int CommandeID { get; set; }
        public float SousTotal { get; set; }
        public float Taxes { get; set; }
        public float Total { get; set; }
        public int ClientID { get; set; }
        [ForeignKey("ClientID")]
        public virtual Client Client { get; set; }
        public virtual IEnumerable<Article> Articles { get; set; }
    }
}