using AutoMapper;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Categories.EntitiesDtos;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.ServiceResponses.Queries;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.HelpersHubs.Queries;
using StoreBasicCRUD.ApplicationServices.Interfaces.CategoryServices.Queries;
using StoreBasicCRUD.Persistence_SQLServer.Interfaces.IUnitsOfWork;
using StoreBasicCRUD.SQLServer_Entities.EFCore.DataBaseFirst.Entities;

namespace StoreBasicCRUD.ApplicationServices.Services.Categories.Queries
{
    public class GetAllCategoriesService : ApplicationQueryBasicHelpersHub, IGetAllCategoriesService
    {
        private readonly ICategoriesUnitOfWork<Category> _categoriesUnitOfWork;
        private readonly IMapper _mapper;
        public GetAllCategoriesService(ICategoriesUnitOfWork<Category> categorieUnitOfWork, IMapper mapper)
        {
            _categoriesUnitOfWork = categorieUnitOfWork;
            _mapper = mapper;
        }
        public async Task<ApplicationServiceQueryResponseDto<List<CategoryDto>>> ResponseAsync()
        {
            try
            {
                var respositoryResponse = await _categoriesUnitOfWork.GetCategoriesRepository.ResponsesAsync();
                if (respositoryResponse is null)
                {
                    //response not found
                }

                var successCollectorResponse = await BasicCollectorQuerySuccessfulAsync(respositoryResponse);
                successCollectorResponse.TotalRecords = successCollectorResponse.Data!.Count;

                var mapperResponse = _mapper.Map<ApplicationServiceQueryResponseDto<List<CategoryDto>>>(successCollectorResponse);

                return await Task.FromResult(mapperResponse);
            }
            catch (Exception e)
            {
                var exceptionCollectorResponse = await BasicCollectorQueryExceptionAsync<List<CategoryDto>>(e.Message, e.HResult, e.Source);
                return await QueryServiceResponseAsync(exceptionCollectorResponse);
            }
        }
    }
}
