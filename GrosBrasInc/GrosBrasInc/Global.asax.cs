﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using GrosBrasInc.Models;

namespace GrosBrasInc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            db.Database.Initialize(true);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
