using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WanTaiWeb
{
    public class UIHelper
    {
        private static object syncRoot = new object();
        private static UIHelper instance;
        public static UIHelper Current
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = MyFrameWork.Ioc.ServiceLocator.Instance.Resolve<UIHelper>();
                    }
                }
                return instance;
            }
        }
        public UIHelper() { }
        public int PageIndex
        {
            get
            {
                int page = 1;
                if (HttpContext.Current.Request["page"] != null) { page = int.Parse(HttpContext.Current.Request["page"]); }
                return page;
            }
        }
        public int PageSize { get; set; }
    }
}