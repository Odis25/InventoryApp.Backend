using InventoryApp.Domain.Common;
using System;

namespace InventoryApp.Domain
{
    public class Checkout
    {
        public long Id { get; set; }
        public virtual Item Item { get; set; }
        public virtual Employee Employee { get; set; }
        public DateTime CheckedIn { get; set; }
        public DateTime? CheckedOut { get; set; }
    }
}
