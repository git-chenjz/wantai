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
    public class ADService : BaseService, IADService
    {
        #region 字段
        private IADRepository _adReposition;
        #endregion

        #region 构造
        public ADService(
            IMySqlRepositoryContext mySqlUnitOfWork,
            IADRepository adReposition
            )
            : base(mySqlUnitOfWork)
        {
            _adReposition = adReposition;
        }
        #endregion

        #region 广告
        /// <summary>
        /// 取所有广告
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AD> GetADs()
        {
            var ads = _adReposition.Get();

            return ads;
        }
        /// <summary>
        /// 取所有可显示的广告
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AD> GetValidADs()
        {
            var ads = _adReposition.Get(a=>a.IsShow==0);

            return ads;
        }
        public AD GetAD(int id)
        {
            var ad = _adReposition.Find(id);

            return ad;
        }
        public void SaveAD(AD ad)
        {
            if (ad.Id == 0)
            {
                ad.CreateTime = DateTime.Now;
                _adReposition.Create(ad);
            }
            else
            {
                var temp = _adReposition.Find(ad.Id);
                if (temp != null)
                {
                    temp.Des = ad.Des;
                    temp.ImgPath = ad.ImgPath;
                    temp.IsShow = ad.IsShow;
                    temp.Link = ad.Link;
                    temp.Sort = ad.Sort;
                }
            }

            _adReposition.Save();
        }
        public void DeleteAD(int id)
        {
            var ad = _adReposition.Find(id);
            if (ad != null)
            {
                _adReposition.Delete(ad);
                _adReposition.Save();
            }
        }
        #endregion
    }
}
