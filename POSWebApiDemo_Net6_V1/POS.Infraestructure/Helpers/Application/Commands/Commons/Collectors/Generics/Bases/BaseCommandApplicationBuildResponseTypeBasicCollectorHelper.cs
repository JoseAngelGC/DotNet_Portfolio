using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;

namespace POS.Infraestructure.Helpers.Application.Commands.Commons.Collectors.Generics.Bases
{
    public abstract class BaseCommandApplicationBuildResponseTypeBasicCollectorHelper<T>
    {
        public abstract Task<CommandApplicationCollectorEntity> ResponseAsync(T interactorResponseDto, string replySuccessfulMessage);
    }
}
