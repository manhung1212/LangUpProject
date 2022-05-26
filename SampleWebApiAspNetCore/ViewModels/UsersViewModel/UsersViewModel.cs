using LangUp.Entities;
using System;
using System.Collections.Generic;

namespace LangUp.ViewModels.UsersViewModel
{
    public class UsersViewModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        //public ICollection<UsersInforViewModel.UsersInforViewModel> UsersInforViewModel { get; set; }
        //public ICollection<CourseViewModel.CourseViewModel> CourseViewModel { get; set; }
    }
}
