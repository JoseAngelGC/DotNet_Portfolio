using AutoMapper;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Categories.EntitiesDtos;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Queries;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.HelpersHubs.Queries;
using StoreBasicCRUD.ApplicationServices.Interfaces.CategoryServices;
using StoreBasicCRUD.Persistence_SQLServer.Interfaces.IUnitsOfWork;
using StoreBasicCRUD.SQLServer_Entities.EFCore.DataBaseFirst.Entities;

namespace StoreBasicCRUD.ApplicationServices.Services.Categories
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
        public async Task<ApplicationServiceQueryResponseEntity<List<CategoryDto>>> ResponseAsync()
        {
            try
            {
                var respositoryResponse = await _categoriesUnitOfWork.GetCategoriesRepository.ResponsesAsync();
                var successCollectorResponse = await BasicCollectorQuerySuccessfulAsync(respositoryResponse);
                var mapperResponse = _mapper.Map<ApplicationServiceQueryResponseEntity<List<CategoryDto>>>(successCollectorResponse);
                
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
