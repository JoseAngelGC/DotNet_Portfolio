using AutoMapper;
using POS.Application.Interfaces.CategoryServices.Queries.GetItem;
using POS.Application.Validators.Commons.Queries.GetItemById;
using POS.Infraestructure.Helpers.Application.Commons.Hubs;
using POS.Infraestructure.SupportDtos.Application.Commons.MappersDtos;
using POS.Infraestructure.SupportDtos.Application.Commons.ResponsesDtos;
using POS.Infraestructure.SupportDtos.Application.EntitiesDtos.CategoryEntityDtos;
using POS.Infraestructure.SupportDtos.Application.RequestsDtos.Commons;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;
using POS.Interactor.Interfaces.InteractorServices.CategoryInteractors.Queries.GetItem;


namespace POS.Application.Services.CategoryServices.Queries.GetItem
{
    public class CategoryByIdApplicationService : QueryApplicationBasicHelpersHub, ICategoryByIdApplicationService
    {
        private readonly ICategoryByIdInteractor _categoryByIdInteractor;
        private readonly IdParamRequestDtoValidator _getIdParamRequestDtoValidator;
        private readonly IMapper _mapper;
        public CategoryByIdApplicationService(ICategoryByIdInteractor categoryByIdInteractor, IMapper mapper, IdParamRequestDtoValidator getIdParamRequestDtoValidator)
        {
            _categoryByIdInteractor = categoryByIdInteractor;
            _getIdParamRequestDtoValidator = getIdParamRequestDtoValidator;
            _mapper = mapper;
            
        }

        public async Task<GenericQueryApplicationResponseDto<CategoryDto>> GetItemAsync(int id)
        {
            try
            {
                SingleParamRequestDto paramRequestDto = new()
                {
                    Id = id
                };

                var validationResult = await _getIdParamRequestDtoValidator.ValidateAsync(paramRequestDto);
                if (!validationResult.IsValid)
                {
                    return await QueryApplicationValidationErrorsBasicCustomResponseAsync<CategoryDto>(validationResult.Errors);
                }

                QueryApplicationCollectorEntity<CategoryDto> successQueryCollector = new();
                var interactorResponse = await _categoryByIdInteractor.GetItemAsync(id);
                if (interactorResponse.Items is null && interactorResponse.IsSuccess == false)
                {
                    var errorsCollectorResponse = await QueryApplicationInteractorErrorBasicCollectorAsync<CategoryDto>(interactorResponse.IsSuccess, interactorResponse.ControlMessage, interactorResponse.CustomErrorCode);
                    return await QueryApplicationBasicServiceResponseAsync(errorsCollectorResponse);
                }

                if (interactorResponse.Items is null && interactorResponse.IsSuccess == true)
                {
                    var notFoundCollectorResponse = await QueryApplicationNotFoundBasicCollectorAsync<CategoryDto>(interactorResponse.IsSuccess, interactorResponse.Records, interactorResponse.ControlMessage);
                    return await QueryApplicationBasicServiceResponseAsync(notFoundCollectorResponse);
                }

                if (interactorResponse.Items is not null && interactorResponse.IsSuccess == true)
                {
                    var mapperCategoryDto = _mapper.Map<GenericMapperDto<CategoryDto>>(interactorResponse);
                    successQueryCollector = await QueryApplicationSuccessfulBasicCollectorAsync(mapperCategoryDto);
                }

                return await QueryApplicationBasicServiceResponseAsync(successQueryCollector);
            }
            catch (Exception e)
            {
                var exceptionCollectorResponse = await QueryApplicationExceptionBasicCollectorAsync<CategoryDto>(2300, e.Message, e.HResult, e.Source);
                return await QueryApplicationBasicServiceResponseAsync(exceptionCollectorResponse);
            }

        }
    }
}
