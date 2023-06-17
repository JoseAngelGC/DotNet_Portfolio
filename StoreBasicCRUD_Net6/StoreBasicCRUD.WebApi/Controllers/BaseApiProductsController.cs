using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreBasicCRUD.ApplicationServices.Interfaces.ProductsServices;
using StoreBasicCRUD.ControllersCoreStructure.ControllerHelpers.Collectors.ResultResponses.Interfaces;

namespace StoreBasicCRUD.WebApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BaseApiProductsController : ControllerBase
    {
        protected readonly IGetAllProductsService _getAllProductsService;
        protected readonly IGenericCustomResultResponse _genericCustomResultResponse;
        protected readonly ISaveProductService _saveProductService;
        protected readonly IUpdateProductService _updateProductService;
        protected readonly IRemoveProductService _removeProductService;
        protected readonly IGetProductByIdService _getProductByIdService;

        public BaseApiProductsController(IGetAllProductsService getAllProductsService, IGenericCustomResultResponse genericCustomResultResponse, ISaveProductService saveProductService, IUpdateProductService updateProductService, IRemoveProductService removeProductService, IGetProductByIdService getProductByIdService)
        {
            _getAllProductsService = getAllProductsService;
            _genericCustomResultResponse = genericCustomResultResponse;
            _saveProductService = saveProductService;
            _updateProductService = updateProductService;
            _removeProductService = removeProductService;
            _getProductByIdService = getProductByIdService;
        }
    }
}
