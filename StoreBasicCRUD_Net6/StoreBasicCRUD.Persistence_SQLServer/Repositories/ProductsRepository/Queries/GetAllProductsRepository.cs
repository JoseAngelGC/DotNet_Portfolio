using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.EntitiesDtos;
using StoreBasicCRUD.Persistence_SQLServer.Context;
using StoreBasicCRUD.Persistence_SQLServer.Interfaces.IProductsRepository.Queries;

namespace StoreBasicCRUD.Persistence_SQLServer.Repositories.ProductsRepository.Queries
{
    public class GetAllProductsRepository : IGetAllProductsRepository
    {
        private readonly StoreBasicCrudContext _context;
        public GetAllProductsRepository(StoreBasicCrudContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<ProductDto>> ResponsesAsync()
        {
            var query = _context.Products.Join(_context.Categories, product => product.IdCategory,
                category => category.IdCategory, (product, category) => new ProductDto
                {
                    IdProduct = product.IdProduct,
                    Nombre = product.Nombre,
                    Precio = product.Precio,
                    IdCategory = category.IdCategory,
                    Category = category.Nombre
                }).AsQueryable();

            return await Task.FromResult(query);
        }
    }
}
