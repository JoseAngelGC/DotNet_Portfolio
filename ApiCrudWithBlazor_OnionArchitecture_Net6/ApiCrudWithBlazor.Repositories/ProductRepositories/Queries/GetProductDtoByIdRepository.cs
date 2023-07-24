using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ProductDtos;
using ApiCrudWithBlazor.CoreAbstractions.Repositories.ProductRepositories.Queries;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore;
using ApiCrudWithBlazor.Repositories.Context;
using Microsoft.EntityFrameworkCore;


namespace ApiCrudWithBlazor.Repositories.ProductRepositories.Queries
{
    public class GetProductDtoByIdRepository<T> : IGetProductDtoByIdRepository<T> where T : Product
    {
        private readonly StoreBasicCrudContext _context;
        private readonly DbSet<T> _entity;
        public GetProductDtoByIdRepository(StoreBasicCrudContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public async Task<ProductDto> QueryAsync(int id)
        {
            var queryResponse = _entity.Join(_context.Categories, product => product.IdCategory,
                category => category.IdCategory, (product, category) => new ProductDto
                {
                    IdProduct = product.IdProduct,
                    Nombre = product.Nombre,
                    Precio = product.Precio,
                    IdCategory = category.IdCategory,
                    Category = category.Nombre
                }).Where(p => p.IdProduct == id).FirstOrDefault();
            
            return await Task.FromResult(queryResponse!);
        }
    }
}
