using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;

namespace POS.Infraestructure.Helpers.Application.Commons.Collectors.Commands.Responses.Bases
{
    public abstract class BaseCommandApplicationResponseCollectorHelper<T>
    {
        public abstract Task<CommandApplicationCollectorEntity> ResponseAsync(T interactorResponseDto, string replySuccessfulMessage);
    }
}
