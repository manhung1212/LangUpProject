using System;
using System.Collections.Generic;

namespace LangUp.ViewModels.WordsViewModel
{
    public class EditWordViewModel
    {
        public Guid WordId { get; set; }
        public string Content { get; set; }
        public Guid LessonId { get; set; }
        public int Status { get; set; }
        public ICollection<WordDetailsViewModel.WordDetailsViewModel> WordDetailsViewModel { get; set; }
    }
}
