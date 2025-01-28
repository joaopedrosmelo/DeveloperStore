using DeveloperStore.Models;

namespace DeveloperStore.Repositories
{
    public interface ISaleRepository
    {
        Task<Sale> GetByIdAsync(int id);
        Task<(List<Sale>, int)> GetSalesAsync(int page, int size, string orderBy, string filter);
        Task AddAsync(Sale sale);
        Task UpdateAsync(Sale sale);
        Task DeleteAsync(int id);
    }
}
