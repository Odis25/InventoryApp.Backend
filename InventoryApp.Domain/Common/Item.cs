using InventoryApp.Domain.Enums;
using System;
using System.Collections.Generic;

namespace InventoryApp.Domain.Common
{
    public abstract class Item
    {
        public Item()
        {
            Checkouts = new List<Checkout>();
        }

        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string EditedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public Status Status { get; set; }
        public virtual IEnumerable<Checkout> Checkouts { get; }
    }
}
