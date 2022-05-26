using System;
using System.Collections.Generic;

namespace LangUp.ViewModels.CoursesViewModel
{
    public class CourseViewModel
    {
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
        public Guid CategoryId { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int Status { get; set; }
        public Guid AuthorId { get; set; }
        public int TotalLeaner { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsPrivate { get; set; }
        public CategoriesViewModel.CategoryViewModel CategoryViewModel { get; set; }
        public ICollection<CourseOfUsersViewModel.CourseOfUsersViewModel> CourseOfUserViewModel { get; set; }
        public ICollection<LessonsViewModel.LessonViewModel> LessonViewModel { get; set; }
    }
}
