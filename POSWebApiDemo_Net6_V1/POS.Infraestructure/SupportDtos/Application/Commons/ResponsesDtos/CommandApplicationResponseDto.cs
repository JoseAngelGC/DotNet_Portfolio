using POS.Infraestructure.SupportEntities.Commons.Responses.Bases;


namespace POS.Infraestructure.SupportDtos.Application.Commons.ResponsesDtos
{
    public class CommandApplicationResponseDto : ResponseBaseEntity
    {
        public int? Records { get; set; }
        public int StatusResponse { get; set; }
        public string? Information { get; set; }
        public object? ValidationErrors { get; set; }
    }
}
