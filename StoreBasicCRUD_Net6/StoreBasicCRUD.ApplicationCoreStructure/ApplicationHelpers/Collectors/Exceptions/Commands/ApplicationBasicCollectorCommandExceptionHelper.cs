using Microsoft.AspNetCore.Http;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Commands;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Exceptions.Commands.Bases;
using StoreBasicCRUD.Utilities.Shared.Consts;

namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.Collectors.Exceptions.Commands
{
    public class ApplicationBasicCollectorCommandExceptionHelper : BaseApplicationCollectorCommandExceptionHelper
    {
        public override async Task<ApplicationCollectorCommandResponseEntity> ResponseAsync(string? messageErrorException, int? hResultException, string? sourceException)
        {
            ApplicationCollectorCommandResponseEntity response = new();
            if (hResultException is not null && sourceException is not null)
            {
                if (hResultException == -2146232060 || sourceException == "Core Microsoft SqlClient Data Provider")
                {
                    response.MessageResponse = ReplyMessage.MESSAGE_UNAVAILABLESERVICE;
                    response.StatusResponse = StatusCodes.Status503ServiceUnavailable;
                }
                else
                {
                    response.MessageResponse = ReplyMessage.MESSAGE_FAILED;
                    response.StatusResponse = StatusCodes.Status500InternalServerError;
                }
            }
            else
            {
                response.MessageResponse = ReplyMessage.MESSAGE_FAILED;
                response.StatusResponse = StatusCodes.Status500InternalServerError;
            }

            response.IsSuccess = false;
            response.Information = "Ocurrio un inconveniente de tipo ...!";

            return await Task.FromResult(response);
        }
    }
}
