using ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.ExecutionFailsResponses.Exceptions.AbstractsBases;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Utilities.Constants;
using System.Net;


namespace ApiCrudWithBlazor.ApplicationServices.Helpers.Basics.ExceptionResponses.Command
{
    public class CommandExceptionBasicHelper : BaseCommandExceptionHelper
    {
        public override async Task<CommandResponseDto> AttributesValuesResponseAsync(string? messageErrorException, int? hResultException, string? sourceException)
        {
            CommandResponseDto response = new();
            if (hResultException is not null && sourceException is not null)
            {
                if (hResultException == -2146232060 || sourceException == "Core Microsoft SqlClient Data Provider")
                {
                    response.MessageResponse = ReplyMessageConstants.MESSAGE_UNAVAILABLESERVICE;
                    response.StatusResponse = (int)HttpStatusCode.ServiceUnavailable;
                }
                else
                {
                    response.MessageResponse = ReplyMessageConstants.MESSAGE_FAILED;
                    response.StatusResponse = (int)HttpStatusCode.InternalServerError;
                }
            }
            else
            {
                response.MessageResponse = ReplyMessageConstants.MESSAGE_FAILED;
                response.StatusResponse = (int)HttpStatusCode.InternalServerError;
            }

            response.IsSuccess = false;
            response.Information = "Ocurrio un inconveniente de tipo ...!";

            return await Task.FromResult(response);
        }
    }
}
