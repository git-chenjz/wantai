using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using MyFrameWork.Data;
using MyFrameWork.Common;

namespace MyFrameWork.Log
{
    public interface IOperateLog
    {
        PagedResult<OperateLogInfo> GetPaged(Expression<Func<OperateLogInfo, bool>> filter, int index = 0, int size = 20);
        OperateLogInfo Find(params object[] keys);
        OperateLogInfo Find(Expression<Func<OperateLogInfo, bool>> filter);
        void Create(OperateLogInfo info);
        void Delete(OperateLogInfo info);
        void Delete(Expression<Func<OperateLogInfo, bool>> filter);
    }
}
