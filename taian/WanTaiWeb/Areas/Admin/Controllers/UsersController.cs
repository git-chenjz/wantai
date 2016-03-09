﻿using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using DataAccess.Domain;
using MyFrameWork.Mvc;
using DataService;
using MyFrameWork.Common;
using MyFrameWork;
using WanTaiWeb.Areas.Admin.Models;
using MyFrameWork.Wechat;

namespace WanTaiWeb.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        #region 字段
        private IWechatService _wechatService; 
        #endregion

        #region 构造
        public UsersController(IWechatService wechatService)
        {
            _wechatService = wechatService;
        } 
        #endregion

        #region 用户信息
        public ActionResult Index(UserModel user)
        {
            user.GetUsers();
            return View(user);
        }
        #endregion

        #region 方法
        //public ActionResult Index(string loginName,string tel,string userName)
        //{
        //    var users = _usersService.GetUsers(loginName,tel,userName);
        //    if (Request.IsAjaxRequest())
        //        return PartialView("UserList", users);
        //    return View(users);
        //}

        //[HttpPost]
        //public JsonResult CheckUser(int? id, string loginName)
        //{
        //    bool result = false;
        //    if (id == 0)
        //    {
        //        var item = _usersService.CheckUser(loginName);
        //        result = (item == null);
        //    }
        //    else
        //    {
        //        result = true;
        //    }

        //    return Json(new { valid = result }, JsonRequestBehavior.AllowGet);
        //}

        //[Description("新增会员用户")]
        //public ActionResult UserInsert()
        //{
        //    return View();
        //}
        
        //[Description("编辑会员用户")]
        //public ActionResult UserUpdate(int id)
        //{
        //    var list = _usersService.GetUserByUid(id);
        //    return View(list);
        //}
        //[Description("保存会员用户")]
        //[HttpPost]
        //public JsonResult UserSave(Users user)
        //{
        //    var result = 0;

        //    if (user.ID > 0)
        //    {
        //        Users model = _usersService.GetUserByUid(user.ID);
        //        model.LoginName = user.LoginName;
        //        model.Tel = user.Tel;
        //        model.UserName = user.UserName;
        //        result = _usersService.Update(model);
        //    }
        //    else
        //    {
        //        user.RegTime = DateTime.Now;
        //        result = _usersService.Insert(user);
        //    }

        //    return Json(new RetrunJsonMsg(result > 0, result > 0 ? "保存成功" : "保存失败"));
        //}
        //[Description("删除会员用户")]
        //[HttpPost]
        //public JsonResult DeleteUser(int[] ids)
        //{
        //    var result = 0;

        //    result = _usersService.DeleteUser(ids);

        //    return Json(new RetrunJsonMsg(result > 0, result > 0 ? "删除成功" : "删除失败"));
        //}   
        #endregion


    }
}