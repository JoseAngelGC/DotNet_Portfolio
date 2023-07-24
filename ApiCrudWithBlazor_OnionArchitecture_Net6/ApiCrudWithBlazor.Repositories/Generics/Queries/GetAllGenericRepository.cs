using ApiCrudWithBlazor.CoreAbstractions.Repositories.Generic.Queries;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore.Bases;
using ApiCrudWithBlazor.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudWithBlazor.Repositories.Generics.Queries
{
    public class GetAllGenericRepository<T> : IGetAllGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreBasicCrudContext _context;
        private readonly DbSet<T> _entity;
        public GetAllGenericRepository(StoreBasicCrudContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }
        public async Task<IQueryable<T>> QueryAsync()
        {
            var response = _entity.AsQueryable();
            return await Task.FromResult(response); 
            
        }
    }
}
