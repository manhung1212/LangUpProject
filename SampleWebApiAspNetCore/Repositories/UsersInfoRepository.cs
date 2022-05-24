using LangUp.Entities;
using LangUp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LangUp.Repositories
{
    public class UsersInfoRepository : GenericRepository<UserInfo>, IUsersInfoRepository
    {
    }
}
