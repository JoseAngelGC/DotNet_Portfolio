using StoreBasicCRUD.Persistence_SQLServer.Context;
using StoreBasicCRUD.Persistence_SQLServer.Interfaces.IProductsRepository.Commands;
using StoreBasicCRUD.SQLServer_Entities.EFCore.DataBaseFirst.Entities;


namespace StoreBasicCRUD.Persistence_SQLServer.Repositories.ProductsRepository.Commands
{
    public class SaveProductRepository : ISaveProductRepository
    {
        private readonly StoreBasicCrudContext _context;
        public SaveProductRepository(StoreBasicCrudContext context)
        {
            _context = context;
        }
        public async Task<int> ResponseAsync(Product productModel)
        {
            await _context.AddAsync(productModel);
            var recordsAffected = await _context.SaveChangesAsync();

            return recordsAffected;
        }
    }
}
