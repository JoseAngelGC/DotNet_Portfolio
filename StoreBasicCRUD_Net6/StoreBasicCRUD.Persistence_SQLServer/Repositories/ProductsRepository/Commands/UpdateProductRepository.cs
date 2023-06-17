using StoreBasicCRUD.Persistence_SQLServer.Context;
using StoreBasicCRUD.Persistence_SQLServer.Interfaces.IProductsRepository.Commands;
using StoreBasicCRUD.SQLServer_Entities.EFCore.DataBaseFirst.Entities;


namespace StoreBasicCRUD.Persistence_SQLServer.Repositories.ProductsRepository.Commands
{
    public class UpdateProductRepository : IUpdateProductRepository
    {
        private readonly StoreBasicCrudContext _context;
        public UpdateProductRepository(StoreBasicCrudContext context)
        {
            _context = context;
        }
        public async Task<int> ResponseAsync(Product productModel)
        {
            _context.Update(productModel);
            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected;
        }
    }
}
