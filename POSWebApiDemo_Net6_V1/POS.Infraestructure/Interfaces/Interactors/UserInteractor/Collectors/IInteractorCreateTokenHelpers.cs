using POS.Infraestructure.SupportEntities.Interactors.UserInteractors.Collectors;

namespace POS.Infraestructure.Interfaces.Interactors.UserInteractor.Collectors
{
    public interface IInteractorCreateTokenHelpers
    {
        Task<InteractorTokenCollectorEntity> InteractorInvalidUserOrPasswordCollectorAsync();
        Task<InteractorTokenCollectorEntity> InteractorTokenSuccessfulCollectorAsync(string? token);
        Task<InteractorTokenCollectorEntity> InteractorTokenExceptionCollectorAsync(int CustomerErrorCode, int? hResultException, string? sourceException);
    }
}
