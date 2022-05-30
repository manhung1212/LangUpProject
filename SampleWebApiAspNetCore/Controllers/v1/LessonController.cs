using LangUp.Entities;
using LangUp.Repositories;
using LangUp.Repositories.Interfaces;
using LangUp.Services.Interfaces;
using LangUp.ViewModels;
using LangUp.ViewModels.CategoriesViewModel;
using LangUp.ViewModels.CoursesViewModel;
using LangUp.ViewModels.LessonsViewModel;
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
    public class LessonController : ControllerBase
    {
        private readonly IUserService _iuserService;
        private readonly ICategoryService _icategoryService;
        private readonly ICourseService _icourseService;
        private readonly ILessonService _ilessonService;

        public LessonController(
            IUserService userService,
            ICategoryService categoryService,
            ICourseService courseService,
            ILessonService lessonService)
        {
            _iuserService = userService;
            _icategoryService = categoryService;
            _icourseService = courseService;
            _ilessonService = lessonService;
        }

        [HttpGet]
        [Route("GetAllLessonByCourseId")]
        public async Task<ActionResult> GetAllLessonByCourseId(Guid courseId)
        {
            ServiceResponse<IEnumerable<Lesson>> response = await _ilessonService.GetAllLessonByCourseId(courseId);
            return Ok(response);
        }

        [HttpPost]
        [Route("CreateLesson")]
        public async Task<ActionResult> CreateLesson(CreateLessonViewModel createLessonViewModel)
        {
            Guid crrId = Guid.Parse("574203e1-8253-4fd6-bc92-911723a12cd7");
            ServiceResponse<bool> response = await _ilessonService.CreateLesson(createLessonViewModel, crrId);
            return Ok(response);
        }

        [HttpPatch]
        [Route("UpdateLesson")]
        public async Task<ActionResult> UpdateLesson(EditLessonViewModel editLessonViewModel)
        {
            Guid crrId = Guid.Parse("574203e1-8253-4fd6-bc92-911723a12cd7");
            ServiceResponse<bool> response = await _ilessonService.UpdateLesson(editLessonViewModel, crrId);
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteLesson")]
        public async Task<ActionResult> DeleteLesson(Guid lessonId)
        {
            Guid crrId = Guid.Parse("574203e1-8253-4fd6-bc92-911723a12cd7");
            ServiceResponse<bool> response = await _ilessonService.DeleteLesson(lessonId, crrId);
            return Ok(response);
        }
    }
}
