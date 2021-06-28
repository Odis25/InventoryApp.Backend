using AutoMapper;
using InventoryApp.Application.Common.Exceptions;
using InventoryApp.Application.Interfaces;
using InventoryApp.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryApp.Application.Employees.Queries.GetEmployeeDetails
{
    public class GetEmployeeDetailsQueryHandler : IRequestHandler<GetEmployeeDetailsQuery, EmployeeDetailsVm>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEmployeeDetailsQueryHandler(IAppDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<EmployeeDetailsVm> Handle(GetEmployeeDetailsQuery request, CancellationToken cancellationToken)
        {
            var employee = await _dbContext.Employees
                .FirstOrDefaultAsync(employee => 
                employee.Id == request.Id, cancellationToken);

            if (employee == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }

            return _mapper.Map<EmployeeDetailsVm>(employee);
        }
    }
}
