using DataAccess.Domain;
using DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WanTaiWeb.Areas.Admin.Controllers
{
    public class QuestionController : Controller
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

        #region 问卷
        public ActionResult Index(int page = 1)
        {
            var result = _questionService.GetPagedQuestions(page);

            return View(result);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return View(new Question { });

            var video = _questionService.GetQuestion(id.Value);
            return View(video == null ? new Question { } : video);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(Question question)
        {
            _questionService.EditQuestion(question);

            return Json(new { success = true, msg = "保存成功" });
        }

        public ActionResult Delete(int id)
        {
            _questionService.DeleteQuestion(id);

            return RedirectToAction("Index");
        }
        #endregion

        #region 题目
        public ActionResult Item(int id = 0)
        {
            var questions = _questionService.GetQuestions();
            if (questions.Any() == false)
                return RedirectToAction("Index");

            var question = questions.SingleOrDefault(a => a.ID.Equals(id));
            if (question == null)
                question = questions.First();

            ViewBag.questions = questions;
            ViewBag.question = question;
            ViewBag.id = question.ID;

            var items = _questionService.GetQuestionItems(question.ID).OrderByDescending(a => a.Sort);

            return View(items);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateItem(int id, string title, bool type,int sort, string list)
        {
            _questionService.CreateItem(id, title, type,sort, list);

            return Json(new { success = true, msg = "保存成功" });
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditItem(int id, string title, bool type, int sort, string list)
        {
            _questionService.EditItem(id, title, type, sort, list);

            return Json(new { success = true, msg = "保存成功" });
        }
        public ActionResult DeleteItem(int id)
        {
            _questionService.DeleteQuestionItem(id);

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }
        public ActionResult EditItem(int id)
        {
            var item = _questionService.GetQuestionItem(id);

            return View(item);
        }
        #endregion

        #region 用户答卷
        public ActionResult UserCommit(int id=0,int userID=0)
        {
            var questions = _questionService.GetQuestions();
            if (questions.Any() == false)
                return RedirectToAction("Index");

            var question = questions.SingleOrDefault(a => a.ID.Equals(id));
            if (question == null)
                question = questions.First();

            ViewBag.questions = questions;
            ViewBag.question = question;
            ViewBag.id = question.ID;

            var us = _questionService.GetQuestionUsers(question.ID);

            return View(us);
        }
        public ActionResult Detail(string uid,int qid)
        {
            var question = _questionService.GetQuestion(qid);
            var selects = _questionService.GetQuestionSelectUsers(uid, qid);

            if (question == null || selects.Any() == false)
                return Content("<script>window.close();</script>");

            ViewBag.question = question;
            ViewBag.selects = selects;

            return View();
        }
        #endregion
    }
}