

namespace POS.Infraestructure.SupportEntities.Commons.Collectors.Bases
{
    public class CollectorBaseEntity
    {
        public bool IsSuccess { get; set; }
        public int? Records { get; set; }
        public string? MessageResponse { get; set; }
    }
}
