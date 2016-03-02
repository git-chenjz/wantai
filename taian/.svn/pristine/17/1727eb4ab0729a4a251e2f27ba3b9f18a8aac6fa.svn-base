using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFrameWork.Ioc
{
    /// <summary>
    /// 设置IOC的DB操作程序集和服务程序集
    /// </summary>
    public class IocSettings
    {
        #region 属性
        /// <summary>
        /// DB操作程序集
        /// </summary>
        public List<string> DataAccess { get; private set; }
        /// <summary>
        /// 服务程序集
        /// </summary>
        public List<string> Services { get; private set; }
        #endregion

        #region 构造
        /// <summary>
        /// 设置IOC的DB操作程序集和服务程序集
        /// </summary>
        /// <param name="dataAccess"></param>
        /// <param name="services"></param>
        public IocSettings(string[] dataAccess, string[] services)
        {
            DataAccess = dataAccess.ToList();
            Services = services.ToList();
        }
        #endregion
    }
}
