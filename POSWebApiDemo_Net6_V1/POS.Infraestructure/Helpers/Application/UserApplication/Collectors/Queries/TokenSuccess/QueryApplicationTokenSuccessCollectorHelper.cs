using Microsoft.AspNetCore.Http;
using POS.Infraestructure.Helpers.Application.UserApplication.Collectors.Queries.TokenSuccess.Bases;
using POS.Infraestructure.SupportDtos.Interactors.UserInteractors.Responses;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;
using POS.Utilities.Commons.Consts;

namespace POS.Infraestructure.Helpers.Application.UserApplication.Collectors.Queries.TokenSuccess
{
    public class QueryApplicationTokenSuccessCollectorHelper: BaseQueryApplicationTokenSuccessCollectorHelper
    {
        public override async Task<QueryApplicationCollectorEntity<T>> ResponseAsync<T>(InteractorCreateTokenResponseDto interactorResponseDto)
        {
            QueryApplicationCollectorEntity<T> collectorEntityResponse = new ();
            object tokenStringResponse = interactorResponseDto.TokenString!;
            switch (interactorResponseDto.ControlMessage)
            {
                case ControlEvent.MESSAGE_UNAVAILABLE:
                    collectorEntityResponse.HttpStatus = StatusCodes.Status503ServiceUnavailable;
                    collectorEntityResponse.MessageResponse = ReplyMessage.MESSAGE_UNAVAILABLESERVICE;
                    collectorEntityResponse.Information = "Ocurrio un inconveniente de tipo " + interactorResponseDto.CustomErrorCode + "!";
                    break;

                case ControlEvent.MESSAGE_UNCONTROLLEDEXCEPTION:
                    collectorEntityResponse.HttpStatus = StatusCodes.Status500InternalServerError;
                    collectorEntityResponse.MessageResponse = ReplyMessage.MESSAGE_FAILED;
                    collectorEntityResponse.Information = "Ocurrio un inconveniente de tipo " + interactorResponseDto.CustomErrorCode + "!";
                    break;

                case ControlEvent.MESSAGE_INVALIDUSERORPASSWORD:
                    collectorEntityResponse.HttpStatus = StatusCodes.Status404NotFound;
                    collectorEntityResponse.MessageResponse = ReplyMessage.MESSAGE_FAILED_TOKEN;
                    collectorEntityResponse.Information = "Usuario o password incorrecto!";
                    break;

                case ControlEvent.MESSAGE_OPERATIONSUCCESSFULLY:
                    collectorEntityResponse.HttpStatus = StatusCodes.Status200OK;
                    collectorEntityResponse.MessageResponse = ReplyMessage.MESSAGE_TOKEN;
                    break;

            }

            collectorEntityResponse.IsSuccess = interactorResponseDto.IsSuccess;
            collectorEntityResponse.Data = (T?)tokenStringResponse;

            return await Task.FromResult(collectorEntityResponse);
        }
    }
}
