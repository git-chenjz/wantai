using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess.Domain;
using MyFrameWork.Common;

namespace DataService
{
    public interface ICycleTableService
    {
        CycleTable GetCycleTableByTypeId(int typeId);
        PagedResult<CycleTable> GetCycleTableList(int typeId, int index = 1, int size = 20);
        CycleTable GetCycleTableById(int id);
        int DeleteCycleTable(int[] ids);
        int Insert(CycleTable table);
        int Update(CycleTable table);
    }
}
