

namespace POS.Infraestructure.SupportEntities.Persistence.Commons.Commands.Responses
{
    public class ExecutedCommandEntity
    {
        public bool IsSuccess { get; set; }
        public int? RecordsAffected { get; set; } = null;
        public int HResultException { get; set; }
        public string? SourceException { get; set; } = null;
        public string? MessageErrorException { get; set; } = null;
    }
}
