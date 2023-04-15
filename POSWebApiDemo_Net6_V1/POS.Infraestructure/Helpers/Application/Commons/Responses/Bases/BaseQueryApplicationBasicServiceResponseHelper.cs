using POS.Infraestructure.SupportDtos.Application.Commons.ResponsesDtos;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;

namespace POS.Infraestructure.Helpers.Application.Commons.Responses.Bases
{
    public abstract class BaseQueryApplicationBasicServiceResponseHelper
    {
        public abstract Task<GenericQueryApplicationResponseDto<T>> ResponseAsync<T>(QueryApplicationCollectorEntity<T> entity);
    }
}
