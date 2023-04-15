using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using POS.Infraestructure.Helpers.Application.Commands.Commons.Collectors.Generics;
using POS.Infraestructure.Helpers.Application.Commons.ExtendHelpers.Bases;
using POS.Infraestructure.Helpers.Application.Commons.Responses.Customs.Validations;
using POS.Infraestructure.Interfaces.Application.Commons.Collectors;
using POS.Infraestructure.SupportDtos.Application.Commons.ResponsesDtos;
using POS.Infraestructure.SupportDtos.Interactors.Commons.Responses;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;
using POS.Utilities.Commons.Consts;

namespace POS.Infraestructure.Helpers.Application.Commons.Hubs
{
    public class CommandApplicationBasicHelpersHub : BaseCommandApplicationExtendBasicHelpers, ICommandApplicationBasicHelpers
    {
        public async Task<CommandApplicationCollectorEntity> CommandApplicationBuildResponseTypeBasicCollectorAsync(CommandInteractorResponseDto interactorResponseDto, string replySuccessfulMessage)
        {
            CommandApplicationBuildResponseTypeBasicCollectorHelper<CommandInteractorResponseDto> commandApplicationBuildResponseTypeBasicCollectorHelper = new ();
            return await commandApplicationBuildResponseTypeBasicCollectorHelper.ResponseAsync(interactorResponseDto, replySuccessfulMessage);
        }

        public async Task<CommandApplicationCollectorEntity> CommandApplicationExceptionBasicCollectorAsync(int? affectedRecords, int CustomerErrorCode, bool isSuccessFlag)
        {
            CommandApplicationExceptionBasicCollectorHelper commandApplicationExceptionBasicCollectorHelper = new ();
            return await commandApplicationExceptionBasicCollectorHelper.ResponseAsync(affectedRecords, CustomerErrorCode, isSuccessFlag);
        }

        public async Task<CommandApplicationCollectorEntity> CommandApplicationValidationErrorsBasicCollectorAsync(object validationErrors)
        {
            CommandApplicationCollectorEntity collectorEntityResponse = new()
            {
                IsSuccess = false,
                MessageResponse = ReplyMessage.MESSAGE_VALIDATE,
                HttpStatus = StatusCodes.Status400BadRequest,
                ValidationErrors = validationErrors
            };

            return await Task.FromResult(collectorEntityResponse);
        }

        public async Task<CommandApplicationResponseDto> CommandApplicationValidationErrorsBasicCustomResponseAsync(List<ValidationFailure> validationErrors)
        {
            ApplicationListValidationErrorsDtoBasicCommonCollectorHelper applicationListValidationErrorsDtoBasicCommonCollectorHelper = new ();
            var listValidationCustomResponse = await applicationListValidationErrorsDtoBasicCommonCollectorHelper.ResponseAsync(validationErrors);
            var validationErrorsCollectorResponse = await CommandApplicationValidationErrorsBasicCollectorAsync(listValidationCustomResponse);
            return await CommandApplicationBasicServiceResponseAsync(validationErrorsCollectorResponse);
        }
    }
}
