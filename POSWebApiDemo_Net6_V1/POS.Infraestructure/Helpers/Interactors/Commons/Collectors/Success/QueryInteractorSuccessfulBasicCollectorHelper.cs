using POS.Infraestructure.Helpers.Interactors.Commons.Collectors.Success.Bases;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Interactors;
using POS.Utilities.Commons.Consts;

namespace POS.Infraestructure.Helpers.Interactors.Commons.Collectors.Success
{
    public class QueryInteractorSuccessfulBasicCollectorHelper : BaseQueryInteractorSuccessfulBasicCollectorHelper
    {
        public override async Task<QueryInteractorCollectorEntity<T>> ResponseAsync<T>(T data, int records)
        {
            QueryInteractorCollectorEntity<T> response = new()
            {
                IsSuccess = true,
                Items = data,
                Records = records,
                ControlMessage = ControlEvent.MESSAGE_OPERATIONSUCCESSFULLY
            };
            return await Task.FromResult(response);
        }
    }
}
