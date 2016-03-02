using MyFrameWork.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MyFrameWork.Common;

namespace MyFrameWork.Mvc
{
    /// <summary>
    /// 错误日志
    /// </summary>
    public class HandleExceptionAttribute : HandleErrorAttribute, IExceptionFilter
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");
            if (filterContext.IsChildAction)
                return;
            //if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
            if (filterContext.ExceptionHandled)
                return;
            var ex = filterContext.Exception.GetBaseException() ?? new Exception("No further infomation exists.");
            if (!ExceptionType.IsInstanceOfType(ex))
                return;
            var loginfo = Ioc.ServiceLocator.Instance.Resolve<LogHelper>("Error");
            if (loginfo != null)
                loginfo.WriteError(ex.Message, ex);
            if (Order == 1)
                filterContext.Result = new JsonNetResult(new RetrunJsonMsg(false, ex.Message, 0, new List<int>()), "text/plain");
            else if (Order == 2)
            {
                HandleErrorInfo data = new HandleErrorInfo(ex, (string)filterContext.RouteData.Values["controller"], (string)filterContext.RouteData.Values["action"]);
                filterContext.Controller.ViewData.Model = data;
                filterContext.Result = new ViewResult { ViewName = "Error", ViewData = filterContext.Controller.ViewData };
            }
            else
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                    filterContext.Result = new JsonResult { Data = new RetrunJsonMsg(false, ex.Message, 0, new List<int>()), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                else
                {
                    HandleErrorInfo data = new HandleErrorInfo(ex, (string)filterContext.RouteData.Values["controller"], (string)filterContext.RouteData.Values["action"]);
                    filterContext.Controller.ViewData.Model = data;
                    filterContext.Result = new ViewResult { ViewName = "Error", ViewData = filterContext.Controller.ViewData };
                    filterContext.HttpContext.Response.StatusCode = 500;
                }
            }
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}
