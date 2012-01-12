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
    public class SpecificationController : Controller
    {
        private ProductContext db = new ProductContext();

        //
        // GET: /Specification/

        public ViewResult Index()
        {
            return View(db.Specification.ToList());
        }

        //
        // GET: /Specification/Details/5

        public ViewResult Details(int id)
        {
            Specification specification = db.Specification.Find(id);
            return View(specification);
        }

        //
        // GET: /Specification/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Specification/Create

        [HttpPost]
        public ActionResult Create(Specification specification)
        {
            if (ModelState.IsValid)
            {
                db.Specification.Add(specification);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(specification);
        }
        
        //
        // GET: /Specification/Edit/5
 
        public ActionResult Edit(int id)
        {
            Specification specification = db.Specification.Find(id);
            return View(specification);
        }

        //
        // POST: /Specification/Edit/5

        [HttpPost]
        public ActionResult Edit(Specification specification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(specification);
        }

        //
        // GET: /Specification/Delete/5
 
        public ActionResult Delete(int id)
        {
            Specification specification = db.Specification.Find(id);
            return View(specification);
        }

        //
        // POST: /Specification/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Specification specification = db.Specification.Find(id);
            db.Specification.Remove(specification);
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