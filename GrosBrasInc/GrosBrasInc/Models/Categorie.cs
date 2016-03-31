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
        public int CategorieID { get; set; }
        public string NomCategorie { get; set; }
    }
}