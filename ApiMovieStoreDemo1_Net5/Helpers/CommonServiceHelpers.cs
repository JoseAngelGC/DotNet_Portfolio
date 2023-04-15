using ApiMovieStoreDemo1_Net5.Helpers.IHelpers;
using ApiMovieStoreDemo1_Net5.Models.Response.ServiceResponses.Common;

namespace ApiMovieStoreDemo1_Net5.Helpers
{
    public class CommonServiceHelpers : ICommonServiceHelpers
    {
        public CommonServiceResponse CommonServiceResponseHelper(int code, string message)
        {
            CommonServiceResponse response = new();
            response.OperationCodeServiceResponse = code;
            response.MessageServiceResponse = message;
            return response;
        }

        public CommonServiceResponse CommonServiceResponseHelper(int code, string message, object data)
        {
            CommonServiceResponse response = new();
            response.OperationCodeServiceResponse = code;
            response.MessageServiceResponse = message;
            response.DataServiceResponse = data;
            return response;
        }
    }
}
