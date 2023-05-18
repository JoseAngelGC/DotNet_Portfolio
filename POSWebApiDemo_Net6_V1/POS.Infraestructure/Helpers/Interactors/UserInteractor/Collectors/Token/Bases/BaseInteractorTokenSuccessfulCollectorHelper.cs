using POS.Infraestructure.SupportEntities.Interactors.UserInteractors.Collectors;


namespace POS.Infraestructure.Helpers.Interactors.UserInteractor.Collectors.Token.Bases
{
    public abstract class BaseInteractorTokenSuccessfulCollectorHelper
    {
        public abstract Task<InteractorTokenCollectorEntity> ResponseAsync(string? TokenString);
    }
}
