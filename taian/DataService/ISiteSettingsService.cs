using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Domain;

namespace DataService
{
    public interface ISiteSettingsService
    {
        SiteSettings GetSiteSettings(string key);

        void SaveSetting(SiteSettings setting);
    }
}
