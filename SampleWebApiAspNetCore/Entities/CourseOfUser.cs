using System;

namespace LangUp.Entities
{
    public class CourseOfUser
    {
        public Guid CourseOfUserId { get; set; }
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsLearnNew { get; set; }
        public bool IsComplete { get; set; }
        public User User { get; set; }
        public Course Course { get; set; }
        public bool IsPrivate { get; set; }

    }
}
