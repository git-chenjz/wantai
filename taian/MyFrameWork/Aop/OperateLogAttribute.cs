using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using MyFrameWork.Log;

namespace MyFrameWork.Aop
{
    /// <summary>
    /// 操作日志特征
    /// </summary>
    [Serializable]
    [AttributeUsage(AttributeTargets.Method)]
    public class OperateLogAttribute : HandlerAttribute
    {
        #region 属性
        public string Description { get; set; }
        public string OpLog { get; set; }
        #endregion

        #region 构造
        /// <summary>
        /// 操作日志特征，日内内容采用NVelocity模板语法处理数据
        /// </summary>
        /// <param name="description">日志名称</param>
        /// <param name="opLog">日志内容</param>
        public OperateLogAttribute(string description, string opLog)
        {
            Description = description;
            OpLog = opLog;
        }
        #endregion

        #region 方法
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            IOperateLog operateLog = container.Resolve<IOperateLog>();
            var operationLogHandler = new OperateLogHandler(Description, OpLog, operateLog);
            operationLogHandler.Order = this.Order;
            return operationLogHandler;
        }
        #endregion
    }
}
