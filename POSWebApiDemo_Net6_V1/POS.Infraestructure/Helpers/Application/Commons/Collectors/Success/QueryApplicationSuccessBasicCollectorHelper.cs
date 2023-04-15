using Microsoft.AspNetCore.Http;
using POS.Infraestructure.Helpers.Application.Commons.Collectors.Success.Bases;
using POS.Infraestructure.SupportDtos.Application.Commons.MappersDtos;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;
using POS.Utilities.Commons.Consts;

namespace POS.Infraestructure.Helpers.Application.Commons.Collectors.Success
{
    public class QueryApplicationSuccessBasicCollectorHelper : BaseQueryApplicationSuccessBasicCollectorHelper
    {
        public override async Task<QueryApplicationCollectorEntity<T>> ResponseAsync<T>(GenericMapperDto<T> mapperDto)
        {
            QueryApplicationCollectorEntity<T> response = new()
            {
                IsSuccess = mapperDto.IsSuccess,
                Data = mapperDto.Items,
                Records = mapperDto.Records,
                MessageResponse = ReplyMessage.MESSAGE_QUERY_SUCCESSFULL,
                HttpStatus = StatusCodes.Status200OK
            };

            return await Task.FromResult(response);
        }
    }
}
