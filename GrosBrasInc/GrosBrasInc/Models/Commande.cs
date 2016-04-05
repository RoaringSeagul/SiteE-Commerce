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
        [Display(ResourceType = typeof(GrosBrasInc.Ressource.Ressource), Name = "Commande_SousTotal")]
        public float SousTotal { get; set; }
        [Display(ResourceType = typeof(GrosBrasInc.Ressource.Ressource), Name = "Commande_Taxes")]
        public float Taxes { get; set; }
        [Display(ResourceType = typeof(GrosBrasInc.Ressource.Ressource), Name = "Commande_Total")]
        public float Total { get; set; }
        public int ClientID { get; set; }
        [ForeignKey("ClientID")]
        [Display(ResourceType = typeof(GrosBrasInc.Ressource.Ressource), Name = "Commande_Client")]
        public virtual Client Client { get; set; }
        public virtual IEnumerable<Article> Articles { get; set; }
    }
}