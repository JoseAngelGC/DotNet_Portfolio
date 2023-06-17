using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.Helpers.Interactors.Commons.Hubs;
using POS.Infraestructure.SupportDtos.Interactors.Commons.Responses;
using POS.Interactor.Interfaces.InteractorServices.UserInteractors.Queries.GetItem;
using POS.Persistence.Interfaces.UnitsOfWork.UserUnitsOfWork;

namespace POS.Interactor.InteractorServices.UserInteractors.Queries.GetItem
{
    public class AccountByUserNameInteractor : QueryInteractorBasicHelpersHub, IAccountByUserNameInteractor
    {
        private readonly IUserQueriesUnitOfWork<User> _userQueriesUnitOfWork;
        public AccountByUserNameInteractor(IUserQueriesUnitOfWork<User> userQueriesUnitOfWork)
        {
            _userQueriesUnitOfWork = userQueriesUnitOfWork;
        }

        public async Task<GenericQueryInteractorResponseDto<User>> GetAccountByUserName(string name)
        {
            try
            {
                List<User> listUserAccountByUserName = new();
                var userAccountByUserName = await _userQueriesUnitOfWork.AccountByUserName.GetUserAccountAsync(name);
                if (userAccountByUserName is null)
                {
                    var notFoundUserAccountCollectorResponse = await QueryInteractorNotFoundBasicCollectorAsync<User>(null);
                    return await QueryInteractorBasicServiceResponseAsync(notFoundUserAccountCollectorResponse);
                }

                listUserAccountByUserName.Add(userAccountByUserName);
                var successCollectorResponse = await QueryInteractorSuccessfulBasicCollectorAsync(userAccountByUserName, listUserAccountByUserName.Count());
                return await QueryInteractorBasicServiceResponseAsync(successCollectorResponse);
            }
            catch (Exception e)
            {
                var exceptionCollectorResponse = await QueryInteractorExceptionBasicCollectorAsync<User>(2800, e.HResult, e.Source);
                return await QueryInteractorBasicServiceResponseAsync(exceptionCollectorResponse);
            }

        }
    }
}
