using DeveloperStore.Models;
using MediatR;

namespace DeveloperStore.Events
{
    public class SaleModifiedEvent : INotification
    {
        public Sale Sale { get; }

        public SaleModifiedEvent(Sale sale)
        {
            Sale = sale;
        }
    }
}