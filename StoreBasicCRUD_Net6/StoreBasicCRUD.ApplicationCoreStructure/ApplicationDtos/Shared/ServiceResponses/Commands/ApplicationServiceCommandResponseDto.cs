using StoreBasicCRUD.SharedCoreStructure.SharedResponseEntities;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Shared.ServiceResponses.Commands
{
    public class ApplicationServiceCommandResponseDto : RecordsAffectedResponseEntity
    {
        public int StatusResponse { get; set; }
        public string? Information { get; set; }
        public object? ValidationErrors { get; set; }
    }
}
