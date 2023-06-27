using AutoMapper;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.RequestDtos;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.ServiceResponses.Commands;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationHelpers.HelpersHubs.Commands;
using StoreBasicCRUD.ApplicationServices.Interfaces.ProductsServices.Commands;
using StoreBasicCRUD.ApplicationServices.Validators.Products;
using StoreBasicCRUD.Persistence_SQLServer.Interfaces.IUnitsOfWork;
using StoreBasicCRUD.SQLServer_Entities.EFCore.DataBaseFirst.Entities;
using StoreBasicCRUD.Utilities.Shared.Consts;

namespace StoreBasicCRUD.ApplicationServices.Services.Products.Commands
{
    public class SaveProductService : ApplicationCommandBasicHelpersHub, ISaveProductService
    {
        private readonly IProductsUnitOfWork<Product> _productsUnitOfWork;
        private readonly IMapper _mapper;
        private readonly ProductRequestDtoValidator _productRequestDtoValidator;
        public SaveProductService(IProductsUnitOfWork<Product> productsUnitOfWork, IMapper mapper, ProductRequestDtoValidator productRequestDtoValidator)
        {
            _productsUnitOfWork = productsUnitOfWork;
            _mapper = mapper;
            _productRequestDtoValidator = productRequestDtoValidator;
        }
        public async Task<ApplicationServiceCommandResponseDto> ResponseAsync(ProductRequestDto requestDto)
        {
            try
            {
                //Request validators
                var validationResult = await _productRequestDtoValidator.ValidateAsync(requestDto);
                if (!validationResult.IsValid)
                {
                    //Validators errors custom response
                    return await BasicCollectorCommandValidatorErrorsAsync(validationResult.Errors);

                }

                var existProduct = await _productsUnitOfWork.ExistProductRepository.ResponseAsync(requestDto.Nombre, requestDto.IdCategory);
                if (existProduct)
                {
                    var existCollectorResponse = await BasicCollectorCommandExistItemAsync();
                    return await CommandServiceResponseAsync(existCollectorResponse);
                }

                var productMapper = _mapper.Map<Product>(requestDto);
                var saveProductResponse = await _productsUnitOfWork.SaveProductRepository.ResponseAsync(productMapper);
                if (saveProductResponse == 0)
                {
                    var errorCollectorResponse = await BasicCollectorCommandErrorAsync();
                    return await CommandServiceResponseAsync(errorCollectorResponse);
                }

                var successCollectorResponse = await BasicCollectorCommandSuccessfulAsync(saveProductResponse, ReplyMessage.MESSAGE_SAVE);
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
