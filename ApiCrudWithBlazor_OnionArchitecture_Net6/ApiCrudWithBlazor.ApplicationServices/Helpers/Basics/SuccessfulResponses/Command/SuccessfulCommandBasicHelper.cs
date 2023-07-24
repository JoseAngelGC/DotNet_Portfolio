using ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.CompletedExecutionResponses.Success.AbstractsBases;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;
using System.Net;

namespace ApiCrudWithBlazor.ApplicationServices.Helpers.Basics.SuccessfulResponses.Command
{
    public class SuccessfulCommandBasicHelper : BaseSuccessfulCommandHelper
    {
        public override async Task<CommandResponseDto> AttributesValuesResponseAsync(int? recordsAffected, string messageResponse)
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
