using DataAccess.Domain;
using MyFrameWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Impl
{
    public class ProblemRepository : Repository<MyProblem>, IProblemRepository
    {
        /// <summary>
        /// 功能操作
        /// </summary>
        /// <param name="repositoryContext"></param>
        public ProblemRepository(IMySqlRepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
