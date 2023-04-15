using FluentValidation;
using POS.Infraestructure.SupportDtos.Application.RequestsDtos.CategoryRequestsDtos;


namespace POS.Application.Validators.CategoryValidators.Commands.Commons
{
    public class CategoryRequesPlusDtoValidator : AbstractValidator<CategoryRequestWithIdDto>
    {
        public CategoryRequesPlusDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("El parámetro {PropertyName} no puede ser nulo.")
                .GreaterThanOrEqualTo(1).WithMessage("El parámetro {PropertyName} debe ser mayor a 0");
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
