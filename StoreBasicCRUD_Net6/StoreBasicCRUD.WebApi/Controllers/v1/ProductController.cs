using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.RequestDtos;
using StoreBasicCRUD.ApplicationServices.Interfaces.ProductsServices;
using StoreBasicCRUD.ControllersCoreStructure.ControllerHelpers.Collectors.Exceptions;
using StoreBasicCRUD.ControllersCoreStructure.ControllerHelpers.Collectors.ResultResponses.Interfaces;

namespace StoreBasicCRUD.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProductController : BaseApiProductsController
    {
        public ProductController(IGetAllProductsService getAllProductsService, IGenericCustomResultResponse genericCustomResultResponse, ISaveProductService saveProductService, IUpdateProductService updateProductService, IRemoveProductService removeProductService, IGetProductByIdService getProductByIdService) : base(getAllProductsService, genericCustomResultResponse, saveProductService, updateProductService, removeProductService, getProductByIdService)
        {
        }

        [HttpGet("Products")]
        public async Task<IActionResult> GetProductsListAsync()
        {
            try
            {
                var response = await _getAllProductsService.ResponseAsync();
                return await _genericCustomResultResponse.ResponseAsync(response, response.StatusResponse);
            }
            catch (Exception)
            {
                var response = await ControllerExceptionBasicCollectorStatic.ResponseAsync();
                return await Task.FromResult(StatusCode(StatusCodes.Status500InternalServerError, response));
            }
        }

        [HttpGet("Product/{id:int}")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            try
            {
                var response = await _getProductByIdService.ResponseAsync(id);
                return await _genericCustomResultResponse.ResponseAsync(response, response.StatusResponse);
            }
            catch (Exception)
            {
                var response = await ControllerExceptionBasicCollectorStatic.ResponseAsync();
                return await Task.FromResult(StatusCode(StatusCodes.Status500InternalServerError, response));
            }
        }

        [HttpPost("RegisterProduct")]
        public async Task<IActionResult> SaveProductAsync([FromBody] ProductRequestDto request)
        {
            try
            {
                var response = await _saveProductService.ResponseAsync(request);
                return await _genericCustomResultResponse.ResponseAsync(response, response.StatusResponse);
            }
            catch (Exception)
            {
                var response = await ControllerExceptionBasicCollectorStatic.ResponseAsync();
                return await Task.FromResult(StatusCode(StatusCodes.Status500InternalServerError, response));
            }
        }

        [HttpPut("EditProduct/{id:int}")]
        public async Task<IActionResult> EditProductAsync(int id, [FromBody] ProductRequestDto request)
        {
            try
            {
                var response = await _updateProductService.ResponseAsync(id, request);
                return await _genericCustomResultResponse.ResponseAsync(response, response.StatusResponse);
            }
            catch (Exception)
            {
                var response = await ControllerExceptionBasicCollectorStatic.ResponseAsync();
                return await Task.FromResult(StatusCode(StatusCodes.Status500InternalServerError, response));
            }
        }

        [HttpDelete("DeleteProduct/{id:int}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            try
            {
                var response = await _removeProductService.ResponseAsync(id);
                return await _genericCustomResultResponse.ResponseAsync(response, response.StatusResponse);
            }
            catch (Exception)
            {
                var response = await ControllerExceptionBasicCollectorStatic.ResponseAsync();
                return await Task.FromResult(StatusCode(StatusCodes.Status500InternalServerError, response));
            }
        }
    }
}
