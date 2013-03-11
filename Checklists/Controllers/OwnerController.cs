using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Checklists.Models;

namespace Checklists.Controllers
{
    public class OwnerController : Controller
    {
        private ChecklistDBContext db = new ChecklistDBContext();

        //
        // GET: /Owner/

        public ActionResult Index()
        {
            return View(db.Owners.ToList());
        }

        //
        // GET: /Owner/Details/5

        public ActionResult Details(int id = 0)
        {
            Owner owner = db.Owners.Find(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        //
        // GET: /Owner/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Owner/Create

        [HttpPost]
        public ActionResult Create(string ownerNames)
        {
            string[] names = ownerNames.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string name in names)
            {
                db.Owners.Add(new Owner
                {
                    Name = name
                });
            }
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //
        // GET: /Owner/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Owner owner = db.Owners.Find(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        //
        // POST: /Owner/Edit/5

        [HttpPost]
        public ActionResult Edit(Owner owner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(owner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(owner);
        }

        //
        // GET: /Owner/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Owner owner = db.Owners.Find(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        //
        // POST: /Owner/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Owner owner = db.Owners.Find(id);
            db.Owners.Remove(owner);
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