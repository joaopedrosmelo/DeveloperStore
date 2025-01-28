using DeveloperStore.Events;
using MediatR;

namespace DeveloperStore.Handlers
{
    public class SaleModifiedEventHandler : INotificationHandler<SaleModifiedEvent>
    {
        private readonly ILogger<SaleModifiedEventHandler> _logger;

        public SaleModifiedEventHandler(ILogger<SaleModifiedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(SaleModifiedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Sale modified: {notification.Sale.SaleNumber}");
            return Task.CompletedTask;
        }
    }
}