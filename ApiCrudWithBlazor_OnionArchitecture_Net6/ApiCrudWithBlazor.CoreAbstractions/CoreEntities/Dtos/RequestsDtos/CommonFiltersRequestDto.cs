using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Bases;


namespace ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.RequestsDtos
{
    public class CommonFiltersRequestDto : BasePaginationEntity
    {
        public string? ColumnNameToFilter { get; set; } = null;
        public string? TextFilter { get; set; } = null;
    }
}
