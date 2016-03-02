using DataAccess.Domain;
using DataAccess.Repositories;
using MyFrameWork.Common;
using MyFrameWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public class QuestionService : BaseService, IQuestionService
    {
        #region 字段
        private IQuestionItemRepository _itemRepository;
        private IQuestionRepository _questionRepository;
        private IQuestionSelectRepository _selectRepository;
        private IQuestionSelectUserRepository _selectUserRepository;
        private IQuestionUserRepository _userRepository;
        #endregion

        #region 构造
        public QuestionService(
            IMySqlRepositoryContext mySqlUnitOfWork,
            IQuestionItemRepository itemRepository,
            IQuestionRepository questionRepository,
            IQuestionSelectRepository selectRepository,
            IQuestionSelectUserRepository selectUserRepository,
            IQuestionUserRepository userRepository
            )
            : base(mySqlUnitOfWork)
        {
            _itemRepository = itemRepository;
            _questionRepository = questionRepository;
            _selectRepository = selectRepository;
            _selectUserRepository = selectUserRepository;
            _userRepository = userRepository;
        }
        #endregion

        #region 问卷
        public IEnumerable<Question> GetQuestions()
        {
            return _questionRepository.Get().OrderByDescending(a => a.CreateTime);
        }
        public PagedResult<Question> GetPagedQuestions(int page = 1)
        {
            return _questionRepository.GetPaged(null, a => a.OrderByDescending(b => b.CreateTime), page);
        }
        public Question GetQuestion(int id)
        {
            return _questionRepository.Get(a => a.ID == id, "QuestionItems").FirstOrDefault();
        }
        public void DeleteQuestion(int id)
        {
            _questionRepository.Delete(a => a.ID == id);
            _questionRepository.Save();
        }
        public void EditQuestion(Question question)
        {
            if (question.ID == 0)
            {
                question.CreateTime = DateTime.Now;
                _questionRepository.Create(question);
            }
            else
            {
                var temp = _questionRepository.Find(question.ID);
                if (temp != null)
                {
                    question.CreateTime = temp.CreateTime;
                    _questionRepository.Update(question);
                }
            }
            _questionRepository.Save();
        }
        #endregion

        #region 题目
        public IEnumerable<QuestionItem> GetQuestionItems(int questionID)
        {
            return _itemRepository.Get(a => a.QuestionID == questionID, "QuestionSelects");
        }
        public QuestionItem GetQuestionItem(int id)
        {
            return _itemRepository.Get(a => a.ID == id, "QuestionSelects").FirstOrDefault();
        }
        public void CreateItem(int questionID, string title, bool isRadio, int sort, string list)
        {
            var l = list.Split('\n').Where(a => string.IsNullOrWhiteSpace(a) == false).Select(a => a.Trim()).Distinct();

            var item = new QuestionItem
            {
                IsRadio = isRadio,
                QuestionID = questionID,
                Title = title.Trim(),
                Sort = sort
            };

            _itemRepository.Create(item);
            _itemRepository.Save();

            var i = 1;
            foreach (var x in l)
            {
                var select = new QuestionSelect { QuestionItemID = item.ID, Value = x, Sort = i++ };
                _selectRepository.Create(select);
            }

            _selectRepository.Save();
        }
        public void EditItem(int itemID, string title, bool isRadio, int sort, string list)
        {
            var l = list.Split('\n').Where(a => string.IsNullOrWhiteSpace(a) == false).Select(a => a.Trim()).Distinct();

            var item = _itemRepository.Find(itemID);
            if (item != null)
            {
                _mySqlUnitOfWork.Commit(() =>
                {
                    item.IsRadio = isRadio;
                    item.Title = title;
                    item.Sort = sort;

                    _itemRepository.Update(item);

                    _selectRepository.Delete(a => a.QuestionItemID == item.ID);
                    _selectRepository.Save();
                    var i = 1;
                    foreach (var x in l)
                    {
                        var select = new QuestionSelect { QuestionItemID = item.ID, Value = x, Sort = i++ };
                        _selectRepository.Create(select);
                    }

                    _selectRepository.Save();
                    _itemRepository.Save();
                });




            }


        }
        public void DeleteQuestionItem(int id)
        {
            _itemRepository.Delete(a => a.ID == id);
            _itemRepository.Save();
        }
        #endregion

        #region 用户
        public IEnumerable<QuestionUser> GetQuestionUsers(int questionID)
        {
            return _userRepository.Get(a => a.QuestionID == questionID);
        }
        public QuestionUser GetQuestionUser(int questionID, string wechatUserID)
        {
            return _userRepository.Get(a => a.QuestionID == questionID && a.WechatUserID == wechatUserID,"").FirstOrDefault();
        }
        public IEnumerable<QuestionSelectUser> GetQuestionSelectUsers(string wechatUserID, int questionID)
        {
            return _selectUserRepository.Get(a => a.WechatUserID == wechatUserID && a.QuestionID == questionID);
        }
        public void SubmitQuestionUser(int id, string wechatUserID, string ids, string name, string tel)
        {
            //验证有没有提交过
            var qu = _userRepository.Get(a => a.QuestionID == id && a.WechatUserID == wechatUserID);
            if (qu.Any() == false)
            {
                var temp = new QuestionUser
                {
                    WechatUserID = wechatUserID,
                    Name = name,
                    Tel = tel,
                    QuestionID = id,
                    Score = 0,
                    CreateTime = DateTime.Now
                };

                _userRepository.Create(temp);

                var sids = ids.Split(',').Select(a => int.Parse(a));
                foreach (var x in sids)
                {
                    var t = new QuestionSelectUser
                    {
                        QuestionSelectID = x,
                        QuestionID = id,
                        WechatUserID = wechatUserID
                    };

                    _selectUserRepository.Create(t);
                }

                _selectUserRepository.Save();
                _userRepository.Save();
            }
        }
        #endregion
    }
}
