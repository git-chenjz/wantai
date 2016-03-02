using System;
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
using WanTaiWeb.Areas.Web.Models;

namespace WanTaiWeb.Areas.Web.Controllers
{
    public class ProblemController : WechatLoginController
    {
        #region 字段

        private IProblemService _problemService;

        #endregion

        #region 构造

        public ProblemController(IProblemService problemService)
        {
            _problemService = problemService;
        }

        #endregion

        #region 方法
        public ActionResult Index(ProblemModel pm)
        {
            return View(pm);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveProblem(string title, string des)
        {
            if (string.IsNullOrWhiteSpace(title))
                return RedirectToAction("Index", new ProblemModel { Tab = 2 });

            _problemService.SaveProblem(new MyProblem
            {
                Content = des,
                Title = title.Trim(),
                IsAudit = 2,
                IsReport = 1,
                WechatUserID = UserCache.WechatUser.ID
            });

            return RedirectToAction("Index", new ProblemModel { Tab = 1 });
        }

        public ActionResult ProblemDetail(int id)
        {
            var detail = _problemService.GetProblem(id);

            if (detail == null || (detail.IsAudit != 0 && detail.WechatUserID != UserCache.WechatUser.ID))
                return RedirectToAction("Index");

            return View(detail);
        }

        public ActionResult DeleteProblem(int id)
        {
            _problemService.DeleteProblem(id, UserCache.WechatUser.ID);

            return RedirectToAction("Index", new ProblemModel { Tab = 1 });
        }
        #endregion
    }
}