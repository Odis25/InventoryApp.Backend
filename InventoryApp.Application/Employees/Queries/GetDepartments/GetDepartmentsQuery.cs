using MediatR;

namespace InventoryApp.Application.Employees.Queries.GetDepartments
{
    public class GetDepartmentsQuery
        :IRequest<DepartmentsListVm>
    {       
    }
}
