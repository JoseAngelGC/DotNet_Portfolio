using FluentValidation;
using POS.Infraestructure.SupportDtos.Commons.Requests;
using POS.Utilities.CategoryUtilities.Consts;
using POS.Utilities.Commons.Consts;

namespace POS.Application.Validators.Commons.Queries.GetFilteredList
{
    public class GenericFiltersRequestDtoValidator : AbstractValidator<GenericFiltersRequestDto>
    {
        private readonly List<string> sortingByColumnElements;
        private readonly List<string> orderingTypeElements;

        public GenericFiltersRequestDtoValidator()
        {
            sortingByColumnElements = SortingByCategoryColumn.ElementsList();
            orderingTypeElements = OrderingType.ElementsList();

            RuleFor(x => x.NumberPage)
                .GreaterThan(0).WithMessage("El campo {PropertyName} sólo acepta valores mayores a cero");

            RuleFor(x => x.NumberRecordsPage)
                .GreaterThan(0).WithMessage("El campo {PropertyName} sólo acepta valores mayores a cero.");

            RuleFor(x => x.Order)
                .Matches(@"^[a-zA-Z]+$").WithMessage("El campo {PropertyName} no acepta caracteres especiales.")
                .Must(order => orderingTypeElements.Contains(order.ToLower())).WithMessage("El valor de la propiedad {PropertyName} no coincide con un tipo de ordenamiento válido.");

            RuleFor(x => x.Sort)
                .Matches(@"^[a-zA-Z]+$").WithMessage("El campo {PropertyName} no acepta caracteres especiales.")
                .Must(sort => sortingByColumnElements.Contains(sort!.ToLower()))
                .WithMessage("El valor de la propiedad {PropertyName} no coincide con un campo válido para realizar el ordenamiento")
                .When(x => x.Sort != null, ApplyConditionTo.CurrentValidator);

            RuleFor(x => x.NumberFilter)
                .GreaterThan(0).WithMessage("El campo {PropertyName} sólo acepta valores mayores a cero");

            RuleFor(x => x.TextFilter)
                .NotEmpty().WithMessage("El campo {PropertyName} no puede ser vacío.").When(x => x.TextFilter != null, ApplyConditionTo.CurrentValidator)
                .Matches(@"^[a-z&ñA-Z&Ñ0-9á-ú\s]+$").WithMessage("El campo {PropertyName} no acepta caracteres especiales.");

            RuleFor(x => x.StateFilter)
                .ExclusiveBetween(-1,2).WithMessage("El campo {PropertyName} sólo acepta los valores 0 y 1.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("La propiedad {PropertyName} no puede ser vacío.").When(x => x.StartDate != null, ApplyConditionTo.CurrentValidator)
                .Matches(@"^(?:3[01]|[12][0-9]|0?[1-9])([\-])(0?[1-9]|1[1-2])([\-])([\d]{4})$").WithMessage("La propiedad {PropertyName} debe cumplir con el siguiente formato dd-mm-yyyy");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("La propiedad {PropertyName} no puede ser vacío.").When(x => x.EndDate != null, ApplyConditionTo.CurrentValidator)
                .Matches(@"^(?:3[01]|[12][0-9]|0?[1-9])([\-])(0?[1-9]|1[1-2])([\-])([\d]{4})$").WithMessage("La propiedad {PropertyName} debe cumplir con el siguiente formato dd-mm-yyyy");
        }
    }
}
