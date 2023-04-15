using POS.Infraestructure.SupportEntities.Commons.Collectors.Interactors;

namespace POS.Infraestructure.Helpers.Interactors.Commons.Collectors.NotFound.Bases
{
    public abstract class BaseQueryInteractorNotFoundBasicCollectorHelper
    {
        public abstract Task<QueryInteractorCollectorEntity<T>> ResponseAsync<T>(int? records);
    }
}
