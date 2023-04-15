using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.SupportDtos.Interactors.Commons.Responses;


namespace POS.Interactor.Interfaces.InteractorServices.CategoryInteractors.Queries.GetItem
{
    public interface ICategoryByIdInteractor
    {
        Task<GenericQueryInteractorResponseDto<Category>> GetItemAsync(int id);
    }
}
