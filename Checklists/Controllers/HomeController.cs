using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Checklists.Models;

namespace Checklists.Controllers
{
    public class HomeController : Controller
    {
        private ChecklistDBContext db = new ChecklistDBContext();

        public ActionResult Index()
        {
            OwnedChecklistVM model = new OwnedChecklistVM();

            model.Owners = db.Owners.AsEnumerable().Select(o =>
                                new SelectListItem
                                {
                                    Text = o.Name,
                                    Value = o.Id.ToString()
                                });

            model.Checklists = db.Checklists.AsEnumerable().Select(c =>
                                new SelectListItem
                                {
                                    Text = c.Title,
                                    Value = c.Id.ToString()
                                });

            return View(model);
        }

        public PartialViewResult GetOwnedChecklist(int ownerId, int checklistId)
        {
            OwnedChecklistVM model = new OwnedChecklistVM();

            model.Owner = db.Owners.Find(ownerId);

            model.Checklist = db.Checklists.Find(checklistId);

            foreach (ChecklistItem item in model.Checklist.Items)
            {
                item.isChecked = model.Owner.CheckedItems.Contains(item);
            }

            return PartialView("_OwnedChecklist", model);
        }





        public ActionResult UpdateOwnedChecklist(OwnedChecklistVM model)
        {
            Owner updatedOwner = db.Owners.Find(model.Owner.Id);

            List<ChecklistItem> dbItems = db.Checklists.Find(model.Checklist.Id).Items.ToList();

            foreach (ChecklistItem item in model.Checklist.Items)
            {
                if (item.isChecked)
                {
                    updatedOwner.CheckedItems.Add(dbItems.Find(i => i.Id == item.Id));
                }
                else
                {
                    updatedOwner.CheckedItems.Remove(dbItems.Find(i => i.Id == item.Id));
                }
            }

            db.SaveChanges();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
