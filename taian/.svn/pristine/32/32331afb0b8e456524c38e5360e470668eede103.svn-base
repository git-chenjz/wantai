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
    public class PageService : BaseService, IPageService
    {
        #region 字段
        private IPageRepository _pageRepository;
        #endregion

        #region 构造
        public PageService(
            IMySqlRepositoryContext mySqlUnitOfWork,
            IPageRepository pageRepository
            )
            : base(mySqlUnitOfWork)
        {
            _pageRepository = pageRepository;
        }
        #endregion

        public Page GetPage()
        {
            var pages = _pageRepository.Get();
            if(pages.Any()==false)
            {
                var page = new Page { CreateTime = DateTime.Now };
                _pageRepository.Create(page);
                _pageRepository.Save();

                return page;
            }

            return pages.First();
        }
        public void SavePage(Page page)
        {
            var temp = GetPage();

            temp.Title = page.Title;
            temp.Content = page.Content;

            _pageRepository.Save();
        }
    }
}
