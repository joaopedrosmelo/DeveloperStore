using DeveloperStore.Models;
using MediatR;

namespace DeveloperStore.Events
{
    public class SaleCreatedEvent : INotification
    {
        public Sale Sale { get; }

        public SaleCreatedEvent(Sale sale)
        {
            Sale = sale;
        }
    }
}