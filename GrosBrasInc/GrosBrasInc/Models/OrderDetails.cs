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
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ArticleId { get; set; }
        public int Quantity { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public float UnitPrice { get; set; }
        public virtual Article Article { get; set; }
        public virtual Order Order { get; set; }
    }
}