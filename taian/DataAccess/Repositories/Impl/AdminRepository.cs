using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Domain;
using MyFrameWork.Data;

namespace DataAccess.Repositories.Impl
{
    /// <summary>
    /// 管理员
    /// </summary>
    public class AdminRepository : Repository<AdminInfo>, IAdminRepository
    {
        /// <summary>
        /// 管理员
        /// </summary>
        /// <param name="repositoryContext"></param>
        public AdminRepository(IMySqlRepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
