using POS.Infraestructure.SupportEntities.Commons.Collectors.Interactors;


namespace POS.Infraestructure.Helpers.Interactors.Commons.Collectors.ExistItem.Bases
{
    public abstract class BaseCommandInteractorExistItemBasicCollectorHelper
    {
        public abstract Task<CommandInteractorCollectorEntity> ResponseAsync(bool existItem);
    }
}
