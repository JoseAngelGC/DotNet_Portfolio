using ApiCrudWithBlazor.CoreAbstractions.Repositories.ProductRepositories.Queries;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore;
using ApiCrudWithBlazor.Repositories.Context;
using Microsoft.EntityFrameworkCore;


namespace ApiCrudWithBlazor.Repositories.ProductRepositories.Queries
{
    public class GetProductByIdRepository<T> : IGetProductByIdRepository<T> where T : Product
    {
        private readonly StoreBasicCrudContext _context;
        private readonly DbSet<T> _entity;
        public GetProductByIdRepository(StoreBasicCrudContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }
        public async Task<Product> QueryAsync(int id)
        {
            var queryResponse = _entity.Where(p => p.IdProduct == id).FirstOrDefault();
            return await Task.FromResult(queryResponse!);
        }
    }
}
