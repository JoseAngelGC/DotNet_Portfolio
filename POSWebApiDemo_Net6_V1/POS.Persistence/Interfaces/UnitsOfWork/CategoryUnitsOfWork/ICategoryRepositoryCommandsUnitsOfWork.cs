using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities.BaseEntities;
using POS.Persistence.Interfaces.CategoryRepository.Queries.ExistItem;
using POS.Persistence.Interfaces.Generics.Commands.RemoveItem;
using POS.Persistence.Interfaces.Generics.Commands.SaveItem;
using POS.Persistence.Interfaces.Generics.Commands.UpdateItem;


namespace POS.Persistence.Interfaces.UnitsOfWork.CategoryUnitsOfWork
{
    public interface ICategoryRepositoryCommandsUnitsOfWork<T> : IDisposable where T : BaseEntity
    {
        public IGenericSaveEntityItem<T> GenericSaveEntityItem { get; }
        public IGenericUpdateEntityItem<T> GenericUpdateEntityItem { get; }
        public IGenericRemoveEntityItem<T> GenericRemoveEntityItem { get; }
        public IExistCategoryItemByName ExistCategoryItemByName { get; }
        public IExistCategoryItemById ExistCategoryItemById { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
