using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities.BaseEntities;
using POS.Infraestructure.Helpers.Persistence.Commands.Commons.Responses.Bases;
using POS.Infraestructure.SupportEntities.Persistence.Commons.Commands.Responses;
using POS.Persistence.Contexts.DomainSQLServer.EFCore.DataBaseFirst.Context;
using POS.Persistence.Interfaces.Generics.Commands.SaveItem;


namespace POS.Persistence.Repository.GenericRepositories.Commands.SaveItem
{
    public class GenericSaveEntityItemCommand<T> : SuccesfulAndExceptionCommandResponse,IGenericSaveEntityItem<T> where T : BaseEntity
    {
        private readonly POSContext _context;
        public GenericSaveEntityItemCommand(POSContext context)
        {
            _context = context;
        }
        public async Task<ExecutedCommandEntity> SaveItemAsync(T entity)
        {
            var transaction = _context.Database.BeginTransaction();
            try
            {
                await _context.AddAsync(entity);
                var recordsAffected = await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return await SuccesfullResponseAsync(recordsAffected);
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return await ExceptionResponseAsync(e.HResult,e.Source!,e.Message);
            }
            
        }
    }
}
