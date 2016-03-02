using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net.Core;
using MyFrameWork.Common;

namespace MyFrameWork.Log
{
    public class TextOperateLog : IOperateLog
    {
        public PagedResult<OperateLogInfo> GetPaged(System.Linq.Expressions.Expression<Func<OperateLogInfo, bool>> filter, int index = 0, int size = 20)
        {
            throw new NotImplementedException();
        }

        public OperateLogInfo Find(params object[] keys)
        {
            throw new NotImplementedException();
        }

        public OperateLogInfo Find(System.Linq.Expressions.Expression<Func<OperateLogInfo, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Create(OperateLogInfo info)
        {
            var loginfo = Ioc.ServiceLocator.Instance.Resolve<LogHelper>("Operate");
            if (loginfo != null)
                loginfo.WriteInfo(info.ToJson());
        }

        public void Delete(OperateLogInfo info)
        {
            throw new NotImplementedException();
        }

        public void Delete(System.Linq.Expressions.Expression<Func<OperateLogInfo, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
