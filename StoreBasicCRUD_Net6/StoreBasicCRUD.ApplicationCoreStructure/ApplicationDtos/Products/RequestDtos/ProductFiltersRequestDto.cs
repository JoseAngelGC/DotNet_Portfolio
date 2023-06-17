using StoreBasicCRUD.SharedCoreStructure.SharedResponseEntities.Bases;


namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.RequestDtos
{
    public class ProductFiltersRequestDto : BasePaginationFiltersEntity
    {
        public string? Nombre { get; set; } = null;
    }
}
