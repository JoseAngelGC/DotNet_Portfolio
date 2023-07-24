using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.CategoryDtos;
using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos;


namespace ApiCrudWithBlazor.CoreAbstractions.InputPorts
{
    public interface ICategoryInputPortsService
    {
        Task<QueryResponseDto<IEnumerable<CategoryDto>>> GetAllCategoriesAsync();
    }
}
