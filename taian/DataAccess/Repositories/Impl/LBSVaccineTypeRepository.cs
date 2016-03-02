﻿using DataAccess.Domain;
using MyFrameWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Impl
{
    public class LBSVaccineTypeRepository : Repository<LBSVaccineType>, ILBSVaccineTypeRepository
    {
        public LBSVaccineTypeRepository(IMySqlRepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
