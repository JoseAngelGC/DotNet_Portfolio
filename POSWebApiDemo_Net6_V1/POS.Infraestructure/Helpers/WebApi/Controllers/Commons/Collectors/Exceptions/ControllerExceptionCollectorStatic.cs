using POS.Utilities.Commons.Consts;

namespace POS.Infraestructure.Helpers.WebApi.Controllers.Commons.Collectors.Exceptions
{
    public static class ControllerExceptionCollectorStatic
    {
        public static async Task<object> ResponseAsync(int customErrorCode)
        {
            object response = new
            {
                MessageResponse = ReplyMessage.MESSAGE_FAILED,
                Information = "Ocurrio un inconveniente de tipo " + customErrorCode + "!",
                StatusResponse = 500
            };

            return await Task.FromResult(response);
        }
    }
}
