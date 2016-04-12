using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GrosBrasInc.Models;
using System.IO;

namespace GrosBrasInc.Controllers
{
    public class ArticlesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Articles
        public ActionResult Index()
        {
            var articles = db.Articles.Include(a => a.Categorie);
            return View(articles.ToList());
        }

        // GET: Articles/Details/5
        [Authorize(Roles = "Administrateur,Modérateur")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Articles/Create
        [Authorize(Roles = "Administrateur,Modérateur")]
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(db.Categories, "CategorieID", "NomCategorie");
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArticleID,NomArticle,Description,Prix,CategorieID,Fichier")] Article article)
        {
            if (ModelState.IsValid)
            {
                article.ImageNom = Path.GetFileName(article.Fichier.FileName);
                article.ImageTaille = article.Fichier.ContentLength;
                article.ImageType = article.Fichier.ContentType;
                article.ImageData = new byte[article.ImageTaille];
                article.Fichier.InputStream.Read(article.ImageData, 0, article.ImageTaille);

                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(db.Categories, "CategorieID", "NomCategorie", article.ArticleID);
            return View(article);
        }

        // GET: Articles/Edit/5
        [Authorize(Roles = "Administrateur,Modérateur")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategorieID = new SelectList(db.Categories, "CategorieID", "NomCategorie", article.CategorieID);
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArticleID,NomArticle,Description,Prix,CategorieID,Fichier,Recommandation")] Article article)
        {
            if (ModelState.IsValid)
            {
                article.ImageNom = Path.GetFileName(article.Fichier.FileName);
                article.ImageTaille = article.Fichier.ContentLength;
                article.ImageType = article.Fichier.ContentType;
                article.ImageData = new byte[article.ImageTaille];
                article.Fichier.InputStream.Read(article.ImageData, 0, article.ImageTaille);

                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategorieID = new SelectList(db.Categories, "CategorieID", "NomCategorie", article.CategorieID);
            return View(article);
        }

        // GET: Articles/Delete/5
        [Authorize(Roles = "Administrateur,Modérateur")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
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
