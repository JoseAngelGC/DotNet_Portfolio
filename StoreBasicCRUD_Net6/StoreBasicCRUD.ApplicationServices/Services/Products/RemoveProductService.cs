using AutoMapper;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.RequestDtos;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Commands;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.HelpersHubs.Commands;
using StoreBasicCRUD.ApplicationServices.Interfaces.ProductsServices;
using StoreBasicCRUD.Persistence_SQLServer.Interfaces.IUnitsOfWork;
using StoreBasicCRUD.SQLServer_Entities.EFCore.DataBaseFirst.Entities;
using StoreBasicCRUD.Utilities.Shared.Consts;

namespace StoreBasicCRUD.ApplicationServices.Services.Products
{
    public class RemoveProductService : ApplicationCommandBasicHelpersHub, IRemoveProductService
    {
        private readonly IProductsUnitOfWork<Product> _productsUnitOfWork;
        private readonly IMapper _mapper;
        public RemoveProductService(IProductsUnitOfWork<Product> productsUnitOfWork, IMapper mapper)
        {
            _productsUnitOfWork = productsUnitOfWork;
            _mapper = mapper;
        }
        public async Task<ApplicationServiceCommandResponseEntity> ResponseAsync(int id)
        {
            try
            {
                var existProductResponse = await _productsUnitOfWork.ExistProductRepository.ResponseAsync(id);
                if (!existProductResponse)
                {
                    var notExistCollectorResponse = await BasicCollectorCommandNotExistAsync();
                    return await CommandServiceResponseAsync(notExistCollectorResponse);
                }

                var getProductByIdResponse = await _productsUnitOfWork.GetProductRepository.ResponsesAsync(id);

                var removeProductResponse = await _productsUnitOfWork.RemoveProductRepository.ResponseAsync(getProductByIdResponse);
                if (removeProductResponse == 0)
                {
                    var errorCollectorResponse = await BasicCollectorCommandErrorAsync();
                    return await CommandServiceResponseAsync(errorCollectorResponse);
                }

                var successCollectorResponse = await BasicCollectorCommandSuccessfulAsync(removeProductResponse, ReplyMessage.MESSAGE_DELETE);
                return await CommandServiceResponseAsync(successCollectorResponse);
            }
            catch (Exception e)
            {
                var exceptionCollectorResponse = await BasicCollectorCommandExceptionAsync(e.Message, e.HResult, e.Source);
                return await CommandServiceResponseAsync(exceptionCollectorResponse);
            }
        }
    }
}
