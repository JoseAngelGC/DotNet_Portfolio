using FluentValidation;
using POS.Infraestructure.SupportDtos.Application.RequestsDtos.UserRequestsDtos;


namespace POS.Application.Validators.UserValidators.Commands.SaveItemRequest
{
    public class UserRequestDtoValidator : AbstractValidator<UserRequestDto>
    {
        public UserRequestDtoValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede ser nulo o vacío.")
                .Matches(@"^[a-z&ñA-Z&Ñ0-9á-ú]+$").WithMessage("El campo {PropertyName} sólo acepta caracteres alfanuméricos")
                .MaximumLength(30).WithMessage("El campo {PropertyName} debe tener un máximo de {TotalLength} caracteres.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede ser nulo o vacío.")
                .Matches(@"^[a-z&ñA-Z&Ñ0-9á-ú]+$").WithMessage("El campo {PropertyName} sólo acepta caracteres alfanuméricos")
                .Length(8, 12).WithMessage("El campo {PropertyName} debe tener un mínimo de {MinLength} caracteres y un máximo de {MaxLength} caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede ser nulo o vacío.")
                .Matches(@"^[a-zA-Z0-9\\_.]+@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?$").WithMessage("{PropertyName} no válido. El {PropertyName} esta incompleto o contiene uno de los siguientes caracteres especiales: !#$%&'*+/=?^`{|}~¡¿][><: ;ñÑ")
                .MaximumLength(30).WithMessage("El campo {PropertyName} debe tener un máximo de {TotalLength} caracteres.");

            RuleFor(x => x.State)
                .NotNull().WithMessage("El campo {PropertyName} no puede ser nulo.")
                .GreaterThanOrEqualTo(0).WithMessage("El campo {PropertyName} sólo acepta los valores 0 ó 1.")
                .LessThanOrEqualTo(1).WithMessage("El campo {PropertyName} sólo acepta los valores 0 ó 1.");

        }
    }
}
