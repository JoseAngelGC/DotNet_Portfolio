using ApiCrudWithBlazor.Core.Abstraction.Utilities.Constants;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.RequestsDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Utilities.Constants;
using FluentValidation;


namespace ApiCrudWithBlazor.ApplicationServices.Validators.ProductValidator
{
    public class ProductFiltersRequestDtoValidator : AbstractValidator<CommonFiltersRequestDto>
    {
        private readonly List<string> _productColumnsName;
        private readonly List<string> _orderType;
        private readonly string stringEmpty = string.Empty;
        public ProductFiltersRequestDtoValidator()
        {
            _productColumnsName = ProductColumnNameConstants.ElementsList();
            _orderType = SortingConstants.ElementsList();

            RuleFor(x => x.NumberPage)
                .GreaterThan(0).WithMessage("El campo {PropertyName} sólo acepta valores mayores a cero");

            RuleFor(x => x.NumberRecordsPage)
                .GreaterThan(0).WithMessage("El campo {PropertyName} sólo acepta valores mayores a cero.");

            RuleFor(x => x.OrderType)
                .Matches(@"^[a-zA-Z]+$").WithMessage("El campo {PropertyName} no acepta caracteres especiales.")
                .Must(order => _orderType.Contains(order.ToLower())).WithMessage("El valor de la propiedad {PropertyName} no coincide con un tipo de ordenamiento válido.");

            RuleFor(x => x.SortByColumn)
                .Matches(@"^[a-zA-Z]+$").WithMessage("El campo {PropertyName} no acepta caracteres especiales.")
                .Must(sort => _productColumnsName.Contains(sort!.ToLower()))
                .WithMessage("El valor de la propiedad {PropertyName} no coincide con un campo válido para realizar el ordenamiento")
                .When(x => x.SortByColumn != null, ApplyConditionTo.CurrentValidator);

            RuleFor(x => x.ColumnNameToFilter)
                .Matches(@"^[a-zA-Z]+$").WithMessage("El campo {PropertyName} no acepta caracteres especiales.")
                .Must(sort => _productColumnsName.Contains(sort!.ToLower()))
                .WithMessage("El valor de la propiedad {PropertyName} no coincide con un campo válido para realizar el ordenamiento")
                .When(x => x.ColumnNameToFilter != null, ApplyConditionTo.CurrentValidator);

            RuleFor(x => x.TextFilter)
                .Matches(@"^[a-z&ñA-Z&Ñ0-9á-ú\s]+$").WithMessage("El campo {PropertyName} no acepta caracteres especiales.")
                .When(x => x.TextFilter != stringEmpty);
        }
    }
}
