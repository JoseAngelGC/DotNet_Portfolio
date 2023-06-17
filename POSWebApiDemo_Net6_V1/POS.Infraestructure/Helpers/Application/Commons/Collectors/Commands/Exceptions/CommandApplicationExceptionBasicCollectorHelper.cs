using Microsoft.AspNetCore.Http;
using POS.Infraestructure.Helpers.Application.Commons.Collectors.Commands.Exceptions.Bases;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;
using POS.Utilities.Commons.Consts;

namespace POS.Infraestructure.Helpers.Application.Commons.Collectors.Commands.Exceptions
{
    public class CommandApplicationExceptionBasicCollectorHelper : BaseCommandApplicationExceptionBasicCollectorHelper
    {
        public override async Task<CommandApplicationCollectorEntity> ResponseAsync(int? affectedRecords, int customerErrorCode, bool isSuccessFlag)
        {
            CommandApplicationCollectorEntity entityResponse = new();
            switch (isSuccessFlag)
            {
                case true:
                    entityResponse.MessageResponse = ReplyMessage.MESSAGE_FAILS_AT_OPERATION_END;
                    entityResponse.Information = "Tipo de inconveniente:" + customerErrorCode + "!";
                    break;
                case false:
                    entityResponse.MessageResponse = ReplyMessage.MESSAGE_FAILED;
                    entityResponse.Information = "Ocurrio un inconveniente de tipo" + customerErrorCode + "!";
                    break;
            }
            entityResponse.Records = affectedRecords;
            entityResponse.IsSuccess = isSuccessFlag;
            entityResponse.HttpStatus = StatusCodes.Status500InternalServerError;

            return await Task.FromResult(entityResponse);
        }
    }
}
