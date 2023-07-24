namespace ApiCrudWithBlazor.BlazorClient.DomainModels.CoreEntities.ApiRequests
{
    public class CommonFiltersApiRequestDto
    {
        public int NumberPage { get; set; } = 1;
        public int NumberRecordsPage { get; set; } = 10;
        public string OrderType { get; set; } = "desc";
        public string SortByColumn { get; set; } = "IdProduct";
        public string? ColumnNameToFilter { get; set; }
        public string? TextFilter { get; set; }
    }
}
