using Microsoft.AspNetCore.Mvc;


namespace POS.Infraestructure.Interfaces.Application.Commons.Responses
{
    public interface IGenericCustomResult
    {
        Task<ObjectResult> ResponseAsync<T>(T applicationResponse, int statusResponse);
    }
}
