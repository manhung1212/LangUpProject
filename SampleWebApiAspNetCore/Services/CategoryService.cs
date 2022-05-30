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
        private readonly ICourseRepository _icourseRepository;
        public CategoryService(ICategoryRepository categoryRepository,ICourseRepository courseRepository)
        {
            _icategoryRepository = categoryRepository;
            _icourseRepository = courseRepository;
        }

        public async Task<ServiceResponse<bool>> CreateCategory(string categoryName, Guid crrUser)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                //add Check is super Admin


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

        public async Task<ServiceResponse<bool>> UpdateCategory(EditCategoryViewModel editCategoryViewModelIn, Guid crrUser)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                //add Check is super Admin

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
                response.Message = "Edit Category Failed: " + e.Message;
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

        public async Task<ServiceResponse<bool>> DeleteCategory(Guid categoryId, Guid crrUser)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                //add Check is super Admin

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
                response.Message = "Delete Category Failed: " + e.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<Category>>> GetAllCategory()
        {
            var response = new ServiceResponse<IEnumerable<Category>>();

            try
            {
                var categories = (await _icategoryRepository.FindBy(x => x.Status != -1)).ToList();
                var lstCategory = new List<Category>();
                if (categories.Count > 0)
                {
                    foreach (var category in categories)
                    {
                        var courses = (await _icourseRepository.FindBy(x => x.CategoryId == category.CategoryId)).ToList();
                        if (courses.Count > 0)
                        {
                            category.Courses = courses;
                        }
                        lstCategory.Add(category);
                    }
                }
                response.Data = lstCategory;
                response.Message = "Get all categories";
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Message = "Get all categories Failed: " + e.Message;
            }
            return response;
        }
    }
}
