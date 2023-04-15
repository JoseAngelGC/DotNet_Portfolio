using POS.Infraestructure.Helpers.Interactors.Commons.Responses.Bases;
using POS.Infraestructure.SupportDtos.Interactors.Commons.Responses;
using POS.Infraestructure.SupportEntities.Commons.Collectors.Interactors;

namespace POS.Infraestructure.Helpers.Interactors.Commons.Responses
{
    public class QueryInteractorBasicServiceResponseHelper: BaseQueryInteractorBasicServiceResponseHelper
    {
        public override async Task<GenericQueryInteractorResponseDto<T>> ResponseAsync<T>(QueryInteractorCollectorEntity<T> queryCollectorEntity)
        {
            GenericQueryInteractorResponseDto<T> response = new()
            {
                IsSuccess = queryCollectorEntity.IsSuccess,
                CustomErrorCode = queryCollectorEntity.CustomErrorCode,
                MessageResponse = queryCollectorEntity.MessageResponse,
                ControlMessage = queryCollectorEntity.ControlMessage,
                Items = queryCollectorEntity.Items,
                Records = queryCollectorEntity.Records
            };

            return await Task.FromResult(response);
        }
    }
}
