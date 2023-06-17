using POS.Infraestructure.Helpers.Interactors.UserInteractor.Responses.Bases;
using POS.Infraestructure.SupportDtos.Interactors.UserInteractors.Responses;
using POS.Infraestructure.SupportEntities.Interactors.UserInteractors.Collectors;

namespace POS.Infraestructure.Helpers.Interactors.UserInteractor.Responses
{
    public class InteractorCreateTokenServiceResponseHelper : BaseInteractorCreateTokenServiceResponseHelper
    {
        public override async Task<InteractorCreateTokenResponseDto> ResponseAsync(InteractorTokenCollectorEntity queryCollectorEntity)
        {
            InteractorCreateTokenResponseDto response = new()
            {
                IsSuccess = queryCollectorEntity.IsSuccess,
                CustomErrorCode = queryCollectorEntity.CustomErrorCode,
                MessageResponse = queryCollectorEntity.MessageResponse,
                ControlMessage = queryCollectorEntity.ControlMessage,
                TokenString = queryCollectorEntity.TokenString
            };

            return await Task.FromResult(response);
        }
    }
}
