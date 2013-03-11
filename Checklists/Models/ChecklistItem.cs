using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Checklists.Models
{
    public class ChecklistItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ChecklistId { get; set; }
        public Checklist Checklist { get; set; }
        public virtual ICollection<Owner> OwnersThatHaveChecked { get; set; }
        [NotMapped]
        public bool isChecked { get; set; }
    }
}