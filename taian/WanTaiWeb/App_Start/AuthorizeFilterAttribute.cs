using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using MyFrameWork.Mvc;
using DataService;

namespace WanTaiWeb
{
    /// <summary>
    /// 权限控制
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeFilterAttribute : ActionFilterAttribute, IActionFilter
    {
        private IPurviewService _purviewService;
        public AuthorizeFilterAttribute()
        {
            _purviewService = MyFrameWork.Ioc.ServiceLocator.Instance.Resolve<IPurviewService>();
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");
            AuthorizeEnum authorizeEnum = AuthorizeEnum.Authorize;
            if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(Authorize), true).Length == 1)
                authorizeEnum = ((Authorize)filterContext.ActionDescriptor.GetCustomAttributes(typeof(Authorize), true).First()).AuthorizeEnum;
            if ((authorizeEnum & AuthorizeEnum.NoAuthorize) != 0)
                return;
            if (!AuthorizeCore(filterContext, (authorizeEnum & AuthorizeEnum.CheckLogin) != 0, (authorizeEnum & AuthorizeEnum.Reuse) != 0))
            {
                if ((authorizeEnum & AuthorizeEnum.ViewPage) != 0)
                {
                    // filterContext.Result = new HttpUnauthorizedResult();//直接URL输入的页面地址跳转到登陆页
                    filterContext.Result = new RedirectResult("/admin/home/login");
                }
                else
                {
                    if (filterContext.HttpContext.Request.IsAjaxRequest())
                        filterContext.Result = new JsonNetResult(new { success = false, msg = "抱歉,您没有权限!", total = 0, rows = new List<int>() });
                    else
                    {
                        if ((authorizeEnum & AuthorizeEnum.FromPage) != 0)
                            filterContext.Result = new JsonNetResult(new { success = false, msg = "抱歉,您没有权限!", total = 0, rows = new List<int>() }, "text/plain");
                        else
                        {
                            filterContext.HttpContext.Response.StatusCode = 403;
                            Exception ex = new Exception("抱歉,您没有权限!");
                            HandleErrorInfo data = new HandleErrorInfo(ex, (string)filterContext.RouteData.Values["controller"], (string)filterContext.RouteData.Values["action"]);
                            filterContext.Controller.ViewData.Model = data;
                            filterContext.Result = new ViewResult { ViewName = "Error", ViewData = filterContext.Controller.ViewData };
                        }
                    }
                }
            }
        }
        //权限判断业务逻辑
        protected virtual bool AuthorizeCore(ActionExecutingContext filterContext, bool realLogin, bool isReuse)
        {
            if (filterContext.HttpContext == null)
                throw new ArgumentNullException("httpContext");
            var area = filterContext.RouteData.DataTokens["area"];
            string areaName = area != null ? area.ToString().ToLower() : "";
            string controllerName = filterContext.RouteData.Values["controller"].ToString().ToLower();
            string actionName = filterContext.RouteData.Values["action"].ToString().ToLower();
            List<string> pruviewFields = new List<string>();
            bool is_ok = _purviewService.IsPermission(areaName, controllerName, actionName, realLogin, ref pruviewFields);
            filterContext.Controller.ViewBag.PruviewFields = pruviewFields;
            return is_ok;
        }
    }
}