using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.SupportDtos.Interactors.Commons.Responses;

namespace POS.Interactor.Interfaces.InteractorServices.UserInteractors.Queries.GetItem
{
    public interface IAccountByUserNameInteractor
    {
        Task<GenericQueryInteractorResponseDto<User>> GetAccountByUserName(string name);
    }
}
