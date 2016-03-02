using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MyFrameWork.Mvc
{
    public class UnityViewPageActivator : IViewPageActivator
    {
        IUnityContainer container;

        public UnityViewPageActivator(IUnityContainer container)
        {
            this.container = container;
        }

        public object Create(ControllerContext controllerContext, Type type)
        {
            return this.container.Resolve(type);
        }
    }
}
