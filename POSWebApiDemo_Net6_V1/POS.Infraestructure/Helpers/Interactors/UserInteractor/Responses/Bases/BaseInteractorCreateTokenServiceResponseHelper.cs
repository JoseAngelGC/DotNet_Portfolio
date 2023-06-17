using POS.Infraestructure.SupportDtos.Interactors.UserInteractors.Responses;
using POS.Infraestructure.SupportEntities.Interactors.UserInteractors.Collectors;

namespace POS.Infraestructure.Helpers.Interactors.UserInteractor.Responses.Bases
{
    public abstract class BaseInteractorCreateTokenServiceResponseHelper
    {
        public abstract Task<InteractorCreateTokenResponseDto> ResponseAsync(InteractorTokenCollectorEntity queryCollectorEntity);
    }
}
