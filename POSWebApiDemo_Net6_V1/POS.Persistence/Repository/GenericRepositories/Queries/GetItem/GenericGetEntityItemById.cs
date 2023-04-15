using Microsoft.EntityFrameworkCore;
using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities.BaseEntities;
using POS.Persistence.Contexts.DomainSQLServer.EFCore.DataBaseFirst.Context;
using POS.Persistence.Interfaces.Generics.Queries.GetItem;


namespace POS.Persistence.Repository.GenericRepositories.Queries.GetItem
{
    public class GenericGetEntityItemById<T> : IGenericGetEntityItemById<T> where T : BaseEntity
    {
        private readonly POSContext _context;
        private readonly DbSet<T> _entity;

        public GenericGetEntityItemById(POSContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }
        public async Task<T> GetItemAsync(int id)
        {
            var entityItem = await _entity.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
            return await Task.FromResult(entityItem!);
        }
    }
}
