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
    public class ProductSpecController : Controller
    {
        private ProductContext db = new ProductContext();

        //
        // GET: /ProductSpec/

        public ViewResult Index()
        {
            var productspecs = db.ProductSpecs.Include(p => p.Product).Include(p => p.Specification);
            return View(productspecs.ToList());
        }

        //
        // GET: /ProductSpec/Details/5

        public ViewResult Details(int id)
        {
            ProductSpec productspec = db.ProductSpecs.Find(id);
            return View(productspec);
        }

        //
        // GET: /ProductSpec/Create

        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "ProductName");
            ViewBag.SpecificationID = new SelectList(db.Specification, "SpecificationID", "SpecName");
            return View();
        } 

        //
        // POST: /ProductSpec/Create

        [HttpPost]
        public ActionResult Create(ProductSpec productspec)
        {
            if (ModelState.IsValid)
            {
                db.ProductSpecs.Add(productspec);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "ProductName", productspec.ProductID);
            ViewBag.SpecificationID = new SelectList(db.Specification, "SpecificationID", "SpecName", productspec.SpecificationID);
            return View(productspec);
        }
        
        //
        // GET: /ProductSpec/Edit/5
 
        public ActionResult Edit(int id)
        {
            ProductSpec productspec = db.ProductSpecs.Find(id);
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "ProductName", productspec.ProductID);
            ViewBag.SpecificationID = new SelectList(db.Specification, "SpecificationID", "SpecName", productspec.SpecificationID);
            return View(productspec);
        }

        //
        // POST: /ProductSpec/Edit/5

        [HttpPost]
        public ActionResult Edit(ProductSpec productspec)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productspec).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "ProductName", productspec.ProductID);
            ViewBag.SpecificationID = new SelectList(db.Specification, "SpecificationID", "SpecName", productspec.SpecificationID);
            return View(productspec);
        }

        //
        // GET: /ProductSpec/Delete/5
 
        public ActionResult Delete(int id)
        {
            ProductSpec productspec = db.ProductSpecs.Find(id);
            return View(productspec);
        }

        //
        // POST: /ProductSpec/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            ProductSpec productspec = db.ProductSpecs.Find(id);
            db.ProductSpecs.Remove(productspec);
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