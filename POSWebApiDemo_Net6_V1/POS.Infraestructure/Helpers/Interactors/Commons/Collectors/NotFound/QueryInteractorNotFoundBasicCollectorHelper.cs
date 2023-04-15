using POS.Infraestructure.Helpers.Interactors.Commons.Collectors.NotFound.Bases;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Interactors;
using POS.Utilities.Commons.Consts;

namespace POS.Infraestructure.Helpers.Interactors.Commons.Collectors.NotFound
{
    public class QueryInteractorNotFoundBasicCollectorHelper : BaseQueryInteractorNotFoundBasicCollectorHelper
    {
        public override async Task<QueryInteractorCollectorEntity<T>> ResponseAsync<T>(int? records)
        {
            QueryInteractorCollectorEntity<T> response = new();
            if (records is not null)
            {
                response.Records = records;
            }
            response.IsSuccess = true;
            response.ControlMessage = ControlEvent.MESSAGE_NOTFOUND;

            return await Task.FromResult(response);
        }
    }
}
