using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.Helpers.Interactors.Commons.Hubs;
using POS.Infraestructure.SupportDtos.Interactors.Commons.Responses;
using POS.Interactor.Interfaces.InteractorServices.CategoryInteractors.Commands.SaveItem;
using POS.Persistence.Interfaces.UnitsOfWork.CategoryUnitsOfWork;
using POS.Utilities.Commons.Consts;

namespace POS.Interactor.InteractorServices.CategoryInteractors.Commands.SaveItem
{
    public class AddCategoryInteractorService : CommandInteractorBasicHelpersHub, IAddCategoryInteractor
    {
        private readonly ICategoryRepositoryCommandsUnitsOfWork<Category> _categoryCommandsUnitsOfWork;
        private bool executedCommandSuccesfulFlag;
        private int? affectedRecords;
        public AddCategoryInteractorService(ICategoryRepositoryCommandsUnitsOfWork<Category> categoryCommandsUnitsOfWork)
        {
            _categoryCommandsUnitsOfWork = categoryCommandsUnitsOfWork;
            executedCommandSuccesfulFlag = false;
            affectedRecords = 0;
        }

        public async Task<CommandInteractorResponseDto> SaveItemAsync(Category entityItem)
        {
            try
            {
                var categoryItemExist = await _categoryCommandsUnitsOfWork.ExistCategoryItemByName.GetItemAsync(entityItem.Name!);
                if (categoryItemExist)
                {
                    var existItemCollectorResponse = await CommandInteractorExistItemBasicCollectorAsync(categoryItemExist);
                    return await CommandInteractorBasicServiceResponseAsync(existItemCollectorResponse);
                }

                entityItem.AuditCreateUser = 1;
                entityItem.AuditCreateDate = DateTime.Now;
                var saveItemResponse = await _categoryCommandsUnitsOfWork.GenericSaveEntityItem.SaveItemAsync(entityItem);
                executedCommandSuccesfulFlag = saveItemResponse.IsSuccess;
                affectedRecords = saveItemResponse.RecordsAffected;

                if (saveItemResponse.IsSuccess == false)
                {
                    var exceptionCollectorResponse = await CommandInteractorExceptionBasicCollectorAsync(affectedRecords, executedCommandSuccesfulFlag,1410, saveItemResponse.HResultException, saveItemResponse.SourceException!);
                    return await CommandInteractorBasicServiceResponseAsync(exceptionCollectorResponse);
                }

                var successfulCommandCollectorResponse = await CommandInteractorSuccessfulBasicCollectorAsync(saveItemResponse.IsSuccess, saveItemResponse.RecordsAffected, ControlEvent.MESSAGE_CREATEDSUCCESFULLY);
                return await CommandInteractorBasicServiceResponseAsync(successfulCommandCollectorResponse);
            }
            catch (Exception e)
            {
                var exceptionCollectorResponse = await CommandInteractorExceptionBasicCollectorAsync(affectedRecords, executedCommandSuccesfulFlag,1400, e.HResult, e.Source!);
                return await CommandInteractorBasicServiceResponseAsync(exceptionCollectorResponse);
            }
            
        }
    }
}
