using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.RequestsDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Utilities.Constants;
using ApiCrudWithBlazor.CoreAbstractions.OutputPorts;
using ApiCrudWithBlazor.CoreAbstractions.Repositories.Generic.Commands;
using ApiCrudWithBlazor.CoreAbstractions.Repositories.Generic.Queries;
using ApiCrudWithBlazor.CoreAbstractions.Repositories.ProductRepositories.Queries;
using ApiCrudWithBlazor.CoreAbstractions.UseCases.ProductUseCases;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore;
using AutoMapper;

namespace ApiCrudWithBlazor.Core.UseCases.ProductUseCases
{
    public class ProductEditUseCase<T> : IProductEditUseCase<T> where T : Product
    {
        private readonly IUpdateGenericRepository<T> _updateGenericRepository;
        private readonly INewProductExistRepository<T> _newProductExistRepository;
        private readonly IResponsesOutputPortsBasicHelpersHub _responsesOutputPortsBasicHelpersHub;
        private readonly IMapper _mapper;
        private readonly IGetAllGenericRepository<T> _getAllGenericRepository;

        public ProductEditUseCase(IUpdateGenericRepository<T> updateGenericRepository, INewProductExistRepository<T> newProductExistRepository, IResponsesOutputPortsBasicHelpersHub responsesOutputPortsBasicHelpersHub, IMapper mapper, IGetAllGenericRepository<T> getAllGenericRepository)
        {
            _updateGenericRepository = updateGenericRepository;
            _newProductExistRepository = newProductExistRepository;
            _responsesOutputPortsBasicHelpersHub = responsesOutputPortsBasicHelpersHub;
            _mapper = mapper;
            _getAllGenericRepository = getAllGenericRepository;
        }
        public async Task<CommandResponseDto> ModifyRecordAsync(ProductRequestPivotDto productRequestPivotDto)
        {
            try
            {
                //Validate if product exist by idProduct.
                var newProductExist = await _newProductExistRepository.QueryAsync("IDPRODUCT", productRequestPivotDto);
                if (!newProductExist)
                {
                    return await _responsesOutputPortsBasicHelpersHub.NotFoundErrorCommandBasicHelperAsync();
                }

                //Validations to secure that product name repeat records not exist.
                var iqueryableProduct = await _getAllGenericRepository.QueryAsync();
                var productNameCounter = iqueryableProduct.Where(p => p.Nombre == productRequestPivotDto.Nombre).Count();
                if (productNameCounter == 1)
                {
                    var product = iqueryableProduct.Where(p => p.Nombre == productRequestPivotDto.Nombre).FirstOrDefault();
                    if (productRequestPivotDto.IdProduct != product!.IdProduct)
                        return await _responsesOutputPortsBasicHelpersHub.RecordExistErrorCommandBasicHelperAsync();
                }
                else
                {
                    if (productNameCounter > 1)
                        return await _responsesOutputPortsBasicHelpersHub.RecordExistErrorCommandBasicHelperAsync();
                }

                //Steps to update product information.
                var productMapper = _mapper.Map<T>(productRequestPivotDto);
                var updateProductResponse = await _updateGenericRepository.CommandAsync(productMapper);
                if (updateProductResponse == 0)
                {
                    return await _responsesOutputPortsBasicHelpersHub.ServerErrorCommandBasicHelperAsync();
                }

                return await _responsesOutputPortsBasicHelpersHub.SuccessfulCommandBasicHelperAsync(updateProductResponse, ReplyMessageConstants.MESSAGE_UPDATE);
            }
            catch (Exception e)
            {
                return await _responsesOutputPortsBasicHelpersHub.ExceptionCommandBasicHelperAsync(e.Message, e.HResult, e.Source);
            }
            
        }
    }
}
