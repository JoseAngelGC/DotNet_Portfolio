using ApiMovieStoreDemo1_Net5.Models.Response.ServiceResponses.Common;

namespace ApiMovieStoreDemo1_Net5.Helpers.IHelpers
{
    public interface ICommonServiceHelpers
    {
        CommonServiceResponse CommonServiceResponseHelper(int code, string message);
        CommonServiceResponse CommonServiceResponseHelper(int code, string message, object data);
    }
}
