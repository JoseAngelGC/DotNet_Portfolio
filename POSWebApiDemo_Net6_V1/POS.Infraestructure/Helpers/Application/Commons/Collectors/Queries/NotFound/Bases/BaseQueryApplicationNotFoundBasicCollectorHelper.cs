using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;

namespace POS.Infraestructure.Helpers.Application.Commons.Collectors.Queries.NotFound.Bases
{
    public abstract class BaseQueryApplicationNotFoundBasicCollectorHelper
    {
        public abstract Task<QueryApplicationCollectorEntity<T>> ResponseAsync<T>(bool isSuccess, int? records, string controlMessage);
    }
}
