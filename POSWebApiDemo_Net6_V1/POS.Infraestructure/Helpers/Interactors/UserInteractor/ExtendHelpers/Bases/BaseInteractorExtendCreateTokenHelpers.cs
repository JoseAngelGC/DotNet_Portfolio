using POS.Infraestructure.Helpers.Interactors.UserInteractor.Responses;
using POS.Infraestructure.SupportDtos.Interactors.UserInteractors.Responses;
using POS.Infraestructure.SupportEntities.Interactors.UserInteractors.Collectors;

namespace POS.Infraestructure.Helpers.Interactors.UserInteractor.ExtendHelpers.Bases
{
    public abstract class BaseInteractorExtendCreateTokenHelpers
    {
        public static async Task<InteractorCreateTokenResponseDto> InteractorCreateTokenServiceResponseAsync(InteractorTokenCollectorEntity queryCollectorEntity)
        {
            InteractorCreateTokenServiceResponseHelper interactorTokenServiceResponseHelper = new ();
            return await interactorTokenServiceResponseHelper.ResponseAsync(queryCollectorEntity);
        }
    }
}
