using DeveloperStore.Data;
using DeveloperStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DeveloperStore.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly ApplicationDbContext _context;

        public SaleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Sale> GetByIdAsync(int id)
        {
            return await _context.Sales.Include(s => s.Items).FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task<(List<Sale>, int)> GetSalesAsync(int page, int size, string orderBy, string filter)
        {
            var query = _context.Sales.Include(s => s.Items).AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(s => s.SaleNumber.Contains(filter) || s.CustomerName.Contains(filter));
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                var orderByParts = orderBy.Split(' ');
                var field = orderByParts[0];
                var direction = orderByParts.Length > 1 ? orderByParts[1] : "asc";

                if (field == "saleNumber")
                {
                    query = direction == "asc" ? query.OrderBy(s => s.SaleNumber) : query.OrderByDescending(s => s.SaleNumber);
                }
                else if (field == "saleDate")
                {
                    query = direction == "asc" ? query.OrderBy(s => s.SaleDate) : query.OrderByDescending(s => s.SaleDate);
                }
            }

            var totalItems = await query.CountAsync();
            var sales = await query.Skip((page - 1) * size).Take(size).ToListAsync();

            return (sales, totalItems);
        }

        public async Task AddAsync(Sale sale)
        {
            await _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Sale sale)
        {
            _context.Sales.Update(sale);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale != null)
            {
                _context.Sales.Remove(sale);
                await _context.SaveChangesAsync();
            }
        }
    }
}
