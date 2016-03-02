using DataService;
using MyFrameWork.Common;
using DataAccess.Domain;
using WanTaiWeb.Areas.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using WanTaiWeb.Infrastructure;

namespace WanTaiWeb.Areas.Web.Controllers
{
    public class QuestionController : WechatLoginController
    {
        #region 字段

        private IQuestionService _questionService;

        #endregion

        #region 构造

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        #endregion

        public ActionResult Index()
        {
            var result = _questionService.GetQuestions().Where(a => a.Status == QuestionStatus.启用);

            return View(result);
        }
        public ActionResult Detail(int id)
        {
            var qu = _questionService.GetQuestionUser(id, UserCache.WechatUser.ID);
            if (qu != null)
                return View("Having", qu);

            var result = _questionService.GetQuestion(id);
            if (result == null)
                return RedirectToAction("Index");

            return View(result);
        }
        public ActionResult QuestionDetail(int id)
        {
            var qu = _questionService.GetQuestionUser(id, UserCache.WechatUser.ID);
            if (qu == null)
                return RedirectToAction("Index");

            var question = _questionService.GetQuestion(qu.QuestionID);
            var selects = _questionService.GetQuestionSelectUsers(UserCache.WechatUser.ID, qu.QuestionID);

            if (question == null || selects.Any() == false)
                return RedirectToAction("Index");

            ViewBag.question = question;
            ViewBag.selects = selects;

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveQuestion(int id, string ids, string name, string tel)
        {
            _questionService.SubmitQuestionUser(id, UserCache.WechatUser.ID, ids, name, tel);

            return Json(new { success = false });
        }
    }
}