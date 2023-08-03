using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses;
using ApiCrudAndAngular.CoreAbstractions.Helpers.OutputPorts.Responses.Successful.AbstractsBases;
using System.Net;

namespace ApiCrudAndAngular.CoreServices.Helpers.OutputPorts.InternalResponses.Successful
{
    internal class SuccessfulCommandResponseBasicHelper : BaseSuccessfulCommandResponseHelper
    {
        public override async Task<CommandResponseDto> AttributesValuesAsync(int? recordsAffected, string messageResponse)
        {
            CommandResponseDto response = new()
            {
                IsSuccess = true,
                RecordsAffected = recordsAffected,
                MessageResponse = messageResponse,
                StatusResponse = (int)HttpStatusCode.OK
            };

            return await Task.FromResult(response);
        }
    }
}
