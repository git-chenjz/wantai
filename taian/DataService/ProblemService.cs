using DataAccess.Domain;
using DataAccess.Repositories;
using MyFrameWork.Common;
using MyFrameWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace DataService
{
    public class ProblemService : BaseService, IProblemService
    {
        #region 字段
        private IProblemRepository _problemRepository;
        #endregion

        #region 构造
        public ProblemService(
            IMySqlRepositoryContext mySqlUnitOfWork,
            IProblemRepository problemRepository
            )
            : base(mySqlUnitOfWork)
        {
            _problemRepository = problemRepository;
        }
        #endregion

        #region 问答
        public IEnumerable<MyProblem> GetPreProblems(string key = "", int id = 0, string wechatUserID = "")
        {
            if (wechatUserID == "")
                return _problemRepository.GetPaged(a => a.IsAudit == 0 && a.Title.Contains(key) && (id == 0 || a.ID < id), a => a.OrderByDescending(b => b.ID), 0, 100).Result;
            else
                return _problemRepository.GetPaged(a => a.WechatUserID == wechatUserID && a.Title.Contains(key) && (id == 0 || a.ID < id), a => a.OrderByDescending(b => b.ID), 0, 100).Result;
        }
        public PagedResult<MyProblem> GetProblems(int page = 0, int msg = 10, int audit = 10)
        {
            var problems = _problemRepository.GetPaged(a => (msg == 10 || a.IsReport == msg) && (audit == 10 || a.IsAudit == audit)
                , a => a.OrderByDescending(c => c.CreateTime), page);

            return problems;
        }
        public PagedResult<MyProblem> GetProblems(string title, int audit, string wechatUserID, int index = 1, int size = 20)
        {
            Expression<Func<MyProblem, bool>> filter = c => true;
            if (!string.IsNullOrEmpty(title))
                filter = filter.And(c => c.Title.Contains(title));
            if (audit == 0)
                filter = filter.And(c => c.IsAudit == 0);
            if (string.IsNullOrWhiteSpace(wechatUserID))
                filter = filter.And(c => c.WechatUserID == wechatUserID);
            return _problemRepository.GetPaged(filter, index, size);
        }
        public MyProblem GetProblem(int id)
        {
            var problem = _problemRepository.Find(id);

            return problem;
        }
        public void DeleteProblem(int id, string wechatUserID)
        {
            _problemRepository.Delete(a => a.ID == id && a.WechatUserID == wechatUserID);
            _problemRepository.Save();
        }
        public void AuditProblem(MyProblem problem)
        {
            var p = _problemRepository.Find(problem.ID);
            if (p != null)
            {
                p.IsAudit = problem.IsAudit;
                p.Reports = problem.Reports == null ? "" : problem.Reports.Trim();
                p.IsReport = p.Reports == "" ? 1 : 0;

                _problemRepository.Save();
            }
        }
        public void CreateProblem(MyProblem problem, string wechatUserID)
        {
            var p = new MyProblem
            {
                Content = problem.Content,
                CreateTime = DateTime.Now,
                IsAudit = 2,
                IsReport = 1,
                Reports = "",
                Title = problem.Title,
                WechatUserID = wechatUserID
            };

            _problemRepository.Create(p);
            _problemRepository.Save();
        }

        public int SaveProblem(MyProblem problem)
        {
            problem.CreateTime = DateTime.Now;
            _problemRepository.Create(problem);
            return _problemRepository.Save();
        }

        public IEnumerable<MyProblem> GetMyProblems(int uid)
        {
            var p = _problemRepository.Get(a => a.WechatUserID.Equals(uid));

            return p;
        }
        #endregion
    }
}
