using ApiCrudWithBlazor.ApplicationServices.Helpers.Basics.ErrorResponses.Command;
using ApiCrudWithBlazor.ApplicationServices.Helpers.Basics.ErrorResponses.Query;
using ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.CustomResponses;
using ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.CustomResponses.ValidatorErrors.AbstractsBases;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrudWithBlazor.ApplicationServices.Helpers.Services
{
    public class CustomErrorResponsesBasicsHelpersService : ICustomErrorResponsesBasicsHelpersService
    {
        private  BaseCustomValidatorErrorsCommandHelper? _baseCustomValidatorErrorsCommandHelper;
        private  BaseCustomValidatorErrorsQueryHelper? _baseCustomValidatorErrorsQueryHelper;
        public async Task<CommandResponseDto> ValidatorErrorsCommandBasicHelperAsync(List<ValidationFailure> validationErrors)
        {
            _baseCustomValidatorErrorsCommandHelper = new CustomValidatorErrorsCommandBasicHelper();
            return await _baseCustomValidatorErrorsCommandHelper.AttributesValuesResponseAsync(validationErrors);
        }

        public async Task<QueryResponseDto<T>> ValidatorErrorsQueryBasicHelperAsync<T>(List<ValidationFailure> validationErrors)
        {
            _baseCustomValidatorErrorsQueryHelper = new CustomValidatorErrorsQueryBasicHelper();
            return await _baseCustomValidatorErrorsQueryHelper.AttributesValuesResponseAsync<T>(validationErrors);
        }
    }
}
