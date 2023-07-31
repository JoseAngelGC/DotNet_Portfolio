using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Bases;


namespace ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.CommonDtos
{
    public class CommonFiltersRequestDto : BasePaginationEntity
    {
        public string? ColumnNameToFilter { get; set; } = null;
        public string? TextFilter { get; set; } = null;
    }
}
