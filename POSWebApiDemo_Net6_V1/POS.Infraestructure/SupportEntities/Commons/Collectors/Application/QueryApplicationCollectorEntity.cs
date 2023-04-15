using POS.Infraestructure.SupportEntities.Commons.Collectors.Bases;


namespace POS.Infraestructure.SupportEntities.Commons.Collectors.Application
{
    public class QueryApplicationCollectorEntity<T> : CollectorBaseEntity
    {
        public T? Data { get; set; }
        public string? Information { get; set; }
        public int HttpStatus { get; set; }
        public object? ValidationErrors { get; set; }
    }
}
