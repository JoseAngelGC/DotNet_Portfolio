using POS.Infraestructure.Helpers.Interactors.Commons.Responses;
using POS.Infraestructure.SupportDtos.Interactors.Commons.Responses;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Interactors;


namespace POS.Infraestructure.Helpers.Interactors.Commons.ExtendHelpers.Bases
{
    public abstract class BaseQueryInteractorExtendBasicHelpers
    {
        public static async Task<GenericQueryInteractorResponseDto<T>> QueryInteractorBasicServiceResponseAsync<T>(QueryInteractorCollectorEntity<T> queryCollectorEntity)
        {
            QueryInteractorBasicServiceResponseHelper queryInteractorBasicServiceResponseHelper = new ();
            return await queryInteractorBasicServiceResponseHelper.ResponseAsync(queryCollectorEntity);
        }
    }
}
