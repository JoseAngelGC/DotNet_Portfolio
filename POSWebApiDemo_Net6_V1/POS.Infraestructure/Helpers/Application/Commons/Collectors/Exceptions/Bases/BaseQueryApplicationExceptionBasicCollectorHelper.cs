using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;

namespace POS.Infraestructure.Helpers.Application.Commons.Collectors.Exceptions.Bases
{
    public abstract class BaseQueryApplicationExceptionBasicCollectorHelper
    {
        public abstract Task<QueryApplicationCollectorEntity<T>> ResponseAsync<T>(int customerErrorCode, string? messageErrorException, int? hResultException, string? sourceException);
    }
}
