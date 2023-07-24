using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ProductDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.RequestsDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;
using ApiCrudWithBlazor.CoreAbstractions.Helpers.DataFiltering;
using ApiCrudWithBlazor.CoreAbstractions.Helpers.DataOrganize;
using ApiCrudWithBlazor.CoreAbstractions.OutputPorts;
using ApiCrudWithBlazor.CoreAbstractions.Repositories.ProductRepositories.Queries;
using ApiCrudWithBlazor.CoreAbstractions.UseCases.ProductUseCases;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore;


namespace ApiCrudWithBlazor.Core.UseCases.ProductUseCases
{
    public class FilteredProductsUseCase<T> : IFilteredProductsUseCase<T> where T : Product
    {
        private readonly IGetAllProductsRepository<T> _getAllProductsRepository;
        private readonly IProductFiltersBasicsHelpersService<ProductDto> _productFiltersBasicsHelpersService;
        private readonly IDataOrganizeBasicsHelpersService<ProductDto> _dataOrganizeBasicsHelpersService;
        private readonly IResponsesOutputPortsBasicHelpersHub _responsesOutputPortsBasicHelpersHub;
        private int pivotTotalRecords;

        public FilteredProductsUseCase(IGetAllProductsRepository<T> getAllProductsRepository, IProductFiltersBasicsHelpersService<ProductDto> productFiltersBasicsHelpersService, IDataOrganizeBasicsHelpersService<ProductDto> dataOrganizeBasicsHelpersService, IResponsesOutputPortsBasicHelpersHub responsesOutputPortsBasicHelpersHub)
        {
            _getAllProductsRepository = getAllProductsRepository;
            _productFiltersBasicsHelpersService = productFiltersBasicsHelpersService;
            _dataOrganizeBasicsHelpersService = dataOrganizeBasicsHelpersService;
            _responsesOutputPortsBasicHelpersHub = responsesOutputPortsBasicHelpersHub;
        }

        public async Task<QueryResponseDto<IQueryable<ProductDto>>> GetAllProductsByFiltersAsync(CommonFiltersRequestDto filters)
        {
            try
            {
                var products = await _getAllProductsRepository.QueryMultiTableAsync();
                var filteredProducts = products;

                if (products is not null)
                {
                    //Filter data
                    filteredProducts = await _productFiltersBasicsHelpersService.ProductsByNameFilterBasicHelperAsync(filters, filteredProducts);
                    pivotTotalRecords = filteredProducts.Count();

                    //Organize data
                    filteredProducts = await _dataOrganizeBasicsHelpersService.DataSortBasicHelperAsync(filters, filteredProducts);
                    filteredProducts = await _dataOrganizeBasicsHelpersService.DataPaginateBasicHelperAsync(filters, filteredProducts);
                }

                var outputPortResponse = await _responsesOutputPortsBasicHelpersHub.SuccessfulQueryBasicHelperAsync(filteredProducts);

                if (filteredProducts is not null)
                {
                    //Total Records
                    outputPortResponse.TotalRecords = pivotTotalRecords;

                    //Total paginates
                    var totalRecords = Convert.ToDouble(outputPortResponse.TotalRecords);
                    outputPortResponse.TotalPaginates = Convert.ToInt32(Math.Ceiling(totalRecords / filters.NumberRecordsPage));
                }

                return outputPortResponse!;
            }
            catch (Exception e)
            {
                return await _responsesOutputPortsBasicHelpersHub.ExceptionQueryBasicHelperAsync<IQueryable<ProductDto>>(e.Message, e.HResult, e.Source);
            }
            
        }
    }
}
