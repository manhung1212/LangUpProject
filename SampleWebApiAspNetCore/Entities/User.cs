using System;
using System.Collections.Generic;

namespace LangUp.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } 
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual UserInfo UserInfos { get; set; }
        public virtual ICollection<CourseOfUser> CourseOfUsers { get; set; }

    }
}
