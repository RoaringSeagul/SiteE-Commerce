using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GrosBrasInc.Models;

namespace GrosBrasInc.Controllers
{
    [Authorize]
    public class OrderDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OrderDetails
        public ActionResult Index()
        {
            var ordersDetails = db.OrdersDetails.Where(o => o.Client.UserName == User.Identity.Name).Include(o => o.Article).Include(o => o.Client).Include(o => o.Order);
            return View(ordersDetails.ToList());
        }

        // GET: OrderDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetails orderDetails = db.OrdersDetails.Find(id);
            if (orderDetails == null)
            {
                return HttpNotFound();
            }
            return View(orderDetails);
        }

        // GET: OrderDetails/Create
        public ActionResult Create()
        {
            ViewBag.ArticleId = new SelectList(db.Articles, "ArticleID", "NomArticle");
            ViewBag.AspNetUserID = new SelectList(db.Users, "Id", "Email");
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "Username");
            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderDetailId,OrderId,ArticleId,Quantity,UnitPrice,AspNetUserID,State")] OrderDetails orderDetails)
        {
            if (ModelState.IsValid)
            {
                db.OrdersDetails.Add(orderDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArticleId = new SelectList(db.Articles, "ArticleID", "NomArticle", orderDetails.ArticleId);
            ViewBag.AspNetUserID = new SelectList(db.Users, "Id", "Email", orderDetails.AspNetUserID);
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "Username", orderDetails.OrderId);
            return View(orderDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
