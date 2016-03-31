using GrosBrasInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrosBrasInc.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Panier> CartItems { get; set; }
        public float CartTotal { get; set; }
    }
}