using AutoMapper;
using POS.Application.Interfaces.CategoryServices.Queries.GetLists;
using POS.Application.Validators.Commons.Queries.GetFilteredList;
using POS.Infraestructure.Helpers.Application.Commons.Hubs;
using POS.Infraestructure.SupportDtos.Application.Commons.MappersDtos;
using POS.Infraestructure.SupportDtos.Application.Commons.ResponsesDtos;
using POS.Infraestructure.SupportDtos.Application.EntitiesDtos.CategoryEntityDtos;
using POS.Infraestructure.SupportDtos.Commons.Requests;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;
using POS.Interactor.Interfaces.InteractorServices.CategoryInteractors.Queries.GetLists;

namespace POS.Application.Services.CategoryServices.Queries.GetLists
{
    internal class FilteredCategoriesApplicationService : QueryApplicationBasicHelpersHub, IFilteredCategoriesApplicationService
    {
        private readonly IFilteredCategoriesInteractor _filteredCategoriesInteractor;
        private readonly GenericFiltersRequestDtoValidator _genericFiltersRequestDtoValidatorRules;
        private readonly IMapper _mapper;
        public FilteredCategoriesApplicationService(IFilteredCategoriesInteractor filteredCategoriesInteractor, IMapper mapper, GenericFiltersRequestDtoValidator genericFiltersRequestDtoValidatorRules)
        {
            _filteredCategoriesInteractor = filteredCategoriesInteractor;
            _genericFiltersRequestDtoValidatorRules = genericFiltersRequestDtoValidatorRules;
            _mapper = mapper;
            
        }
        public async Task<GenericQueryApplicationResponseDto<List<CategoryDto>>> GetListAsync(GenericFiltersRequestDto filtersRequest)
        {
            try
            {
                var validationResult = await _genericFiltersRequestDtoValidatorRules.ValidateAsync(filtersRequest);
                if (!validationResult.IsValid)
                {
                    return await QueryApplicationValidationErrorsBasicCustomResponseAsync<List<CategoryDto>>(validationResult.Errors);
                }

                QueryApplicationCollectorEntity<List<CategoryDto>> successfulQueryCollector = new();
                var interactorResponse = await _filteredCategoriesInteractor.GetListAsync(filtersRequest);
                if (interactorResponse.Items is null)
                {
                    switch (interactorResponse.IsSuccess)
                    {
                        case false:
                            var interactorErrorCollectorResponse = await QueryApplicationInteractorErrorBasicCollectorAsync<List<CategoryDto>>(interactorResponse.IsSuccess, interactorResponse.ControlMessage, interactorResponse.CustomErrorCode);
                            return await QueryApplicationBasicServiceResponseAsync(interactorErrorCollectorResponse);

                        case true:
                            var notFoundCollectorResponse = await QueryApplicationNotFoundBasicCollectorAsync<List<CategoryDto>>(interactorResponse.IsSuccess, interactorResponse.Records, interactorResponse.ControlMessage);
                            return await QueryApplicationBasicServiceResponseAsync(notFoundCollectorResponse);
                    }
                }

                if (interactorResponse.Items is not null && interactorResponse.IsSuccess == true)
                {
                    var mapperCategoryDto = _mapper.Map<GenericMapperDto<List<CategoryDto>>>(interactorResponse);
                    successfulQueryCollector = await QueryApplicationSuccessfulBasicCollectorAsync(mapperCategoryDto);
                }

                return await QueryApplicationBasicServiceResponseAsync(successfulQueryCollector);
            }
            catch (Exception e)
            {
                var exceptionCollectorResponse = await QueryApplicationExceptionBasicCollectorAsync<List<CategoryDto>>(2100, e.Message, e.HResult, e.Source);
                return await QueryApplicationBasicServiceResponseAsync(exceptionCollectorResponse);
            }
        }

    }
}
