using LangUp.ViewModels;
using LangUp.ViewModels.CategoriesViewModel;
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
    }
}
