using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.CategoryDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;
using ApiCrudWithBlazor.CoreAbstractions.InputPorts;
using ApiCrudWithBlazor.CoreAbstractions.UseCases.CategoryUseCases;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore;


namespace ApiCrudWithBlazor.ApplicationServices.InputPortsServices
{
    public class CategoryInputPortsService : ICategoryInputPortsService
    {
        private readonly ICategoriesListUseCase<Category> _categoriesListUseCase;
        public CategoryInputPortsService(ICategoriesListUseCase<Category> categoriesListUseCase)
        {
            _categoriesListUseCase = categoriesListUseCase;
        }
        public async Task<QueryResponseDto<IEnumerable<CategoryDto>>> GetAllCategoriesAsync()
        {
            return await _categoriesListUseCase.GetCategoriesAsync();        
        }
    }
}
