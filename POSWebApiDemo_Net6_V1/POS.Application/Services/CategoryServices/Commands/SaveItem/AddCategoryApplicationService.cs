using AutoMapper;
using POS.Application.Interfaces.CategoryServices.Commands.SaveItem;
using POS.Application.Validators.CategoryValidators.Commands.SaveItemRequests;
using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;
using POS.Infraestructure.Helpers.Application.Commons.Hubs;
using POS.Infraestructure.SupportDtos.Application.Commons.ResponsesDtos;
using POS.Infraestructure.SupportDtos.Application.RequestsDtos.CategoryRequestsDtos;
using POS.Interactor.Interfaces.InteractorServices.CategoryInteractors.Commands.SaveItem;
using POS.Utilities.Commons.Consts;

namespace POS.Application.Services.CategoryServices.Commands.SaveItem
{
    public class AddCategoryApplicationService : CommandApplicationBasicHelpersHub, IAddCategoryApplicationServices
    {
        private readonly IAddCategoryInteractor _addCategoryInteractor;
        private readonly CategoryRequestDtoValidator _categoryRequestValidatorRules;
        private readonly IMapper _mapper;
        private bool isSuccessFlag;
        private int? affectedRecords;

        public AddCategoryApplicationService(IAddCategoryInteractor addCategoryInteractor, CategoryRequestDtoValidator categoryRequestValidatorRules, IMapper mapper)
        {
            _addCategoryInteractor = addCategoryInteractor;
            _categoryRequestValidatorRules = categoryRequestValidatorRules;
            _mapper = mapper;
            isSuccessFlag = false;
            affectedRecords = 0;
        }

        public async Task<CommandApplicationResponseDto> SaveItemAsync(CategoryRequestDto categoryRequestDto)
        {
            try
            {
                var validationResult = await _categoryRequestValidatorRules.ValidateAsync(categoryRequestDto);
                if (!validationResult.IsValid) 
                {
                    return await CommandApplicationValidationErrorsBasicCustomResponseAsync(validationResult.Errors);
                }

                var cleaningDescriptionProperty = categoryRequestDto.Description!.TrimStart().TrimEnd();
                categoryRequestDto.Description = cleaningDescriptionProperty;
                var mapperCategoryEntity = _mapper.Map<Category>(categoryRequestDto);
                var saveItemResponse = await _addCategoryInteractor.SaveItemAsync(mapperCategoryEntity);
                isSuccessFlag = saveItemResponse.IsSuccess;
                affectedRecords = saveItemResponse.AffectedRecords;

                var collectorCommandResponse = await CommandApplicationBuildResponseTypeBasicCollectorAsync(saveItemResponse, ReplyMessage.MESSAGE_SAVE);
                return await CommandApplicationBasicServiceResponseAsync(collectorCommandResponse);
            }
            catch (Exception)
            {
                var collectorExceptionResponse = await CommandApplicationExceptionBasicCollectorAsync(affectedRecords, 4200, isSuccessFlag);
                return await CommandApplicationBasicServiceResponseAsync(collectorExceptionResponse);
            }

        }

    }
}
