using System.Collections.Generic;

namespace InventoryApp.Application.Employees.Queries.GetDepartments
{
    public class DepartmentsListVm
    {
        public IEnumerable<DepartmentDto> Departments { get; set; }
    }
}