using POS.Infraestructure.Helpers.Interactors.UserInteractor.Collectors.Exceptions.Bases;
using POS.Infraestructure.SupportEntities.Interactors.UserInteractors.Collectors;
using POS.Utilities.Commons.Consts;

namespace POS.Infraestructure.Helpers.Interactors.UserInteractor.Collectors.Exceptions
{
    public class InteractorTokenExceptionCollectorHelper : BaseInteractorTokenExceptionCollectorHelper
    {
        public override async Task<InteractorTokenCollectorEntity> ResponseAsync(int CustomerErrorCode, int? hResultException, string? sourceException)
        {
            InteractorTokenCollectorEntity response = new()
            {
                IsSuccess = false,
                CustomErrorCode = CustomerErrorCode
            };

            if (hResultException is not null && sourceException is not null)
            {
                if (hResultException == -2146232060 || sourceException == "Core Microsoft SqlClient Data Provider")
                {
                    response.ControlMessage = ControlEvent.MESSAGE_UNAVAILABLE;
                }
                else
                {
                    response.ControlMessage = ControlEvent.MESSAGE_UNCONTROLLEDEXCEPTION;
                }
            }
            else
            {
                response.ControlMessage = ControlEvent.MESSAGE_UNCONTROLLEDEXCEPTION;
            }

            return await Task.FromResult(response);
        }
    }
}
