﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Checklists.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ChecklistItem> CheckedItems {get; set;}
        public int Credits { get; set; }
    }
}