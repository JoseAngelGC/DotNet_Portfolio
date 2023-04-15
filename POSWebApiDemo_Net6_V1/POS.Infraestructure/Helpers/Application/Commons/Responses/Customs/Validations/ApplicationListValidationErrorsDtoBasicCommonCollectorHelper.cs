using FluentValidation.Results;
using POS.Infraestructure.Helpers.Application.Commons.Responses.Customs.Validations.Bases;
using POS.Infraestructure.SupportDtos.Application.ValidationDtos.Commons;


namespace POS.Infraestructure.Helpers.Application.Commons.Responses.Customs.Validations
{
    public class ApplicationListValidationErrorsDtoBasicCommonCollectorHelper : BaseApplicationListValidationErrorsDtoBasicCommonCollectorHelper
    {
        public override async Task<List<CommonValidationErrorsDto>> ResponseAsync(List<ValidationFailure> validationErrors)
        {
            List<CommonValidationErrorsDto> listValidationErrorsDto = new();
            foreach (var result in validationErrors)
            {
                CommonValidationErrorsDto commonCategoryRequestDtoValidationErrors = new();
                commonCategoryRequestDtoValidationErrors.PropertyName = result.PropertyName;
                commonCategoryRequestDtoValidationErrors.ErrorMessage = result.ErrorMessage;
                listValidationErrorsDto.Add(commonCategoryRequestDtoValidationErrors);
            }

            return await Task.FromResult(listValidationErrorsDto);
        }
    }
}
