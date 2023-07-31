using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Shared;


namespace ApiCrudAndAngular.CoreAbstractions.CoreEntities.Dtos.OutputPortDtos.Responses
{
    public class CommandResponseDto : RecordsAffectedResponseEntity
    {
        public int StatusResponse { get; set; }
        public string? Information { get; set; }
        public object? ValidationErrors { get; set; }
    }
}
