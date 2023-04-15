using POS.Infraestructure.SupportEntities.Commons.Responses.ResponseTypes;


namespace POS.Infraestructure.SupportDtos.Application.Commons.ResponsesDtos
{
    public class GenericQueryApplicationResponseDto<T> : GenericExternalResponseEntity<T>
    {
        public int StatusResponse { get; set; }
        public string? Information { get; set; }
        public object? ValidationErrors { get; set; }
    }
}
