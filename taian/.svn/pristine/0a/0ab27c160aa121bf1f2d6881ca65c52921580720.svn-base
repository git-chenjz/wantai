using DataAccess.Domain;
using DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WanTaiWeb.Areas.Admin.Controllers
{
    public class WechatController : Controller
    {
        #region 字段
        private IWechatService _wechatService;
        #endregion

        #region 构造
        public WechatController(IWechatService wechatService)
        {
            _wechatService = wechatService;
        }
        #endregion


        // GET: Admin/Wechat
        public ActionResult Index()
        {
            var config = _wechatService.GetWechatConfig();

            return View(config);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(WechatConfig config)
        {
            _wechatService.SaveWechatConfig(config);

            return Json(new { msg = "保存成功", success = true });
        }

        public ActionResult ReSave()
        {
            _wechatService.SaveWechatToken();

            return RedirectToAction("Cache");
        }

        public ActionResult Cache()
        {
            var config = _wechatService.GetWechatConfig();

            return View(config);
        }
    }
}