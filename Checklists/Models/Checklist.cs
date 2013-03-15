using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Checklists.Models
{
    public class Checklist
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<ChecklistItem> Items {get; set;}
        public int RequiredCredits { get; set; }
    }
}