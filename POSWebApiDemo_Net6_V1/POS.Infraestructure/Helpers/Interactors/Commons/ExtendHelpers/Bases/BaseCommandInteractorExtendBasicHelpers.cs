using POS.Infraestructure.Helpers.Interactors.Commons.Responses;
using POS.Infraestructure.SupportDtos.Interactors.Commons.Responses;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Interactors;


namespace POS.Infraestructure.Helpers.Interactors.Commons.ExtendHelpers.Bases
{
    public abstract class BaseCommandInteractorExtendBasicHelpers
    {
        public static async Task<CommandInteractorResponseDto> CommandInteractorBasicServiceResponseAsync(CommandInteractorCollectorEntity commandCollectorEntity)
        {
            CommandInteractorBasicServiceResponseHelper commandBasicResponseInteractor = new ();
            return await commandBasicResponseInteractor.ResponseAsync(commandCollectorEntity);
        }
    }
}
