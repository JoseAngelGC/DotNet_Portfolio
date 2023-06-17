using StoreBasicCRUD.SharedCoreStructure.SharedResponseEntities.Bases;

namespace StoreBasicCRUD.SharedCoreStructure.SharedResponseEntities
{
    public class GenericDataResponseEntity<T> : BaseResponseEntity
    {
        public T? Data { get; set; }
        public int? Records { get; set; }
    }
}
