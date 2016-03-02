using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MyFrameWork.Ioc
{
    public static class ExtensionIoc
    {
        /// <summary>
        /// 返回程序集中所有接口
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetInterfaces(this Assembly assembly)
        {
            return assembly.GetTypes().Where(c => c.IsInterface);
        }

        /// <summary>
        /// 返回程序集中指定接口的实现类的集合
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="interfaceType"></param>
        /// <returns></returns>
        public static List<Type> GetImplementationsOfInterface(this Assembly assembly, Type interfaceType)
        {
            var implementations = new List<Type>();
            var concreteTypes = assembly.GetTypes().Where(c => !c.IsInterface && !c.IsAbstract && interfaceType.IsAssignableFrom(c));
            concreteTypes.ToList().ForEach(implementations.Add);
            return implementations;
        }
    }
}
