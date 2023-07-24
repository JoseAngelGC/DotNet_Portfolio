using ApiCrudWithBlazor.CoreAbstractions.CoreEntities.Dtos.RequestsDtos;
using ApiCrudWithBlazor.CoreAbstractions.Repositories.ProductRepositories.Queries;
using ApiCrudWithBlazor.Entities.ApiCrud.EFCore;
using ApiCrudWithBlazor.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudWithBlazor.Repositories.ProductRepositories.Queries
{
    public class NewProductExistRepository<T> : INewProductExistRepository<T> where T : Product
    {
        private readonly StoreBasicCrudContext _context;
        private readonly DbSet<T> _entity;
        private bool _response;
        public NewProductExistRepository(StoreBasicCrudContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
            _response = default;
        }
        public async Task<bool> QueryAsync(string recordAction, ProductRequestPivotDto entity)
        {
            switch (recordAction)
            {
                //Validate if product exist, matching 1 parameter (idProduct).
                case "IDPRODUCT":
                    _response = await _entity.AnyAsync(p => p.IdProduct == entity.IdProduct);
                    break;

                //Validate if product exist, matching 1 parameter (idProduct).
                case "PRODUCTNAME":
                    _response = await _entity.AnyAsync(p => p.Nombre == entity.Nombre);
                    break;

                //Validate if product exist, matching 2 parameters (name, idCategory).
                case "NAME_IDCATEGORY":
                    _response = await _entity.AnyAsync(p => p.Nombre.ToLower().Trim() == entity.Nombre.ToLower() && p.IdCategory == entity.IdCategory);
                    break;

                //Validate if product exist, matching 3 parameters (idProduct,name, idCategory).
                case "IDPRODUCT_NAME_IDCATEGORY":
                    _response = await _entity.AnyAsync(p => p.IdProduct == entity.IdProduct && p.Nombre.ToLower().Trim() == entity.Nombre.ToLower() && p.IdCategory == entity.IdCategory);
                    break;
            }
            
            return _response;
        }
    }
}
