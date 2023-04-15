using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities.BaseEntities;
using POS.Infraestructure.Helpers.Persistence.Commands.Commons.Responses.Bases;
using POS.Infraestructure.SupportEntities.Persistence.Commons.Commands.Responses;
using POS.Persistence.Contexts.DomainSQLServer.EFCore.DataBaseFirst.Context;
using POS.Persistence.Interfaces.Generics.Commands.RemoveItem;


namespace POS.Persistence.Repository.GenericRepositories.Commands.RemoveItem
{
    public class GenericRemoveEntityItemCommand<T> : SuccesfulAndExceptionCommandResponse, IGenericRemoveEntityItem<T> where T : BaseEntity
    {
        private readonly POSContext _context;
        public GenericRemoveEntityItemCommand(POSContext context)
        {
            _context = context;
        }

        public async Task<ExecutedCommandEntity> RemoveItemAsync(T entity)
        {
            var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Remove(entity);
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
