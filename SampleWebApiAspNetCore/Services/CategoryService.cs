using LangUp.Entities;
using LangUp.Repositories.Interfaces;
using LangUp.Services.Interfaces;
using LangUp.ViewModels;
using LangUp.ViewModels.CategoriesViewModel;
using LangUp.ViewModels.CoursesViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LangUp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _icategoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _icategoryRepository = categoryRepository;
        }

        public async Task<ServiceResponse<bool>> CreateCategory(string categoryName)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                if (String.IsNullOrEmpty(categoryName))
                {
                    response.Message = "Category Name can NOT empty";
                    return response;
                }
                if (IsExistCategory(categoryName))
                {
                    response.Message = "Category has exist";
                    return response;
                }
                var newCategory = new Category
                {
                    CategoryName = categoryName,
                    Status = 1
                };

                if (await _icategoryRepository.Create(newCategory) != null)
                {
                    response.Message = "Create Category Successfull";
                    response.Data = true;
                    response.Success = true;
                }
            }
            catch (Exception e)
            {
                response.Message = "Create Category Fail: " + e.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateCategory(EditCategoryViewModel editCategoryViewModelIn)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var category = (await _icategoryRepository.FindBy(x => x.CategoryId == editCategoryViewModelIn.CategoryId)).FirstOrDefault();
                if (category == null)
                {
                    response.Message = "Category NOT exist";
                    return response;
                }
                category.Status = editCategoryViewModelIn.Status;
                category.CategoryName = editCategoryViewModelIn.CategoryName;

                if (await _icategoryRepository.Update(category, category.CategoryId) != -1)
                {
                    response.Message = "Edit Category Successfull";
                    response.Success = true;
                    response.Data = true;
                }
            }
            catch (Exception e)
            {
                response.Message = "Edit Category Failed: "+e.Message;
            }

            return response;
        }

        public bool IsExistCategory(string categoryName)
        {
            var category = _icategoryRepository.FindBy(x => x.CategoryName.Equals(categoryName));
            if (category == null)
            {
                return false;
            }
            return true;
        }

        public async Task<ServiceResponse<bool>> DeleteCategory(Guid categoryId)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var category = (await _icategoryRepository.FindBy(x => x.CategoryId == categoryId)).FirstOrDefault();
                if (category == null)
                {
                    response.Message = "Category NOT exist";
                    return response;
                }
                category.Status = -1;

                if (await _icategoryRepository.Update(category, category.CategoryId) != -1)
                {
                    response.Message = "Delete Category Successfull";
                    response.Success = true;
                    response.Data = true;
                }
            }
            catch (Exception e)
            {
                response.Message = "Delete Category Failed: "+e.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<Category>>> GetAllCategory()
        {

            try
            {
                return new ServiceResponse<IEnumerable<Category>>
                {
                    Data = (await _icategoryRepository.FindBy(x => x.Status != -1)).ToList(),
                    Message = "Get all categories",
                    Success = true
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
