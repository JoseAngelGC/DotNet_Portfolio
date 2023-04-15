using POS.Infraestructure.SupportEntities.Persistence.Commons.Commands.Responses;


namespace POS.Infraestructure.Helpers.Persistence.Commands.Commons.Responses.Bases
{
    public abstract class SuccesfulAndExceptionCommandResponse
    {
        public static async Task<ExecutedCommandEntity> ExceptionResponseAsync(int hResultException, string sourceException, string messageErrorException)
        {
            ExecutedCommandEntity entity = new()
            {
                IsSuccess = false,
                RecordsAffected = null,
                HResultException = hResultException,
                SourceException = sourceException,
                MessageErrorException = messageErrorException
            };

            return await Task.FromResult(entity);
        }

        public static async Task<ExecutedCommandEntity> SuccesfullResponseAsync(int recordsAffected)
        {
            ExecutedCommandEntity entity = new()
            {
                IsSuccess = true,
                RecordsAffected = recordsAffected
            };

            return await Task.FromResult(entity);
        }
    }
}
