using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Checklists.Models
{
    public class ChecklistDBContext : DbContext
    {
        public ChecklistDBContext()
            : base("DefaultConnection")
        {

        }
        
        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }


    public class ChecklistInitializer : DropCreateDatabaseIfModelChanges<ChecklistDBContext>
    {
        protected override void Seed(ChecklistDBContext context)
        {
            List<ChecklistItem> items = new List<ChecklistItem>
            {
                new ChecklistItem { Description = "Do Something" },
                new ChecklistItem { Description = "Read a book" },
                new ChecklistItem { Description = "Build a diarama" },
                new ChecklistItem { Description = "Take a test" },
                new ChecklistItem { Description = "Think about stuff" },
            };

            Checklist checklist = new Checklist
            {
                Title = "History Degree Requirements",
                Items = new List<ChecklistItem>()
            };

            items.ForEach(i => checklist.Items.Add(i));
            context.Checklists.Add(checklist);
            context.SaveChanges();

            List<Owner> owners = new List<Owner>
            {
                new Owner { Name = "Becky", CheckedItems= new List<ChecklistItem>() },
                new Owner { Name = "Buck" },
                new Owner { Name = "Brad" },
                new Owner { Name = "Bingo" },
                new Owner { Name = "Bart" }
            };

            owners[0].CheckedItems.Add(items[0]);
            owners[0].CheckedItems.Add(items[1]);
            owners[0].CheckedItems.Add(items[2]);

            owners.ForEach(o => context.Owners.Add(o));
            context.SaveChanges();
           
        }
    }
}