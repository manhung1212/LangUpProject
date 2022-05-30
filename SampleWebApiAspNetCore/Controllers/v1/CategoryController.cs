using LangUp.Entities;
using LangUp.Repositories;
using LangUp.Repositories.Interfaces;
using LangUp.Services.Interfaces;
using LangUp.ViewModels;
using LangUp.ViewModels.CategoriesViewModel;
using LangUp.ViewModels.UsersViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LangUp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICategoryService _icategoryService;

        public CategoryController(
            IUserService userService,
            ICategoryService categoryService)
        {
            _userService = userService;
            _icategoryService = categoryService;
        }

        [HttpGet]
        [Route("GetAllCategory")]
        public async Task<ActionResult> GetAllCategory()
        {
            ServiceResponse<IEnumerable<Category>> response = await _icategoryService.GetAllCategory();
            return Ok(response);
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<ActionResult> CreateCategory(string categoryName)
        {
            Guid crrId = Guid.Parse("574203e1-8253-4fd6-bc92-911723a12cd7");
            ServiceResponse<bool> response = await _icategoryService.CreateCategory(categoryName, crrId);
            return Ok(response);
        }

        [HttpPatch]
        [Route("UpdateCategory")]
        public async Task<ActionResult> UpdateCategory(EditCategoryViewModel editCategoryViewModel)
        {
            Guid crrId = Guid.Parse("574203e1-8253-4fd6-bc92-911723a12cd7");
            ServiceResponse<bool> response = await _icategoryService.UpdateCategory(editCategoryViewModel, crrId);
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteCategory")]
        public async Task<ActionResult> DeleteCategory(Guid categoryId)
        {
            Guid crrId = Guid.Parse("574203e1-8253-4fd6-bc92-911723a12cd7");
            ServiceResponse<bool> response = await _icategoryService.DeleteCategory(categoryId, crrId);
            return Ok(response);
        }
    }
}
