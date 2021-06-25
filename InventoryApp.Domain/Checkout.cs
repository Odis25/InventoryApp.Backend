using InventoryApp.Domain.Common;
using System;

namespace InventoryApp.Domain
{
    public class Checkout
    {
        public long Id { get; set; }
        public Item Item { get; set; }
        public Employee Employee { get; set; }
        public DateTime CheckedIn { get; set; }
        public DateTime? CheckedOut { get; set; }
    }
}
