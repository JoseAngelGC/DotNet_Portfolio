using POS.Infraestructure.SupportDtos.Interactors.Commons.Responses;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Interactors;

namespace POS.Infraestructure.Helpers.Interactors.Commons.Responses.Bases
{
    public abstract class BaseQueryInteractorBasicServiceResponseHelper
    {
        public abstract Task<GenericQueryInteractorResponseDto<T>> ResponseAsync<T>(QueryInteractorCollectorEntity<T> queryCollectorEntity);
    }
}
