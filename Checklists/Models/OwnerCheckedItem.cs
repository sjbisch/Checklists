using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Checklists.Models
{
    public class OwnerCheckedItem
    {
        public int OwnerId { get; set; }
        public int ChecklistItemId { get; set; }
    }
}