using POS.Infraestructure.Helpers.Application.Commons.Responses;
using POS.Infraestructure.SupportDtos.Application.Commons.ResponsesDtos;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;


namespace POS.Infraestructure.Helpers.Application.Commons.ExtendHelpers.Bases
{
    public abstract class BaseCommandApplicationExtendBasicHelpers
    {
        public static async Task<CommandApplicationResponseDto> CommandApplicationBasicServiceResponseAsync(CommandApplicationCollectorEntity commandCollectorEntity)
        {
            CommandApplicationBasicServiceResponseHelper commandApplicationBasicServiceResponseHelper = new ();
            return await commandApplicationBasicServiceResponseHelper.ResponseAsync(commandCollectorEntity);
        }
    }
}
