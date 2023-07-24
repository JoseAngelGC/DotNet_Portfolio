using ApiCrudWithBlazor.ApplicationServices.Validators.ProductValidator;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ProductDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.RequestsDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;
using ApiCrudWithBlazor.CoreAbstractions.InputPorts;
using ApiCrudWithBlazor.CoreAbstractions.OutputPorts;
using ApiCrudWithBlazor.CoreAbstractions.UseCases.ProductUseCases;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore;
using AutoMapper;

namespace ApiCrudWithBlazor.ApplicationServices.InputPortsServices
{
    public class ProductInputPortsService : IProductInputPortsService
    {
        private readonly IFilteredProductsUseCase<Product> _filteredProductsUseCase;
        private readonly IShowProductUseCase<Product> _showProductUseCase;
        private readonly INewProductRegisterUseCase<Product> _newProductRegisterUseCase;
        private readonly IProductEditUseCase<Product> _editProductUseCase;
        private readonly IProductDeleteUseCase<Product> _deleteProductUseCase;
        private readonly ProductRequestDtoValidator _productRequestDtoValidator;
        private readonly ProductRequestPivotDtoValidator _productRequestPivotDtoValidator;
        private readonly ProductFiltersRequestDtoValidator _productFiltersRequestDtoValidator;
        private readonly IResponsesOutputPortsBasicHelpersHub _responsesOutputPortsBasicHelpersHub;
        private readonly IMapper _mapper;

        public ProductInputPortsService(IFilteredProductsUseCase<Product> filteredProductsUseCase, IShowProductUseCase<Product> showProductUseCase, INewProductRegisterUseCase<Product> newProductRegisterUseCase, IProductEditUseCase<Product> editProductUseCase, IProductDeleteUseCase<Product> deleteProductUseCase, ProductRequestDtoValidator productRequestDtoValidator, ProductRequestPivotDtoValidator productRequestPivotDtoValidator, ProductFiltersRequestDtoValidator productFiltersRequestDtoValidator, IResponsesOutputPortsBasicHelpersHub responsesOutputPortsBasicHelpersHub, IMapper mapper)
        {
            _filteredProductsUseCase = filteredProductsUseCase;
            _showProductUseCase = showProductUseCase;
            _newProductRegisterUseCase = newProductRegisterUseCase;
            _editProductUseCase = editProductUseCase;
            _deleteProductUseCase = deleteProductUseCase;
            _productRequestDtoValidator = productRequestDtoValidator;
            _productRequestPivotDtoValidator = productRequestPivotDtoValidator;
            _productFiltersRequestDtoValidator = productFiltersRequestDtoValidator;
            _responsesOutputPortsBasicHelpersHub = responsesOutputPortsBasicHelpersHub;
            _mapper = mapper;
        }
        public async Task<QueryResponseDto<IQueryable<ProductDto>>> GetFilteredProductsAsync(CommonFiltersRequestDto commonFiltersRequestDto)
        {
            //Request validator
            var validationResult = await _productFiltersRequestDtoValidator.ValidateAsync(commonFiltersRequestDto);
            if (!validationResult.IsValid)
            {
                //Custom validator errors response
                return await _responsesOutputPortsBasicHelpersHub.ValidatorErrorsQueryBasicHelperAsync<IQueryable<ProductDto>>(validationResult.Errors);

            }
            return await _filteredProductsUseCase.GetAllProductsByFiltersAsync(commonFiltersRequestDto);
        }

        public async Task<QueryResponseDto<ProductDto>> GetProductByIdAsync(int id)
        {
            return await _showProductUseCase.GetByIdAsync(id);
        }

        public async Task<CommandResponseDto> CreateProductAsync(ProductRequestDto productRequestDto)
        {
            //Request validator
            var validationResult = await _productRequestDtoValidator.ValidateAsync(productRequestDto);
            if (!validationResult.IsValid)
            {
                //Custom validator errors response
                return await _responsesOutputPortsBasicHelpersHub.ValidatorErrorsCommandBasicHelperAsync(validationResult.Errors);

            }
            return await _newProductRegisterUseCase.CreateRecordAsync(productRequestDto);
        }

        public async Task<CommandResponseDto> EditProductAsync(int id, ProductRequestDto productRequestDto)
        {
            var mappedProductRequestPivotDto = _mapper.Map<ProductRequestPivotDto>(productRequestDto);
            mappedProductRequestPivotDto.IdProduct = id;

            //Request validator
            var validationResult = await _productRequestPivotDtoValidator.ValidateAsync(mappedProductRequestPivotDto);
            if (!validationResult.IsValid)
            {
                //Custom validator errors response
                return await _responsesOutputPortsBasicHelpersHub.ValidatorErrorsCommandBasicHelperAsync(validationResult.Errors);

            }
            return await _editProductUseCase.ModifyRecordAsync(mappedProductRequestPivotDto);
        }

        public async Task<CommandResponseDto> DeleteProductAsync(int id)
        {
            return await _deleteProductUseCase.ModifyRecordAsync(id);
        }

    }
}
