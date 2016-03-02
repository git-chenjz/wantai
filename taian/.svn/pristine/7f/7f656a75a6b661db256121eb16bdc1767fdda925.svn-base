using DataAccess.Domain;
using DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WanTaiWeb.Areas.Admin.Controllers
{
    public class PageController : Controller
    {
        #region 字段
        private IPageService _pageService;
        #endregion

        #region 构造
        public PageController(IPageService pageService)
        {
            _pageService = pageService;
        }
        #endregion


        public ActionResult Index()
        {
            var page = _pageService.GetPage();

            return View(page);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(Page page)
        {
            _pageService.SavePage(page);

            return Json(new { msg = "保存成功", success = true });
        }
    }
}