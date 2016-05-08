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
        public ShoppingCartViewModel()
        {
            List<SelectListItem> lstSelect = new List<SelectListItem>();
            foreach (var i in ShippingCost.ListFraisdePort)
            {
                lstSelect.Add(new SelectListItem() { Text = i.NomService + ": " + i.Montant });
            }

            Items = new SelectList(lstSelect);
            CurrentItem = ShippingCost.ListFraisdePort.First().NomService + ": " + ShippingCost.ListFraisdePort.First().Montant;
        }

        public SelectList Items { get; set; }
        public string CurrentItem { get; set; }

        public List<Panier> CartItems { get; set; }
        public Box ShippingCost { get; set; }
        public double CartTotal { get; set; }
    }
}