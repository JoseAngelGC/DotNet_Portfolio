using POS.Infraestructure.SupportEntities.Interactors.UserInteractors.Collectors;


namespace POS.Infraestructure.Helpers.Interactors.UserInteractor.Collectors.InvalidParamsRequest.Bases
{
    public abstract class BaseInteractorInvalidUserOrPasswordCollectorHelper
    {
        public abstract Task<InteractorTokenCollectorEntity> ResponseAsync();
    }
}
