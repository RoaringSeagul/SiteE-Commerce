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
    public class SujetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sujets
        public ActionResult Index()
        {
            return View(db.Sujets.ToList());
        }

        // GET: Sujets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sujet sujet = db.Sujets.Find(id);
            if (sujet == null)
            {
                return HttpNotFound();
            }
            return View(sujet);
        }

        // GET: Sujets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sujets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SujetID,SubjectTitle,SubjectBody")] Sujet sujet)
        {
            if (ModelState.IsValid)
            {
                db.Sujets.Add(sujet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sujet);
        }

        // GET: Sujets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sujet sujet = db.Sujets.Find(id);
            if (sujet == null)
            {
                return HttpNotFound();
            }
            return View(sujet);
        }

        // POST: Sujets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SujetID,SubjectTitle,SubjectBody")] Sujet sujet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sujet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sujet);
        }

        // GET: Sujets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sujet sujet = db.Sujets.Find(id);
            if (sujet == null)
            {
                return HttpNotFound();
            }
            return View(sujet);
        }

        // POST: Sujets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sujet sujet = db.Sujets.Find(id);
            db.Sujets.Remove(sujet);
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
