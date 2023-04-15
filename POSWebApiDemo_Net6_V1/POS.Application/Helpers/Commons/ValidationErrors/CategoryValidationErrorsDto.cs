using POS.Infraestructure.SupportDtos.Application.ValidationDtos.Commons;

namespace POS.Application.Helpers.Commons.ValidationErrors
{
    public class CategoryValidationErrorsDto
    {
        public async Task<List<CommonValidationErrorsDto>> GetListHelperAsync(List<FluentValidation.Results.ValidationFailure> validationErrors)
        {
            List<CommonValidationErrorsDto> listResponse = new();
            foreach (var result in validationErrors)
            {
                CommonValidationErrorsDto commonCategoryRequestDtoValidationErrors = new();
                commonCategoryRequestDtoValidationErrors.PropertyName = result.PropertyName;
                commonCategoryRequestDtoValidationErrors.ErrorMessage = result.ErrorMessage;
                listResponse.Add(commonCategoryRequestDtoValidationErrors);
            }

            return await Task.FromResult(listResponse);
        }
    }
}
