using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MyFrameWork.Common;
using MyFrameWork.Log;
using MyFrameWork.Mvc;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using MyFrameWork.Wechat;
using DataService;

namespace WanTaiWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = UnityConfig.Initialise();

            container.RegisterType<LogHelper>("Error", new ContainerControlledLifetimeManager(), new InjectionConstructor("Error"));
            container.RegisterType<LogHelper>("Operate", new ContainerControlledLifetimeManager(), new InjectionConstructor("Operate"));
            container.RegisterType<LogHelper>("SqlResult", new ContainerControlledLifetimeManager(), new InjectionConstructor("SqlResult"));


            WechatService.RefreshTokens(null, null);
            //微信
            var time = new TimerCenter();
            time.AddService(WechatService.RefreshTokens, 10000);

            //取数组参数
            ModelBinders.Binders.DefaultBinder = new JQAjaxModelBinder();
        }
    }
}
