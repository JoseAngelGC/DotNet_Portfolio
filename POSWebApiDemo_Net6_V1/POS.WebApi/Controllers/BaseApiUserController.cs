using Microsoft.AspNetCore.Mvc;
using POS.Application.Interfaces.UserServices.Commands.SaveItem;
using POS.Application.Interfaces.UserServices.Queries.GetToken;
using POS.Infraestructure.Helpers.WebApi.Controllers.Commons.Responses;

namespace POS.WebApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BaseApiUserController : ControllerBase
    {
        protected readonly ISaveUserApplicationService _saveUserApplicationService;
        protected readonly IGetTokenApplicationService _tokenApplicationService;
        protected readonly GenericCustomResult _genericCustomResult;

        public BaseApiUserController(ISaveUserApplicationService saveUserApplicationService, IGetTokenApplicationService tokenApplicationService)
        {
            _saveUserApplicationService = saveUserApplicationService;
            _tokenApplicationService = tokenApplicationService;
            _genericCustomResult = new GenericCustomResult();
        }
    }
}
