using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.CategoryDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore;


namespace ApiCrudWithBlazor.CoreAbstractions.UseCases.CategoryUseCases
{
    public interface ICategoriesListUseCase<T> where T : Category
    {
        Task<QueryResponseDto<IEnumerable<CategoryDto>>> GetCategoriesAsync();
    }
}
