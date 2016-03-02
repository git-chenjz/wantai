using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Repositories;
using MyFrameWork.Data;
using DataAccess.Domain;
using MyFrameWork.Aop;
using MyFrameWork.Log;
using MyFrameWork;
using MyFrameWork.Extensions;
using MyFrameWork.Common;
using System.Linq.Expressions;

namespace DataService
{
    /// <summary>
    /// 用户服务类
    /// </summary>
    public class UsersService : BaseService, IUsersService
    {
        #region 字段
        private IUsersRepository _usersRepository;
        #endregion

        #region 构造
        public UsersService(
            IMySqlRepositoryContext mySqlUnitOfWork,
            IUsersRepository usersRepository
            )
            : base(mySqlUnitOfWork)
        {
            _usersRepository = usersRepository;
        }
        #endregion

        #region 用户

        public PagedResult<Users> GetUsers(string loginName, string tel, string userName,int currentPage = 1, int pageSize = 20)
        {
            Expression<Func<Users, bool>> filter=c=>true;

            if (!loginName.IsNullOrEmpty())
            {
                filter = c => c.LoginName.Contains(loginName);  
            }
            if (!tel.IsNullOrEmpty())
            {
                filter = c => c.Tel.Contains(tel);
            }
            if (!userName.IsNullOrEmpty())
            {
                filter = c => c.UserName.Contains(userName);
            }
            return _usersRepository.GetPaged(filter, currentPage, pageSize);
        }

        public Users GetUserByUid(int uid)
        {
            return _usersRepository.Find(c=>c.ID == uid);
        }

        /// <summary>
        /// 通过微信OPENid 获得用户信息
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public Users GetUsersByOpenId(string openid)
        {
            var obj = _usersRepository.Find(c => c.Openid == openid);
            return obj;
        }

        /// <summary>
        /// 通过用户名密码，检查该用户是否存在，用户名密码不处理加密。
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckUser(string loginName)
        {
            var obj = _usersRepository.Contains(c => c.LoginName == loginName);
            return obj;
        }

        public Users Login(string loginName, string loginPwd)
        {
            return _usersRepository.Find(c=>c.LoginName.Equals(loginName) && c.Password.Equals(loginPwd));
        }

        public bool UserIsExsit(string loginName, string loginPwd)
        {
            return _usersRepository.Contains(c => c.LoginName.Equals(loginName) && c.Password.Equals(loginPwd));
        }

        public int Insert(Users user)
        {
            _usersRepository.Create(user);
            return _usersRepository.Save();
        }

        public int Update(Users user)
        {
            _usersRepository.Update(user);
            return _usersRepository.Save();
        }

        public int DeleteUser(int[] ids)
        {
            foreach (var id in ids)
                _usersRepository.Delete(c => c.ID == id);
            return _usersRepository.Save();
        }

        public void UnBindEmail(int id)
        {
            Users user = _usersRepository.Find(c=>c.ID == id);
            user.BindEmail = null;
            _usersRepository.Update(user);
            _usersRepository.Save();
        }

        public void BindEmail(int id, string email)
        {
            Users user = _usersRepository.Find(c=>c.ID == id);
            user.BindEmail = email;
            _usersRepository.Update(user);
            _usersRepository.Save();
        }

        public void BindWxChat(int id,string openId)
        {
            Users user = _usersRepository.Find(c=>c.ID == id);
            user.Openid = openId;
            _usersRepository.Update(user);
            _usersRepository.Save();
        }

        public void UnBindWxChat(int id)
        {
            Users user = _usersRepository.Find(c=>c.ID == id);
            user.Openid = null;
            _usersRepository.Update(user);
            _usersRepository.Save();
        }

        public void UpdatePwd(string email, string password)
        {
            Users user = _usersRepository.Find(c=>c.LoginName.Equals(email));
            user.Password = Md5.Encode(password);
            _usersRepository.Update(user);
            _usersRepository.Save();
        }
        #endregion
    }
}
