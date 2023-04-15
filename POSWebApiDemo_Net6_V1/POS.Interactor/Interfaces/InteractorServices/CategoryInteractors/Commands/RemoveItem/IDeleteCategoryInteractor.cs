using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.SupportDtos.Interactors.Commons.Responses;


namespace POS.Interactor.Interfaces.InteractorServices.CategoryInteractors.Commands.RemoveItem
{
    public interface IDeleteCategoryInteractor
    {
        Task<CommandInteractorResponseDto> RemoveItemAsync(Category entityItem);
    }
}
