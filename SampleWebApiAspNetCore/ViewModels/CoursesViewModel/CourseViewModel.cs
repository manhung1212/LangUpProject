using LangUp.Entities;
using System;
using System.Collections.Generic;

namespace LangUp.ViewModels.CourseViewModel
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
        public CategoryViewModel.CategoryViewModel CategoryViewModel { get; set; }
        public  ICollection<CourseOfUserViewModel.CourseOfUserViewModel> CourseOfUserViewModel { get; set; }
        public  ICollection<LessonViewModel.LessonViewModel> LessonViewModel { get; set; }
    }
}
