using LangUp.Entities;
using LangUp.ViewModels;
using LangUp.ViewModels.CategoriesViewModel;
using LangUp.ViewModels.CoursesViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LangUp.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ServiceResponse<bool>> CreateCategory(string categoryName);
        Task<ServiceResponse<bool>> UpdateCategory(EditCategoryViewModel editCategoryViewModel);
        Task<ServiceResponse<bool>> DeleteCategory(Guid categoryId);
        Task<ServiceResponse<IEnumerable<Category>>> GetAllCategory();
    }
}
