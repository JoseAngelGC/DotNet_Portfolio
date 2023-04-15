using POS.Infraestructure.Helpers.Interactors.Commons.Responses.Bases;
using POS.Infraestructure.SupportDtos.Interactors.Commons.Responses;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Interactors;

namespace POS.Infraestructure.Helpers.Interactors.Commons.Responses
{
    public class CommandInteractorBasicServiceResponseHelper : BaseCommandInteractorBasicServiceResponseHelper
    {
        public override async Task<CommandInteractorResponseDto> ResponseAsync(CommandInteractorCollectorEntity commandCollectorEntity)
        {
            CommandInteractorResponseDto response = new()
            {
                IsSuccess = commandCollectorEntity.IsSuccess,
                CustomErrorCode = commandCollectorEntity.CustomErrorCode,
                ControlMessage = commandCollectorEntity.ControlMessage,
                MessageResponse = commandCollectorEntity.MessageResponse,
                AffectedRecords = commandCollectorEntity.Records
            };

            return await Task.FromResult(response);
        }
    }
}
