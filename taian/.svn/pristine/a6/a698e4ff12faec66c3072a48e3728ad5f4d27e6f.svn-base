using System.Web;
using System.Web.UI;

using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace MyFrameWork.Ioc
{
    public class ServiceLocator
    {
        #region 字段、属性
        /// <summary>
        /// IOC容器
        /// </summary>
        public readonly IUnityContainer container;
        private static object syncRoot = new object();
        private static ServiceLocator instance;
        /// <summary>
        /// 单例
        /// </summary>
        public static ServiceLocator Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ServiceLocator();
                    }
                }
                return instance;
            }
        }
        #endregion

        #region 构造
        /// <summary>
        /// IOC容器构造
        /// </summary>
        private ServiceLocator()
        {
            ExeConfigurationFileMap map = new ExeConfigurationFileMap();
            map.ExeConfigFilename = HttpContext.Current.Server.MapPath("Unity.config");
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            UnityConfigurationSection section = (UnityConfigurationSection)config.GetSection("unity");
            container = new UnityContainer();
            section.Configure(container, "DefaultContainer");
        }
        #endregion

        #region 方法
        /// <summary>
        /// 反转实现对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Resolve<T>()
        {
            return Resolve<T>(null);
        }
        /// <summary>
        /// 按名称反转实现对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public T Resolve<T>(string name)
        {
            if (string.IsNullOrEmpty(name))
                return container.Resolve<T>();
            return container.Resolve<T>(name);
        }
        #endregion
    }
}
