using DataAccess.Domain;
using DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WanTaiWeb.Areas.Admin.Controllers
{
    public class ProblemController : Controller
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


        public ActionResult Index(int page = 1, int msg = 10, int audit = 10)
        {
            var problems = _problemService.GetProblems(page, msg, audit);
            ViewBag.page = page;
            ViewBag.msg = msg;
            ViewBag.audit = audit;

            return View(problems);
        }

        public ActionResult Edit(int id, int page = 1, int msg = 10, int audit = 10)
        {
            var problem = _problemService.GetProblem(id);
            ViewBag.msg = msg;
            ViewBag.audit = audit;

            if (problem == null)
                return RedirectToAction("Index", new { page = page, msg = msg, audit = audit });

            return View(problem);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(MyProblem problem, int page = 1,int msg=10,int audit=10)
        {
            _problemService.AuditProblem(problem);

            return RedirectToAction("Index", new { page = page, msg = msg, audit = audit });
        }
    }
}