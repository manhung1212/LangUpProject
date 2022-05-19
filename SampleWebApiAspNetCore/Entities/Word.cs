using System;
using System.Collections.Generic;

namespace LangUp.Entities
{
    public class Word
    {
        public Guid WordId { get; set; }
        public string Content { get; set; }
        public Guid LessonId { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Lesson Lesson { get; set; }
        public virtual ICollection<WordDetail> WordDetail { get; set; }
    }
}
