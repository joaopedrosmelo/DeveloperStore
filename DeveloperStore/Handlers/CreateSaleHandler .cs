using DeveloperStore.Commands;
using DeveloperStore.Events;
using DeveloperStore.Models;
using DeveloperStore.Repositories;
using DeveloperStore.Utils;
using MediatR;

namespace DeveloperStore.Handlers
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, int>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMediator _mediator;

        public CreateSaleHandler(ISaleRepository saleRepository, IMediator mediator)
        {
            _saleRepository = saleRepository;
            _mediator = mediator;
        }

        public async Task<int> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            SaleDiscountCalculator.ApplyDiscounts(request.Sale);
            await _saleRepository.AddAsync(request.Sale);
            await _mediator.Publish(new SaleCreatedEvent(request.Sale), cancellationToken);
            return request.Sale.Id;
        }
    }
}