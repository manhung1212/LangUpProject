using LangUp.Entities;
using LangUp.Repositories;
using LangUp.Repositories.Interfaces;
using LangUp.Services.Interfaces;
using LangUp.ViewModels;
using LangUp.ViewModels.CategoriesViewModel;
using LangUp.ViewModels.CoursesViewModel;
using LangUp.ViewModels.LessonsViewModel;
using LangUp.ViewModels.UsersViewModel;
using LangUp.ViewModels.WordDetailsViewModel;
using LangUp.ViewModels.WordsViewModel;
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
    public class WordController : ControllerBase
    {
        private readonly IWordService _iwordService;

        public WordController(
            IWordService wordService)
        {
            _iwordService = wordService;
        }

        [HttpGet]
        [Route("GetAllWordByLesson")]
        public async Task<ActionResult> GetAllWordByLesson(Guid lessonId)
        {
            ServiceResponse<IEnumerable<Word>> response = await _iwordService.GetAllWordyLessonId(lessonId);
            return Ok(response);
        }

        [HttpPost]
        [Route("CreateWord")]
        public async Task<ActionResult> CreateWord(CreateWordViewModel createLessonViewModel)
        {
            Guid crrId = Guid.Parse("574203e1-8253-4fd6-bc92-911723a12cd7");
            ServiceResponse<bool> response = await _iwordService.CreateWord(createLessonViewModel, crrId);
            return Ok(response);
        }

        [HttpPatch]
        [Route("UpdateWord")]
        public async Task<ActionResult> UpdateWord(EditWordViewModel editLessonViewModel)
        {
            Guid crrId = Guid.Parse("574203e1-8253-4fd6-bc92-911723a12cd7");
            ServiceResponse<bool> response = await _iwordService.UpdateWord(editLessonViewModel, crrId);
            return Ok(response);
        }

        [HttpPatch]
        [Route("UpdateSingleDetailWord")]
        public async Task<ActionResult> UpdateSingleDetailWord(EditSingleWordDetailsViewModel editSingleWordDetailsViewModel)
        {
            Guid crrId = Guid.Parse("574203e1-8253-4fd6-bc92-911723a12cd7");
            ServiceResponse<bool> response = await _iwordService.UpdateSingleDetailWord(editSingleWordDetailsViewModel, crrId);
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteWord")]
        public async Task<ActionResult> DeleteWord(Guid lessonId)
        {
            Guid crrId = Guid.Parse("574203e1-8253-4fd6-bc92-911723a12cd7");
            ServiceResponse<bool> response = await _iwordService.DeleteWord(lessonId, crrId);
            return Ok(response);
        }
    }
}
