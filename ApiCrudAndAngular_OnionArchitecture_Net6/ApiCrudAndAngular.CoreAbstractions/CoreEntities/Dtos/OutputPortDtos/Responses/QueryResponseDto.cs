using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Shared;


namespace ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses
{
    public class QueryResponseDto<T> : GenericDataResponseEntity<T>
    {
        public int StatusResponse { get; set; }
        public string? Information { get; set; }
        public object? ValidationErrors { get; set; }
    }
}
