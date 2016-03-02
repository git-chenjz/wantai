using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess.Repositories;
using MyFrameWork.Data;
using DataAccess.Domain;
using MyFrameWork.Aop;
using MyFrameWork.Log;
using MyFrameWork;
using MyFrameWork.Common;
using System.Linq.Expressions;

namespace DataService
{
    public class SiteSettingsService : BaseService, ISiteSettingsService
    {
        #region 字段
        private ISiteSettingsRepository _siteSettingsRepository;
        #endregion

        #region 构造
        public SiteSettingsService(
            IMySqlRepositoryContext mySqlUnitOfWork,
            ISiteSettingsRepository siteSettingsRepository
            )
            : base(mySqlUnitOfWork)
        {
            _siteSettingsRepository = siteSettingsRepository;
        }
        #endregion

        #region 方法

        public SiteSettings GetSiteSettings(string key)
        {
            SiteSettings setting = _siteSettingsRepository.Find(c=>c.Key == key);
            if (setting == null)
                setting = new SiteSettings();
            return setting;
        }

        public void SaveSetting(SiteSettings setting)
        {
            SiteSettings siteSetting = _siteSettingsRepository.Find(c=>c.Key == setting.Key);
            if (siteSetting == null)
            {
                _siteSettingsRepository.Create(setting);
            }
            else
            {
                siteSetting.Value = setting.Value;
                _siteSettingsRepository.Update(siteSetting);
            }
            _siteSettingsRepository.Save();
        }

        #endregion
    }
}
