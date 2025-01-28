using DeveloperStore.Models;
using MediatR;

namespace DeveloperStore.Commands
{
    public class UpdateSaleCommand : IRequest
    {
        public Sale Sale { get; }

        public UpdateSaleCommand(Sale sale)
        {
            Sale = sale;
        }
    }
}
