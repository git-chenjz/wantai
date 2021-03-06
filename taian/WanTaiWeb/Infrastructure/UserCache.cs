﻿using DataAccess.Domain;
using DataService;
using MyFrameWork.Ioc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WanTaiWeb.Infrastructure
{
    /// <summary>
    /// 用户缓存
    /// </summary>
    public static class UserCache
    {
        #region 微信数据
        /// <summary>
        /// 微信用户
        /// </summary>
        public static WechatUser WechatUser
        {
            get
            {
                if (HttpContext.Current.Session["WechatUser"] == null)
                {
                    return null;
                }
                else
                {
                    return ((WechatUser)HttpContext.Current.Session["WechatUser"]);
                }
            }
        }
        /// <summary>
        /// 是否登录微信用户
        /// </summary>
        public static bool IsLoginWechatUser
        {
            get
            {
                return WechatUser != null;
            }
        }
        /// <summary>
        /// 使用OPENID直接登录微信帐号
        /// </summary>
        /// <param name="openID"></param>
        public static void LoginWechatUserByOpenID(string openID)
        {
            var wsv = ServiceLocator.Instance.Resolve<IWechatService>();

            LoginWechatUser(wsv.GetWechatUserByOpenID(openID));
        }
        /// <summary>
        /// 使用CODE直接登录微信账号
        /// </summary>
        /// <param name="code"></param>
        public static void LoginWechatUserByCode(string code)
        {
            var wsv = ServiceLocator.Instance.Resolve<IWechatService>();

            LoginWechatUser(wsv.GetWechatUserByCode(code));
        }
        /// <summary>
        /// 登录微信用户
        /// </summary>
        /// <param name="user"></param>
        public static void LoginWechatUser(WechatUser user)
        {
            HttpContext.Current.Session["WechatUser"] = user;
            if(user!=null)
            {
                var wsv = ServiceLocator.Instance.Resolve<IWechatService>();
                wsv.EditWechatUserProfile(user.ID, a =>
                {
                    a.LastLoginTime = DateTime.Now;
                    a.LoginTimes += 1;
                });
            }
        }
        /// <summary>
        /// 微信登录特性
        /// </summary>
        public class WechatLoginAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (IsLoginWechatUser == false)
                {
                    var url = ConfigurationManager.AppSettings["WeChatUserLogin"];
                    filterContext.Controller.TempData["from"] = filterContext.HttpContext.Request.RawUrl;
                    filterContext.Result = new RedirectResult(url);
                }
            }
        }
        #endregion
    }
}