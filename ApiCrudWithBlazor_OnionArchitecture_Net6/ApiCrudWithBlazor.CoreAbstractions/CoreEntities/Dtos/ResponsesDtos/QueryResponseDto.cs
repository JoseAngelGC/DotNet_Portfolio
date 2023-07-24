using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Shared;


namespace ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos
{
    public class QueryResponseDto<T> : GenericDataResponseEntity<T>
    {
        public int StatusResponse { get; set; }
        public string? Information { get; set; }
        public object? ValidationErrors { get; set; }
    }
}
