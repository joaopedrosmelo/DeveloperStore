using DeveloperStore.Models;
using MediatR;

namespace DeveloperStore.Commands
{
    public class CreateSaleCommand : IRequest<int>
    {
        public Sale Sale { get; }

        public CreateSaleCommand(Sale sale)
        {
            Sale = sale;
        }
    }
}
