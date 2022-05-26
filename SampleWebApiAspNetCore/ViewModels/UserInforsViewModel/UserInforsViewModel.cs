using System;

namespace LangUp.ViewModels.UserInforsViewModel
{
    public class UserInforsViewModel
    {
        public Guid UserInfoId { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public UsersViewModel.UsersViewModel UsersViewModel { get; set; }
    }
}
