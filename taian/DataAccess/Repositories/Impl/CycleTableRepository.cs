using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess.Domain;
using MyFrameWork.Data;

namespace DataAccess.Repositories.Impl
{
    public class CycleTableRepository : Repository<CycleTable>, ICycleTableRepository
    {
        public CycleTableRepository(IMySqlRepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
