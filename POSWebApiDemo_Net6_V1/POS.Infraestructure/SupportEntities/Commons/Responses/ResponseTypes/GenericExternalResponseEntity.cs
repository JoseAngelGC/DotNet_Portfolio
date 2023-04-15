using POS.Infraestructure.SupportEntities.Commons.Responses.Bases;


namespace POS.Infraestructure.SupportEntities.Commons.Responses.ResponseTypes
{
    public class GenericExternalResponseEntity<T> : ResponseBaseEntity
    {
        public T? Data { get; set; }
        public int? Records { get; set; }
    }
}
