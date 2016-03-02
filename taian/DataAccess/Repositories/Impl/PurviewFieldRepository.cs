using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Domain;
using MyFrameWork.Data;

namespace DataAccess.Repositories.Impl
{
    /// <summary>
    /// 权限字段
    /// </summary>
    public class PurviewFieldRepository : Repository<PurviewField>, IPurviewFieldRepository
    {
        /// <summary>
        /// 权限字段
        /// </summary>
        /// <param name="repositoryContext"></param>
        public PurviewFieldRepository(IMySqlRepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
