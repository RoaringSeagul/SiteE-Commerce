using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GrosBrasInc.Models
{
    public class Categorie
    {
        [Key]
        [ScaffoldColumn(false)]
        public int CategorieID { get; set; }
        [Display(ResourceType = typeof(GrosBrasInc.Ressource.Ressource), Name = "Categorie_NomCategorie")]
        public string NomCategorie { get; set; }
    }
}