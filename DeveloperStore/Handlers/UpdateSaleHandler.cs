using DeveloperStore.Commands;
using DeveloperStore.Events;
using DeveloperStore.Repositories;
using DeveloperStore.Utils;
using MediatR;

namespace DeveloperStore.Handlers
{
    public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMediator _mediator;

        public UpdateSaleHandler(ISaleRepository saleRepository, IMediator mediator)
        {
            _saleRepository = saleRepository;
            _mediator = mediator;
        }

        public async Task Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
        {
            SaleDiscountCalculator.ApplyDiscounts(request.Sale);
            await _saleRepository.UpdateAsync(request.Sale);
            await _mediator.Publish(new SaleModifiedEvent(request.Sale), cancellationToken);
        }
    }
}
