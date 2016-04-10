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
    public class MessagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Messages
        public ActionResult Index(int? id)
        {
            IQueryable<Message> messages = db.Messages.Where(m => m.SujetID == id);

            //var messages = db.Messages.Include(m => m.Author).Include(m => m.ParentSujet);
            return View(messages.ToList());
        }

        // GET: Messages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: Messages/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "Email");
            //ViewBag.SujetID = new SelectList(db.Sujets, "SujetID", "SubjectTitle");
            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MessageID,ApplicationUserID,MessageBody,SujetID")] Message message, int? id)
        {
            //ViewBag.SujetID = new SelectList(db.Sujets, "SujetID", "SubjectTitle", message.SujetID);
            if (ModelState.IsValid)
            {
                ApplicationUser CurrentUser = db.Users.Where(m => m.UserName == User.Identity.Name).FirstOrDefault();
                message.Author = CurrentUser;
                message.ApplicationUserID = message.Author.Id;
                message.SujetID = id.Value;
                db.Messages.Add(message);
                db.SaveChanges(db);
                return RedirectToAction("Index", new { id = id.Value });
            }
            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "Email", message.ApplicationUserID);

            return View(message);
        }

        // GET: Messages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ApplicationUserID = new SelectList(db.ApplicationUsers, "Id", "Email", message.ApplicationUserID);
            ViewBag.SujetID = new SelectList(db.Sujets, "SujetID", "SubjectTitle", message.SujetID);
            return View(message);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MessageID,ApplicationUserID,MessageBody,SujetID")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.ApplicationUserID = new SelectList(db.ApplicationUsers, "Id", "Email", message.ApplicationUserID);
            ViewBag.SujetID = new SelectList(db.Sujets, "SujetID", "SubjectTitle", message.SujetID);
            return View(message);
        }

        // GET: Messages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
            db.SaveChanges();
            return RedirectToAction("Index");
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
