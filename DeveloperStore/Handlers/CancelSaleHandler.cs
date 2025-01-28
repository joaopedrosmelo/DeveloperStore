using DeveloperStore.Commands;
using DeveloperStore.Events;
using DeveloperStore.Repositories;
using MediatR;

namespace DeveloperStore.Handlers
{
    public class CancelSaleHandler : IRequestHandler<CancelSaleCommand>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMediator _mediator;

        public CancelSaleHandler(ISaleRepository saleRepository, IMediator mediator)
        {
            _saleRepository = saleRepository;
            _mediator = mediator;
        }

        public async Task Handle(CancelSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = await _saleRepository.GetByIdAsync(request.Id);
            if (sale != null)
            {
                sale.IsCancelled = true;
                await _saleRepository.UpdateAsync(sale);
                await _mediator.Publish(new SaleCancelledEvent(request.Id), cancellationToken);
            }
        }
    }
}
