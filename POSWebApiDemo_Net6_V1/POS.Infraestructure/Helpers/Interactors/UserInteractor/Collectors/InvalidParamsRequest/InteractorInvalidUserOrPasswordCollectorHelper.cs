using POS.Infraestructure.Helpers.Interactors.UserInteractor.Collectors.InvalidParamsRequest.Bases;
using POS.Infraestructure.SupportEntities.Interactors.UserInteractors.Collectors;
using POS.Utilities.Commons.Consts;

namespace POS.Infraestructure.Helpers.Interactors.UserInteractor.Collectors.InvalidParamsRequest
{
    public class InteractorInvalidUserOrPasswordCollectorHelper : BaseInteractorInvalidUserOrPasswordCollectorHelper
    {
        public override async Task<InteractorTokenCollectorEntity> ResponseAsync()
        {
            InteractorTokenCollectorEntity tokenCollectorEntity = new()
            {
                IsSuccess = true,
                ControlMessage = ControlEvent.MESSAGE_INVALIDUSERORPASSWORD
            };

            return await Task.FromResult(tokenCollectorEntity);
        }
    }
}
