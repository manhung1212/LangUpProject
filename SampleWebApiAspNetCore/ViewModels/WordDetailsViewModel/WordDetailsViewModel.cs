﻿using LangUp.Entities;
using System;
using System.Collections.Generic;

namespace LangUp.ViewModels.WordDetailsViewModel
{
    public class WordDetailsViewModel
    {
        public Guid WordDetailId { get; set; }
        public Guid WordId { get; set; }
        public string Meaning { get; set; }
        public string Example { get; set; }
        public string Spelling { get; set; }
        public string WordType { get; set; }
        public string Status { get; set; }
        public WordsViewModel.WordsViewModel WordsViewModel { get; set; }
    }
}
