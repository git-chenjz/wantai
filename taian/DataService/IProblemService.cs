using DataAccess.Domain;
using MyFrameWork.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public interface IProblemService : IBaseService
    {
        IEnumerable<MyProblem> GetPreProblems(string key = "", int id = 0, string wechatUserID = "");
        PagedResult<MyProblem> GetProblems(int page = 0, int msg = 10, int audit = 10);
        PagedResult<MyProblem> GetProblems(string title, int audit,string wechatUserID, int index = 1, int size = 20);
        MyProblem GetProblem(int id);
        void AuditProblem(MyProblem problem);
        void DeleteProblem(int id, string wechatUserID);

        int SaveProblem(MyProblem problem);
    }
}
