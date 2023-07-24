using ApiCrudWithBlazor.CoreAbstractions.Repositories.Generic.Commands;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore.Bases;
using ApiCrudWithBlazor.Repositories.Context;
using Microsoft.EntityFrameworkCore;


namespace ApiCrudWithBlazor.Repositories.Generics.Commands
{
    public class SaveGenericRepository<T> : ISaveGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreBasicCrudContext _context;
        private readonly DbSet<T> _entity;
        public SaveGenericRepository(StoreBasicCrudContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }
        public async Task<int> CommandAsync(T entity)
        {
            _entity.Add(entity);
            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected;
        }
    }
}
