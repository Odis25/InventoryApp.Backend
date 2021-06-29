using MediatR;

namespace InventoryApp.Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand: IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int DepartmentId { get; set; }
    }
}
