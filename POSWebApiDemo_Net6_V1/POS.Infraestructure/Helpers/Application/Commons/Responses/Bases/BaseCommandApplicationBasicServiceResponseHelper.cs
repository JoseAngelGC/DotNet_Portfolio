using POS.Infraestructure.SupportDtos.Application.Commons.ResponsesDtos;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;


namespace POS.Infraestructure.Helpers.Application.Commons.Responses.Bases
{
    public abstract class BaseCommandApplicationBasicServiceResponseHelper
    {
        public abstract Task<CommandApplicationResponseDto> ResponseAsync(CommandApplicationCollectorEntity commandCollectorEntity);
    }
}
