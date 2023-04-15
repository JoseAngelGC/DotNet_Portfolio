using FluentValidation;
using POS.Infraestructure.SupportDtos.Application.RequestsDtos.CategoryRequestsDtos;

namespace POS.Application.Validators.CategoryValidators.Commands.SaveItemRequests
{
    public class CategoryRequestDtoValidator : AbstractValidator<CategoryRequestDto>
    {
        public CategoryRequestDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede ser nulo o vacío.")
                .Matches(@"^[a-z&ñA-Z&Ñ0-9á-ú]+$").WithMessage("El campo {PropertyName} no acepta caracteres especiales.")
                .MaximumLength(30);
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede ser vacío.")
                .Matches(@"^[a-z&ñA-Z&Ñ0-9á-ú\s]+$").WithMessage("El campo {PropertyName} no acepta caracteres especiales.");
            RuleFor(x => x.State)
                .NotNull().WithMessage("El campo {PropertyName} no puede ser nulo.")
                .GreaterThanOrEqualTo(0).WithMessage("El campo {PropertyName} sólo acepta los valores 0 ó 1.")
                .LessThanOrEqualTo(1).WithMessage("El campo {PropertyName} sólo acepta los valores 0 ó 1.");
        }
    }
}
