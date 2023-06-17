using POS.Infraestructure.Helpers.Interactors.UserInteractor.Collectors.Token.Bases;
using POS.Infraestructure.SupportEntities.Interactors.UserInteractors.Collectors;
using POS.Utilities.Commons.Consts;

namespace POS.Infraestructure.Helpers.Interactors.UserInteractor.Collectors.Token
{
    public class InteractorTokenSuccessfulCollectorHelper : BaseInteractorTokenSuccessfulCollectorHelper
    {
        public override async Task<InteractorTokenCollectorEntity> ResponseAsync(string? TokenString)
        {
            InteractorTokenCollectorEntity tokenCollectorEntity = new()
            {
                IsSuccess = true,
                TokenString = TokenString,
                ControlMessage = ControlEvent.MESSAGE_OPERATIONSUCCESSFULLY
            };

            return await Task.FromResult(tokenCollectorEntity);
        }
    }
}
