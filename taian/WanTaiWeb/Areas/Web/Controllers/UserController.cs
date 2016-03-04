using DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WanTaiWeb.Infrastructure;

namespace WanTaiWeb.Areas.Web.Controllers
{
    public class UserController : WechatLoginController
    {
        #region 字段

        private IADService _adService;
        private IPageService _pageService;
        private IVideoService _videoService;
        private ILBSService _lbsService;
        private ICycleTableService _cycleTableService;

        #endregion

        #region 构造

        public UserController(IADService adService, IPageService pageService, IVideoService videoService, ILBSService lbsService, ICycleTableService cycleTableService)
        {
            _adService = adService;
            _pageService = pageService;
            _videoService = videoService;
            _lbsService = lbsService;
            _cycleTableService = cycleTableService;
        }

        #endregion



        public ActionResult Index()
        {
            return View();
        }
    }
}