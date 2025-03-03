using AcunMedya.Restaurantly.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaRestaurantly.Controllers
{
    [Authorize]
    public class NotificationController : Controller
    {
        RestauranlyContext Db = new RestauranlyContext();

        public ActionResult Index()
        {
            var value = Db.Notifications.ToList();
            return View(value);
        }
        public ActionResult NotificationList()
        {
            var value = Db.Notifications.ToList();
            return View(value);
        }
        public ActionResult Okundu(int id)
        {
            var value = Db.Notifications.Find(id);
           value.IsRead = "true";
            Db.SaveChanges();
            return RedirectToAction("NotificationList");
        }
    }
}