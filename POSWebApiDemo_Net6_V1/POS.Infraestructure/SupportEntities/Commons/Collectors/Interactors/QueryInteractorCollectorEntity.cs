using POS.Infraestructure.SupportEntities.Commons.Collectors.Bases;

namespace POS.Infraestructure.SupportEntities.Commons.Collectors.Interactors
{
    public class QueryInteractorCollectorEntity<T> : CollectorBaseEntity
    {
        public T? Items { get; set; }
        public int? CustomErrorCode { get; set; }
        public string ControlMessage { get; set; }
    }
}
