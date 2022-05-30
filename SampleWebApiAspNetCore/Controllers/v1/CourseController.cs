using LangUp.Entities;
using LangUp.Repositories;
using LangUp.Repositories.Interfaces;
using LangUp.Services.Interfaces;
using LangUp.ViewModels;
using LangUp.ViewModels.CategoriesViewModel;
using LangUp.ViewModels.CoursesViewModel;
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
    public class CourseController : ControllerBase
    {
        private readonly IUserService _iuserService;
        private readonly ICategoryService _icategoryService;
        private readonly ICourseService _icourseService;

        public CourseController(
            IUserService userService,
            ICategoryService categoryService,
            ICourseService courseService)
        {
            _iuserService = userService;
            _icategoryService = categoryService;
            _icourseService = courseService;
        }

        [HttpGet]
        [Route("GetAllCourse")]
        public async Task<ActionResult> GetAllCourse()
        {
            ServiceResponse<IEnumerable<Category>> response = await _icategoryService.GetAllCategory();
            return Ok(response);
        }

        [HttpPost]
        [Route("CreateCourse")]
        public async Task<ActionResult> CreateCourse(CreateCourseViewModel createCourseViewModel)
        {
            ServiceResponse<bool> response = await _icourseService.CreateCourse(createCourseViewModel);
            return Ok(response);
        }

        [HttpPatch]
        [Route("UpdateCourse")]
        public async Task<ActionResult> UpdateCourse(EditCourseViewModel editCourseViewModel)
        {
            Guid crrId = Guid.Parse("574203e1-8253-4fd6-bc92-911723a12cd7");
            ServiceResponse<bool> response = await _icourseService.UpdateCourse(editCourseViewModel, crrId);
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteCourse")]
        public async Task<ActionResult> DeleteCourse(Guid categoryId)
        {
            ServiceResponse<bool> response = await _icategoryService.DeleteCategory(categoryId);
            return Ok(response);
        }
    }
}
