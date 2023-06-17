using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Commands;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Exceptions.Commands.Bases
{
    public abstract class BaseApplicationCollectorCommandExceptionHelper
    {
        public abstract Task<ApplicationCollectorCommandResponseEntity> ResponseAsync(string? messageErrorException, int? hResultException, string? sourceException);
    }
}
