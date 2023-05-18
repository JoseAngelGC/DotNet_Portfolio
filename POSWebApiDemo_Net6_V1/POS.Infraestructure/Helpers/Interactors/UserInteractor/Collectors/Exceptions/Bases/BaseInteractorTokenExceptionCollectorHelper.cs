using POS.Infraestructure.SupportEntities.Interactors.UserInteractors.Collectors;


namespace POS.Infraestructure.Helpers.Interactors.UserInteractor.Collectors.Exceptions.Bases
{
    public abstract class BaseInteractorTokenExceptionCollectorHelper
    {
        public abstract Task<InteractorTokenCollectorEntity> ResponseAsync(int CustomerErrorCode, int? hResultException, string? sourceException);
    }
}
