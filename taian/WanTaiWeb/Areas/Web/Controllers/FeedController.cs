using DataAccess.Domain;
using DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WanTaiWeb.Infrastructure;

namespace WanTaiWeb.Areas.Web.Controllers
{
    public class FeedController : WechatLoginController
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

        public ActionResult Innovate(InnovateFeedType type = InnovateFeedType.戊肝知识)
        {
            var feeds = _feedService.GetInnovateFeeds(type, ActiveStatus.启用).OrderByDescending(a=>a.CreateTime);
            ViewBag.type = type;

            return View(feeds);
        }
        public ActionResult InnovateDetail(int id)
        {
            var feed = _feedService.GetInnovateFeed(id, true);
            if (feed == null)
                return RedirectToAction("Innovate");

            return View(feed);
        }
    }
}