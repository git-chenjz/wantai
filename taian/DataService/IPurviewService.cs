using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Domain;
using MyFrameWork;
using MyFrameWork.Aop;
using MyFrameWork.Log;
using MyFrameWork.Mvc;

namespace DataService
{
    /// <summary>
    /// 权限信息服务接口
    /// </summary>
    public interface IPurviewService : IBaseService
    {
        #region 读取actionResult
        /// <summary>
        /// 读取actionResult
        /// </summary>
        /// <returns></returns>
        IList<ActionPermission> GetActionResult();
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
        bool IsPermission(string areaName, string controllerName, string actionName, bool realLogin, ref List<string> pruviewFields);
        #endregion
        #region 功能
        /// <summary>
        /// 功能信息列表
        /// </summary>
        /// <returns></returns>
        
        IEnumerable<Features> GetFeatures();

        /// <summary>
        /// 功能信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        Features GetFeatures(int id);

        
        int InsertFeatures(Features item);

        
        int UpdateFeatures(Features item);

        
        int DeleteFeatures(int[] ids);
        #endregion
        #region 功能操作
        
        IEnumerable<Operate> GetOperate(int? featuresId = null);

        
        Operate GetOperateFrist(int id);

        
        int InsertOperate(Operate item);

        
        int UpdateOperate(Operate item);

        
        int DeleteOperate(int[] ids);
        #endregion
        #region 权限字段
        
        IEnumerable<PurviewField> GetPurviewField(int? type = null, int? objID = null);

        
        PurviewField GetPurviewField(int id);

        
        int InsertPurviewField(PurviewField item);

        
        int UpdatePurviewField(PurviewField item);

        
        int DeletePurviewField(int[] ids);
        #endregion
        #region 管理员
        
        IEnumerable<AdminDto> GetAdmin();

        
        AdminDto GetAdmin(int id);

        AdminDto GetAdmin(string username);

        
        int UpdatePassword(AdminDto item, string oldPassword, string newPassword);

        
        AdminDto UserLogin(string username, string password, string ip);

        
        int InsertAdmin(AdminDto item);

        
        int UpdateAdmin(AdminDto item);

        
        int DeleteAdmin(int[] ids);
        #endregion
        #region 角色
        
        IEnumerable<Role> GetRole();

        
        Role GetRole(int id);

        
        int InsertRole(Role item);

        
        int UpdateRole(Role item);

        
        int DeleteRole(int[] ids);
        #endregion
    }
}
