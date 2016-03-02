using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Domain;
using DataAccess.Repositories;
using MyFrameWork.Data;
using MyFrameWork.Common;
using System.Linq.Expressions;

namespace DataService
{
    public class CycleTableService : BaseService, ICycleTableService
    {
        #region 字段
        private ICycleTableRepository _cycleReposition;
        #endregion

        #region 构造
        public CycleTableService(
            IMySqlRepositoryContext mySqlUnitOfWork,
            ICycleTableRepository adReposition
            )
            : base(mySqlUnitOfWork)
        {
            _cycleReposition = adReposition;
        }
        #endregion

        #region 方法

        public CycleTable GetCycleTableByTypeId(int typeId)
        {
            return _cycleReposition.Find(c => c.Type.Equals(typeId) && c.IsShow.Equals(0));
        }

        public PagedResult<CycleTable> GetCycleTableList(int typeId, int index = 1, int size = 20)
        {
            Expression<Func<CycleTable, bool>> filter = c => true;
            if (typeId > 0)
                filter = filter.And(c => c.Type.Equals(typeId));
            return _cycleReposition.GetPaged(filter, index, size);
        }

        public CycleTable GetCycleTableById(int id)
        {
            return _cycleReposition.Find(c => c.Id == id);
        }
        public int DeleteCycleTable(int[] ids)
        {
            foreach (var id in ids)
                _cycleReposition.Delete(c => c.Id == id);
            return _cycleReposition.Save();
        }
        public int Insert(CycleTable table)
        {
            SetCycleTableStatus(table);
            _cycleReposition.Create(table);
            return _cycleReposition.Save();
        }
        public int Update(CycleTable table)
        {
            SetCycleTableStatus(table);
            _cycleReposition.Update(table);
            return _cycleReposition.Save();
        }

        private void SetCycleTableStatus(CycleTable table)
        {
            bool status = _cycleReposition.Contains(c => (c.IsShow == 1 && c.Type.Equals(table.Type)));
            if (status)
            {
                CycleTable model = _cycleReposition.Find(c => c.IsShow == 1 && c.Type.Equals(table.Type));
                model.IsShow = 0;
                _cycleReposition.Update(model);
            }
        }
        #endregion
    }
}
