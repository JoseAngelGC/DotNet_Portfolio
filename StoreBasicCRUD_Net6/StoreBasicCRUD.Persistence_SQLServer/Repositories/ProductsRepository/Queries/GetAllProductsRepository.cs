using StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.EntitiesDtos;
using StoreBasicCRUD.Persistence_SQLServer.Context;
using StoreBasicCRUD.Persistence_SQLServer.Interfaces.IProductsRepository.Queries;

namespace StoreBasicCRUD.Persistence_SQLServer.Repositories.ProductsRepository.Queries
{
    public class GetAllProductsRepository : IGetAllProductsRepository
    {
        private readonly StoreBasicCrudContext _context;
        public GetAllProductsRepository(StoreBasicCrudContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDto>> ResponsesAsync()
        {
            var query = _context.Products.Join(_context.Categories, product => product.IdCategory,
                category => category.IdCategory, (product, category) => new
                {
                    ProductId = product.IdProduct,
                    NameProduct = product.Nombre,
                    PrecioProduct = product.Precio,
                    CategoryId = category.IdCategory,
                    NameCategory = category.Nombre
                }).ToList();

            List<ProductDto> productDtoList = new List<ProductDto>();

            foreach (var item in query)
            {
                ProductDto productDto = new ProductDto();
                productDto.IdProduct = item.ProductId;
                productDto.Nombre = item.NameProduct;
                productDto.Precio = item.PrecioProduct;
                productDto.IdCategory = item.CategoryId;
                productDto.Category = item.NameCategory;
                productDtoList.Add(productDto);
            }

            return await Task.FromResult(productDtoList);
        }
    }
}
