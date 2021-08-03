using AutoMapper;
using AutoMapper.QueryableExtensions;
using InventoryApp.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryApp.Application.Employees.Queries.GetDepartments
{
    public class GetDepartmentsQueryHandler : IRequestHandler<GetDepartmentsQuery, DepartmentsListVm>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDepartmentsQueryHandler(IAppDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<DepartmentsListVm> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var departments = await _dbContext.Departments
                .ProjectTo<DepartmentDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();

            return new DepartmentsListVm { Departments = departments };
        }
    }
}
