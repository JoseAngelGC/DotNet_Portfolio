using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.SupportDtos.Commons.Requests;
using POS.Infraestructure.SupportDtos.Interactors.Commons.Responses;

namespace POS.Interactor.Interfaces.InteractorServices.CategoryInteractors.Queries.GetLists
{
    public interface IFilteredCategoriesInteractor
    {
        Task<GenericQueryInteractorResponseDto<List<Category>>> GetListAsync(GenericFiltersRequestDto filters);
    }
}
