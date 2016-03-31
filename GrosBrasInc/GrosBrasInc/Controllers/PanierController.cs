using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrosBrasInc.Controllers
{
    public class PanierController : Controller
    {
        // GET: Panier
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConditionsGenerales()
        {
            return View();
        }

        public ActionResult InformationsLegales()
        {
            return View();
        }
    }
}