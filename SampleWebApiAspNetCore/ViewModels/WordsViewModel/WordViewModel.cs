using System;
using System.Collections.Generic;

namespace LangUp.ViewModels.WordsViewModel
{
    public class WordViewModel
    {
        public Guid WordId { get; set; }
        public string Content { get; set; }
        public Guid LessonId { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public LessonsViewModel.LessonViewModel Lesson { get; set; }
        public ICollection<WordDetailsViewModel.WordDetailsViewModel> WordDetailsViewModel { get; set; }
    }
}
