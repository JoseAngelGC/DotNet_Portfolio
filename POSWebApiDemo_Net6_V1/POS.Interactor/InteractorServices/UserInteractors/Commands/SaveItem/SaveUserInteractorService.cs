using BC = BCrypt.Net.BCrypt;
using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.Helpers.Interactors.Commons.Hubs;
using POS.Infraestructure.SupportDtos.Interactors.Commons.Responses;
using POS.Interactor.Interfaces.InteractorServices.UserInteractors.Commands.SaveItem;
using POS.Persistence.Interfaces.UnitsOfWork.UserUnitsOfWork;
using POS.Utilities.Commons.Consts;

namespace POS.Interactor.InteractorServices.UserInteractors.Commands.SaveItem
{
    public class SaveUserInteractorService : CommandInteractorBasicHelpersHub, ISaveUserInteractor
    {
        private readonly IUserCommandsUnitOfWork<User> _userRepositoryCommandsUnitOfWork;
        private bool executedCommandSuccesfulFlag;
        private int? affectedRecords;
        public SaveUserInteractorService(IUserCommandsUnitOfWork<User> userRepositoryCommandsUnitOfWork)
        {
            _userRepositoryCommandsUnitOfWork = userRepositoryCommandsUnitOfWork;
            executedCommandSuccesfulFlag = false;
            affectedRecords = 0;
        }
        public async Task<CommandInteractorResponseDto> SaveItemAsync(User userItem)
        {
            try
            {
                var userItemExist = await _userRepositoryCommandsUnitOfWork.ExistUserItemByName.ExistItemAsync(userItem.UserName!);
                if (userItemExist)
                {
                    var existItemCollectorResponse = await CommandInteractorExistItemBasicCollectorAsync(userItemExist);
                    return await CommandInteractorBasicServiceResponseAsync(existItemCollectorResponse);
                }

                userItem.AuditCreateUser = 1;
                userItem.AuditCreateDate = DateTime.Now;
                userItem.Password = BC.HashPassword(userItem.Password);
                userItem.Email = userItem.Email!.ToLower().Trim();
                var saveItemResponse = await _userRepositoryCommandsUnitOfWork.GenericSaveEntityItem.SaveItemAsync(userItem);
                executedCommandSuccesfulFlag = saveItemResponse.IsSuccess;
                affectedRecords = saveItemResponse.RecordsAffected;

                if (saveItemResponse.IsSuccess == false)
                {
                    var exceptionCollectorResponse = await CommandInteractorExceptionBasicCollectorAsync(affectedRecords, executedCommandSuccesfulFlag, 1410, saveItemResponse.HResultException, saveItemResponse.SourceException!);
                    return await CommandInteractorBasicServiceResponseAsync(exceptionCollectorResponse);
                }

                var successfulCommandCollectorResponse = await CommandInteractorSuccessfulBasicCollectorAsync(saveItemResponse.IsSuccess, saveItemResponse.RecordsAffected, ControlEvent.MESSAGE_CREATEDSUCCESFULLY);
                return await CommandInteractorBasicServiceResponseAsync(successfulCommandCollectorResponse);
            }
            catch (Exception e)
            {
                var exceptionCollectorResponse = await CommandInteractorExceptionBasicCollectorAsync(affectedRecords, executedCommandSuccesfulFlag, 1400, e.HResult, e.Source!);
                return await CommandInteractorBasicServiceResponseAsync(exceptionCollectorResponse);
            }

        }
    }
}
