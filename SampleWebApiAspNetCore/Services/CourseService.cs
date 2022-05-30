using LangUp.Entities;
using LangUp.Repositories.Interfaces;
using LangUp.Services.Interfaces;
using LangUp.ViewModels;
using LangUp.ViewModels.CoursesViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LangUp.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _icourseRepository;
        private readonly ICategoryRepository _icategoryRepository;
        public CourseService(ICourseRepository courseRepository, ICategoryRepository categoryRepository)
        {
            _icourseRepository = courseRepository;
            _icategoryRepository = categoryRepository;
        }

        public async Task<ServiceResponse<bool>> CreateCourse(CreateCourseViewModel createCourseViewModel)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                if (String.IsNullOrWhiteSpace(createCourseViewModel.CourseName))
                {
                    response.Message = "Course name can NOT empty";
                    return response;
                }

                var category = (await _icategoryRepository.FindBy(x => x.CategoryId == createCourseViewModel.CategoryId)).FirstOrDefault();
                if (category == null)
                {
                    response.Message = "Category not exist";
                    return response;
                }

                var course = new Course
                {
                    AuthorId = Guid.Parse("574203e1-8253-4fd6-bc92-911723a12cd7"), //temp is huynhnd
                    CategoryId = category.CategoryId,
                    Code = "CodeTemp",
                    CourseName = createCourseViewModel.CourseName,
                    Description = createCourseViewModel.Description,
                    IsPrivate = createCourseViewModel.IsPrivate,
                    Status = 1,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                };

                if ((await _icourseRepository.Create(course)) != null)
                {
                    response.Data = true;
                    response.Message = "Create Course Successfull";
                    response.Success = true;
                }
            }
            catch (Exception e)
            {
                response.Message = "Create Course Failed: " + e.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteCourse(Guid courseId, Guid crrUser)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var course = (await _icourseRepository.FindBy(x => x.CourseId == courseId)).FirstOrDefault();
                if (course == null)
                {
                    response.Message = "Course NOT exist";
                    return response;
                }

                if (course.AuthorId != crrUser)
                {
                    response.Message = "You NOT permission this Course";
                    return response;
                }
                course.Status = -1;
                if ((await _icourseRepository.Update(course, course.CourseId)) != -1)
                {
                    response.Data = true;
                    response.Message = "Delete Course Successfull";
                    response.Success = true;
                }
            }
            catch (Exception e)
            {
                response.Message = "Delete Course Failed: " + e.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<Course>>> GetAllCourses()
        {
            var response = new ServiceResponse<IEnumerable<Course>>();
            try
            {
                response.Data = (await _icourseRepository.GetAll()).ToList();
                response.Message = "Create Course Successfull";
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Message = "Get AllCourse Failed: " + e.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateCourse(EditCourseViewModel editCourseViewModel, Guid crrUser)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var course = (await _icourseRepository.FindBy(x => x.CourseId == editCourseViewModel.CourseId)).FirstOrDefault();
                if(course == null)
                {
                    response.Message = "Course NOT exist";
                    return response;
                }

                if(course.AuthorId != crrUser)
                {
                    response.Message = "You NOT permission this Course";
                    return response;
                }

                if (String.IsNullOrWhiteSpace(editCourseViewModel.CourseName))
                {
                    response.Message = "Course name can NOT empty";
                    return response;
                }

                course.CourseName = editCourseViewModel.CourseName;
                course.Description = editCourseViewModel.Description;
                course.IsPrivate = editCourseViewModel.IsPrivate;

                if((await _icourseRepository.Update(course, course.CourseId)) != -1)
                {
                    response.Data = true;
                    response.Message = "Update Course Successfull";
                    response.Success = true;
                }
            }
            catch (Exception e)
            {
                response.Message = "Update Course Failed: " + e.Message;
            }
            return response;
        }
    }
}
