using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Safari.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        [Route("", Name = "HomeControllerRouteIndex")]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        [Route("acerca-de-nosotros", Name = "HomeControllerRouteAbout")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        [Route("contacto", Name = "HomeControllerRouteContact")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}