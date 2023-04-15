using POS.Infraestructure.SupportEntities.Commons.Collectors.Interactors;

namespace POS.Infraestructure.Interfaces.Interactors.Commons.Collectors
{
    public interface IQueryInteractorBasicHelpers
    {
        public Task<QueryInteractorCollectorEntity<T>> QueryInteractorExceptionBasicCollectorAsync<T>(int CustomerErrorCode, int? hResultException, string? sourceException);
        public Task<QueryInteractorCollectorEntity<T>> QueryInteractorSuccessfulBasicCollectorAsync<T>(T data, int records);
        public Task<QueryInteractorCollectorEntity<T>> QueryInteractorNotFoundBasicCollectorAsync<T>(int? records);
    }
}
