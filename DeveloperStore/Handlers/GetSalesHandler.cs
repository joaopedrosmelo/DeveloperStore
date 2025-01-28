using DeveloperStore.Models;
using DeveloperStore.Queries;
using DeveloperStore.Repositories;
using MediatR;

namespace DeveloperStore.Handlers
{
    public class GetSalesHandler : IRequestHandler<GetSalesQuery, (List<Sale>, int)>
    {
        private readonly ISaleRepository _saleRepository;

        public GetSalesHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<(List<Sale>, int)> Handle(GetSalesQuery request, CancellationToken cancellationToken)
        {
            return await _saleRepository.GetSalesAsync(request.Page, request.Size, request.OrderBy, request.Filter);
        }
    }
}
