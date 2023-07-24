namespace ApiCrudWithBlazor.BlazorClient.DomainModels.CoreEntities.ApiResponses
{
    public class ApiQueryResponse<T>
    {
        public int StatusResponse { get; set; }
        public string? Information { get; set; }
        public object? ValidationErrors { get; set; }
        public T? Data { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPaginates { get; set; }
        public string? MessageResponse { get; set; }
        public bool IsSuccess { get; set; }
    }
}
