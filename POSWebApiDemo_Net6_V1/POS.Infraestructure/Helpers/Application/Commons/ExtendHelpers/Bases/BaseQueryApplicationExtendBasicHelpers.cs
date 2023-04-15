using POS.Infraestructure.Helpers.Application.Commons.Responses;
using POS.Infraestructure.SupportDtos.Application.Commons.ResponsesDtos;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;


namespace POS.Infraestructure.Helpers.Application.Commons.ExtendHelpers.Bases
{
    public abstract class BaseQueryApplicationExtendBasicHelpers
    {
        public static async Task<GenericQueryApplicationResponseDto<T>> QueryApplicationBasicServiceResponseAsync<T>(QueryApplicationCollectorEntity<T> entity)
        {
            QueryApplicationBasicServiceResponseHelper queryApplicationBasicServiceResponseHelper = new ();
            return await queryApplicationBasicServiceResponseHelper.ResponseAsync(entity);
        }
    }
}
