using System;
using System.Collections.Generic;

namespace LangUp.ViewModels.CategoriesViewModel
{
    public class CategoryViewModel
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int Status { get; set; }
        public ICollection<CoursesViewModel.CourseViewModel> CourseViewModel { get; set; }
    }
}
