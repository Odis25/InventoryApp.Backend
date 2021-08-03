using AutoMapper;
using InventoryApp.Application.Common.Exceptions;
using InventoryApp.Application.Interfaces;
using InventoryApp.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryApp.Application.Cables.Queries.GetCableDetails
{
    public class GetCableDetailsQueryHandler : IRequestHandler<GetCableDetailsQuery, CableDetailsVm>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCableDetailsQueryHandler(IAppDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<CableDetailsVm> Handle(GetCableDetailsQuery request, CancellationToken cancellationToken)
        {
            var cable = await _dbContext.Cables
                .FirstOrDefaultAsync(cable => cable.Id == request.Id, 
                cancellationToken);

            if (cable == null)
            {
                throw new NotFoundException(nameof(Cable), request.Id);
            }

            return _mapper.Map<CableDetailsVm>(cable);
        }
    }
}
