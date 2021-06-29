using InventoryApp.Application.Common.Exceptions;
using InventoryApp.Application.Interfaces;
using InventoryApp.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryApp.Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler 
        : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IAppDbContext _dbContext;

        public UpdateEmployeeCommandHandler(IAppDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _dbContext.Employees.FindAsync(new object[] { request.Id }, cancellationToken);

            if (employee == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }

            employee.Name = request.Name;
            employee.LastName = request.LastName;
            employee.Patronymic = request.Patronymic;
            employee.Department = await _dbContext.Departments.FindAsync(new object[] { request.DepartmentId }, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
