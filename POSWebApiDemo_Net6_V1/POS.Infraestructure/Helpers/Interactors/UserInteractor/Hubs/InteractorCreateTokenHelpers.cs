using POS.Infraestructure.Helpers.Interactors.UserInteractor.Collectors.Exceptions;
using POS.Infraestructure.Helpers.Interactors.UserInteractor.Collectors.InvalidParamsRequest;
using POS.Infraestructure.Helpers.Interactors.UserInteractor.Collectors.Token;
using POS.Infraestructure.Helpers.Interactors.UserInteractor.ExtendHelpers.Bases;
using POS.Infraestructure.Interfaces.Interactors.UserInteractor.Collectors;
using POS.Infraestructure.SupportEntities.Interactors.UserInteractors.Collectors;

namespace POS.Infraestructure.Helpers.Interactors.UserInteractor.Hubs
{
    public class InteractorCreateTokenHelpers : BaseInteractorExtendCreateTokenHelpers, IInteractorCreateTokenHelpers
    {
        public async Task<InteractorTokenCollectorEntity> InteractorInvalidUserOrPasswordCollectorAsync()
        {
            InteractorInvalidUserOrPasswordCollectorHelper invalidUserOrPasswordCollectorHelper = new ();
            return await invalidUserOrPasswordCollectorHelper.ResponseAsync();
        }

        public Task<InteractorTokenCollectorEntity> InteractorTokenExceptionCollectorAsync(int CustomerErrorCode, int? hResultException, string? sourceException)
        {
            InteractorTokenExceptionCollectorHelper interactorTokenExceptionCollectorHelper = new ();
            return interactorTokenExceptionCollectorHelper.ResponseAsync(CustomerErrorCode, hResultException, sourceException);
        }

        public async Task<InteractorTokenCollectorEntity> InteractorTokenSuccessfulCollectorAsync(string? token)
        {
            InteractorTokenSuccessfulCollectorHelper tokenSuccessfulCollectorHelper = new ();
            return await tokenSuccessfulCollectorHelper.ResponseAsync(token);
        }
    }
}
