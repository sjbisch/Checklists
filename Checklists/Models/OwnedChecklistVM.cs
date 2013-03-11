using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Checklists.Models
{
    public class OwnedChecklistVM
    {
        public IEnumerable<SelectListItem> Owners { get; set; }
        public IEnumerable<SelectListItem> Checklists { get; set; }

        public Owner Owner { get; set; }
        public Checklist Checklist { get; set; }
    }
}