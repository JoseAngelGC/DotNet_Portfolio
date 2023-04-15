using POS.Infraestructure.SupportDtos.Application.Commons.MappersDtos;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;

namespace POS.Infraestructure.Helpers.Application.Commons.Collectors.Success.Bases
{
    public abstract class BaseQueryApplicationSuccessBasicCollectorHelper
    {
        public abstract Task<QueryApplicationCollectorEntity<T>> ResponseAsync<T>(GenericMapperDto<T> mapperDto);
    }
}
