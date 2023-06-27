using AutoMapper;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.EntitiesDtos;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.Requests;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.ServiceResponses.Queries;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.HelpersHubs.Queries;
using StoreBasicCRUD.ApplicationServices.Interfaces.ProductsServices.Queries;
using StoreBasicCRUD.Persistence_SQLServer.Interfaces.IUnitsOfWork;
using StoreBasicCRUD.SQLServer_Entities.EFCore.DataBaseFirst.Entities;

namespace StoreBasicCRUD.ApplicationServices.Services.Products.Queries
{
    public class GetAllProductsService : ApplicationQueryBasicHelpersHub, IGetAllProductsService
    {
        private readonly IProductsUnitOfWork<Product> _productsUnitOfWork;
        private readonly IMapper _mapper;
        public GetAllProductsService(IProductsUnitOfWork<Product> productsUnitOfWork, IMapper mapper)
        {
            _productsUnitOfWork = productsUnitOfWork;
            _mapper = mapper;
        }
        public async Task<ApplicationServiceQueryResponseDto<List<ProductDto>>> ResponseAsync(CommonFiltersRequestDto filtersRequestDto)
        {
            try
            {
                //Get Data
                var queryableDataRepositoryResponse = await _productsUnitOfWork.GetProductsRepository.ResponsesAsync();

                //Filter Data
                var filteredDataResponse = await BasicCollectorQueryFilterDataAsync(filtersRequestDto, queryableDataRepositoryResponse);

                //Organizate(Sort and paginate) Data
                var orderedPaginatedDataResponse = await BasicCollectorQueryOrganizateDataAsync(filtersRequestDto, filteredDataResponse);

                //Mapping Data to Service response DTO
                var mapperResponse = _mapper.Map<ApplicationServiceQueryResponseDto<List<ProductDto>>>(orderedPaginatedDataResponse);

                return await Task.FromResult(mapperResponse);
            }
            catch (Exception e)
            {
                var exceptionCollectorResponse = await BasicCollectorQueryExceptionAsync<List<ProductDto>>(e.Message, e.HResult, e.Source);
                return await QueryServiceResponseAsync(exceptionCollectorResponse);
            }
        }
    }
}
