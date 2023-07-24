using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ProductDtos;
using ApiCrudWithBlazor.CoreAbstractions.Repositories.ProductRepositories.Queries;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore;
using ApiCrudWithBlazor.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudWithBlazor.Repositories.ProductRepositories.Queries
{
    public class GetAllProductsRepository<T> : IGetAllProductsRepository<T> where T : Product
    {
        private readonly StoreBasicCrudContext _context;
        private readonly DbSet<T> _entity;
        public GetAllProductsRepository(StoreBasicCrudContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }
        public async Task<IQueryable<ProductDto>> QueryMultiTableAsync()
        {
            var query = _entity.Join(_context.Categories, product => product.IdCategory,
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
