using GrosBrasInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrosBrasInc.Controllers
{
    public class HomeController : Controller
    {
<<<<<<< HEAD
        ApplicationDbContext db = new ApplicationDbContext();
        [ChildActionOnly]
        public ActionResult _ListeRecommendation()
        {
            List<Article> articles = db.Articles.Where(c => c.Recommandation).ToList();
            return View(articles);
        }

=======
        public ActionResult TermofUse()
        {
            return View();
        }
>>>>>>> 75b631b3364766816206c0c5e5d174a1acf063e5
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}