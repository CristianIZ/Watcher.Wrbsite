using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Watcher.Wrbsite.Infrastructure;

namespace Watcher.Wrbsite.Controllers
{
    public class HomeController : Controller
    {
        private INotificationAction _notificationAction;
        public HomeController(INotificationAction notificationAction)
        {
            this._notificationAction = notificationAction;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            PoolWatcher pw = new PoolWatcher();
            pw.Notify(ViewBag.Message);

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Structure map instance Home/Contact().";
            PoolWatcher pw = new PoolWatcher();
            pw.Action = this._notificationAction;
            pw.Notify(ViewBag.Message);

            return View();
        }
    }
}