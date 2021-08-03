using AutoMapper;
using AutoMapper.QueryableExtensions;
using InventoryApp.Application.Interfaces;
using InventoryApp.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryApp.Application.Cables.Queries.GetCablesList
{
    public class GetCablesListQueryHandler : IRequestHandler<GetCablesListQuery, CablesListVm>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCablesListQueryHandler(IAppDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<CablesListVm> Handle(GetCablesListQuery request, CancellationToken cancellationToken)
        {
            var cables = await _dbContext.Cables
                .Where(c => c.Status != Status.Deleted)
                .ProjectTo<CableDto>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return new CablesListVm { Cables = cables };
        }
    }
}
