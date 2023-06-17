using Microsoft.EntityFrameworkCore;
using StoreBasicCRUD.Persistence_SQLServer.Context;
using StoreBasicCRUD.Persistence_SQLServer.Interfaces.IProductsRepository.Queries;
using StoreBasicCRUD.SQLServer_Entities.EFCore.DataBaseFirst.Entities;

namespace StoreBasicCRUD.Persistence_SQLServer.Repositories.ProductsRepository.Queries
{
    public class ExistProductRepository : IExistProductRepository
    {
        private readonly StoreBasicCrudContext _context;
        public ExistProductRepository(StoreBasicCrudContext context)
        {
            _context = context;
        }
        public async Task<bool> ResponseAsync(string productName, int categoryId, int? productId = null)
        {
            bool existProductResponse;
            if (productId == null)
            {
                existProductResponse = await _context.Products.AnyAsync(p => p.Nombre.ToLower().Trim() == productName.ToLower() && p.IdCategory == categoryId);
            }
            else
            {
                existProductResponse = await _context.Products.AnyAsync(p => p.IdProduct == productId && p.Nombre.ToLower().Trim() == productName.ToLower() && p.IdCategory == categoryId);
            }

            return existProductResponse;
        }

        public async Task<bool> ResponseAsync(int productId)
        {
            return await _context.Products.AnyAsync(p => p.IdProduct == productId);
        }
    }
}
