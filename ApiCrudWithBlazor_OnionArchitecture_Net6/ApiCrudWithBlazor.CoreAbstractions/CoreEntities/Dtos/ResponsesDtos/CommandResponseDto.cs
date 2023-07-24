using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Shared;


namespace ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.ResponsesDtos
{
    public class CommandResponseDto : RecordsAffectedResponseEntity
    {
        public int StatusResponse { get; set; }
        public string? Information { get; set; }
        public object? ValidationErrors { get; set; }
    }
}
