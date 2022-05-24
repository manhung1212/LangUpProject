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

        public UserService(
            ICategoryRepository categoryRepository,
            IUsersRepository usersRepository)
        {
            _icategoryRepository = categoryRepository;
            _iuserRepository = usersRepository;
        }

        public Task<IEnumerable<User>> GetAllUsers()
        {
            var u = _iuserRepository.GetAll();
            return u;
        }
    }
}
