using LangUp.Entities;
using LangUp.ViewModels;
using LangUp.ViewModels.LessonsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LangUp.Services.Interfaces
{
    public interface ILessonService
    {
        Task<ServiceResponse<bool>> CreateLesson(CreateLessonViewModel createLessonViewModel, Guid crrUser);
        Task<ServiceResponse<bool>> UpdateLesson(EditLessonViewModel editLessonViewModel, Guid crrUser);
        Task<ServiceResponse<bool>> DeleteLesson(Guid lessonId, Guid crrUser);
        Task<ServiceResponse<IEnumerable<Lesson>>> GetAllLessonByCourseId(Guid courseId);
    }
}
