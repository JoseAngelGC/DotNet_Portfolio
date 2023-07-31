using Microsoft.AspNetCore.Mvc;

namespace ApiCrudAndAngular.CoreAbstractions.Helpers.ApiControllers.Responses
{
    public interface IControllerBasicResponsesHelpersService
    {
        Task<ObjectResult> CustomResponseBasicHelperAsync<T>(T applicationResponse, int statusResponse);
        Task<object> ExceptionResponseBasicHelperAsync();
    }
}
