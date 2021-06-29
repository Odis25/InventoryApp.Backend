using AutoMapper;
using InventoryApp.Application.Interfaces;
using MediatR;
using System;
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

        public Task<CablesListVm> Handle(GetCablesListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
