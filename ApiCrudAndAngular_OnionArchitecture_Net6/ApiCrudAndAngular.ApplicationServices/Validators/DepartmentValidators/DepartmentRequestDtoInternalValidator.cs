using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.DepartmentDtos;
using FluentValidation;

namespace ApiCrudAndAngular.ApplicationServices.Validators.DepartmentValidators
{
    public class DepartmentRequestDtoInternalValidator : AbstractValidator<DepartmentRequestDtoInternal>
    {
        public DepartmentRequestDtoInternalValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede ser nulo o vacío.")
                .GreaterThan(0).WithMessage("El campo {PropertyName} debe ser mayor a 0.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede ser nulo o vacío.")
                .Matches(@"^[a-z&ñA-Z&Ñ0-9á-ú\s]+$").WithMessage("El campo {PropertyName} sólo acepta caracteres alfanuméricos")
                .MaximumLength(30).WithMessage("El campo {PropertyName} debe tener un máximo de {TotalLength} caracteres.");
        }
    }
}
