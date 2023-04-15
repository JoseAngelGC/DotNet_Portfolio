using POS.Infraestructure.Helpers.Interactors.Commons.Collectors.Exceptions;
using POS.Infraestructure.Helpers.Interactors.Commons.Collectors.NotFound;
using POS.Infraestructure.Helpers.Interactors.Commons.Collectors.Success;
using POS.Infraestructure.Helpers.Interactors.Commons.ExtendHelpers.Bases;
using POS.Infraestructure.Interfaces.Interactors.Commons.Collectors;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Interactors;

namespace POS.Infraestructure.Helpers.Interactors.Commons.Hubs
{
    public class QueryInteractorBasicHelpersHub : BaseQueryInteractorExtendBasicHelpers, IQueryInteractorBasicHelpers
    {
        public async Task<QueryInteractorCollectorEntity<T>> QueryInteractorExceptionBasicCollectorAsync<T>(int CustomerErrorCode, int? hResultException, string? sourceException)
        {
            QueryInteractorExceptionBasicCollectorHelper queryInteractorExceptionBasicCollectorHelper = new ();
            return await queryInteractorExceptionBasicCollectorHelper.ResponseAsync<T>(CustomerErrorCode, hResultException, sourceException);
        }

        public async Task<QueryInteractorCollectorEntity<T>> QueryInteractorSuccessfulBasicCollectorAsync<T>(T data, int records)
        {
            QueryInteractorSuccessfulBasicCollectorHelper queryInteractorSuccessfulBasicCollectorHelper = new ();
            return await queryInteractorSuccessfulBasicCollectorHelper.ResponseAsync(data, records);
        }

        public async Task<QueryInteractorCollectorEntity<T>> QueryInteractorNotFoundBasicCollectorAsync<T>(int? records)
        {
            QueryInteractorNotFoundBasicCollectorHelper queryInteractorNotFoundBasicCollectorHelper = new ();
            return await queryInteractorNotFoundBasicCollectorHelper.ResponseAsync<T>(records);
        }


    }
}
