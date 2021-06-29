using AutoMapper;
using InventoryApp.Application.Interfaces;
using MediatR;
using System;
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

        public Task<CableDetailsVm> Handle(GetCableDetailsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
