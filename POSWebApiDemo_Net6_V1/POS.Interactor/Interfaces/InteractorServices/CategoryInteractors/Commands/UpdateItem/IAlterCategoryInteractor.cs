using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.SupportDtos.Interactors.Commons.Responses;


namespace POS.Interactor.Interfaces.InteractorServices.CategoryInteractors.Commands.UpdateItem
{
    public interface IAlterCategoryInteractor
    {
        Task<CommandInteractorResponseDto> UpdateItemAsync(Category entityItem);
    }
}
