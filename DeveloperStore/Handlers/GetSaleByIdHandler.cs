using DeveloperStore.Models;
using DeveloperStore.Queries;
using DeveloperStore.Repositories;
using MediatR;

namespace DeveloperStore.Handlers
{
    public class GetSaleByIdHandler : IRequestHandler<GetSaleByIdQuery, Sale>
    {
        private readonly ISaleRepository _saleRepository;

        public GetSaleByIdHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<Sale> Handle(GetSaleByIdQuery request, CancellationToken cancellationToken)
        {
            return await _saleRepository.GetByIdAsync(request.Id);
        }
    }
}
