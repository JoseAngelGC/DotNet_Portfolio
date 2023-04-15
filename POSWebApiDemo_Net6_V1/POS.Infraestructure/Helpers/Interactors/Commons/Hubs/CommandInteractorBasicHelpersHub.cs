using POS.Infraestructure.Helpers.Interactors.Commons.Collectors.Exceptions;
using POS.Infraestructure.Helpers.Interactors.Commons.Collectors.ExistItem;
using POS.Infraestructure.Helpers.Interactors.Commons.ExtendHelpers.Bases;
using POS.Infraestructure.Interfaces.Interactors.Commons.Collectors;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Interactors;


namespace POS.Infraestructure.Helpers.Interactors.Commons.Hubs
{
    public class CommandInteractorBasicHelpersHub : BaseCommandInteractorExtendBasicHelpers,ICommandInteractorBasicHelpers
    {
        public async Task<CommandInteractorCollectorEntity> CommandInteractorExceptionBasicCollectorAsync(int? affectedRecords, bool executedCommandSuccesful, int CustomerErrorCode, int hResultException, string sourceException)
        {
            CommandInteractorExceptionBasicCollectorHelper commandInteractorExceptionBasicCollectorHelper = new();
            return await commandInteractorExceptionBasicCollectorHelper.ResponseAsync(affectedRecords, executedCommandSuccesful, CustomerErrorCode, hResultException, sourceException);
        }

        public async Task<CommandInteractorCollectorEntity> CommandInteractorExistItemBasicCollectorAsync(bool existItem)
        {
            CommandInteractorExistItemBasicCollectorHelper commandInteractorExistItemBasicCollectorHelper = new();
            return await commandInteractorExistItemBasicCollectorHelper.ResponseAsync(existItem);
        }

        public async Task<CommandInteractorCollectorEntity> CommandInteractorSuccessfulBasicCollectorAsync(bool isSuccess, int? records, string controlEventMessage)
        {
            CommandInteractorCollectorEntity response = new()
            {
                IsSuccess = isSuccess,
                Records = records,
                ControlMessage = controlEventMessage
            };
            return await Task.FromResult(response);
        }
    }
}
