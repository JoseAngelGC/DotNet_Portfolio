using POS.Infraestructure.SupportEntities.Commons.Responses.Bases;


namespace POS.Infraestructure.SupportDtos.Application.ResponsesDtos.UserResponsesDtos
{
    public class TokenApplicationResponseDto : ResponseBaseEntity
    {
        public string? TokenResponse { get; set; }
        public int StatusResponse { get; set; }
        public string? Information { get; set; }
        public object? ValidationErrors { get; set; }
    }
}
