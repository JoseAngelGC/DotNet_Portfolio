using StoreBasicCRUD.SharedCoreStructure.SharedResponseEntities.Bases;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.Requests
{
    public class CommonFiltersRequestDto : BasePaginationEntity
    {
        public string? ColumnNameToFilter { get; set; } = null;
        public string? TextFilter { get; set; } = null;
    }
}
