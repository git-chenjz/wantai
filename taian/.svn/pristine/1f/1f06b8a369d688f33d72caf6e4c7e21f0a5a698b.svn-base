using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFrameWork.Mvc
{
    public enum AuthorizeEnum
    {
        /// <summary>
        /// 表示当前Action请求需要权限控制
        /// </summary>
        Authorize = 1,
        /// <summary>
        /// 表示当前Action请求不需要权限控制
        /// </summary>
        NoAuthorize = 2,
        /// <summary>
        /// 表示当前Action请求为一个具体的功能页面
        /// </summary>
        ViewPage = 4,
        /// <summary>
        /// 只要登录就可以浏览
        /// </summary>
        CheckLogin = 8,
        /// <summary>
        /// 方法可以重用
        /// </summary>
        Reuse = 16,
        /// <summary>
        /// 前台UI的JS需要的权限json
        /// </summary>
        Pruview = 32,
        /// <summary>
        /// 表单提交页面
        /// </summary>
        FromPage = 64,
        /// <summary>
        /// 事务
        /// </summary>
        Transactional = 128
    }
}
