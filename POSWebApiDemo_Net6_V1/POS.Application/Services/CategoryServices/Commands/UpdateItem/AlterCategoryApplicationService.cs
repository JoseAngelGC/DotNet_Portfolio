using AutoMapper;
using POS.Application.Interfaces.CategoryServices.Commands.UpdateItem;
using POS.Application.Validators.CategoryValidators.Commands.Commons;
using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.Helpers.Application.Commons.Hubs;
using POS.Infraestructure.SupportDtos.Application.Commons.ResponsesDtos;
using POS.Infraestructure.SupportDtos.Application.RequestsDtos.CategoryRequestsDtos;
using POS.Interactor.Interfaces.InteractorServices.CategoryInteractors.Commands.UpdateItem;
using POS.Utilities.Commons.Consts;

namespace POS.Application.Services.CategoryServices.Commands.UpdateItem
{
    public class AlterCategoryApplicationService : CommandApplicationBasicHelpersHub, IAlterCategoryApplicationServices
    {
        private readonly IAlterCategoryInteractor _alterCategoryInteractor;
        private readonly CategoryRequesPlusDtoValidator _categoryRequestWithIdDtoValidator;
        private readonly IMapper _mapper;
        private bool isSuccessFlag = false;
        private int? affectedRecords;
        public AlterCategoryApplicationService(IAlterCategoryInteractor alterCategoryInteractor, CategoryRequesPlusDtoValidator categoryRequestWithIdDtoValidator, IMapper mapper)
        {
            _alterCategoryInteractor = alterCategoryInteractor;
            _categoryRequestWithIdDtoValidator = categoryRequestWithIdDtoValidator;
            _mapper = mapper;
            isSuccessFlag = false;
            affectedRecords = 0;
        }
        public async Task<CommandApplicationResponseDto> UpdateItemAsync(int id, CategoryRequestDto categoryRequestDto)
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
                var updateItemResponse = await _alterCategoryInteractor.UpdateItemAsync(mapperCategoryEntity);
                isSuccessFlag = updateItemResponse.IsSuccess;
                affectedRecords = updateItemResponse.AffectedRecords;

                var collectorCommandResponse = await CommandApplicationBuildResponseTypeBasicCollectorAsync(updateItemResponse, ReplyMessage.MESSAGE_UPDATE);
                return await CommandApplicationBasicServiceResponseAsync(collectorCommandResponse);
            }
            catch (Exception)
            {
                var collectorExceptionResponse = await CommandApplicationExceptionBasicCollectorAsync(affectedRecords, 5200, isSuccessFlag);
                return await CommandApplicationBasicServiceResponseAsync(collectorExceptionResponse);
            }
        }

    }
}
