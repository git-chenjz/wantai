using DataService;
using MyFrameWork.Common;
using DataAccess.Domain;
using WanTaiWeb.Areas.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WanTaiWeb.Infrastructure;

namespace WanTaiWeb.Areas.Web.Controllers
{
    public class MeetingController : WechatLoginController
    {
        #region 字段
        private IMeetingService _meetingService;
        #endregion

        #region 构造
        public MeetingController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }
        #endregion

        public ActionResult Index()
        {
            var meetings = _meetingService.GetMeetings(1, MeetingStatus.启用);

            return View(meetings);
        }

        public ActionResult Detail(int id)
        {
            var meeting = _meetingService.GetMeeting(id);
            if (meeting == null || meeting.Status != 0)
                return RedirectToAction("index");

            var signUpMeetings = _meetingService.GetMeetingsByWechatUserID(UserCache.WechatUser.ID);

            ViewBag.IsAttend = signUpMeetings.Any(a => a.ID == id);
            return View(meeting);
        }

        public PartialViewResult Hospital()
        {
            return PartialView();
        }

        public PartialViewResult School()
        {
            return PartialView();
        }
        [HttpPost]
        public JsonResult Enroll(UserModel user)
        {
            _meetingService.SignUpMeeting(user.MeetingId, UserCache.WechatUser.ID, user.UserIdentity);

            return Json(new RetrunJsonMsg(true, "报名成功！"));

        }

        /// <summary>
        /// 签到
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult SignIn(int id)
        {
            _meetingService.SignInMeeting(id, UserCache.WechatUser.ID);
            return RedirectToAction("Index");
        }
    }
}