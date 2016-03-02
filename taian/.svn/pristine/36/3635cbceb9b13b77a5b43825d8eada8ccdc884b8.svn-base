using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Repositories;
using MyFrameWork.Data;
using DataAccess.Domain;
using MyFrameWork.Aop;
using MyFrameWork.Log;
using MyFrameWork;
using MyFrameWork.Common;
using MyFrameWork.Mvc;
using System.Web;
using MyFrameWork.Extensions;

namespace DataService
{
    /// <summary>
    /// 权限服务类
    /// </summary>
    public class PurviewService : BaseService, IPurviewService
    {
        #region 字段
        private IFeaturesRepository _featuresRty;
        private IOperateRepository _operateRty;
        private IPurviewFieldRepository _purviewFieldRty;
        private IAdminRepository _adminRty;
        private IRoleRepository _roleRty;
        private ReadActionHelper _readActionHelper;
        #endregion

        #region 构造
        /// <summary>
        /// 权限服务类
        /// </summary>
        /// <param name="sqlUnitOfWork"></param>
        public PurviewService(
            IMySqlRepositoryContext mySqlUnitOfWork,
            IFeaturesRepository featuresRty,
            IOperateRepository operateRty,
            IPurviewFieldRepository purviewFieldRty,
            IAdminRepository adminRty,
            IRoleRepository roleRty,
            ReadActionHelper readActionHelper
            )
            : base(mySqlUnitOfWork)
        {
            _featuresRty = featuresRty;
            _operateRty = operateRty;
            _purviewFieldRty = purviewFieldRty;
            _adminRty = adminRty;
            _roleRty = roleRty;
            _readActionHelper = readActionHelper;
        }
        #endregion

        #region 读取actionResult
        public IList<ActionPermission> GetActionResult()
        {
            var list = _readActionHelper.GetAllActionByAssembly();
            var result = new List<ActionPermission>();
            Expression<Func<Features, bool>> filter = c => c.Type == 1;
            var features = _featuresRty.Get(filter);
            var operates = _operateRty.Get();
            foreach (var item in list)
            {
                var feature = features.FirstOrDefault(c => c.Url.Equals(item.ActionUrl, StringComparison.OrdinalIgnoreCase));
                Operate operate = null;
                if (feature == null)
                    operate = operates.FirstOrDefault(c => c.Url.Equals(item.ActionUrl, StringComparison.OrdinalIgnoreCase));
                if (feature == null && operate == null)
                    result.Add(item);
            }
            return result;
        }
        #endregion

        #region 返回指定方法是否有权访问
        /// <summary>
        /// 返回指定方法是否有权访问
        /// </summary>
        /// <param name="area"></param>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <param name="realLogin">只要登录状态</param>
        /// <param name="pruview"></param>
        /// <returns></returns>
        public bool IsPermission(string area, string controller, string action, bool realLogin, ref List<string> pruviewFields)
        {
            bool isOK = false;
            var user = HttpContext.Current.User;
            isOK = user.Identity.IsAuthenticated;
            if (isOK && !realLogin)
            {
                var info = AdminInfo;
                if (info == null || (info != null && !info.RoleID.HasValue)) isOK = false;
                else
                {
                    var role = _roleRty.Find(info.RoleID.Value);
                    var permission = role.Permission;
                    if (permission.Count == 0) isOK = false;
                    else
                    {
                        var url = string.Format("{0}/{1}/{2}", (!area.IsNullOrEmpty() ? "/" + area : ""), controller, action);
                        var perview = permission.FirstOrDefault(c => c.Url.IndexOf(url, StringComparison.OrdinalIgnoreCase) == 0);
                        isOK = perview != null;
                        if (isOK) pruviewFields = perview.Fields;
                    }
                }
            }
            return isOK;
        }
        #endregion

        #region 功能
        public IEnumerable<Features> GetFeatures()
        {
            var list = _featuresRty.Get();
            IEnumerable<Features> data = list.Where(c => c.Pid == 0).OrderBy(c => c.Sort);
            foreach (var item in data)
                item.Childrens = list.Where(c => c.Pid == item.ID).OrderBy(c => c.Sort);
            return data;
        }
        public Features GetFeatures(int id)
        {
            var obj = _featuresRty.Find(id);
            return obj;
        }

        public int InsertFeatures(Features item)
        {
            _featuresRty.Create(item);
            return _featuresRty.Save();
        }

        public int UpdateFeatures(Features item)
        {
            _featuresRty.Update(item);
            return _featuresRty.Save();
        }
        public int DeleteFeatures(int[] ids)
        {
            foreach (var id in ids)
                _featuresRty.Delete(c => c.ID == id);
            return _featuresRty.Save();
        }
        #endregion

        #region 功能操作
        public IEnumerable<Operate> GetOperate(int? featuresId = null)
        {
            Expression<Func<Operate, bool>> filter = c => true;
            if (featuresId.HasValue)
                filter = filter.And(c => c.FeaturesID == featuresId);
            var list = _operateRty.Get(filter);
            return list;
        }
        public Operate GetOperateFrist(int id)
        {
            var obj = _operateRty.Find(id);
            return obj;
        }

        public int InsertOperate(Operate item)
        {
            _operateRty.Create(item);
            return _operateRty.Save();
        }

        public int UpdateOperate(Operate item)
        {
            _operateRty.Update(item);
            return _operateRty.Save();
        }
        public int DeleteOperate(int[] ids)
        {
            foreach (var id in ids)
                _operateRty.Delete(c => c.ID == id);
            return _operateRty.Save();
        }
        #endregion

        #region 权限字段
        public IEnumerable<PurviewField> GetPurviewField(int? type = null, int? objID = null)
        {
            Expression<Func<PurviewField, bool>> filter = c => true;
            if (type.HasValue)
                filter = filter.And(c => c.Type == type);
            if (objID.HasValue)
                filter = filter.And(c => c.ObjID == objID);
            var list = _purviewFieldRty.Get(filter);
            return list;
        }
        public PurviewField GetPurviewField(int id)
        {
            var obj = _purviewFieldRty.Find(id);
            return obj;
        }

        public int InsertPurviewField(PurviewField item)
        {
            _purviewFieldRty.Create(item);
            return _purviewFieldRty.Save();
        }

        public int UpdatePurviewField(PurviewField item)
        {
            _purviewFieldRty.Update(item);
            return _purviewFieldRty.Save();
        }
        public int DeletePurviewField(int[] ids)
        {
            foreach (var id in ids)
                _purviewFieldRty.Delete(c => c.ID == id);
            return _purviewFieldRty.Save();
        }
        #endregion

        #region 管理员
        public IEnumerable<AdminDto> GetAdmin()
        {
            var list = _adminRty.Get("Role").ProjectedAs<AdminInfo, AdminDto>();
            return list;
        }
        public AdminDto GetAdmin(int id)
        {
            var obj = _adminRty.Find(id).ProjectedAs<AdminDto>();
            return obj;
        }

        public AdminDto GetAdmin(string username)
        {
            var obj = _adminRty.Find(c => c.UserName == username).ProjectedAs<AdminDto>();
            return obj;
        }

        public AdminDto UserLogin(string username, string password, string ip)
        {
            var admin = _adminRty.Find(c => c.UserName == username && c.Password == password);
            if (admin != null)
            {
                admin.LoginIP = ip;
                admin.Login++;
                admin.LoginTime = DateTime.Now;
                _adminRty.Update(admin);
                _adminRty.Save();
                var dto = admin.ProjectedAs<AdminDto>();
                return dto;
            }
            return null;
        }

        public int UpdatePassword(AdminDto item, string oldPassword, string newPassword)
        {
            int result = 0;
            var admin = _adminRty.Find(item.ID);
            if (admin.Password == Md5.Encode(oldPassword))
            {
                item.UpdateTime = DateTime.Now;
                admin.UpdateTime = item.UpdateTime;
                admin.Password = Md5.Encode(newPassword);
                _adminRty.Update(admin);
                result = _adminRty.Save();
            }
            else result = -1;
            return result;
        }

        public int InsertAdmin(AdminDto item)
        {
            var admin = item.ProjectedAs<AdminInfo>();
            if (admin.Password.IsNullOrEmpty()) admin.Password = "123456";
            admin.Password = Md5.Encode(admin.Password);
            admin.RegTime = DateTime.Now;
            _adminRty.Create(admin);
            return _adminRty.Save();
        }

        public int UpdateAdmin(AdminDto item)
        {
            var admin = _adminRty.Find(item.ID);
            if (!item.Password.IsNullOrEmpty()) admin.Password = Md5.Encode(item.Password);
            admin.UserName = item.UserName;
            admin.Status = item.Status;
            admin.Remark = item.Remark;
            admin.RoleID = item.RoleID;
            admin.UpdateTime = DateTime.Now;
            _adminRty.Update(admin);
            return _adminRty.Save();
        }
        public int DeleteAdmin(int[] ids)
        {
            foreach (var id in ids)
                _adminRty.Delete(c => c.ID == id);
            return _adminRty.Save();
        }
        #endregion

        #region 角色
        public IEnumerable<Role> GetRole()
        {
            var list = _roleRty.Get();
            return list;
        }
        public Role GetRole(int id)
        {
            var obj = _roleRty.Find(id);
            return obj;
        }

        public int InsertRole(Role item)
        {
            _roleRty.Create(item);
            return _roleRty.Save();
        }

        public int UpdateRole(Role item)
        {
            _roleRty.Update(item);
            return _roleRty.Save();
        }
        public int DeleteRole(int[] ids)
        {
            foreach (var id in ids)
                _roleRty.Delete(c => c.ID == id);
            return _roleRty.Save();
        }
        #endregion
    }
}
