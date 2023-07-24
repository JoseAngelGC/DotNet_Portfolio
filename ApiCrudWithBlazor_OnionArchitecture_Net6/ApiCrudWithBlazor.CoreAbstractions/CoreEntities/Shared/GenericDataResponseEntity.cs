using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Bases;


namespace ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Shared
{
    public class GenericDataResponseEntity<T> : BaseResponseEntity
    {
        public T? Data { get; set; }
        public int TotalRecords { get; set; } = 0;
        public int TotalPaginates { get; set; } = 0;
    }
}
