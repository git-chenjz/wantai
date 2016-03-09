using DataAccess.Domain;
using MyFrameWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Impl
{
    public class VInoculationRecordRepository : Repository<VInoculationRecord>, IVInoculationRecordRepository
    {
        public VInoculationRecordRepository(IMySqlRepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
