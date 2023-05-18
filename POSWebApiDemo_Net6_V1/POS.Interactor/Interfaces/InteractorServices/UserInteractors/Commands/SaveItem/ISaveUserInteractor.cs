using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.SupportDtos.Interactors.Commons.Responses;

namespace POS.Interactor.Interfaces.InteractorServices.UserInteractors.Commands.SaveItem
{
    public interface ISaveUserInteractor
    {
        Task<CommandInteractorResponseDto> SaveItemAsync(User userItem);
    }
}
