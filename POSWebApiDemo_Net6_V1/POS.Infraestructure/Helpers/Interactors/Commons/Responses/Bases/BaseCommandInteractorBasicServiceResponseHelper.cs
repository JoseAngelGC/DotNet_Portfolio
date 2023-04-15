using POS.Infraestructure.SupportDtos.Interactors.Commons.Responses;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Interactors;


namespace POS.Infraestructure.Helpers.Interactors.Commons.Responses.Bases
{
    public abstract class BaseCommandInteractorBasicServiceResponseHelper
    {
        public abstract Task<CommandInteractorResponseDto> ResponseAsync(CommandInteractorCollectorEntity commandCollectorEntity);
    }
}
