using InventoryApp.Application.Interfaces;
using InventoryApp.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryApp.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler 
        : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly IAppDbContext _dbContext;

        public CreateEmployeeCommandHandler(IAppDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                Name = request.Name,
                LastName = request.LastName,
                Patronymic = request.Patronymic,
                Position = await _dbContext.Positions.FindAsync(request.PositionId, cancellationToken),
                Department = await _dbContext.Departments.FindAsync(request.DepartmentId, cancellationToken),
                IsActive = true
            };

            await _dbContext.Employees.AddAsync(employee, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return employee.Id;
        }
    }
}
