using DataAccess.Domain;
using DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WanTaiWeb.Areas.Admin.Controllers
{
    public class MeetingController : Controller
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

        #region 会议
        public ActionResult Index(int page = 1, MeetingStatus? status = null)
        {
            var meetings = _meetingService.GetMeetings(page, status);

            ViewBag.page = page;
            ViewBag.status = status;

            return View(meetings);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return View(new Meeting { MeetingTime = DateTime.Now });

            var meeting = _meetingService.GetMeeting(id.Value);
            return View(meeting == null ? new Meeting { MeetingTime = DateTime.Now } : meeting);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(Meeting meeting)
        {
            _meetingService.EditMeeting(meeting);
            return Json(new { msg = "编辑成功", success = true });
        }
        public ActionResult Delete(int id)
        {
            _meetingService.DeleteMeeting(id);
            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }
        #endregion

        #region 与会人员
        public ActionResult MeetingUser(int? id = null)
        {
            var meetings = _meetingService.GetMeetings().Result;

            if (meetings.Any() == false)
                return RedirectToAction("Index");

            ViewBag.meetings = meetings;

            if (id == null)
                return RedirectToAction("MeetingUser", new { id = meetings.First().ID });

            var meeting = _meetingService.GetMeeting(id.Value);
            if (meeting == null)
                return RedirectToAction("MeetingUser", new { id = meetings.First().ID });

            ViewBag.meetingUsers = _meetingService.GetMeetingUsers(meeting.ID);

            return View(meeting);
        }

        #endregion
    }
}