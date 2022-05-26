using System;

namespace LangUp.ViewModels.CourseOfUsersViewModel
{
    public class CourseOfUsersViewModel
    {
        public Guid CourseOfUserId { get; set; }
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsLearnNew { get; set; }
        public bool IsComplete { get; set; }
        public UsersViewModel.UsersViewModel UsersViewModel { get; set; }
        public CoursesViewModel.CourseViewModel CoursesViewModel { get; set; }
        public bool IsPrivate { get; set; }
    }
}
