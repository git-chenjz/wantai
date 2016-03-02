using DataAccess.Domain;
using MyFrameWork.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    /// <summary>
    /// 问卷服务
    /// </summary>
    public interface IQuestionService
    {
        #region 问卷
        IEnumerable<Question> GetQuestions();
        PagedResult<Question> GetPagedQuestions(int page = 1);
        Question GetQuestion(int id);
        void DeleteQuestion(int id);
        void EditQuestion(Question question);
        #endregion

        #region 题目
        IEnumerable<QuestionItem> GetQuestionItems(int questionID);
        QuestionItem GetQuestionItem(int id);
        void CreateItem(int questionID, string title, bool isRadio, int sort, string list);
        void EditItem(int itemID, string title, bool isRadio, int sort, string list);
        void DeleteQuestionItem(int id);
        #endregion

        #region 用户
        QuestionUser GetQuestionUser(int questionID, string wechatUserID);
        IEnumerable<QuestionUser> GetQuestionUsers(int questionID);
        IEnumerable<QuestionSelectUser> GetQuestionSelectUsers(string wechatUserID, int questionID);
        void SubmitQuestionUser(int id, string wechatUserID, string ids, string name, string tel);
        #endregion
    }
}
