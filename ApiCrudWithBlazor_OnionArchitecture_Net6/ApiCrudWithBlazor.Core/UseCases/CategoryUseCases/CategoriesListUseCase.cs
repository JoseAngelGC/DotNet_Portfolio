using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.CategoryDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.RequestsDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;
using ApiCrudWithBlazor.CoreAbstractions.OutputPorts;
using ApiCrudWithBlazor.CoreAbstractions.Repositories.Generic.Queries;
using ApiCrudWithBlazor.CoreAbstractions.UseCases.CategoryUseCases;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore;
using AutoMapper;

namespace ApiCrudWithBlazor.Core.UseCases.CategoryUseCases
{
    public class CategoriesListUseCase<T> : ICategoriesListUseCase<T> where T : Category
    {
        private readonly IGetAllGenericRepository<T> _getAllGenericRepository;
        private readonly IResponsesOutputPortsBasicHelpersHub _responsesOutputPortsBasicHelpersHub;
        private readonly IMapper _mapper;
        private readonly CommonFiltersRequestDto filters;

        public CategoriesListUseCase(IGetAllGenericRepository<T> getAllGenericRepository, IResponsesOutputPortsBasicHelpersHub responsesOutputPortsBasicHelpersHub, IMapper mapper)
        {
            _getAllGenericRepository = getAllGenericRepository;
            _responsesOutputPortsBasicHelpersHub = responsesOutputPortsBasicHelpersHub;
            _mapper = mapper;
            filters = new CommonFiltersRequestDto();
        }
        public async Task<QueryResponseDto<IEnumerable<CategoryDto>>> GetCategoriesAsync()
        {
            try
            {
                var categoryIQueryable = await _getAllGenericRepository.QueryAsync();
                var categoryIEnumerable = categoryIQueryable.OrderBy(c => c.IdCategory).AsEnumerable();
                var outputPortResponse = await _responsesOutputPortsBasicHelpersHub.SuccessfulQueryBasicHelperAsync(categoryIEnumerable);
                
                //Analizar como encapsular ésta funcionalidad
                if (categoryIEnumerable is not null)
                {
                    //Total Records
                    outputPortResponse.TotalRecords = categoryIQueryable.Count();

                    //Total paginates
                    var totalRecords = Convert.ToDouble(categoryIQueryable.Count());
                    outputPortResponse.TotalPaginates = Convert.ToInt32(Math.Ceiling(totalRecords / filters.NumberRecordsPage));
                }

                var responseMapping = _mapper.Map<QueryResponseDto<IEnumerable<CategoryDto>>>(outputPortResponse);

                return await Task.FromResult(responseMapping);
            }
            catch (Exception e)
            {
                return await _responsesOutputPortsBasicHelpersHub.ExceptionQueryBasicHelperAsync<IEnumerable<CategoryDto>>(e.Message, e.HResult, e.Source);
            }
            
        }
    }
}
