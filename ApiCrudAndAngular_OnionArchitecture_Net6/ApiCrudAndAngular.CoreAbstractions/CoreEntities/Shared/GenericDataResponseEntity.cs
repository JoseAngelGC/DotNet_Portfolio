using ApiCrudAndAngular.CoreAbstractions.CoreEntities.Bases;


namespace ApiCrudAndAngular.CoreAbstractions.CoreEntities.Shared
{
    public class GenericDataResponseEntity<T> : BaseResponseEntity
    {
        public T? Data { get; set; }
        public int TotalRecords { get; set; } = 0;
        public int TotalPaginates { get; set; } = 0;
    }
}
