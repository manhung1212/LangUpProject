using LangUp.Entities;
using System;
using System.Collections.Generic;

namespace LangUp.ViewModels.LessonViewModel
{
    public class LessonViewModel
    {
        public Guid LessonId { get; set; }
        public string LessonName { get; set; }
        public string LessonDescription { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public ICollection<WordsViewModel.WordsViewModel> WordsViewModel { get; set; }
    }
}
