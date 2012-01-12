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
    public class CategoryController : Controller
    {
        private ProductContext db = new ProductContext();

        //
        // GET: /Category/

        public ViewResult Index()
        {
            var category = db.Category.Include(c => c.ParentCategory);
            return View(category.ToList());
        }

        //
        // GET: /Category/Details/5

        public ViewResult Details(int id)
        {
            Category category = db.Category.Find(id);
            return View(category);
        }

        //
        // GET: /Category/Create

        public ActionResult Create()
        {
            ViewBag.ParentID = new SelectList(db.Category, "CategoryID", "CategoryName");
            return View();
        } 

        //
        // POST: /Category/Create

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Category.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.ParentID = new SelectList(db.Category, "CategoryID", "CategoryName", category.ParentID);
            return View(category);
        }
        
        //
        // GET: /Category/Edit/5
 
        public ActionResult Edit(int id)
        {
            Category category = db.Category.Find(id);
            ViewBag.ParentID = new SelectList(db.Category, "CategoryID", "CategoryName", category.ParentID);
            return View(category);
        }

        //
        // POST: /Category/Edit/5

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentID = new SelectList(db.Category, "CategoryID", "CategoryName", category.ParentID);
            return View(category);
        }

        //
        // GET: /Category/Delete/5
 
        public ActionResult Delete(int id)
        {
            Category category = db.Category.Find(id);
            return View(category);
        }

        //
        // POST: /Category/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Category category = db.Category.Find(id);
            db.Category.Remove(category);
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