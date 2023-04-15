using POS.Infraestructure.Helpers.Interactors.Commons.Collectors.Exceptions.Bases;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Interactors;
using POS.Utilities.Commons.Consts;

namespace POS.Infraestructure.Helpers.Interactors.Commons.Collectors.Exceptions
{
    public class QueryInteractorExceptionBasicCollectorHelper: BaseQueryInteractorExceptionBasicCollectorHelper
    {
        public override async Task<QueryInteractorCollectorEntity<T>> ResponseAsync<T>(int CustomerErrorCode, int? hResultException, string? sourceException)
        {
            QueryInteractorCollectorEntity<T> response = new()
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
