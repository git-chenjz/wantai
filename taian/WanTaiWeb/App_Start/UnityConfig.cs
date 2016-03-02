using System.Web.Mvc;
using System.Web.Http;
using System.Reflection;
using Microsoft.Practices.Unity;
using DataAccess.Context;
using MyFrameWork;
using MyFrameWork.Common;
using MyFrameWork.Ioc;
using Microsoft.Practices.Unity.InterceptionExtension;
using MyFrameWork.Mvc;
using Microsoft.Practices.Unity.Mvc;

namespace WanTaiWeb
{
    public static class UnityConfig
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            container.RegisterType<IViewPageActivator, UnityViewPageActivator>(new InjectionConstructor(container));//注入视图
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));//注入MVC
            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = ServiceLocator.Instance.container;
            RegisterTypes(container);
            container.Resolve<ExecuteStartupTasks>();//对象反射
            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            var iocSettings = container.Resolve<IocSettings>();

            foreach (var dataAccess in iocSettings.DataAccess)
            {
                var assembly = Assembly.Load(dataAccess);
                var interfaces = assembly.GetInterfaces();
                interfaces.ForEach(interfaceType =>
                {
                    var currentInterfaceType = interfaceType;
                    var implementations = assembly.GetImplementationsOfInterface(interfaceType);
                    if (implementations.Count > 1)
                        implementations.ForEach(c => container.RegisterType(currentInterfaceType, c, c.Name, new ContainerControlledLifetimeManager()));
                    else
                        implementations.ForEach(c => container.RegisterType(currentInterfaceType, c, new ContainerControlledLifetimeManager()));
                });
            }

            foreach (var services in iocSettings.Services)
            {
                var assembly = Assembly.Load(services);
                var interfaces = assembly.GetInterfaces();
                interfaces.ForEach(interfaceType =>
                {
                    var currentInterfaceType = interfaceType;
                    var implementations = assembly.GetImplementationsOfInterface(interfaceType);
                    if (implementations.Count > 1)
                        implementations.ForEach(c => container.RegisterType(currentInterfaceType, c, c.Name,
                            new ContainerControlledLifetimeManager(),
                            new Interceptor<InterfaceInterceptor>(),
                            new InterceptionBehavior<PolicyInjectionBehavior>()));
                    else
                        implementations.ForEach(c => container.RegisterType(currentInterfaceType, c,
                            new ContainerControlledLifetimeManager(),
                            new Interceptor<InterfaceInterceptor>(),
                            new InterceptionBehavior<PolicyInjectionBehavior>()));
                });
            }
        }
    }
}