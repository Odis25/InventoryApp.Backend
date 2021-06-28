using System.Collections.Generic;

namespace InventoryApp.Domain
{
    public class Employee
    {
        public Employee()
        {
            Checkouts = new List<Checkout>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public bool IsActive { get; set; }
        public virtual Department Department { get; set; }
        public virtual Position Position { get; set; }
        public virtual IEnumerable<Checkout> Checkouts { get; }
    }
}
