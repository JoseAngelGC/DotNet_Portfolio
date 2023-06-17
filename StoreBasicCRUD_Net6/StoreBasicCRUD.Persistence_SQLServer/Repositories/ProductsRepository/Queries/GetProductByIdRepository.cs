using Microsoft.EntityFrameworkCore;
using StoreBasicCRUD.Persistence_SQLServer.Context;
using StoreBasicCRUD.Persistence_SQLServer.Interfaces.IProductsRepository.Queries;
using StoreBasicCRUD.SQLServer_Entities.EFCore.DataBaseFirst.Entities;

namespace StoreBasicCRUD.Persistence_SQLServer.Repositories.ProductsRepository.Queries
{
    public class GetProductByIdRepository : IGetProductByIdRepository
    {
        private readonly StoreBasicCrudContext _context;
        public GetProductByIdRepository(StoreBasicCrudContext context)
        {
            _context = context;
        }

        public async Task<Product> ResponsesAsync(int productId)
        {
            var productResponse = await _context.Products.FirstOrDefaultAsync(p => p.IdProduct == productId);
            return productResponse!;
        }
    }
}
