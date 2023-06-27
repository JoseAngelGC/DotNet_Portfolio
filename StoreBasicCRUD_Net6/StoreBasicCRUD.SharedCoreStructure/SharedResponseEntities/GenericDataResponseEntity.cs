using StoreBasicCRUD.SharedCoreStructure.SharedResponseEntities.Bases;

namespace StoreBasicCRUD.SharedCoreStructure.SharedResponseEntities
{
    public class GenericDataResponseEntity<T> : BaseResponseEntity
    {
        public T? Data { get; set; }
        public int TotalRecords { get; set; } = 0;
        public int TotalPaginates { get; set; } = 0;
    }
}
