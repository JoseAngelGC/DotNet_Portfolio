using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;
using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Utilities.Constants;
using ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Errors.AbstractsBases;
using System.Net;

namespace ApiCrudAndAngular.CoreServices.Helpers.OutputPorts.InternalResponses.Errors.Commands
{
    internal class ExistingRecordErrorCommandResponseBasicHelper : BaseErrorCommandResponseHelper
    {
        public override async Task<CommandResponseDto> AttributesValuesAsync()
        {
            CommandResponseDto response = new()
            {
                IsSuccess = false,
                MessageResponse = ReplyMessageConstants.MESSAGE_EXIST,
                StatusResponse = (int)HttpStatusCode.BadRequest
            };

            return await Task.FromResult(response);
        }
    }
}
