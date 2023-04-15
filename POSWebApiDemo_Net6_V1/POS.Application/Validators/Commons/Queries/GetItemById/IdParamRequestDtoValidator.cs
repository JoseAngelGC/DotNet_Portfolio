using FluentValidation;
using POS.Infraestructure.SupportDtos.Application.RequestsDtos.Commons;


namespace POS.Application.Validators.Commons.Queries.GetItemById
{
    public class IdParamRequestDtoValidator : AbstractValidator<SingleParamRequestDto>
    {
        public IdParamRequestDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("El parámetro {PropertyName} no puede ser nulo.")
                .GreaterThanOrEqualTo(1).WithMessage("El parámetro {PropertyName} debe ser mayor a 0.");
        }
    }
}
