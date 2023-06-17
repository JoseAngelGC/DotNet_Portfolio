using StoreBasicCRUD.SharedCoreStructure.SharedResponseEntities;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationEntities.Responses.Commands
{
    public class ApplicationCollectorCommandResponseEntity : RecordsAffectedResponseEntity
    {
        public int StatusResponse { get; set; }
        public string? Information { get; set; }
        public object? ValidationErrors { get; set; }
    }
}
