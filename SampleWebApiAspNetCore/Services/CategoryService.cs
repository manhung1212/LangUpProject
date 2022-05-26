using LangUp.Entities;
using LangUp.Repositories.Interfaces;
using LangUp.Services.Interfaces;
using LangUp.ViewModels;
using LangUp.ViewModels.CategoriesViewModel;
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
            if (String.IsNullOrEmpty(categoryName))
            {
                return new ServiceResponse<bool> { Data = false, Success = false, Message = "Category Name can NOT empty" };
            }
            if (isExistCategory(categoryName))
            {
                return new ServiceResponse<bool> { Data = false, Success = false, Message = "Category has exist" };
            }
            var newCategory = new Category
            {
                CategoryName = categoryName,
                Status = 1
            };

            if (await _icategoryRepository.Create(newCategory) != null)
            {
                return new ServiceResponse<bool> { Data = true, Success = true, Message = "Create Category Successfull" };
            }
            return new ServiceResponse<bool> { Data = false, Success = false, Message = "Create Category Successfull" };
        }


        public async Task<ServiceResponse<bool>> UpdateCategory(EditCategoryViewModel editCategoryViewModelIn)
        {
            var category = (await _icategoryRepository.FindBy(x => x.CategoryId == editCategoryViewModelIn.CategoryId)).FirstOrDefault();
            if (category == null)
            {
                return new ServiceResponse<bool> { Data = false, Success = false, Message = "Category NOT exist" };
            }
            category.Status = editCategoryViewModelIn.Status;
            category.CategoryName = editCategoryViewModelIn.CategoryName;

            if (await _icategoryRepository.Update(category, category.CategoryId) != -1)
            {
                return new ServiceResponse<bool> { Data = true, Success = true, Message = "Edit Category Successfull" };
            }
            return new ServiceResponse<bool> { Data = false, Success = false, Message = "Edit Category Successfull" };
        }

        public bool isExistCategory(string categoryName)
        {
            var category = _icategoryRepository.FindBy(x => x.CategoryName.Equals(categoryName));
            if (category == null)
            {
                return true;
            }
            return false;
        }
    }
}
