using LangUp.Entities;
using LangUp.ViewModels;
using LangUp.ViewModels.CoursesViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LangUp.Services.Interfaces
{
    public interface ICourseService
    {
        Task<ServiceResponse<bool>> CreateCourse(CreateCourseViewModel createCourseViewModel, Guid crrUser);
        Task<ServiceResponse<bool>> UpdateCourse(EditCourseViewModel editCourseViewModel, Guid crrUser);
        Task<ServiceResponse<bool>> DeleteCourse(Guid courseId, Guid crrUser);
        Task<ServiceResponse<IEnumerable<Course>>> GetAllCourses();
    }
}
