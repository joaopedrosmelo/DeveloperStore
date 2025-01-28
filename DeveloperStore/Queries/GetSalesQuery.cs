using DeveloperStore.Models;
using MediatR;

namespace DeveloperStore.Queries
{
    public class GetSalesQuery : IRequest<(List<Sale>, int)>
    {
        public int Page { get; }
        public int Size { get; }
        public string OrderBy { get; }
        public string Filter { get; }

        public GetSalesQuery(int page, int size, string orderBy, string filter)
        {
            Page = page;
            Size = size;
            OrderBy = orderBy;
            Filter = filter;
        }
    }
}