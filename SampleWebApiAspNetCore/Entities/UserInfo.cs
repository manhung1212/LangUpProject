using System;

namespace LangUp.Entities
{
    public class UserInfo
    {
        public Guid UserInfoId { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public User User { get; set; }

    }
}
