using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ProductDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.RequestsDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;
using ApiCrudWithBlazor.CoreAbstractions.OutputPorts;
using ApiCrudWithBlazor.CoreAbstractions.Repositories.ProductRepositories.Queries;
using ApiCrudWithBlazor.CoreAbstractions.UseCases.ProductUseCases;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore;


namespace ApiCrudWithBlazor.Core.UseCases.ProductUseCases
{
    public class ShowProductUseCase<T> : IShowProductUseCase<T> where T : Product
    {
        private readonly IGetProductDtoByIdRepository<T> _getProductByIdRepository;
        private readonly IResponsesOutputPortsBasicHelpersHub _responsesOutputPortsBasicHelpersHub;
        private readonly CommonFiltersRequestDto filters;

        public ShowProductUseCase(IGetProductDtoByIdRepository<T> getProductByIdRepository, IResponsesOutputPortsBasicHelpersHub responsesOutputPortsBasicHelpersHub)
        {
            _getProductByIdRepository = getProductByIdRepository;
            _responsesOutputPortsBasicHelpersHub = responsesOutputPortsBasicHelpersHub;
            filters = new CommonFiltersRequestDto();
        }
        public async Task<QueryResponseDto<ProductDto>> GetByIdAsync(int id)
        {
            try
            {
                var productDto = await _getProductByIdRepository.QueryAsync(id);
                if (productDto is null)
                {
                    return await _responsesOutputPortsBasicHelpersHub.NotFoundErrorQueryBasicHelperAsync<ProductDto>();
                }

                var outputPortResponse = await _responsesOutputPortsBasicHelpersHub.SuccessfulQueryBasicHelperAsync(productDto);

                outputPortResponse.TotalRecords = 1;
                var totalRecords = Convert.ToDouble(outputPortResponse.TotalRecords);
                outputPortResponse.TotalPaginates = Convert.ToInt32(Math.Ceiling(totalRecords / filters.NumberRecordsPage));

                return await Task.FromResult(outputPortResponse);
            }
            catch (Exception e)
            {
                return await _responsesOutputPortsBasicHelpersHub.ExceptionQueryBasicHelperAsync<ProductDto>(e.Message, e.HResult, e.Source);
            }
            
        }
    }
}
