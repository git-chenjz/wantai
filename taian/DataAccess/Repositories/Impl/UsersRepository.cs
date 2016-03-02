using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Domain;
using MyFrameWork.Data;

namespace DataAccess.Repositories.Impl
{
    /// <summary>
    /// 用户
    /// </summary>
    public class UsersRepository : Repository<Users>, IUsersRepository
    {
        /// <summary>
        /// 用户
        /// </summary>
        /// <param name="repositoryContext"></param>
        public UsersRepository(IMySqlRepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
