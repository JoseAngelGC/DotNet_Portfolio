using AutoMapper;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.PivotsDtos;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.RequestDtos;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Commands;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.HelpersHubs.Commands;
using StoreBasicCRUD.ApplicationServices.Interfaces.ProductsServices;
using StoreBasicCRUD.ApplicationServices.Validators.Products;
using StoreBasicCRUD.Persistence_SQLServer.Interfaces.IUnitsOfWork;
using StoreBasicCRUD.SQLServer_Entities.EFCore.DataBaseFirst.Entities;
using StoreBasicCRUD.Utilities.Shared.Consts;

namespace StoreBasicCRUD.ApplicationServices.Services.Products
{
    public class UpdateProductService : ApplicationCommandBasicHelpersHub, IUpdateProductService
    {
        private readonly IProductsUnitOfWork<Product> _productsUnitOfWork;
        private readonly IMapper _mapper;
        private readonly ProductPivotDtoValidator _productPivotDtoValidator;
        public UpdateProductService(IProductsUnitOfWork<Product> productsUnitOfWork, IMapper mapper, ProductPivotDtoValidator productPivotDtoValidator)
        {
            _productsUnitOfWork = productsUnitOfWork;
            _mapper = mapper;
            _productPivotDtoValidator = productPivotDtoValidator;
        }
        public async Task<ApplicationServiceCommandResponseEntity> ResponseAsync(int id, ProductRequestDto requestDto)
        {
            try
            {
                var productPivotMapper = _mapper.Map<ProductPivotDto>(requestDto);
                productPivotMapper.IdProduct= id;

                //Request validators
                var validationResult = await _productPivotDtoValidator.ValidateAsync(productPivotMapper);
                if (!validationResult.IsValid)
                {
                    //Validators errors custom response
                    return await BasicCollectorCommandValidatorErrorsAsync(validationResult.Errors);

                }

                var existProduct = await _productsUnitOfWork.ExistProductRepository.ResponseAsync(id);
                if (!existProduct)
                {
                    var notExistCollectorResponse = await BasicCollectorCommandNotExistAsync();
                    return await CommandServiceResponseAsync(notExistCollectorResponse);
                }

                var productMapper = _mapper.Map<Product>(requestDto);
                productMapper.IdProduct = id;
                var updateProductResponse = await _productsUnitOfWork.UpdateProductRepository.ResponseAsync(productMapper);
                if (updateProductResponse == 0)
                {
                    var errorCollectorResponse = await BasicCollectorCommandErrorAsync();
                    return await CommandServiceResponseAsync(errorCollectorResponse);
                }

                var successCollectorResponse = await BasicCollectorCommandSuccessfulAsync(updateProductResponse, ReplyMessage.MESSAGE_UPDATE);
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
