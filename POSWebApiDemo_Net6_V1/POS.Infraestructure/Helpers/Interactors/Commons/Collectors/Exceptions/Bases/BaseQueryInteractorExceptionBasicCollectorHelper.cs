using POS.Infraestructure.SupportEntities.Commons.Collectors.Interactors;

namespace POS.Infraestructure.Helpers.Interactors.Commons.Collectors.Exceptions.Bases
{
    public abstract class BaseQueryInteractorExceptionBasicCollectorHelper
    { 
        public abstract Task<QueryInteractorCollectorEntity<T>> ResponseAsync<T>(int CustomerErrorCode, int? hResultException, string? sourceException);
    }
}
