using System.Collections.Generic;

namespace InventoryApp.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public Department Department { get; set; }
        public Position Position { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<Checkout> Checkouts { get; set; }
    }
}
