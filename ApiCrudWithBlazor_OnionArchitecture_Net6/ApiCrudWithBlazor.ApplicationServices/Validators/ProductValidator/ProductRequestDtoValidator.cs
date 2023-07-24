using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.RequestsDtos;
using FluentValidation;


namespace ApiCrudWithBlazor.ApplicationServices.Validators.ProductValidator
{
    public class ProductRequestDtoValidator : AbstractValidator<ProductRequestDto>
    {
        public ProductRequestDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede ser nulo o vacío.")
                .Matches(@"^[a-z&ñA-Z&Ñ0-9á-ú\s]+$").WithMessage("El campo {PropertyName} sólo acepta caracteres alfanuméricos")
                .MaximumLength(30).WithMessage("El campo {PropertyName} debe tener un máximo de {TotalLength} caracteres.");

            RuleFor(x => x.Precio)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede ser nulo o vacío.")
                .GreaterThan(0).WithMessage("El campo {PropertyName} debe ser mayor a 0.")
                .PrecisionScale(14, 2, false).WithMessage("El campo {PropertyName} soporta un total de {ExpectedPrecision} digitos, incluyendo {ExpectedScale} decimales.");

            RuleFor(x => x.IdCategory)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede ser nulo o vacío.")
                .GreaterThan(0).WithMessage("El campo {PropertyName} debe ser mayor a 0.");
        }
    }
}
