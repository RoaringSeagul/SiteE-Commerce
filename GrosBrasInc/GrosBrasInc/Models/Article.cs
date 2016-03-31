using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GrosBrasInc.Models
{
    public class Article
    {
        [Key]
        public int ArticleID { get; set; }
        public string NomArticle { get; set; }
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public float Prix { get; set; }
        public int CategorieID { get; set; }
        public virtual Categorie Categorie { get; set; }
    }
}