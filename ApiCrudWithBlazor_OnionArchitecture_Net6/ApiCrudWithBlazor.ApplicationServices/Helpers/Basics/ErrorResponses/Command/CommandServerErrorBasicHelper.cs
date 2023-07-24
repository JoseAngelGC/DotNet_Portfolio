using ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.ExecutionFailsResponses.Errors.AbstractsBases;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Utilities.Constants;
using System.Net;

namespace ApiCrudWithBlazor.ApplicationServices.Helpers.Basics.ErrorResponses.Command
{
    public class CommandServerErrorBasicHelper : BaseCommandErrorsHelper
    {
        public override async Task<CommandResponseDto> AttributesValuesResponseAsync()
        {
            CommandResponseDto response = new()
            {
                IsSuccess = false,
                MessageResponse = ReplyMessageConstants.MESSAGE_FAILED,
                StatusResponse = (int)HttpStatusCode.InternalServerError
            };

            return await Task.FromResult(response);
        }
    }
}
