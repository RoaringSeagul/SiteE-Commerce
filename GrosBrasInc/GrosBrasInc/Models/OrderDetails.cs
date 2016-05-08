using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrosBrasInc.Models
{
    public class OrderDetails
    {
        public enum OrderState { Payé, envoyé, commentaire };


        [Key]
        [ScaffoldColumn(false)]
        public int OrderDetailId { get; set; }
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }
        [ScaffoldColumn(false)]
        public int ArticleId { get; set; }
        [Display(ResourceType = typeof(GrosBrasInc.Ressource.Ressource), Name = "OrderDetails_Quantity")]
        public int Quantity { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        [Display(ResourceType = typeof(GrosBrasInc.Ressource.Ressource), Name = "OrderDetails_UnitPrice")]
        public double UnitPrice { get; set; }
        [Display(ResourceType = typeof(GrosBrasInc.Ressource.Ressource), Name = "OrderDetails_Article")]
        public virtual Article Article { get; set; }
        public virtual Order Order { get; set; }
        [ScaffoldColumn(false)]
        public string AspNetUserID { get; set; }
        [ForeignKey("AspNetUserID")]
        public virtual ApplicationUser Client { get; set; }
        public OrderState State { get; set; }
    }
}