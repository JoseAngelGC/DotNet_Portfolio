using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.Helpers.Interactors.Commons.Hubs;
using POS.Infraestructure.SupportDtos.Interactors.Commons.Responses;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Interactors;
using POS.Interactor.Interfaces.InteractorServices.CategoryInteractors.Commands.RemoveItem;
using POS.Persistence.Interfaces.UnitsOfWork.CategoryUnitsOfWork;
using POS.Utilities.Commons.Consts;

namespace POS.Interactor.InteractorServices.CategoryInteractors.Commands.RemoveItem
{
    public class DeleteCategoryInteractorService : CommandInteractorBasicHelpersHub, IDeleteCategoryInteractor
    {
        private readonly ICategoryRepositoryCommandsUnitsOfWork<Category> _categoryCommandsUnitsOfWork;
        private bool executedCommandSuccesfulFlag;
        private int? affectedRecords;
        public DeleteCategoryInteractorService(ICategoryRepositoryCommandsUnitsOfWork<Category> categoryCommandsUnitsOfWork)
        {
            _categoryCommandsUnitsOfWork = categoryCommandsUnitsOfWork;
            executedCommandSuccesfulFlag = false;
            affectedRecords = 0;
        }
        public async Task<CommandInteractorResponseDto> RemoveItemAsync(Category entityItem)
        {
            try
            {
                CommandInteractorCollectorEntity commandInteractorCollectorResponse = new();

                var categoryItemExistById = await _categoryCommandsUnitsOfWork.ExistCategoryItemById.ResponseAsync(entityItem.Id);
                var categoryItemExistByName = await _categoryCommandsUnitsOfWork.ExistCategoryItemByName.GetItemAsync(entityItem.Name!);
                if ((categoryItemExistById == false) || (categoryItemExistByName == false))
                {
                    var existItemCollectorResponse = await CommandInteractorExistItemBasicCollectorAsync(false);
                    return await CommandInteractorBasicServiceResponseAsync(existItemCollectorResponse);
                }

                if ((categoryItemExistById == true) || (categoryItemExistByName == true))
                {
                    var removeItemResponse = await _categoryCommandsUnitsOfWork.GenericRemoveEntityItem.RemoveItemAsync(entityItem);
                    executedCommandSuccesfulFlag = removeItemResponse.IsSuccess;
                    affectedRecords = removeItemResponse.RecordsAffected;

                    if (removeItemResponse.IsSuccess == false)
                    {
                        var exceptionCollectorResponse = await CommandInteractorExceptionBasicCollectorAsync(affectedRecords, executedCommandSuccesfulFlag, 1610, removeItemResponse.HResultException, removeItemResponse.SourceException!);
                        return await CommandInteractorBasicServiceResponseAsync(exceptionCollectorResponse);
                    }

                    commandInteractorCollectorResponse = await CommandInteractorSuccessfulBasicCollectorAsync(removeItemResponse.IsSuccess, removeItemResponse.RecordsAffected, ControlEvent.MESSAGE_OPERATIONSUCCESSFULLY);
                }

                return await CommandInteractorBasicServiceResponseAsync(commandInteractorCollectorResponse);
            }
            catch (Exception e)
            {
                var exceptionCollectorResponse = await CommandInteractorExceptionBasicCollectorAsync(affectedRecords,executedCommandSuccesfulFlag, 1600, e.HResult, e.Source!);
                return await CommandInteractorBasicServiceResponseAsync(exceptionCollectorResponse);
            }
            
        }
    }
}
