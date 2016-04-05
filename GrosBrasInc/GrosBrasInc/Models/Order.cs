using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GrosBrasInc.Models
{
    public partial class Order
    {
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }
        [ScaffoldColumn(false)]
        [Display(ResourceType = typeof(GrosBrasInc.Ressource.Ressource), Name = "Order_Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [DisplayName("First Name")]
        [StringLength(160)]
        [Display(ResourceType = typeof(GrosBrasInc.Ressource.Ressource), Name = "Order_FirstName")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [DisplayName("Last Name")]
        [StringLength(160)]
        [Display(ResourceType = typeof(GrosBrasInc.Ressource.Ressource), Name = "Order_LastName")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(70)]
        [Display(ResourceType = typeof(GrosBrasInc.Ressource.Ressource), Name = "Order_Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City is required")]
        [StringLength(40)]
        [Display(ResourceType = typeof(GrosBrasInc.Ressource.Ressource), Name = "Order_City")]
        public string City { get; set; }
        [Required(ErrorMessage = "State is required")]
        [StringLength(40)]
        [Display(ResourceType = typeof(GrosBrasInc.Ressource.Ressource), Name = "Order_State")]
        public string State { get; set; }
        [Required(ErrorMessage = "Postal code is required")]
        [DisplayName("Postal Code")]
        [StringLength(10)]
        [Display(ResourceType = typeof(GrosBrasInc.Ressource.Ressource), Name = "Order_PostalCode")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Country is required")]
        [StringLength(40)]
        [Display(ResourceType = typeof(GrosBrasInc.Ressource.Ressource), Name = "Order_Country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [StringLength(24)]
        [Display(ResourceType = typeof(GrosBrasInc.Ressource.Ressource), Name = "Order_Phone")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Email Address is required")]
        [DisplayName("Email Address")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        [Display(ResourceType = typeof(GrosBrasInc.Ressource.Ressource), Name = "Order_Email")]
        public string Email { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        [ScaffoldColumn(false)]
        [Display(ResourceType = typeof(GrosBrasInc.Ressource.Ressource), Name = "Order_Total")]
        public float Total { get; set; }
        [Display(ResourceType = typeof(GrosBrasInc.Ressource.Ressource), Name = "Order_OrderDate")]
        public System.DateTime OrderDate { get; set; }
        [ScaffoldColumn(false)]
        public List<OrderDetails> OrderDetails { get; set; }
    }
}