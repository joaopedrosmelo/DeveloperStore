using MediatR;

namespace DeveloperStore.Events
{
    public class SaleCancelledEvent : INotification
    {
        public int SaleId { get; }

        public SaleCancelledEvent(int saleId)
        {
            SaleId = saleId;
        }
    }
}