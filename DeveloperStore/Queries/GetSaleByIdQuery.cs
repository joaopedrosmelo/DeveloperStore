using DeveloperStore.Models;
using MediatR;

namespace DeveloperStore.Queries
{
    public class GetSaleByIdQuery : IRequest<Sale>
    {
        public int Id { get; }

        public GetSaleByIdQuery(int id)
        {
            Id = id;
        }
    }
}