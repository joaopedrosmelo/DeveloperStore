using MediatR;

namespace DeveloperStore.Commands
{
    public class CancelSaleCommand : IRequest
    {
        public int Id { get; }

        public CancelSaleCommand(int id)
        {
            Id = id;
        }
    }
}
