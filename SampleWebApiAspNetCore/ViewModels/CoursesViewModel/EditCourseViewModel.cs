using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LangUp.ViewModels.CoursesViewModel
{
    public class EditCourseViewModel
    {
        public Guid CourseId { get; set; }

        public string CourseName { get; set; }
        public Guid CategoryId { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
    }
}
