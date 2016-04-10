using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrosBrasInc.Models
{
    public partial class ShoppingCart
    {
        ApplicationDbContext db = new ApplicationDbContext();
        string ShoppingCartID { get; set; }
        private string cartID;

        public string CartID
        {
            get
            {
                if (HttpContextManager.Current.Session[CartSessionKey] == null)
                {
                    if (HttpContextManager.Current.User != null && !string.IsNullOrWhiteSpace(HttpContextManager.Current.User.Identity.Name))
                    {
                        HttpContextManager.Current.Session[CartSessionKey] = HttpContextManager.Current.User.Identity.Name;
                    }
                    else
                    {
                        // Generate a new random GUID using System.Guid class
                        Guid tempCartId = Guid.NewGuid();
                        // Send tempCartId back to client as a cookie
                        HttpContextManager.Current.Session[CartSessionKey] = tempCartId.ToString();
                    }
                }
                return HttpContextManager.Current.Session[CartSessionKey].ToString();
            }

            set
            {
                cartID = value;
            }
        }

        public const string CartSessionKey = "CartID";


        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartID = cart.CartID;
            return cart;
        }

        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(Article article)
        {
            // Get the matching cart and album instances
            var cartItem = db.Paniers.SingleOrDefault(
            c => c.KeyPanier == ShoppingCartID
            && c.ArticleID == article.ArticleID);
            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new Panier
                {
                    ArticleID = article.ArticleID,
                    KeyPanier = ShoppingCartID,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                db.Paniers.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart,
                // then add one to the quantity
                cartItem.Count++;
            }
            // Save changes
            db.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = db.Paniers.Single(
            cart => cart.KeyPanier == ShoppingCartID
            && cart.PanierID == id);
            int itemCount = 0;
            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    db.Paniers.Remove(cartItem);
                }
                // Save changes
                db.SaveChanges();
            }
            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = db.Paniers.Where(
            cart => cart.KeyPanier == ShoppingCartID);
            foreach (var cartItem in cartItems)
            {
                db.Paniers.Remove(cartItem);
            }
            // Save changes
            db.SaveChanges();
        }

        public List<Panier> GetCartItems()
        {
            return db.Paniers.Where(p => p.KeyPanier == ShoppingCartID).ToList();
        }

        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in db.Paniers
                          where cartItems.KeyPanier == ShoppingCartID
                          select (int?)cartItems.Count).Sum();
            // Return 0 if all entries are null
            return count ?? 0;
        }

        public float GetTotal()
        {
            // Multiply album price by count of that album to get
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            float? total = (from cartItems in db.Paniers
                              where cartItems.KeyPanier == ShoppingCartID
                              select (int?)cartItems.Count *
                              cartItems.Article.Prix).Sum();
            return total ?? 0f;
        }

        public int CreateOrder(Order order)
        {
            float orderTotal = 0;
            var cartItems = GetCartItems();
            var user = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            // Iterate over the items in the cart,
            // adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetails
                {
                    ArticleId = item.ArticleID,
                    OrderId = order.OrderId,
                    UnitPrice = item.Article.Prix,
                    Quantity = item.Count,
                    Client = db.Users.Where(o => o.UserName == HttpContext.Current.User.Identity.Name).FirstOrDefault()
                };
                // Set the order total of the shopping cart
                orderTotal += (item.Count * item.Article.Prix);
                db.OrdersDetails.Add(orderDetail);
            }
            // Set the order's total to the orderTotal count
            order.Total = orderTotal;
            // Save the order
            db.SaveChanges();
            // Empty the shopping cart
            EmptyCart();
            // Return the OrderId as the confirmation number
            return order.OrderId;
        }

        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            var shoppingCart = db.Paniers.Where(
            c => c.KeyPanier == ShoppingCartID);
            foreach (Panier item in shoppingCart)
            {
                item.KeyPanier = userName;
            }
            db.SaveChanges();
        }
    }
}