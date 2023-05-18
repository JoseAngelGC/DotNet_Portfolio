using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using POS.Infraestructure.Helpers.Application.Commons.Collectors.Queries.Exceptions;
using POS.Infraestructure.Helpers.Application.Commons.Collectors.Queries.InteractorErrors;
using POS.Infraestructure.Helpers.Application.Commons.Collectors.Queries.NotFound;
using POS.Infraestructure.Helpers.Application.Commons.Collectors.Queries.Success;
using POS.Infraestructure.Helpers.Application.Commons.ExtendHelpers.Bases;
using POS.Infraestructure.Helpers.Application.Commons.Responses.Customs.Validations;
using POS.Infraestructure.Helpers.Application.UserApplication.Collectors.Queries.TokenSuccess;
using POS.Infraestructure.Interfaces.Application.Commons.Collectors;
using POS.Infraestructure.SupportDtos.Application.Commons.MappersDtos;
using POS.Infraestructure.SupportDtos.Application.Commons.ResponsesDtos;
using POS.Infraestructure.SupportDtos.Interactors.UserInteractors.Responses;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;
using POS.Utilities.Commons.Consts;

namespace POS.Infraestructure.Helpers.Application.Commons.Hubs
{
    public class QueryApplicationBasicHelpersHub : BaseQueryApplicationExtendBasicHelpers, IQueryApplicationBasicHelpers
    {
        public async Task<QueryApplicationCollectorEntity<T>> QueryApplicationSuccessfulBasicCollectorAsync<T>(GenericMapperDto<T> mapperDto)
        {
            QueryApplicationSuccessBasicCollectorHelper queryApplicationSuccessBasicCollectorHelper = new();
            return await queryApplicationSuccessBasicCollectorHelper.ResponseAsync(mapperDto);
        }

        public async Task<QueryApplicationCollectorEntity<T>> QueryApplicationExceptionBasicCollectorAsync<T>(int customerErrorCode, string? messageErrorException, int? hResultException, string? sourceException)
        {
            QueryApplicationExceptionBasicCollectorHelper queryApplicationExceptionBasicCollectorHelper = new ();
            return await queryApplicationExceptionBasicCollectorHelper.ResponseAsync<T>(customerErrorCode, messageErrorException, hResultException, sourceException);
        }

        public async Task<QueryApplicationCollectorEntity<T>> QueryApplicationInteractorErrorBasicCollectorAsync<T>(bool isSuccess, string controlMessage, int? customErrorCode)
        {
            QueryApplicationInteractorErrorBasicCollectorHelper queryApplicationInteractorErrorBasicCollectorHelper = new ();
            return await queryApplicationInteractorErrorBasicCollectorHelper.ResponseAsync<T>(isSuccess, controlMessage, customErrorCode);
        }

        public async Task<QueryApplicationCollectorEntity<T>> QueryApplicationNotFoundBasicCollectorAsync<T>(bool isSuccess, int? records, string controlMessage)
        {
            QueryApplicationNotFoundBasicCollectorHelper queryApplicationNotFoundBasicCollectorHelper = new ();
            return await queryApplicationNotFoundBasicCollectorHelper.ResponseAsync<T>(isSuccess, records, controlMessage);
        }

        public async Task<QueryApplicationCollectorEntity<T>> QueryApplicationValidationErrorsBasicCollectorAsync<T>(object validationErrors)
        {
            QueryApplicationCollectorEntity<T> collectorEntityResponse = new()
            {
                IsSuccess = false,
                MessageResponse = ReplyMessage.MESSAGE_VALIDATE,
                HttpStatus = StatusCodes.Status400BadRequest,
                ValidationErrors = validationErrors
            };

            return await Task.FromResult(collectorEntityResponse);
        }

        public async Task<GenericQueryApplicationResponseDto<T>> QueryApplicationValidationErrorsBasicCustomResponseAsync<T>(List<ValidationFailure> validationErrors)
        {
            ApplicationListValidationErrorsDtoBasicCommonCollectorHelper applicationListValidationErrorsDtoBasicCommonCollectorHelper = new();
            var listValidationCustomResponse = await applicationListValidationErrorsDtoBasicCommonCollectorHelper.ResponseAsync(validationErrors);
            var validationErrorsCollectorResponse = await QueryApplicationValidationErrorsBasicCollectorAsync<T>(listValidationCustomResponse);
            return await QueryApplicationBasicServiceResponseAsync(validationErrorsCollectorResponse);
        }

        public async Task<QueryApplicationCollectorEntity<T>> QueryApplicationResponseTypesCollectorAsync<T>(InteractorCreateTokenResponseDto interactorResponseDto)
        {
            QueryApplicationTokenSuccessCollectorHelper applicationTokenSuccessCollectorHelper = new();
            return await applicationTokenSuccessCollectorHelper.ResponseAsync<T>(interactorResponseDto);
        }
    }
}
