using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyFrameWork.Common;
using MyFrameWork.Data;
using DataAccess.Domain;
using System.Web;
using System.Web.Security;

namespace DataService
{
    /// <summary>
    /// 基础服务类
    /// </summary>
    public class BaseService
    {
        #region 字段
        protected IMySqlRepositoryContext _mySqlUnitOfWork;
        private AdminDto _adminDto;
        #endregion
        /// <summary>
        /// 管理员消息
        /// </summary>
        /// <returns></returns>
        public AdminDto AdminInfo
        {
            get
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    var userData = CookieHelper.Current.GetTicketFromCookie();
                    _adminDto = userData.ToObject<AdminDto>();
                }
                return _adminDto;
            }
        }

        #region 构造
        /// <summary>
        /// 基础服务类
        /// </summary>
        /// <param name="sqlUnitOfWork"></param>
        /// <param name="mySqlUnitOfWork"></param>
        public BaseService(IMySqlRepositoryContext mySqlUnitOfWork = null)
        {
            _mySqlUnitOfWork = mySqlUnitOfWork;
        }
        #endregion
    }
}
