using LangUp.Entities;
using System;
using System.Collections.Generic;

namespace LangUp.ViewModels.CategoryViewModel
{
    public class CategoryViewModel
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int Status { get; set; }
        public ICollection<CourseViewModel.CourseViewModel> CourseViewModel { get; set; }
    }
}
