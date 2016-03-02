using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyFrameWork.Mvc
{
    public class ReadActionHelper
    {
        private string _assembly;
        public ReadActionHelper(string assembly)
        {
            _assembly = assembly;
        }
        public IList<ActionPermission> GetAllActionByAssembly()
        {
            var result = new List<ActionPermission>();
            var assembly = Assembly.Load(_assembly);
            var types = (from t in assembly.GetTypes()
                         where typeof(IController).IsAssignableFrom(t) && !t.IsAbstract
                         select t).ToList();
            foreach (var type in types)
            {
                var methodInfos = type.GetMethods().Where(p => p.ReturnType.Name.Contains("Result"));
                foreach (var methodInfo in methodInfos)
                {
                    var ap = new ActionPermission();
                    ap.ActionName = methodInfo.Name.ToLower();
                    var roules = methodInfo.DeclaringType.FullName.Split('.');
                    if (roules.Contains("Areas"))
                    {
                        string fullName = methodInfo.DeclaringType.FullName;
                        int aI = fullName.IndexOf("Areas");
                        int cI = fullName.IndexOf("Controllers");
                        ap.AreasName = fullName.Substring(aI + 6, cI - aI - 7).ToLower();
                    }
                    ap.ControllerName = methodInfo.DeclaringType.Name.Substring(0, methodInfo.DeclaringType.Name.Length - 10).ToLower(); // 去掉“Controller”后缀
                    ap.ActionUrl = "/" + (string.IsNullOrEmpty(ap.AreasName) ? "" : ap.AreasName + "/") + ap.ControllerName + "/" + ap.ActionName;
                    if (result.Exists(c => c.ActionUrl == ap.ActionUrl)) continue;
                    AuthorizeEnum authorizeEnum = AuthorizeEnum.Authorize;
                    if (methodInfo.GetCustomAttributes(typeof(Authorize), true).Length == 1)
                        authorizeEnum = ((Authorize)methodInfo.GetCustomAttributes(typeof(Authorize), true).First()).AuthorizeEnum;
                    ap.IsReuse = (authorizeEnum & AuthorizeEnum.Reuse) != 0;
                    if ((authorizeEnum & (AuthorizeEnum.NoAuthorize | AuthorizeEnum.CheckLogin)) == 0)
                    {
                        var attrs = methodInfo.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), true);
                        if (attrs.Length > 0)
                            ap.Description = (attrs[0] as System.ComponentModel.DescriptionAttribute).Description;
                        else
                            ap.Description = ap.ActionName;
                        result.Add(ap);
                    }
                }
            }
            return result;
        }
    }
}
