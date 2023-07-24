namespace ApiCrudWithBlazor.BlazorClient.DomainModels.CoreEntities.ApiResponses
{
    public class ApiCommandResponse
    {
        public int StatusResponse { get; set; }
        public string? Information { get; set; }
        public object? ValidationErrors { get; set; }
        public int? RecordsAffected { get; set; }
        public string? MessageResponse { get; set; }
        public bool IsSuccess { get; set; }
    }
}
