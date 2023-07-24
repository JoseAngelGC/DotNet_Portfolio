using ApiCrudWithBlazor.CoreAbstractions.Repositories.Generic.Commands;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore.Bases;
using ApiCrudWithBlazor.Repositories.Context;
using Microsoft.EntityFrameworkCore;


namespace ApiCrudWithBlazor.Repositories.Generics.Commands
{
    public class RemoveGenericRepository<T> : IRemoveGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreBasicCrudContext _context;
        private readonly DbSet<T> _entity;
        public RemoveGenericRepository(StoreBasicCrudContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }
        public async Task<int> CommandAsync(T entity)
        {
            _entity.Remove(entity);
            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected;
        }
    }
}
