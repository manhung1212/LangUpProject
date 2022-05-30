using System;
using System.Collections.Generic;

namespace LangUp.ViewModels.LessonsViewModel
{
    public class CreateLessonViewModel
    {
        public string LessonName { get; set; }
        public string LessonDescription { get; set; }
        public Guid CourseId { get; set; }
    }
}
