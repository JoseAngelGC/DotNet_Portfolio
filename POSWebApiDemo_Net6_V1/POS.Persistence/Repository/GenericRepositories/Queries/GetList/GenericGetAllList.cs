using Microsoft.EntityFrameworkCore;
using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities.BaseEntities;
using POS.Persistence.Contexts.DomainSQLServer.EFCore.DataBaseFirst.Context;
using POS.Persistence.Interfaces.Generics.Queries.GetList;
using POS.Utilities.Commons.Enums;

namespace POS.Persistence.Repository.GenericRepositories.Queries.GetList
{
    public class GenericGetAllList<T> : IGenericGetAllList<T> where T : BaseEntity
    {
        private readonly POSContext _context;
        private readonly DbSet<T> _entity;

        public GenericGetAllList(POSContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }
        public async Task<IQueryable<T>> GetQueryableAsync()
        {
            IQueryable<T> query = _entity;
            query =  query.Where(x => x.State.Equals((int)RecordState.Active)
                    && x.AuditDeleteUser == null && x.AuditDeleteDate == null).AsNoTracking();

            return await Task.FromResult(query);
        }
    }
}
