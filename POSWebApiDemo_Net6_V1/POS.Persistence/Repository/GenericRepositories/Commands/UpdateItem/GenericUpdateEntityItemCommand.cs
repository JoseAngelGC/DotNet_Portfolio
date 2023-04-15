using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities.BaseEntities;
using POS.Infraestructure.Helpers.Persistence.Commands.Commons.Responses.Bases;
using POS.Infraestructure.SupportEntities.Persistence.Commons.Commands.Responses;
using POS.Persistence.Contexts.DomainSQLServer.EFCore.DataBaseFirst.Context;
using POS.Persistence.Interfaces.Generics.Commands.UpdateItem;


namespace POS.Persistence.Repository.GenericRepositories.Commands.UpdateItem
{
    public class GenericUpdateEntityItemCommand<T> : SuccesfulAndExceptionCommandResponse, IGenericUpdateEntityItem<T> where T : BaseEntity
    {
        private readonly POSContext _context;
        public GenericUpdateEntityItemCommand(POSContext context)
        {
            _context = context;
        }

        public async Task<ExecutedCommandEntity> UpdateItemAsync(T entity)
        {
            var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Update(entity);
                _context.Entry(entity).Property(x => x.AuditCreateUser).IsModified = false;
                _context.Entry(entity).Property(x => x.AuditCreateDate).IsModified = false;
                var recordsAffected = await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return await SuccesfullResponseAsync(recordsAffected);
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return await ExceptionResponseAsync(e.HResult, e.Source!, e.Message);
            }
            
        }
    }
}
