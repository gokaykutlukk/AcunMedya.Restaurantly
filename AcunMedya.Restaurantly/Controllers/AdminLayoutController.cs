using AcunMedya.Restaurantly.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedya.Restaurantly.Controllers
{
    
    public class AdminLayoutController : Controller
    {
        RestauranlyContext Db = new RestauranlyContext();
        // GET: AdminLayout
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PartialHead()
        {
            return PartialView();
        }
        public ActionResult PartialNavbar()
        {
            ViewBag.notificationIsreadByfalseCount = Db.Notifications.Where(x => x.IsRead == "False").Count();
            var values = Db.Notifications.Where(x => x.IsRead == "False").ToList();
            return PartialView(values);
        }
        public ActionResult PartialSidebar()
        {
            return PartialView();
        }
        public ActionResult PartialFooter()
        {
            return PartialView();
        }
        public ActionResult PartialScript()
        {
            return PartialView();
        }
        public ActionResult NotificationsStatusChangesToTrue(int id)
        {
            var values = Db.Notifications.Find(id);
            values.IsRead = "True";
            Db.SaveChanges();
            return RedirectToAction("ProductList", "Product");
        }
      


    }

    
    
}