using AcunMedya.Restaurantly.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedya.Restaurantly.Controllers
{
    public class CategoryController : Controller
    {
        RestauranlyContext Db=new RestauranlyContext();
        // GET: Category
        public ActionResult Index()
        {
            var value = Db.Categories.ToList();
            return View(value);
        }
    }
}