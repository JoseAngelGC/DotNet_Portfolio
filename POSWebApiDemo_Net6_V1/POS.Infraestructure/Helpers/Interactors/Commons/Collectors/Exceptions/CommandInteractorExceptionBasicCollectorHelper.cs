using POS.Infraestructure.Helpers.Interactors.Commons.Collectors.Exceptions.Bases;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Interactors;
using POS.Utilities.Commons.Consts;

namespace POS.Infraestructure.Helpers.Interactors.Commons.Collectors.Exceptions
{
    public class CommandInteractorExceptionBasicCollectorHelper : BaseCommandInteractorExceptionBasicCollectorHelper
    {
        public override async Task<CommandInteractorCollectorEntity> ResponseAsync(int? affectedRecords, bool executedCommandSuccesful, int customerErrorCode, int hResultException, string sourceException)
        {
            CommandInteractorCollectorEntity response = new();

            switch (executedCommandSuccesful)
            {
                case false:
                    if (hResultException == -2146232060 || sourceException == "Core Microsoft SqlClient Data Provider")
                    {
                        response.ControlMessage = ControlEvent.MESSAGE_UNAVAILABLE;
                    }
                    else
                    {
                        response.ControlMessage = ControlEvent.MESSAGE_UNCONTROLLEDEXCEPTION;
                    }
                    break;

                case true:
                    response.ControlMessage = ControlEvent.MESSAGE_OPERATIONCOMPLETEDWITHFAILS;
                    break;
            }

            response.IsSuccess = executedCommandSuccesful;
            response.CustomErrorCode = customerErrorCode;
            response.Records = affectedRecords;
            
            return await Task.FromResult(response);
        }
    }
}
