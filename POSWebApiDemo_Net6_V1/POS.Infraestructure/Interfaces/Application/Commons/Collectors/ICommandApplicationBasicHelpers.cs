using POS.Infraestructure.SupportDtos.Application.Commons.ResponsesDtos;
using POS.Infraestructure.SupportDtos.Interactors.Commons.Responses;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;

namespace POS.Infraestructure.Interfaces.Application.Commons.Collectors
{
    public interface ICommandApplicationBasicHelpers
    {
        Task<CommandApplicationCollectorEntity> CommandApplicationValidationErrorsBasicCollectorAsync(object validationErrors);
        Task<CommandApplicationCollectorEntity> CommandApplicationBuildResponseTypeBasicCollectorAsync(CommandInteractorResponseDto interactorResponseDto, string replySuccessfulMessage);
        Task<CommandApplicationCollectorEntity> CommandApplicationExceptionBasicCollectorAsync(int? affectedRecords, int CustomerErrorCode, bool isSuccessFlag);
        Task<CommandApplicationResponseDto> CommandApplicationValidationErrorsBasicCustomResponseAsync(List<FluentValidation.Results.ValidationFailure> validationErrors);
    }
}
