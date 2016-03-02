using DataAccess.Domain;
using DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WanTaiWeb.Areas.Admin.Controllers
{
    public class VideoController : Controller
    {
        #region 字段
        private IVideoService _videoService;
        #endregion

        #region 构造
        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }
        #endregion

        public ActionResult Index()
        {
            var videos = _videoService.GetVideos();

            return View(videos);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return View(new Video { });

            var video = _videoService.GetVideo(id.Value);
            return View(video == null ? new Video { } : video);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(Video video)
        {
            _videoService.SaveVideo(video);
            return Json(new { msg = "编辑成功", success = true });
        }

        public ActionResult Delete(int id)
        {
            _videoService.DeleteVideo(id);
            return RedirectToAction("Index");
        }
    }
}