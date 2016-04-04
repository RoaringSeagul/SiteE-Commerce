using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrosBrasInc.Models
{
    public class Article
    {
        [ScaffoldColumn(false)]
        [Key]
        public int ArticleID { get; set; }
        [Display(ResourceType = typeof(GrosBrasInc.Ressource), Name = "Article_NomArticle")]
        public string NomArticle { get; set; }
        public string Description { get; set; }
        [Display(ResourceType = typeof(GrosBrasInc.Ressource), Name = "Article_Prix")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public float Prix { get; set; }
        [ScaffoldColumn(false)]
        public int CategorieID { get; set; }
        [Display(ResourceType = typeof(GrosBrasInc.Ressource), Name = "Article_Categorie")]
        public virtual Categorie Categorie { get; set; }
        [ScaffoldColumn(false)]
        public string ImageNom { get; set; }
        [ScaffoldColumn(false)]
        public string ImageType { get; set; }
        [ScaffoldColumn(false)]
        public int ImageTaille { get; set; }
        [ScaffoldColumn(false)]
        public byte[] ImageData { get; set; }
        [NotMapped]
        public HttpPostedFileBase Fichier { get; set; }
    }
}