using DataAccess.Domain;
using DataAccess.Repositories;
using MyFrameWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public class FeedService : BaseService, IFeedService
    {
        #region 字段
        private IInnovateFeedRepository _innovateFeedRepository;
        #endregion

        #region 构造
        public FeedService(
            IMySqlRepositoryContext mySqlUnitOfWork,
            IInnovateFeedRepository innovateFeedRepository
            )
            : base(mySqlUnitOfWork)
        {
            _innovateFeedRepository = innovateFeedRepository;
        }
        #endregion

        #region 创新疫苗
        public IEnumerable<InnovateFeed> GetInnovateFeeds(InnovateFeedType? type = null, ActiveStatus? status = null)
        {
            return _innovateFeedRepository.Get(
                a => (type == null || a.Type == type)
                    && (status == null || a.Status == status),
                a => a.OrderByDescending(b => b.CreateTime)
                );
        }
        public InnovateFeed GetInnovateFeed(int id, bool isView = false)
        {
            var feed = _innovateFeedRepository.Find(id);
            if (feed == null)
                return null;

            if (isView)
            {
                feed.ClickNum += 1;
                _innovateFeedRepository.Save();
            }

            return feed;
        }
        public void EditInnovateFeed(InnovateFeed feed)
        {
            if (feed.ID == 0)
            {
                feed.CreateTime = DateTime.Now;
                feed.ClickNum = 0;
                _innovateFeedRepository.Create(feed);
                _innovateFeedRepository.Save();
            }
            else
            {
                var temp = _innovateFeedRepository.Find(feed.ID);
                if (temp != null)
                {
                    temp.Author = feed.Author;
                    temp.Content = feed.Content;
                    temp.Des = feed.Des;
                    temp.ImgPath = feed.ImgPath;
                    temp.Status = feed.Status;
                    temp.Title = feed.Title;
                    temp.Type = feed.Type;

                    _innovateFeedRepository.Update(temp);
                    _innovateFeedRepository.Save();
                }
            }
        }
        public void DeleteInnovateFeed(int id)
        {
            _innovateFeedRepository.Delete(a => a.ID == id);
            _innovateFeedRepository.Save();
        }
        #endregion
    }
}
