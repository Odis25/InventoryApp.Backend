using InventoryApp.Domain;
using System.Collections.Generic;
using System.Linq;

namespace InventoryApp.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Departments.Any())
            {
                var departments = new List<Department>
                {
                    new Department { Name = "ДИСО" },
                    new Department { Name = "ДАСУ" },
                    new Department { Name = "ДАСО" },
                    new Department { Name = "ДПТК" },
                    new Department { Name = "ДТОМ" },
                };

                context.Departments.AddRange(departments);
                context.SaveChanges();
            }

            if (!context.DeviceTypes.Any())
            {
                var deviceTypes = new List<DeviceType>
                {
                    new DeviceType { Name = "Комплектующие для ноутбуков и ПК"},
                    new DeviceType { Name = "Ноутбуки и ПК"},
                    new DeviceType { Name = "Периферийное оборудование"},
                    new DeviceType { Name = "Рабочий инструмент"},
                    new DeviceType { Name = "Сетевое оборудование"},
                    new DeviceType { Name = "Средства индивидуальной защиты"},
                };

                context.DeviceTypes.AddRange(deviceTypes);

                context.SaveChanges();
            }
        }
    }
}
