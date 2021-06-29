using AutoMapper;
using AutoMapper.QueryableExtensions;
using InventoryApp.Application.Interfaces;
using InventoryApp.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryApp.Application.Cables.Queries.GetAvailableCablesList
{
    public class GetAvailableCablesListQueryHandler : IRequestHandler<GetAvailableCablesListQuery, CablesListVm>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAvailableCablesListQueryHandler(IAppDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<CablesListVm> Handle(GetAvailableCablesListQuery request, CancellationToken cancellationToken)
        {
            var devices = await _dbContext.Cables
                .Where(cable => cable.Status == Status.Available)
                .ProjectTo<CableDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new CablesListVm { Cables = devices };
        }
    }
}
