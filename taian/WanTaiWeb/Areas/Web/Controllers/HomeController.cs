﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DataAccess.Domain;
using DataService;
using MyFrameWork.Mvc;
using MyFrameWork.Common;
using System.ComponentModel;
using WanTaiWeb.Infrastructure;

namespace WanTaiWeb.Areas.Web.Controllers
{
    public class HomeController : WechatLoginController
    {
        #region 字段

        private IADService _adService;
        private IPageService _pageService;
        private IVideoService _videoService;
        private ILBSService _lbsService;
        private ICycleTableService _cycleTableService;

        #endregion

        #region 构造

        public HomeController(IADService adService, IPageService pageService, IVideoService videoService, ILBSService lbsService, ICycleTableService cycleTableService)
        {
            _adService = adService;
            _pageService = pageService;
            _videoService = videoService;
            _lbsService = lbsService;
            _cycleTableService = cycleTableService;
        }

        #endregion

        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            IEnumerable<AD> ads = _adService.GetValidADs();
            ViewBag.Video = _videoService.GetTopVideo();
            return View(ads);
        }
        /// <summary>
        /// 关于我们
        /// </summary>
        /// <returns></returns>
        public ActionResult AboutUs()
        {
            var page = _pageService.GetPage();
            return View(page);
        }
        /// <summary>
        /// 企业视频
        /// </summary>
        /// <returns></returns>
        public ActionResult Video()
        {
            IEnumerable<Video> videos = _videoService.GetVideos();
            return View(videos);
        }
        /// <summary>
        /// 疫苗接种周期表主页
        /// </summary>
        /// <returns></returns>
        public ActionResult CycleTable()
        {
            var types = _lbsService.GetVaccineTypes().OrderBy(a => a.Name);
            return View(types);
        }
        /// <summary>
        /// 疫苗接种周期表详情页
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult CycleTableDetail(int id)
        {
            var list = _cycleTableService.GetCycleTableByTypeId(id);
            if (list == null)
                return RedirectToAction("CycleTable");
            return View(list);
        }
    }
}