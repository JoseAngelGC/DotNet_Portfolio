using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.SupportDtos.Interactors.Commons.Responses;

namespace POS.Interactor.Interfaces.InteractorServices.CategoryInteractors.Commands.SaveItem
{
    public interface IAddCategoryInteractor
    {
        Task<CommandInteractorResponseDto> SaveItemAsync(Category entityItem);
    }
}
