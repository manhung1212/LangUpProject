using System;
using System.Collections.Generic;

namespace LangUp.ViewModels.WordsViewModel
{
    public class CreateWordViewModel
    {
        public string Content { get; set; }
        public Guid LessonId { get; set; }
        public ICollection<WordDetailsViewModel.CreateWordDetailsViewModel> CreateWordDetailsViewModel { get; set; }
    }
}
