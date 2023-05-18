using Microsoft.AspNetCore.Http;
using POS.Infraestructure.Helpers.Application.Commons.Collectors.Commands.Responses.Bases;
using POS.Infraestructure.SupportDtos.Interactors.Commons.Responses;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;
using POS.Utilities.Commons.Consts;


namespace POS.Infraestructure.Helpers.Application.Commons.Collectors.Commands.Responses
{
    public class CommandApplicationResponseCollectorHelper<T> : BaseCommandApplicationResponseCollectorHelper<T> where T : CommandInteractorResponseDto
    {
        public override async Task<CommandApplicationCollectorEntity> ResponseAsync(T interactorResponseDto, string replySuccessfulMessage)
        {
            CommandApplicationCollectorEntity collectorEntityResponse = new();
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
                case ControlEvent.MESSAGE_OPERATIONCOMPLETEDWITHFAILS:
                    collectorEntityResponse.HttpStatus = StatusCodes.Status500InternalServerError;
                    collectorEntityResponse.MessageResponse = ReplyMessage.MESSAGE_FAILS_AT_OPERATION_END;
                    collectorEntityResponse.Information = "Tipo de inconveniente:" + interactorResponseDto.CustomErrorCode + "!";
                    break;
                case ControlEvent.MESSAGE_EXIST:
                    collectorEntityResponse.HttpStatus = StatusCodes.Status400BadRequest;
                    collectorEntityResponse.MessageResponse = ReplyMessage.MESSAGE_EXIST;
                    break;
                case ControlEvent.MESSAGE_NOTFOUND:
                    collectorEntityResponse.HttpStatus = StatusCodes.Status404NotFound;
                    collectorEntityResponse.MessageResponse = ReplyMessage.MESSAGE_QUERY_EMPTY;
                    collectorEntityResponse.Information = "No se pudo realizar la operación!";
                    break;
                case ControlEvent.MESSAGE_CREATEDSUCCESFULLY:
                    collectorEntityResponse.HttpStatus = StatusCodes.Status201Created;
                    collectorEntityResponse.MessageResponse = replySuccessfulMessage;
                    break;
                case ControlEvent.MESSAGE_OPERATIONSUCCESSFULLY:
                    collectorEntityResponse.HttpStatus = StatusCodes.Status200OK;
                    collectorEntityResponse.MessageResponse = replySuccessfulMessage;
                    break;

            }

            collectorEntityResponse.IsSuccess = interactorResponseDto.IsSuccess;
            collectorEntityResponse.Records = interactorResponseDto.AffectedRecords;

            return await Task.FromResult(collectorEntityResponse);
        }
    }
}
