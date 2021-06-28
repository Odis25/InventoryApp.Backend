using AutoMapper;
using AutoMapper.QueryableExtensions;
using InventoryApp.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryApp.Application.Employees.Queries.GetEmployeesList
{
    public class GetEmployeesListQueryHandler : IRequestHandler<GetEmployeesListQuery, EmployeesListVm>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEmployeesListQueryHandler(IAppDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<EmployeesListVm> Handle(GetEmployeesListQuery request, CancellationToken cancellationToken)
        {
            var employees = await _dbContext.Employees
                .Where(employee => employee.IsActive)
                .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new EmployeesListVm { Employees = employees };
        }
    }
}
