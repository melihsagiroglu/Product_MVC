using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Deneme5.Models;
using Deneme5.DAL;

namespace Deneme5.Controllers
{ 
    public class ProductController : Controller
    {
        private ProductContext db = new ProductContext();

        //
        // GET: /Product/

        public ViewResult Index(string sortOrder, string searchString)
        {
            //var product = db.Product.Include(p => p.Category);
            //return View(product.ToList());
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "ProductName desc" : "";
            ViewBag.DateSortParm = sortOrder == "RecordTime" ? "RecordTime desc" : "RecordTime";
            var products = from s in db.Product
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.ProductName.ToUpper().Contains(searchString.ToUpper()));
            }


            switch (sortOrder)
            {
                case "ProductName desc":
                    products = products.OrderByDescending(s => s.ProductName);
                    break;
                case "RecordTime":
                    products = products.OrderBy(s => s.RecordTime);
                    break;
                case "RecordTime desc": 
                    products = products.OrderByDescending(s => s.RecordTime); 
                    break;
                default:
                    products = products.OrderBy(s => s.ProductName);
                    break;
            }
            return View(products.ToList());

        }

        //
        // GET: /Product/Details/5

        public ViewResult Details(int id)
        {
            Product product = db.Product.Find(id);
            return View(product);
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Category, "CategoryID", "CategoryName");
            return View();
        } 

        //
        // POST: /Product/Create

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.CategoryID = new SelectList(db.Category, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }
        
        //
        // GET: /Product/Edit/5
 
        public ActionResult Edit(int id)
        {
            Product product = db.Product.Find(id);
            ViewBag.CategoryID = new SelectList(db.Category, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Category, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        //
        // GET: /Product/Delete/5
 
        public ActionResult Delete(int id)
        {
            Product product = db.Product.Find(id);
            return View(product);
        }

        //
        // POST: /Product/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}