using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;

namespace POS.Infraestructure.Helpers.Application.Commons.Collectors.InteractorErrors.Bases
{
    public abstract class BaseQueryApplicationInteractorErrorBasicCollectorHelper
    {
        public abstract Task<QueryApplicationCollectorEntity<T>> ResponseAsync<T>(bool isSuccess, string controlMessage, int? customErrorCode);
    }
}
