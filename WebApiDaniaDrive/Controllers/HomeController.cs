using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiDaniaDrive.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult SimpleGet()
        {
            ViewBag.Title = "Get Page";

            return View();
        }

        public ActionResult SimpleJsonGet()
        {
            ViewBag.Title = "Get Page";

            return View();
        }
    }
}
