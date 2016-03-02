using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Domain;
using MyFrameWork.Data;

namespace DataAccess.Repositories
{
    /// <summary>
    /// 用户信息仓储接口
    /// </summary>
    public interface IUsersRepository : IRepository<Users>
    {
    }
}
