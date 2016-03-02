using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DataAccess.Domain;
using MyFrameWork.Common;
using DataService;
using MyFrameWork.Wechat;
using MyFrameWork.Mvc;

namespace WanTaiWeb.Areas.Web.Controllers
{
    public class BaseController : Controller
    {
        public Users CurrentUser
        {
            get
            {
                int id = Models.UserCookieEncryptHelper.Decrypt(WebHelper.GetCookie(CookieKeysCollection.WANTAI_USER), "Web");
                if (id != 0L)
                {
                    return MyFrameWork.Ioc.ServiceLocator.Instance.Resolve<IUsersService>().GetUserByUid(id);
                }
                return null;
            }
        }

        public bool IsWxLogin
        {
            get
            {
                return Request.UserAgent.ToLower().Contains("micromessenger");
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool isLogin = (CurrentUser == null ? false : true);
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");
            AuthorizeEnum authorizeEnum = AuthorizeEnum.NoAuthorize;
            if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(Authorize), true).Length == 1)
                authorizeEnum = ((Authorize)filterContext.ActionDescriptor.GetCustomAttributes(typeof(Authorize), true).First()).AuthorizeEnum;
            if ((authorizeEnum & AuthorizeEnum.NoAuthorize) != 0)
                return;

            if (!IsWxLogin && !isLogin)
            {
                Response.Redirect("/web/account/login");
            }

            if (IsWxLogin && !isLogin)
            {
                string url = string.Format("http://{0}/account/wxcode", Request.UserHostName);
                Response.Redirect(WebService.GetCurrentUserCodeBySnsapi_base(url));
            }

            if (IsWxLogin && isLogin)
            {
                string url = string.Format("http://{0}/account/wxcode", Request.UserHostName);
                Response.Redirect(WebService.GetCurrentUserCodeBySnsapi_base(url, CurrentUser.ID.ToString()));
            }
        }
    }
}