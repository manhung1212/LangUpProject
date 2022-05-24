using System;
using System.Collections.Generic;

namespace LangUp.Entities
{
    public class Course
    {
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
        public Guid CategoryId { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int Status { get; set; }
        public Guid AuthorId { get; set; }
        public int TotalLeaner { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsPrivate { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<CourseOfUser> CourseOfUsers { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }

    }
}
