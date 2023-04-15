using POS.Infraestructure.SupportEntities.Commons.Responses.Bases;

namespace POS.Infraestructure.SupportEntities.Commons.Responses.ResponseTypes
{
    public class GenericCoreResponseEntity<T> : ResponseBaseEntity
    {
        public T? Items { get; set; }
        public int? Records { get; set; }
    }
}
