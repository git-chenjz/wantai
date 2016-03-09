using DataAccess.Domain;
using MyFrameWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Impl
{
    public class VUserRepository : Repository<VUser>, IVUserRepository
    {
        public VUserRepository(IMySqlRepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
