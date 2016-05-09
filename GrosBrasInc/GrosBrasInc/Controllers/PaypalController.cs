using GrosBrasInc.Models;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrosBrasInc.Controllers
{
    [Authorize]
    public class PaypalController : Controller
    {
        // GET: Paypal
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            if (cart == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var ls = cart.GetCartItems();
            var _total = cart.GetTotal();
            var config = ConfigManager.Instance.GetProperties();
            var accessToken = new OAuthTokenCredential(config).GetAccessToken();
            var apiContext = new APIContext(accessToken);

            try
            {
                var payment = Payment.Create(apiContext, new Payment
                {
                    intent = "sale",
                    payer = new Payer
                    {
                        payment_method = "paypal"
                    },
                    transactions = new List<Transaction>
                {
                    new Transaction
                    {
                        description = "Transaction description.",
                        invoice_number = "001",
                        amount = new Amount
                        {
                            currency = "CAD",
                            total = (_total + Convert.ToDouble(cart.GetShippingCost().ListFraisdePort.Where(x => x.CodeService == this.HttpContext.Session[ShoppingCart.SelectedId].ToString()).First().Montant)).ToString("0.00"),
                            details = new Details
                            {
                                tax = "0",
                                shipping = (cart.GetShippingCost().ListFraisdePort.Where(x => x.CodeService == this.HttpContext.Session[ShoppingCart.SelectedId].ToString()).First().Montant).ToString(),
                                subtotal = _total.ToString("0.00")
                            }
                        },
                        item_list = new ItemList
                        {
                            items = ls.Select(x => new Item {
                                sku = x.Article.ArticleID.ToString(),
                                price = x.Article.Prix.ToString("0.00"),
                                name = x.Article.NomArticle.ToString(),
                                quantity = x.Count.ToString(),
                                description = x.Article.Description,
                                currency = "CAD"//,
                                //tax = (x.Article.Prix * 0.15).ToString("0.00")
                            }).ToList()
                        }
                    }
                },
                    redirect_urls = new RedirectUrls
                    {
                        return_url = "http://localhost:38716/Panier",
                        cancel_url = "http://localhost:38716/Panier"
                    }
                });

                return this.Redirect(payment.GetApprovalUrl());

            }
            catch (PayPal.HttpException ex)
            {
                if (ex.InnerException is PayPal.HttpException)
                {
                    this.HttpContext.Response.Write(ex.Response);
                }
                else
                {
                    this.HttpContext.Response.Write(ex.Message);
                }
            }

            return null;
        }
    }
}
