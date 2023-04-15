using AutoMapper;
using POS.Application.Interfaces.CategoryServices.Commands.RemoveItem;
using POS.Application.Validators.CategoryValidators.Commands.Commons;
using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.Helpers.Application.Commons.Hubs;
using POS.Infraestructure.SupportDtos.Application.Commons.ResponsesDtos;
using POS.Infraestructure.SupportDtos.Application.RequestsDtos.CategoryRequestsDtos;
using POS.Interactor.Interfaces.InteractorServices.CategoryInteractors.Commands.RemoveItem;
using POS.Utilities.Commons.Consts;

namespace POS.Application.Services.CategoryServices.Commands.RemoveItem
{
    public class DeleteCategoryApplicationService : CommandApplicationBasicHelpersHub, IDeleteCategoryApplication
    {
        private readonly IDeleteCategoryInteractor _deleteCategoryInteractor;
        private readonly CategoryRequesPlusDtoValidator _categoryRequestWithIdDtoValidator;
        private readonly IMapper _mapper;
        private bool isSuccessFlag = false;
        private int? affectedRecords;
        public DeleteCategoryApplicationService(IDeleteCategoryInteractor deleteCategoryInteractor, CategoryRequesPlusDtoValidator categoryRequestWithIdDtoValidator, IMapper mapper)
        {
            _deleteCategoryInteractor = deleteCategoryInteractor;
            _categoryRequestWithIdDtoValidator = categoryRequestWithIdDtoValidator;
            _mapper = mapper;
            isSuccessFlag = false;
            affectedRecords = 0;

        }
        public async Task<CommandApplicationResponseDto> RemoveItemAsync(int id, CategoryRequestDto categoryRequestDto)
        {
            try
            {
                CategoryRequestWithIdDto categoryRequestWithIdDto = new()
                {
                    Id = id,
                    Name = categoryRequestDto.Name,
                    Description = categoryRequestDto.Description,
                    State = categoryRequestDto.State
                };

                var validationResult = await _categoryRequestWithIdDtoValidator.ValidateAsync(categoryRequestWithIdDto);
                if (!validationResult.IsValid)
                {
                    return await CommandApplicationValidationErrorsBasicCustomResponseAsync(validationResult.Errors);
                }

                var dirtyDescriptionProperty = categoryRequestWithIdDto.Description!.TrimStart().TrimEnd();
                categoryRequestWithIdDto.Description = dirtyDescriptionProperty;
                var mapperCategoryEntity = _mapper.Map<Category>(categoryRequestWithIdDto);
                var removeItemResponse = await _deleteCategoryInteractor.RemoveItemAsync(mapperCategoryEntity);
                isSuccessFlag = removeItemResponse.IsSuccess;
                affectedRecords = removeItemResponse.AffectedRecords;

                var collectorCommandResponse = await CommandApplicationBuildResponseTypeBasicCollectorAsync(removeItemResponse, ReplyMessage.MESSAGE_DELETE);
                return await CommandApplicationBasicServiceResponseAsync(collectorCommandResponse);
            }
            catch (Exception)
            {
                var collectorExceptionResponse = await CommandApplicationExceptionBasicCollectorAsync(affectedRecords, 6200, isSuccessFlag);
                return await CommandApplicationBasicServiceResponseAsync(collectorExceptionResponse);
            } 
        }

    }
}
