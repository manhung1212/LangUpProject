using System;
using System.Collections.Generic;

namespace LangUp.Entities
{
    public class Lesson
    {
        public Guid LessonId { get; set; }
        public string LessonName { get; set;}
        public string LessonDescription { get; set;}
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public virtual ICollection<Word> Words { get; set; }

    }
}
