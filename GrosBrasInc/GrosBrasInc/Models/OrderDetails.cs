using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GrosBrasInc.Models
{
    public class OrderDetails
    {
        [Key]
        [ScaffoldColumn(false)]
        public int OrderDetailId { get; set; }
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }
        [ScaffoldColumn(false)]
        public int ArticleId { get; set; }
        [Display(ResourceType = typeof(GrosBrasInc.Ressource), Name = "OrderDetails_Quantity")]
        public int Quantity { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        [Display(ResourceType = typeof(GrosBrasInc.Ressource), Name = "OrderDetails_UnitPrice")]
        public float UnitPrice { get; set; }
        [Display(ResourceType = typeof(GrosBrasInc.Ressource), Name = "OrderDetails_Article")]
        public virtual Article Article { get; set; }
        public virtual Order Order { get; set; }
    }
}