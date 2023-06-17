using Microsoft.AspNetCore.Mvc;


namespace StoreBasicCRUD.ControllersCoreStructure.ControllerHelpers.Collectors.ResultResponses.Interfaces
{
    public interface IGenericCustomResultResponse
    {
        Task<ObjectResult> ResponseAsync<T>(T applicationResponse, int statusResponse);
    }
}
