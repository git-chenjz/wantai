using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess.Domain;
using MyFrameWork;
using MyFrameWork.Aop;
using MyFrameWork.Log;
using MyFrameWork.Common;

namespace DataService
{
    public interface IWechatTemplateService
    {
        PagedResult<WechatTemplate> GetUserTemplates(string openId);
        int DeleteUserTemplateById(string tempId);
        void SendTemplate(string openID, string templateID, object data);
    }
}
