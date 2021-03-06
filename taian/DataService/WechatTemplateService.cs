﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccess.Domain;
using DataAccess.Repositories;
using DataAccess.Repositories.Impl;
using MyFrameWork.Data;
using MyFrameWork.Ioc;
using MyFrameWork.Wechat;
using MyFrameWork.Common;
using System.Linq.Expressions;

namespace DataService
{
    public class WechatTemplateService : BaseService, IWechatTemplateService
    {
        #region 字段

        private IWechatTemplateRepository _wechatTemplateRepository;
        
        #endregion

        #region 构造

        public WechatTemplateService(IMySqlRepositoryContext mySqlUnitOfWork, IWechatTemplateRepository wechatTemplateRepository)
            : base(mySqlUnitOfWork)
        {
            _wechatTemplateRepository = wechatTemplateRepository;
        }
        
        #endregion

        #region 方法

        public PagedResult<WechatTemplate> GetUserTemplates(string openId)
        {
            Expression<Func<WechatTemplate, bool>> filter = c => true;
            if (!openId.IsNullOrEmpty())
                filter = filter.And(c=>c.OpenID.Equals(openId));
            return _wechatTemplateRepository.GetPaged(filter);
        }

        public int DeleteUserTemplateById(string tempId)
        {
            _wechatTemplateRepository.Delete(c => c.ID.Equals(tempId));
            return _wechatTemplateRepository.Save();
        }

        public void SendTemplate(string openID,string templateID,int linkid,object data)
        {
            var temp = new WechatTemplate
            {
                Data = JsonHelper.ToJson(data),
                OpenID = openID,
                SendTime = DateTime.Now,
                Status = "WAIT",
                TemplateID = templateID,
                LinkID = linkid
            };

            _wechatTemplateRepository.Create(temp);
            _wechatTemplateRepository.Save();

            var result = SessionService.ServiceSendTemplate(new WX_TemplateSend
            {
                touser = openID,
                template_id = templateID,
                data = data
            });

            temp.MsgID = result.msgid;
            _wechatTemplateRepository.Save();
        }
        
        #endregion
    }
}
