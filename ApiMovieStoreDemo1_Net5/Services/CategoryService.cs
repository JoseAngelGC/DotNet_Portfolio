using ApiMovieStoreDemo1_Net5.Helpers.IHelpers;
using ApiMovieStoreDemo1_Net5.Models;
using ApiMovieStoreDemo1_Net5.Models.Dtos.CategoryDtos;
using ApiMovieStoreDemo1_Net5.Models.Response.ServiceResponses.Common;
using ApiMovieStoreDemo1_Net5.Repository.IRepository;
using ApiMovieStoreDemo1_Net5.Services.IServices;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiMovieStoreDemo1_Net5.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _ictRepo;
        private readonly ICommonServiceHelpers _icsh;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository icategoryRepository, ICommonServiceHelpers icommonServiceHelpers, IMapper mapper)
        {
            _ictRepo = icategoryRepository;
            _icsh = icommonServiceHelpers;
            _mapper = mapper;
        }

        public async Task<CommonServiceResponse> CreateCategoryService(CreateCategoryDto createCategoryDto)
        {
            try
            {
                //Validation block
                var existCategoryResponse = await _ictRepo.ExistCategoryByName(createCategoryDto.Nombre);
                if (existCategoryResponse.OperationCodeRepositoryResponse == -1)
                {
                    return _icsh.CommonServiceResponseHelper(existCategoryResponse.OperationCodeRepositoryResponse, "Ocurrio un inconveniente de tipo REC902E!");
                }

                if (existCategoryResponse.ExistCategoryRepoResponse)
                {
                    return _icsh.CommonServiceResponseHelper(existCategoryResponse.OperationCodeRepositoryResponse, "Exist");
                }

                //Create Category block
                var categoryModelMapper = _mapper.Map<Category>(createCategoryDto);
                categoryModelMapper.CreatedDate = DateTime.Now;
                categoryModelMapper.UpdatedBy = createCategoryDto.CreatedBy;
                categoryModelMapper.UpdatedDate = DateTime.Now;
                var createCategoryResponse = await _ictRepo.CreateCategory(categoryModelMapper);
                if (createCategoryResponse.OperationCodeRepositoryResponse == -1)
                {
                    return _icsh.CommonServiceResponseHelper(createCategoryResponse.OperationCodeRepositoryResponse, "Ocurrio un inconveniente de tipo R902E!");
                }

                return _icsh.CommonServiceResponseHelper(createCategoryResponse.OperationCodeRepositoryResponse, "Se creó de manera exitosa la categoria!");
            }
            catch (Exception)
            {
                return _icsh.CommonServiceResponseHelper(-2, "Ocurrio un inconveniente de tipo S902E!");
            }
        }

        public async Task<CommonServiceResponse> DeleteCategoryService(int id)
        {
            try
            {
                //Validation block
                var getCategoryResponse = await _ictRepo.GetCategory(id);
                if (getCategoryResponse.OperationCodeRepositoryResponse == -1)
                {
                    return _icsh.CommonServiceResponseHelper(getCategoryResponse.OperationCodeRepositoryResponse, "Ocurrio un inconveniente de tipo REC903E!");
                }

                if (getCategoryResponse.CategoryDataRepositoryResponse == null)
                {
                    return _icsh.CommonServiceResponseHelper(getCategoryResponse.OperationCodeRepositoryResponse, "NotFound");
                }

                //Delete Category block
                var deleteCategoryResponse = await _ictRepo.DeleteCategory(getCategoryResponse.CategoryDataRepositoryResponse);
                if (deleteCategoryResponse.OperationCodeRepositoryResponse == -1)
                {
                    return _icsh.CommonServiceResponseHelper(deleteCategoryResponse.OperationCodeRepositoryResponse, "Ocurrio un inconveniente de tipo R904E!");
                }

                return _icsh.CommonServiceResponseHelper(deleteCategoryResponse.OperationCodeRepositoryResponse, "Se eliminó de manera exitosa la categoria!");
            }
            catch (Exception)
            {
                return _icsh.CommonServiceResponseHelper(-2, "Ocurrio un inconveniente de tipo S904E!");
            }
        }

        public async Task<CommonServiceResponse> GetCategoriesService()
        {
            try
            {
                var CategoryListDto = new List<CategoryDto>();
                var getCategoriesResponse = await _ictRepo.GetCategories();
                if (getCategoriesResponse.OperationCodeRepositoryResponse == -1)
                {
                    return _icsh.CommonServiceResponseHelper(getCategoriesResponse.OperationCodeRepositoryResponse, "Ocurrio un inconveniente de tipo R900E!");
                }

                if (getCategoriesResponse.CategoryCollectionRepositoryResponse.Count == 0)
                {
                    return _icsh.CommonServiceResponseHelper(getCategoriesResponse.OperationCodeRepositoryResponse, "No hay registros insertados!", null);
                }

                foreach (var lista in getCategoriesResponse.CategoryCollectionRepositoryResponse)
                {
                    CategoryListDto.Add(_mapper.Map<CategoryDto>(lista));
                }

                return _icsh.CommonServiceResponseHelper(getCategoriesResponse.OperationCodeRepositoryResponse, "Listado de categorias!", CategoryListDto);
            }
            catch (Exception)
            {
                return _icsh.CommonServiceResponseHelper(-2, "Ocurrio un inconveniente de tipo S900E!");
            }
        }

        public async Task<CommonServiceResponse> GetCategoryService(int categoryId)
        {
            try
            {
                var categoryDto = new CategoryDto();
                var getCategoryResponse = await _ictRepo.GetCategory(categoryId);
                if (getCategoryResponse.OperationCodeRepositoryResponse == -1)
                {
                    return _icsh.CommonServiceResponseHelper(getCategoryResponse.OperationCodeRepositoryResponse, "Ocurrio un inconveniente de tipo R901E!");
                }

                if (getCategoryResponse.CategoryDataRepositoryResponse == null)
                {
                    return _icsh.CommonServiceResponseHelper(getCategoryResponse.OperationCodeRepositoryResponse, "NotFound");
                }

                categoryDto = _mapper.Map<CategoryDto>(getCategoryResponse.CategoryDataRepositoryResponse);

                return _icsh.CommonServiceResponseHelper(getCategoryResponse.OperationCodeRepositoryResponse, "Categoria encontrada!", categoryDto);
            }
            catch (Exception)
            {
                return _icsh.CommonServiceResponseHelper(-2, "Ocurrio un inconveniente de tipo S901E!");
            }
        }

        public async Task<CommonServiceResponse> UpdateCategoryService(UpdateCategoryDto updateCategoryDto)
        {
            try
            {
                //Validation block
                var getCategoryResponse = await _ictRepo.GetCategory(updateCategoryDto.CategoryId);
                if (getCategoryResponse.OperationCodeRepositoryResponse == -1)
                {
                    return _icsh.CommonServiceResponseHelper(getCategoryResponse.OperationCodeRepositoryResponse, "Ocurrio un inconveniente de tipo REC903E!");
                }

                if (getCategoryResponse.CategoryDataRepositoryResponse == null)
                {
                    return _icsh.CommonServiceResponseHelper(getCategoryResponse.OperationCodeRepositoryResponse, "NotFound", null);
                }

                //Update data values
                getCategoryResponse.CategoryDataRepositoryResponse.CategoryName = updateCategoryDto.Nombre;
                getCategoryResponse.CategoryDataRepositoryResponse.UpdatedBy = updateCategoryDto.UpdatedBy;
                getCategoryResponse.CategoryDataRepositoryResponse.UpdatedDate = DateTime.Now;
                var updateCategory_Response = await _ictRepo.UpdateCategory(getCategoryResponse.CategoryDataRepositoryResponse);

                if (updateCategory_Response.OperationCodeRepositoryResponse == -1)
                {
                    return _icsh.CommonServiceResponseHelper(getCategoryResponse.OperationCodeRepositoryResponse, "Ocurrio un inconveniente de tipo R903E!");
                }

                return _icsh.CommonServiceResponseHelper(getCategoryResponse.OperationCodeRepositoryResponse, "Se editó de manera exitosa la categoria!");
            }
            catch (Exception)
            {
                return _icsh.CommonServiceResponseHelper(-2, "Ocurrio un inconveniente de tipo S903E!");
            }
        }
    }
}
