using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess.Domain;
using MyFrameWork.Data;

namespace DataAccess.Repositories.Impl
{
    public class SiteSettingsRepository : Repository<SiteSettings>, ISiteSettingsRepository
    {
        public SiteSettingsRepository(IMySqlRepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
