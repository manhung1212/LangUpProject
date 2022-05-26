using LangUp.Entities;
using System;

namespace LangUp.ViewModels.CourseOfUserViewModel
{
    public class CourseOfUserViewModel
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
        public CourseViewModel.CourseViewModel CourseViewModel { get; set; }
        public bool IsPrivate { get; set; }
    }
}
