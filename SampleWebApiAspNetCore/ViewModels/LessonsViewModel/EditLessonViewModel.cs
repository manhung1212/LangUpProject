using System;
using System.Collections.Generic;

namespace LangUp.ViewModels.LessonsViewModel
{
    public class EditLessonViewModel
    {
        public Guid LessonId { get; set; }
        public string LessonName { get; set; }
        public string LessonDescription { get; set; }
        public int Status { get; set; }
    }
}
