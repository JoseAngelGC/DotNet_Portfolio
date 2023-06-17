using Microsoft.AspNetCore.Http;
using POS.Infraestructure.Helpers.Application.Commons.Collectors.Queries.NotFound.Bases;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Application;
using POS.Utilities.Commons.Consts;

namespace POS.Infraestructure.Helpers.Application.Commons.Collectors.Queries.NotFound
{
    public class QueryApplicationNotFoundBasicCollectorHelper : BaseQueryApplicationNotFoundBasicCollectorHelper
    {
        public override async Task<QueryApplicationCollectorEntity<T>> ResponseAsync<T>(bool isSuccess, int? records, string controlMessage)
        {
            QueryApplicationCollectorEntity<T> response = new();
            switch (controlMessage)
            {
                case ControlEvent.MESSAGE_NOTFOUND:
                    response.MessageResponse = ReplyMessage.MESSAGE_QUERY_EMPTY;
                    response.HttpStatus = StatusCodes.Status404NotFound;
                    break;
            }

            response.IsSuccess = isSuccess;
            response.Records = records;

            return await Task.FromResult(response);
        }
    }
}
