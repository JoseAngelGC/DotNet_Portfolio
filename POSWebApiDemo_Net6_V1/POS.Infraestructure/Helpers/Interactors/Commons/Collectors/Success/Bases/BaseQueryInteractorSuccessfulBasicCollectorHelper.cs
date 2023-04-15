using POS.Infraestructure.SupportEntities.Commons.Collectors.Interactors;

namespace POS.Infraestructure.Helpers.Interactors.Commons.Collectors.Success.Bases
{
    public abstract class BaseQueryInteractorSuccessfulBasicCollectorHelper
    {
        public abstract Task<QueryInteractorCollectorEntity<T>> ResponseAsync<T>(T data, int records);
    }
}
