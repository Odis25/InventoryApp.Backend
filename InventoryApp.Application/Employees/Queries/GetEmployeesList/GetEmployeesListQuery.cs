using MediatR;

namespace InventoryApp.Application.Employees.Queries.GetEmployeesList
{
    public class GetEmployeesListQuery 
        : IRequest<EmployeesListVm>
    { 
    }
}
