using POS.Infraestructure.SupportDtos.Application.ValidationDtos.Commons;


namespace POS.Infraestructure.Helpers.Application.Commons.Responses.Customs.Validations.Bases
{
    public abstract class BaseApplicationListValidationErrorsDtoBasicCommonCollectorHelper
    {
        public abstract Task<List<CommonValidationErrorsDto>> ResponseAsync(List<FluentValidation.Results.ValidationFailure> validationErrors);
    }
}
