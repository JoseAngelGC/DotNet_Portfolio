using StoreBasicCRUD.Utilities.Shared.Consts;


namespace StoreBasicCRUD.ControllersCoreStructure.ControllerHelpers.Collectors.Exceptions
{
    public class ControllerExceptionBasicCollectorStatic
    {
        public static async Task<object> ResponseAsync()
        {
            object response = new
            {
                MessageResponse = ReplyMessage.MESSAGE_FAILED,
                Information = "Ocurrio un inconveniente de tipo ...!",
                StatusResponse = 500
            };

            return await Task.FromResult(response);
        }
    }
}
