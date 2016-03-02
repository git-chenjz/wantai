using DataAccess.Domain;
using DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WanTaiWeb.Areas.Admin.Controllers
{
    public class FeedController : Controller
    {
        #region 字段
        private IFeedService _feedService;
        #endregion

        #region 构造
        public FeedController(IFeedService feedService)
        {
            _feedService = feedService;
        }
        #endregion

        #region 创新疫苗
        public ActionResult Innovate(InnovateFeedType? type,ActiveStatus? status)
        {
            var feeds = _feedService.GetInnovateFeeds(type, status);
            ViewBag.type = type;
            ViewBag.status = status;

            return View(feeds);
        }
        public ActionResult EditInnovate(int id=0)
        {
            var feed = _feedService.GetInnovateFeed(id);
            if (feed == null)
                feed = new InnovateFeed { };

            return View(feed);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveInnovate(InnovateFeed feed)
        {
            _feedService.EditInnovateFeed(feed);

            return Json(new { success=true,msg="保存成功"});
        }
        public ActionResult DeleteInnovate(int id)
        {
            _feedService.DeleteInnovateFeed(id);

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }
        #endregion
        
    }
}