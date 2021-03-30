using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Product>> GetProductAsync()
        {
            return await _context.Products
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
             return await _context.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIDAsync(int id)
        {
            return await _context.Products
             .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypeAsync()
        {
             return await _context.ProductType.ToListAsync();
        }
    }
}