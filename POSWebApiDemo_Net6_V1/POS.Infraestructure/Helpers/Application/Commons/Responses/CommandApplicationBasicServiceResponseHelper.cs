using POS.Infraestructure.Helpers.Application.Commons.Responses.Bases;
using POS.Infraestructure.SupportDtos.Application.Commons.ResponsesDtos;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;


namespace POS.Infraestructure.Helpers.Application.Commons.Responses
{
    public class CommandApplicationBasicServiceResponseHelper : BaseCommandApplicationBasicServiceResponseHelper
    {
        public override async Task<CommandApplicationResponseDto> ResponseAsync(CommandApplicationCollectorEntity commandCollectorEntity)
        {
            CommandApplicationResponseDto responseDto = new()
            {
                IsSuccess = commandCollectorEntity.IsSuccess,
                Records = commandCollectorEntity.Records,
                MessageResponse = commandCollectorEntity.MessageResponse,
                Information = commandCollectorEntity.Information,
                ValidationErrors = commandCollectorEntity.ValidationErrors,
                StatusResponse = commandCollectorEntity.HttpStatus
            };

            return await Task.FromResult(responseDto);
        }
    }
}
