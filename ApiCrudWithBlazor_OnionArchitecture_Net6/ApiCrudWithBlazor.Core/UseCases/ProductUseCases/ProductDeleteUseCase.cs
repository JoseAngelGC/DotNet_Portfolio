using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Utilities.Constants;
using ApiCrudWithBlazor.CoreAbstractions.OutputPorts;
using ApiCrudWithBlazor.CoreAbstractions.Repositories.Generic.Commands;
using ApiCrudWithBlazor.CoreAbstractions.Repositories.ProductRepositories.Queries;
using ApiCrudWithBlazor.CoreAbstractions.UseCases.ProductUseCases;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore;
using AutoMapper;


namespace ApiCrudWithBlazor.Core.UseCases.ProductUseCases
{
    public class ProductDeleteUseCase<T> : IProductDeleteUseCase<T> where T : Product
    {
        private readonly IRemoveGenericRepository<T> _removeGenericRepository;
        private readonly IResponsesOutputPortsBasicHelpersHub _responsesOutputPortsBasicHelpersHub;
        private readonly IGetProductByIdRepository<T> _getProductByIdRepository;
        private T? productById;

        public ProductDeleteUseCase(IRemoveGenericRepository<T> removeGenericRepository, IResponsesOutputPortsBasicHelpersHub responsesOutputPortsBasicHelpersHub, IGetProductByIdRepository<T> getProductByIdRepository)
        {
            _removeGenericRepository = removeGenericRepository;
            _responsesOutputPortsBasicHelpersHub = responsesOutputPortsBasicHelpersHub;
            _getProductByIdRepository = getProductByIdRepository;
        }
        public async Task<CommandResponseDto> ModifyRecordAsync(int id)
        {
            try
            {
                productById = (T)await _getProductByIdRepository.QueryAsync(id);
                if (productById is null)
                {
                    return await _responsesOutputPortsBasicHelpersHub.NotFoundErrorCommandBasicHelperAsync();
                }

                var removeProductResponse = await _removeGenericRepository.CommandAsync(productById);
                if (removeProductResponse == 0)
                {
                    return await _responsesOutputPortsBasicHelpersHub.ServerErrorCommandBasicHelperAsync();
                }

                return await _responsesOutputPortsBasicHelpersHub.SuccessfulCommandBasicHelperAsync(removeProductResponse, ReplyMessageConstants.MESSAGE_DELETE);
            }
            catch (Exception e)
            {
                return await _responsesOutputPortsBasicHelpersHub.ExceptionCommandBasicHelperAsync(e.Message, e.HResult, e.Source);
            }
            
        }
    }
}
