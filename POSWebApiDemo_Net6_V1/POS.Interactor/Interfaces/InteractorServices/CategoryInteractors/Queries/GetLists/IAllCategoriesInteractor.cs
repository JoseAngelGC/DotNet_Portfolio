using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.SupportDtos.Interactors.Commons.Responses;


namespace POS.Interactor.Interfaces.InteractorServices.CategoryInteractors.Queries.GetLists
{
    public interface IAllCategoriesInteractor
    {
        Task<GenericQueryInteractorResponseDto<IEnumerable<Category>>> GetItemsAsync();
    }
}
