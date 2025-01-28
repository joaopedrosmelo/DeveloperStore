using DeveloperStore.Events;
using MediatR;

namespace DeveloperStore.Handlers
{
    public class SaleCreatedEventHandler : INotificationHandler<SaleCreatedEvent>
    {
        private readonly ILogger<SaleCreatedEventHandler> _logger;

        public SaleCreatedEventHandler(ILogger<SaleCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(SaleCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Sale created: {notification.Sale.SaleNumber}");
            return Task.CompletedTask;
        }
    }
}