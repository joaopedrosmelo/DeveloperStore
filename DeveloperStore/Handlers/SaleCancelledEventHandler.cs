using DeveloperStore.Events;
using MediatR;

namespace DeveloperStore.Handlers
{
    public class SaleCancelledEventHandler : INotificationHandler<SaleCancelledEvent>
    {
        private readonly ILogger<SaleCancelledEventHandler> _logger;

        public SaleCancelledEventHandler(ILogger<SaleCancelledEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(SaleCancelledEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Sale cancelled: {notification.SaleId}");
            return Task.CompletedTask;
        }
    }
}