using DataAccess.Domain;
using DataService;
using MyFrameWork.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WanTaiWeb.Areas.Web.Models
{
    public class ProblemModel
    {
        private int _tab { get; set; }

        public int Tab
        {
            get
            {
                return _tab;
            }
            set
            {
                _tab = value > 2 || value < 0 ? 0 : value;
            }
        }
        public int ID { get; set; }
        public string Key { get; set; }
        public string LastProblemID { get; set; }
        public IEnumerable<MyProblem> Problems { get; set; }
        public MyProblem Problem { get; set; }

        public ProblemModel()
        {
            ID = 0;
            Key = "";
            LastProblemID = "";
            Problems = new List<MyProblem> { };
            Problem = new MyProblem();
        }


        public void GetNextProblems(string wechatUserID="")
        {
            Key = string.IsNullOrWhiteSpace(Key) ? "" : Key.Trim();

            var psv = ServiceLocator.Instance.Resolve<IProblemService>();
            Problems = psv.GetPreProblems(Key, ID, wechatUserID);
        }
    }
}