using GrosBrasInc.Models;
using GrosBrasInc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrosBrasInc.Controllers
{
    public class PanierController : Controller
    {
        private ApplicationDbContext db;

        public PanierController()
        {
            this.db = new ApplicationDbContext();
        }

        public PanierController(ApplicationDbContext data)
        {
            this.db = data;
        }

        // GET: ShoppingCart
        public ActionResult Index(string Value = "")
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            decimal total = 0;

            List<SelectListItem> lst = new List<SelectListItem>();
            foreach (var item in cart.GetShippingCost().ListFraisdePort)
            {
                lst.Add(new SelectListItem() { Value = item.CodeService, Text = item.NomService + ": " + item.Montant.ToString("C") });
                if (item.CodeService == Value)
                    total = item.Montant;
            }
            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal(total),
                Items = lst,
                SelectedItemID = lst.First().Value
            };

            // FAIRE SELECT LIST

            // Return the view
            return View(viewModel);
        }

        //
        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            var addedAlbum = db.Articles
            .Single(p => p.ArticleID == id);
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.AddToCart(addedAlbum);
            return RedirectToAction("Index");
        }
        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);
            // Get the name of the album to display confirmation
            string albumName = db.Paniers
            .Single(p => p.PanierID == id).Article.NomArticle;
            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);
            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(albumName) + " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }

        //
        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult _CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            ViewData["CartCount"] = cart.GetCount();
            return PartialView("_CartSummary");
        }
    }
}