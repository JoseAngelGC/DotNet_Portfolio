using Microsoft.AspNetCore.Mvc;


namespace ApiCrudWithBlazor.Core.Abstraction.BasicHelpers.ApiControllersResponses
{
    public interface IControllerResponsesBasicsHelpersService
    {
        Task<ObjectResult> CustomResponseBasicHelperAsync<T>(T applicationResponse, int statusResponse);
        Task<object> ExceptionResponseBasicHelperAsync();
    }
}
