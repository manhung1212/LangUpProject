using System;

namespace LangUp.ViewModels.WordDetailsViewModel
{
    public class EditSingleWordDetailsViewModel
    {
        public Guid WordDetailId { get; set; }
        public string Meaning { get; set; }
        public string Example { get; set; }
        public string Spelling { get; set; }
        public string WordType { get; set; }
        public string Status { get; set; }
    }
}
