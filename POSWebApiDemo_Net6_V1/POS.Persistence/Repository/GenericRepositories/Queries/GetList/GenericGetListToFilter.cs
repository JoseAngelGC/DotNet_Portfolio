using Microsoft.EntityFrameworkCore;
using POS.Persistence.Contexts.DomainSQLServer.EFCore.DataBaseFirst.Context;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities.BaseEntities;
using POS.Persistence.Interfaces.Generics.Queries.GetList;

namespace POS.Persistence.Repository.GenericRepositories.Queries.GetList
{
    internal class GenericGetListToFilter<T> : IGenericGetListToFilter<T> where T : BaseEntity
    {
        private readonly POSContext _context;
        private readonly DbSet<T> _entity;
        public GenericGetListToFilter(POSContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public async Task<IQueryable<T>> GetQueryableEntityItemsAsync(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _entity;
            if (filter is not null) query = query.Where(filter);

            return await Task.FromResult(query);
        }
    }
}
