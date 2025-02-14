using AcunMedya.Restaurantly.Context;
using AcunMedya.Restaurantly.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedya.Restaurantly.Controllers
{
    public class ProductController : Controller
    {
        RestauranlyContext Db = new RestauranlyContext();
        // GET: Product
        [Authorize]
        public ActionResult Index()
        {
            var value = Db.Products.ToList();
            return View(value);
        }
        public ActionResult ProductList()
        {
            var value = Db.Products.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult ProductCreate()
        {
            List<SelectListItem> values = (from x in Db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text=x.Categoryname,
                                               Value=x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public ActionResult ProductCreate(Product model)
        {
            Db.Products.Add(model);
            Db.SaveChanges();
            return RedirectToAction("Productlist");
        }
        [HttpGet]
        public ActionResult ProductEdit(int id)
        {
            var value = Db.Products.Find(id);
            List<SelectListItem> values = (from x in Db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Categoryname,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View(value);
        }
        [HttpPost]
        public ActionResult ProductEdit(Product model)
        {
            var values = Db.Products.Find(model.ProductId);
            values.Name= model.Name;
            values.Description= model.Description;
            values.price= model.price;
            values.imageUrl= model.imageUrl;
            values.CategoryId = model.CategoryId;
            Db.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public ActionResult ProductDelete(int id)
        {
            var value = Db.Products.Find(id);
            Db.Products.Remove(value);
            Db.SaveChanges();
            return RedirectToAction("ProductList");
        }

    }
}
