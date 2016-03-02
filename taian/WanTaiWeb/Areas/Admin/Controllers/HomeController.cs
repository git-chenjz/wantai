using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Domain;
using MyFrameWork.Mvc;
using DataService;
using System.ComponentModel;
using MyFrameWork.Common;
using MyFrameWork;
using System.IO;
using System.Drawing;

namespace WanTaiWeb.Areas.Admin.Controllers
{
    [AuthorizeFilter]
    public class HomeController : GeneralController
    {
        private IPurviewService _purviewService;
        private IUsersService _usersService;
        public HomeController(IPurviewService purviewServer,IUsersService usersService)
        {
            _purviewService = purviewServer;
            _usersService = usersService;
        }

        [@Authorize(AuthorizeEnum.CheckLogin | AuthorizeEnum.ViewPage)]
        public ActionResult Index()
        {
            var list = _purviewService.GetFeatures();
            return View(list);
        }
        [@Authorize(AuthorizeEnum.CheckLogin)]
        public ActionResult Main()
        {
            return View();
        }

        [@Authorize(AuthorizeEnum.NoAuthorize)]
        public ActionResult Ueditor()
        {
            return View();
        }

        #region 登录
        [@Authorize(AuthorizeEnum.NoAuthorize)]
        public ActionResult Login()
        {
            return View();
        }
        [@Authorize(AuthorizeEnum.NoAuthorize)]
        [HttpPost]
        public JsonResult Login(string username, string password, bool? rememberMe)
        {
            password = Md5.Encode(password);
            var user = _purviewService.UserLogin(username, password, Request.UserHostAddress);
            if (user != null)
            {
                if (user.Status == 1)
                    return Json(new RetrunJsonMsg(false, "登录失败"));
                bool reMe = rememberMe ?? false;
                if (!user.RoleID.HasValue)
                    return Json(new RetrunJsonMsg(false, "没有权限"));
                var userInfo = new { ID = user.ID, UserName = user.UserName, RoleID = user.RoleID, Status = user.Status, LoginTimeDto = user.LoginTime, Login = user.Login, LoginIP = user.LoginIP, Remark = user.Remark };
                CookieHelper.Current.SaveTicketCookie(user.UserName, userInfo.ToJson(), reMe ? 24 * 60 * 360 : 0);
                return Json(new RetrunJsonMsg(true, "登录成功"));
            }
            return Json(new RetrunJsonMsg(false, "登录失败"));
        }
        #endregion

        #region 注销登录
        [@Authorize(AuthorizeEnum.NoAuthorize)]
        public ActionResult Logout()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            return Redirect("/admin/home/login");
        }
        #endregion

        #region 我的资料
        [Description("我的资料")]
        [@Authorize(AuthorizeEnum.CheckLogin)]
        public ActionResult Profile()
        {
            var item = _purviewService.AdminInfo;
            return View(item);
        }
        #endregion

        #region 修改密码
        [Description("修改密码")]
        [@Authorize(AuthorizeEnum.CheckLogin)]
        public ActionResult ChangePassword()
        {
            var item = _purviewService.AdminInfo;
            return View(item);
        }
        [Description("修改密码")]
        [@Authorize(AuthorizeEnum.CheckLogin)]
        [HttpPost]
        public JsonResult ChangePassword(string oldPassword, string newPassword)
        {
            var user = _purviewService.AdminInfo;
            var v = _purviewService.UpdatePassword(user, oldPassword, newPassword);
            if (v == 0)
                return Json(new RetrunJsonMsg(false, "修改失败"));
            else if (v == -1)
                return Json(new RetrunJsonMsg(false, "原密码不正确"));
            return Json(new RetrunJsonMsg(true, "修改成功"));
        }
        #endregion

        #region 产品列表
        [@Authorize(AuthorizeEnum.CheckLogin)]
        public PartialViewResult ModelQuery(ModelQueryOp mqo, string username, string title)
        {
            mqo.IsMultiple = Request["IsMultiple"] == "1" ? true : false;
            ViewBag.Mqo = mqo;
            switch (mqo.PartialName)
            {
                case "_GoodsList":
                    int? gcid = null; if (!Request["gcid"].IsNullOrEmpty()) gcid = int.Parse(Request["gcid"]);
                    
                    break;
                //case "_UsersList":
                //    int role = -1; if (!Request["role"].IsNullOrEmpty()) role = int.Parse(Request["role"]);
                //    var users = _usersService.GetUsers(username, -1, role, UIHelper.Current.PageIndex, UIHelper.Current.PageSize);
                //    ViewData.Model = users;
                //    break;
            }
            return PartialView(mqo.PartialName);
        }
        #endregion
        #region 上传图片
        [Description("上传图片")]
        [@Authorize(AuthorizeEnum.NoAuthorize)]
        [HttpPost]
        public JsonResult Upload(string type)
        {
            var json = new { success = false, fileName = "", url = "", message = "图片格式不符合要求" };
            HttpPostedFileBase file = HttpContext.Request.Files["FileData"];
            string fileName = file.FileName;
            string fileType = fileName.Substring(fileName.LastIndexOf("."));
            string GuidName = Guid.NewGuid().ToString().Replace("-", "");
            Stream stream = file.InputStream;
            Image img = Image.FromStream(stream);
            string basePath = System.AppDomain.CurrentDomain.BaseDirectory + @"\images\upload";
            var datetime = DateTime.Now.ToString("yyyyMMdd");
            string savePath = basePath + @"\" + type + @"\" + datetime + @"\";
            if (!System.IO.Directory.Exists(savePath)) System.IO.Directory.CreateDirectory(savePath);
            string saveFile = savePath + GuidName + fileType;
            if (img.Width > 0 && img.Height > 0)
            {
                img.Save(saveFile);
                string url = "/images/upload/" + type + "/" + datetime + "/" + GuidName + fileType;
                json = new { success = true, fileName = file.FileName, url = url, message = "" };
            }

            return Json(json, "json");
        }
        #endregion
    }
}