using POS.Infraestructure.SupportDtos.Application.Commons.MappersDtos;
using POS.Infraestructure.SupportDtos.Application.Commons.ResponsesDtos;
using POS.Infraestructure.SupportDtos.Interactors.UserInteractors.Responses;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;

namespace POS.Infraestructure.Interfaces.Application.Commons.Collectors
{
    public interface IQueryApplicationBasicHelpers
    {
        Task<QueryApplicationCollectorEntity<T>> QueryApplicationSuccessfulBasicCollectorAsync<T>(GenericMapperDto<T> mapperDto);
        Task<QueryApplicationCollectorEntity<T>> QueryApplicationInteractorErrorBasicCollectorAsync<T>(bool isSuccess, string controlMessage, int? customErrorCode);
        Task<QueryApplicationCollectorEntity<T>> QueryApplicationNotFoundBasicCollectorAsync<T>(bool isSuccess, int? records, string controlMessage);
        Task<QueryApplicationCollectorEntity<T>> QueryApplicationExceptionBasicCollectorAsync<T>(int customerErrorCode, string? messageErrorException, int? hResultException, string? sourceException);
        Task<QueryApplicationCollectorEntity<T>> QueryApplicationValidationErrorsBasicCollectorAsync<T>(object validationErrors);
        Task<GenericQueryApplicationResponseDto<T>> QueryApplicationValidationErrorsBasicCustomResponseAsync<T>(List<FluentValidation.Results.ValidationFailure> validationErrors);
        Task<QueryApplicationCollectorEntity<T>> QueryApplicationResponseTypesCollectorAsync<T>(InteractorCreateTokenResponseDto interactorResponseDto);
    }
}
