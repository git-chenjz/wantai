using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Domain;
using MyFrameWork;
using MyFrameWork.Aop;
using MyFrameWork.Log;
using MyFrameWork.Common;

namespace DataService
{
    public interface IUsersService
    {
        #region 用户
        PagedResult<Users> GetUsers(string loginName, string tel, string userName, int currentPage = 1, int pageSize = 20);
        Users GetUserByUid(int uid);
        Users GetUsersByOpenId(string openid);
        bool CheckUser(string loginName);
        int Insert(Users user);
        int Update(Users user);
        int DeleteUser(int[] ids);
        Users Login(string loginName, string loginPwd);
        void UnBindEmail(int id);
        void BindEmail(int id,string email);
        void BindWxChat(int id, string openId);
        void UnBindWxChat(int id);
        bool UserIsExsit(string loginName, string loginPwd);
        void UpdatePwd(string email, string password);
        #endregion
    }
}
