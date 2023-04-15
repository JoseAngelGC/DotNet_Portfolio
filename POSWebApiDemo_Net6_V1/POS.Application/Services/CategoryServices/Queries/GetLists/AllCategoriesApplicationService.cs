using AutoMapper;
using POS.Application.Interfaces.CategoryServices.Queries.GetLists;
using POS.Infraestructure.Helpers.Application.Commons.Hubs;
using POS.Infraestructure.SupportDtos.Application.Commons.MappersDtos;
using POS.Infraestructure.SupportDtos.Application.Commons.ResponsesDtos;
using POS.Infraestructure.SupportDtos.Application.EntitiesDtos.CategoryEntityDtos;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;
using POS.Interactor.Interfaces.InteractorServices.CategoryInteractors.Queries.GetLists;


namespace POS.Application.Services.CategoryServices.Queries.GetLists
{
    public class AllCategoriesApplicationService : QueryApplicationBasicHelpersHub, IAllCategoriesApplicationService
    {
        private readonly IAllCategoriesInteractor _allCategoriesInteractor;
        private readonly IMapper _mapper;
        public AllCategoriesApplicationService(IAllCategoriesInteractor allCategoriesInteractor, IMapper mapper)
        {
            _allCategoriesInteractor = allCategoriesInteractor;
            _mapper = mapper;
        }

        public async Task<GenericQueryApplicationResponseDto<IEnumerable<CategorySelectDto>>> GetItemsAsync()
        {
            try
            {
                QueryApplicationCollectorEntity<IEnumerable<CategorySelectDto>> successQueryCollector = new();
                var interactorResponse = await _allCategoriesInteractor.GetItemsAsync();
                if (interactorResponse.Items is null && interactorResponse.IsSuccess == false)
                {
                    var errorsCollectorResponse = await QueryApplicationInteractorErrorBasicCollectorAsync<IEnumerable<CategorySelectDto>>(interactorResponse.IsSuccess, interactorResponse.ControlMessage, interactorResponse.CustomErrorCode);
                    return await QueryApplicationBasicServiceResponseAsync(errorsCollectorResponse);
                }

                if (interactorResponse.Items is null && interactorResponse.IsSuccess == true)
                {
                    var notFoundCollectorResponse = await QueryApplicationNotFoundBasicCollectorAsync<IEnumerable<CategorySelectDto>>(interactorResponse.IsSuccess, interactorResponse.Records, interactorResponse.ControlMessage);
                    return await QueryApplicationBasicServiceResponseAsync(notFoundCollectorResponse);
                }

                if (interactorResponse.Items is not null && interactorResponse.IsSuccess == true)
                {
                    var mapperCategoryDto = _mapper.Map<GenericMapperDto<IEnumerable<CategorySelectDto>>>(interactorResponse);
                    successQueryCollector = await QueryApplicationSuccessfulBasicCollectorAsync(mapperCategoryDto);
                }

                return await QueryApplicationBasicServiceResponseAsync(successQueryCollector);
            }
            catch (Exception e)
            {
                var exceptionCollectorResponse = await QueryApplicationExceptionBasicCollectorAsync<IEnumerable<CategorySelectDto>>(2200, e.Message, e.HResult, e.Source);
                return await QueryApplicationBasicServiceResponseAsync(exceptionCollectorResponse);
            }
            
        }
    }
}
