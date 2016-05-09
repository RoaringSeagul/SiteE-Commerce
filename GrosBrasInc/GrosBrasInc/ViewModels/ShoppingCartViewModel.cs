using GrosBrasInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrosBrasInc.ViewModels
{

    public class ShoppingCartViewModel
    {
        public List<Panier> CartItems { get; set; }
        public double CartTotal { get; set; }
        public string SelectedItemID { get; set; }
        public IEnumerable<SelectListItem> Items { get; set; }
    }
}