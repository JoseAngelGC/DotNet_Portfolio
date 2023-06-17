using AutoMapper;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.EntitiesDtos;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Queries;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.HelpersHubs.Queries;
using StoreBasicCRUD.ApplicationServices.Interfaces.ProductsServices;
using StoreBasicCRUD.Persistence_SQLServer.Interfaces.IUnitsOfWork;
using StoreBasicCRUD.SQLServer_Entities.EFCore.DataBaseFirst.Entities;

namespace StoreBasicCRUD.ApplicationServices.Services.Products
{
    public class GetProductByIdService : ApplicationQueryBasicHelpersHub, IGetProductByIdService
    {
        private readonly IProductsUnitOfWork<Product> _productsUnitOfWork;
        private readonly IMapper _mapper;
        public GetProductByIdService(IProductsUnitOfWork<Product> productsUnitOfWork, IMapper mapper)
        {
            _productsUnitOfWork = productsUnitOfWork;
            _mapper = mapper;
        }
        public async Task<ApplicationServiceQueryResponseEntity<ProductDto>> ResponseAsync(int productId)
        {
            try
            {
                var respositoryResponse = await _productsUnitOfWork.GetProductRepository.ResponsesAsync(productId);
                var successCollectorResponse = await BasicCollectorQuerySuccessfulAsync(respositoryResponse);
                var mapperResponse = _mapper.Map<ApplicationServiceQueryResponseEntity<ProductDto>>(successCollectorResponse);

                return await Task.FromResult(mapperResponse);
            }
            catch (Exception e)
            {
                var exceptionCollectorResponse = await BasicCollectorQueryExceptionAsync<ProductDto>(e.Message, e.HResult, e.Source);
                return await QueryServiceResponseAsync(exceptionCollectorResponse);
            }
        }
    }
}
