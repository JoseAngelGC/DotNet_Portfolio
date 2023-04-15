using POS.Infraestructure.Helpers.Interactors.Commons.Collectors.ExistItem.Bases;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Interactors;
using POS.Utilities.Commons.Consts;


namespace POS.Infraestructure.Helpers.Interactors.Commons.Collectors.ExistItem
{
    public class CommandInteractorExistItemBasicCollectorHelper : BaseCommandInteractorExistItemBasicCollectorHelper
    {
        public override async Task<CommandInteractorCollectorEntity> ResponseAsync(bool existItem)
        {
            CommandInteractorCollectorEntity response = new();
            switch (existItem)
            {
                case true:
                    response.ControlMessage = ControlEvent.MESSAGE_EXIST;
                    break;
                case false:
                    response.ControlMessage = ControlEvent.MESSAGE_NOTFOUND;
                    break;
            }

            response.IsSuccess = false;
            return await Task.FromResult(response);
        }
    }
}
