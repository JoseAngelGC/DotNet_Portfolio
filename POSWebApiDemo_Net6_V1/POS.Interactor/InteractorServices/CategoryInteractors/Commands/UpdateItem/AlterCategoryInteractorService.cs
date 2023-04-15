using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.Helpers.Interactors.Commons.Hubs;
using POS.Infraestructure.SupportDtos.Interactors.Commons.Responses;
using POS.Interactor.Interfaces.InteractorServices.CategoryInteractors.Commands.UpdateItem;
using POS.Persistence.Interfaces.UnitsOfWork.CategoryUnitsOfWork;
using POS.Utilities.Commons.Consts;

namespace POS.Interactor.InteractorServices.CategoryInteractors.Commands.UpdateItem
{
    public class AlterCategoryInteractorService : CommandInteractorBasicHelpersHub, IAlterCategoryInteractor
    {
        private readonly ICategoryRepositoryCommandsUnitsOfWork<Category> _categoryCommandsUnitsOfWork;
        private bool executedCommandSuccesfulFlag;
        private int? affectedRecords;
        public AlterCategoryInteractorService(ICategoryRepositoryCommandsUnitsOfWork<Category> categoryCommandsUnitsOfWork)
        {
            _categoryCommandsUnitsOfWork = categoryCommandsUnitsOfWork;
            executedCommandSuccesfulFlag = false;
            affectedRecords = 0;
        }

        public async Task<CommandInteractorResponseDto> UpdateItemAsync(Category entityItem)
        {
            try
            {
                var categoryItemExist = await _categoryCommandsUnitsOfWork.ExistCategoryItemById.ResponseAsync(entityItem.Id);
                if (!categoryItemExist)
                {
                    var existItemCollectorResponse = await CommandInteractorExistItemBasicCollectorAsync(categoryItemExist);
                    return await CommandInteractorBasicServiceResponseAsync(existItemCollectorResponse);
                }

                entityItem.AuditUpdateUser = 1;
                entityItem.AuditUpdateDate = DateTime.Now;
                var updateItemResponse = await _categoryCommandsUnitsOfWork.GenericUpdateEntityItem.UpdateItemAsync(entityItem);
                executedCommandSuccesfulFlag = updateItemResponse.IsSuccess;
                affectedRecords = updateItemResponse.RecordsAffected;

                if (updateItemResponse.IsSuccess == false)
                {
                    var exceptionCollectorResponse = await CommandInteractorExceptionBasicCollectorAsync(affectedRecords, executedCommandSuccesfulFlag , 1510, updateItemResponse.HResultException, updateItemResponse.SourceException!);
                    return await CommandInteractorBasicServiceResponseAsync(exceptionCollectorResponse);
                }

                var successfulCommandCollectorResponse = await CommandInteractorSuccessfulBasicCollectorAsync(updateItemResponse.IsSuccess, updateItemResponse.RecordsAffected, ControlEvent.MESSAGE_OPERATIONSUCCESSFULLY);
                return await CommandInteractorBasicServiceResponseAsync(successfulCommandCollectorResponse);
            }
            catch (Exception e)
            {
                var exceptionCollectorResponse = await CommandInteractorExceptionBasicCollectorAsync(affectedRecords, executedCommandSuccesfulFlag, 1500, e.HResult, e.Source!);
                return await CommandInteractorBasicServiceResponseAsync(exceptionCollectorResponse);
            }
            
        }
    }
}
