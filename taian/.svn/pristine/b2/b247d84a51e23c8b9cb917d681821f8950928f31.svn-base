using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Microsoft.Practices;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using MyFrameWork.Common;
using MyFrameWork.Log;
using System.Web;
using MyFrameWork.Common.Exceptions;

namespace MyFrameWork.Aop
{
    /// <summary>
    /// 操作日志拦截行为
    /// </summary>
    public class OperateLogHandler : ICallHandler
    {
        #region 属性、字段
        public int Order { get; set; }
        private string _description;
        private string _opLog;
        private IOperateLog _operateLog;
        #endregion

        #region 构造
        public OperateLogHandler(string description, string opLog, IOperateLog operateLog)
        {
            _description = description;
            _opLog = opLog;
            _operateLog = operateLog;
        }
        #endregion

        #region 接口实现
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            object[] customAttributes = input.MethodBase.GetCustomAttributes(typeof(OperateLogAttribute), false);
            if ((customAttributes == null) || (customAttributes.Length == 0))
                return new VirtualMethodReturn(input, new Exception());
            string className = input.MethodBase.DeclaringType.Name;
            string methodName = input.MethodBase.Name;
            //string generic = input.MethodBase.DeclaringType.IsGenericType ? string.Format("<{0}>", input.MethodBase.DeclaringType.GetGenericArguments().Select(p => p.Name).Aggregate((i, j) => { return i + "," + j; })) : string.Empty;
            string generic = input.MethodBase.DeclaringType.IsGenericType ? string.Format("<{0}>", input.MethodBase.DeclaringType.GetGenericArguments().ToStringList()) : string.Empty;
            string arguments = input.Arguments.ToStringList();
            Dictionary<string, object> parameterInfos = new Dictionary<string, object>();
            int i = 0;
            foreach (object paramVal in input.Arguments)
            {
                ParameterInfo parameterInfo = input.Arguments.GetParameterInfo(i);
                parameterInfos.Add(parameterInfo.Name, paramVal);
                i++;
            }
            //Invoke method
            IMethodReturn msg = getNext()(input, getNext);
            if (msg.Exception == null)
            {
                parameterInfos.Add("returnValue", msg.ReturnValue);
                Dictionary<string, object> data = new Dictionary<string, object>();
                string result = NVHelper.Get(_opLog, parameterInfos);
                try
                {
                    OperateLogInfo info = new OperateLogInfo();
                    info.MethodName = string.Format("{0}{1}.{2}({3})", className, generic, methodName, arguments);
                    info.Name = _description;
                    info.Content = result;
                    if (HttpContext.Current.User != null)
                        info.UserName = HttpContext.Current.User.Identity.Name;
                    info.CreateDate = DateTime.Now;
                    _operateLog.Create(info);
                }
                catch (Exception ex)
                {
                    throw new ComponentException("mongodb异常，无法写入", ex);
                }
            }
            return msg;
        }
        #endregion
    }
    public static class EnumerableExtensions
    {
        public static string ToStringList(this System.Collections.IEnumerable list)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (var item in list)
            {
                sb.AppendFormat("{0}, ", item);
            }
            if (sb.Length > 0) sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }
    }
}
