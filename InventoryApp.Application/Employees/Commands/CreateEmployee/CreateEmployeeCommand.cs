using MediatR;

namespace InventoryApp.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int DepartmentId { get; set; }
    }
}
