using LangUp.Entities;
using LangUp.Repositories.Interfaces;
using LangUp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LangUp.Services
{
    public class UserService : IUserService
    {
        private readonly ICategoryRepository _icategoryRepository;
        private readonly IUsersRepository _iuserRepository;
        private readonly IUsersInfoRepository _iuserInforRepository;
        private readonly ICourseOfUserRepository _icourseOfUserRepository;
        private readonly ICourseRepository _icourseRepository;

        public UserService(
            ICategoryRepository categoryRepository,
            IUsersRepository usersRepository,
            IUsersInfoRepository usersInfoRepository,
            ICourseOfUserRepository courseOfUserRepository,
            ICourseRepository courseRepository)
        {
            _icategoryRepository = categoryRepository;
            _iuserRepository = usersRepository;
            _iuserInforRepository = usersInfoRepository;
            _icourseOfUserRepository = courseOfUserRepository;
            _icourseRepository = courseRepository;  
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var u = await _iuserRepository.GetAll();
            var lstUser = new List<User>();
            foreach (var user in u)
            {
                var uInfor = (await _iuserInforRepository.FindBy(x => x.UserId == user.UserId)).FirstOrDefault();
                if (uInfor != null)
                {
                    user.UserInfos = uInfor;
                }
                
                var uCOU = (await _icourseOfUserRepository.FindBy(x=>x.UserId == user.UserId)).ToList();
                if (uCOU.Count > 0)
                {
                    user.CourseOfUsers = uCOU;
                }

                lstUser.Add(user);  
            }
            return lstUser;
        }
    }
}
