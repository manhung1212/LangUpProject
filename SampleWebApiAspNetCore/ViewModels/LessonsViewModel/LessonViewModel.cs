using System;
using System.Collections.Generic;

namespace LangUp.ViewModels.LessonsViewModel
{
    public class LessonViewModel
    {
        public Guid LessonId { get; set; }
        public string LessonName { get; set; }
        public string LessonDescription { get; set; }
        public Guid CourseId { get; set; }
        public CoursesViewModel.CourseViewModel CoursesViewModel { get; set; }
        public ICollection<WordsViewModel.WordViewModel> WordsViewModel { get; set; }
    }
}
