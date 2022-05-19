﻿using System;

namespace LangUp.Entities
{
    public class WordDetail
    {
        public Guid WordDetailId { get; set; }
        public Guid WordId { get; set; }
        public string Meaning { get; set; }
        public string Example { get; set; }
        public string Spelling { get; set; }
        public string WordType { get; set; }
        public string Status { get; set; }
        public Word Word { get; set; }  

    }
}
