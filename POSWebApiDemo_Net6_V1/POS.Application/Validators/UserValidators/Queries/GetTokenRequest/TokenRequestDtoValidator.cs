using FluentValidation;
using POS.Infraestructure.SupportDtos.Application.RequestsDtos.UserRequestsDtos;


namespace POS.Application.Validators.UserValidators.Queries.GetTokenRequest
{
    public class TokenRequestDtoValidator : AbstractValidator<TokenRequestDto>
    {
        public TokenRequestDtoValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede ser nulo o vacío.")
                .Matches(@"^[a-z&ñA-Z&Ñ0-9á-ú]+$").WithMessage("El campo {PropertyName} sólo acepta caracteres alfanuméricos")
                .MaximumLength(30).WithMessage("El campo {PropertyName} debe tener un máximo de {TotalLength} caracteres.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede ser nulo o vacío.")
                .Matches(@"^[a-z&ñA-Z&Ñ0-9á-ú]+$").WithMessage("El campo {PropertyName} sólo acepta caracteres alfanuméricos")
                .Length(8, 12).WithMessage("El campo {PropertyName} debe tener un mínimo de {MinLength} caracteres y un máximo de {MaxLength} caracteres.");
        }
    }
}
