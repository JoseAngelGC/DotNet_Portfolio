using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.RequestsDtos;
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
    public class NewProductRegisterUseCase<T> : INewProductRegisterUseCase<T> where T : Product
    {
        private readonly ISaveGenericRepository<T> _saveGenericRepository;
        private readonly INewProductExistRepository<T> _newProductExistRepository;
        private readonly IResponsesOutputPortsBasicHelpersHub _responsesOutputPortsBasicHelpersHub;
        private readonly IMapper _mapper;
        public NewProductRegisterUseCase(ISaveGenericRepository<T> saveGenericRepository, INewProductExistRepository<T> newProductExistRepository, IResponsesOutputPortsBasicHelpersHub responsesOutputPortsBasicHelpersHub, IMapper mapper)
        {
            _saveGenericRepository = saveGenericRepository;
            _newProductExistRepository = newProductExistRepository;
            _responsesOutputPortsBasicHelpersHub = responsesOutputPortsBasicHelpersHub;
            _mapper = mapper;
        }
        public async Task<CommandResponseDto> CreateRecordAsync(ProductRequestDto productRequestDto)
        {
            try
            {
                var productRequestPivotDtoMapping = _mapper.Map<ProductRequestPivotDto>(productRequestDto);
                var newProductExist = await _newProductExistRepository.QueryAsync("PRODUCTNAME", productRequestPivotDtoMapping);
                if (newProductExist)
                {
                    return await _responsesOutputPortsBasicHelpersHub.RecordExistErrorCommandBasicHelperAsync();
                }

                var productMapper = _mapper.Map<T>(productRequestPivotDtoMapping);
                var saveProductResponse = await _saveGenericRepository.CommandAsync(productMapper);
                if (saveProductResponse == 0)
                {
                    return await _responsesOutputPortsBasicHelpersHub.ServerErrorCommandBasicHelperAsync();
                }

                return await _responsesOutputPortsBasicHelpersHub.SuccessfulCommandBasicHelperAsync(saveProductResponse, ReplyMessageConstants.MESSAGE_SAVE);
            }
            catch (Exception e)
            {
                return await _responsesOutputPortsBasicHelpersHub.ExceptionCommandBasicHelperAsync(e.Message, e.HResult, e.Source);
            }
            
        }
    }
}
