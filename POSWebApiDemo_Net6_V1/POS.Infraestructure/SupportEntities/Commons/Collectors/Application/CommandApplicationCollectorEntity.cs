using POS.Infraestructure.SupportEntities.Commons.Collectors.Bases;


namespace POS.Infraestructure.SupportEntities.Commons.Collectors.Application
{
    public class CommandApplicationCollectorEntity : CollectorBaseEntity
    {
        public string? Information { get; set; }
        public int HttpStatus { get; set; }
        public object? ValidationErrors { get; set; }
    }
}
