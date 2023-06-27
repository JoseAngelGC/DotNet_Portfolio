using AutoMapper;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.EntitiesDtos;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.ServiceResponses.Queries;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.HelpersHubs.Queries;
using StoreBasicCRUD.ApplicationServices.Interfaces.ProductsServices.Queries;
using StoreBasicCRUD.Persistence_SQLServer.Interfaces.IUnitsOfWork;
using StoreBasicCRUD.SQLServer_Entities.EFCore.DataBaseFirst.Entities;

namespace StoreBasicCRUD.ApplicationServices.Services.Products.Queries
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
        public async Task<ApplicationServiceQueryResponseDto<ProductDto>> ResponseAsync(int productId)
        {
            try
            {
                var respositoryResponse = await _productsUnitOfWork.GetProductRepository.ResponsesAsync(productId);
                if (respositoryResponse is null)
                {
                    //response not found
                }

                var successCollectorResponse = await BasicCollectorQuerySuccessfulAsync(respositoryResponse);
                successCollectorResponse.TotalRecords = 1;
                
                var mapperResponse = _mapper.Map<ApplicationServiceQueryResponseDto<ProductDto>>(successCollectorResponse);

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
