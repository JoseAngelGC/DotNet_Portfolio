using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.DepartmentDtos;
using FluentValidation;

namespace ApiCrudAndAngular.ApplicationServices.Validators.DepartmentValidators
{
    public class DepartmentRequestDtoValidator : AbstractValidator<DepartmentRequestDto>
    {
        public DepartmentRequestDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede ser nulo o vacío.")
                .Matches(@"^[a-z&ñA-Z&Ñ0-9á-ú\s]+$").WithMessage("El campo {PropertyName} sólo acepta caracteres alfanuméricos")
                .MaximumLength(30).WithMessage("El campo {PropertyName} debe tener un máximo de {TotalLength} caracteres.");
        }
    }
}
