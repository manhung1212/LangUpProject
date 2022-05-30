using LangUp.Entities;
using LangUp.Repositories.Interfaces;
using LangUp.Services.Interfaces;
using LangUp.ViewModels;
using LangUp.ViewModels.LessonsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LangUp.Services
{
    public class LessonService : ILessonService
    {
        private readonly ICourseRepository _icourseRepository;
        private readonly ILessonRepository _ilessonRepository;
        public LessonService(ICourseRepository courseRepository, ILessonRepository lessonRepository)
        {
            _icourseRepository = courseRepository;
            _ilessonRepository = lessonRepository;
        }

        public async Task<ServiceResponse<bool>> CreateLesson(CreateLessonViewModel createLessonViewModel, Guid crrUser)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var checkCourse = (await _icourseRepository.FindBy(x => x.CourseId == createLessonViewModel.CourseId)).FirstOrDefault();
                if (checkCourse == null)
                {
                    response.Message = "Course NOT exist";
                    return response;
                }
                if (String.IsNullOrWhiteSpace(createLessonViewModel.LessonName))
                {
                    response.Message = "Course name CAN NOT empty";
                    return response;
                }

                var creLesson = new Lesson
                {
                    CourseId = createLessonViewModel.CourseId,
                    LessonName = createLessonViewModel.LessonName,
                    LessonDescription = createLessonViewModel.LessonDescription,
                    Status = 1
                };
                if((await _ilessonRepository.Create(creLesson)) != null)
                {
                    response.Success = true;
                    response.Message = "Create Lessson Successfull";
                    response.Data = true;
                }
            }
            catch (Exception e)
            {
                response.Message = "CreateLesson Failed: " + e.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteLesson(Guid lessonId, Guid crrUser)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var checkLesson = (await _ilessonRepository.FindBy(x => x.LessonId == lessonId)).FirstOrDefault();
                if (checkLesson == null)
                {
                    response.Message = "Lesson NOT exist";
                    return response;
                }
                var courseOfLesson = (await _icourseRepository.FindBy(x => x.CourseId == checkLesson.CourseId)).FirstOrDefault();
                if (courseOfLesson == null)
                {
                    response.Message = "Course of Lesson NOT exist";
                    return response;
                }
                if (courseOfLesson.AuthorId != crrUser)
                {
                    response.Message = "You NOT permission this function";
                    return response;
                }
                checkLesson.Status = -1;
                if((await _ilessonRepository.Update(checkLesson, checkLesson.LessonId)) != -1)
                {
                    response.Message = "DeleteLesson Successfull";
                    response.Success = true;
                    response.Data = true;
                }
            }
            catch (Exception e)
            {
                response.Message = "DeleteLesson Failed: " + e.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<Lesson>>> GetAllLessonByCourseId(Guid courseId)
        {
            var response = new ServiceResponse<IEnumerable<Lesson>>();
            try
            {
                var checkCourse = (await _icourseRepository.FindBy(x => x.CourseId == courseId)).FirstOrDefault();
                if (checkCourse == null)
                {
                    response.Message = "Course NOT exist";
                    return response;
                }

                response.Data = (await _ilessonRepository.FindBy(x => x.CourseId == courseId)).ToList();
                response.Message = "Get All Lesson by Course";
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Message = "GetAllLesson Failed: " + e.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateLesson(EditLessonViewModel editLessonViewModel, Guid crrUser)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var checkLesson = (await _ilessonRepository.FindBy(x => x.LessonId == editLessonViewModel.LessonId)).FirstOrDefault();
                if (checkLesson == null)
                {
                    response.Message = "Lesson NOT exist";
                    return response;
                }
                var courseOfLesson = (await _icourseRepository.FindBy(x => x.CourseId == checkLesson.CourseId)).FirstOrDefault();
                if (courseOfLesson == null)
                {
                    response.Message = "Course of Lesson NOT exist";
                    return response;
                }
                if (courseOfLesson.AuthorId != crrUser)
                {
                    response.Message = "You NOT permission this function";
                    return response;
                }
                checkLesson.Status = editLessonViewModel.Status;
                checkLesson.LessonDescription = editLessonViewModel.LessonDescription;
                checkLesson.LessonName = editLessonViewModel.LessonName;
                if ((await _ilessonRepository.Update(checkLesson, checkLesson.LessonId)) != -1)
                {
                    response.Message = "Edit Successfull";
                    response.Success = true;
                    response.Data = true;
                }
            }
            catch (Exception e)
            {
                response.Message = "UpdateLesson Failed: " + e.Message;
            }
            return response;
        }
    }
}
