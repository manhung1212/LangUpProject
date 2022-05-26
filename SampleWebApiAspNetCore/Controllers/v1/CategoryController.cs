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
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            //var xOut = new ServiceResponse<IEnumerable<User>>
            //{
            //    Message = "Error",
            //    Success = false,
            //    Data = null
            //};

            var x = await _userService.GetAllUsers();

            //xOut.Data = x;
            //xOut.Success = true;
            //xOut.Message = "Success";

            return Ok(new ServiceResponse<IEnumerable<User>>
            {
                Data = x,
                Message = "Success",
                StatusCode = 200,
                Success = true
            });
        }


        [HttpPost]
        [Route("CreateCategory")]
        public async Task<ActionResult> CreateCategory(string categoryName)
        {
            ServiceResponse<bool> response = await _icategoryService.CreateCategory(categoryName);
            return Ok(response);
        }


        [HttpPatch]
        [Route("UpdateCategory")]
        public async Task<ActionResult> UpdateCategory(EditCategoryViewModel editCategoryViewModel)
        {
            ServiceResponse<bool> response = await _icategoryService.UpdateCategory(editCategoryViewModel);
            return Ok(response);
        }

    }
}
